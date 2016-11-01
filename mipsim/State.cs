using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace mipsim
{
    public class State
    {
        private byte[] memory;
        private uint[] registers = new uint[31];

        private const int PROGRAM_COUNTER_STEP_SIZE = 4;

        public State(int MemorySize)
        {
            memory = new byte[MemorySize];
            WriteRegister((int)Registers.sp, (uint)(MemorySize + 0x10010000));
            ProgramCounter = 0x00400000;
        }

        public bool Overflow { get; set; }
        public bool Zero { get; set; }
        public bool Carry { get; set; }

        public int ProgramCounter { get; set; }

        public void LoadMemoryStateFromFile(string Path)
        {
            byte[] ReadBytes = File.ReadAllBytes(Path);
            Buffer.BlockCopy(ReadBytes, 0, memory, 0, ReadBytes.Length);
        }

        public void UpdateProgramCounterFromOffset(short Offset)
        {
            ProgramCounter = (ProgramCounter + (Offset * 4));
        }

        public void StepProgramCounter()
        {
            ProgramCounter += PROGRAM_COUNTER_STEP_SIZE;
        }

        public uint ReadRegister(int RegisterID)
        {
            if(RegisterID == 0)
                return 0;
            return registers[RegisterID - 1];
        }

        public void WriteRegister(int RegisterID, uint Data)
        {
            if(RegisterID != 0)
            {
                registers[RegisterID - 1] = Data;
            }
        }

        public uint ReadByte(int Address)
        {
            Address = Address - 0x10010000;
            byte read = memory[Address];
            return SignExtend(read);
        }

        public uint ReadUByte(int Address)
        {
            Address = Address - 0x10010000;
            return memory[Address];
        }

        public uint ReadHalfWord(int Address)
        {
            if(CheckMultiplicandIfMultipleOf(2, Address))
            {
                byte ls = (byte)ReadUByte(Address);
                byte ms = (byte)ReadUByte(Address + 1);
                uint MSExtended = SignExtend(ms);
                return ((MSExtended << 8) | ls);
            }
            throw new ArgumentException("The address has to be a multiple of 2");
        }

        public uint ReadUHalfWord(int Address)
        {
            if(CheckMultiplicandIfMultipleOf(2, Address))
            {
                byte ls = (byte)ReadUByte(Address);
                return ((ReadUByte(Address + 1) << 8) | ls);
            }
            throw new ArgumentException("The address has to be a multiple of 2");
        }

        public uint ReadWord(int Address)
        {
            if(CheckMultiplicandIfMultipleOf(4, Address))
            {
                return ((ReadUHalfWord(Address + 2) << 16) | ReadUHalfWord(Address));
            }
            throw new ArgumentException("The address has to be a multiple of 4");
        }

        public void WriteByte(int Address, byte Value)
        {
            Address = Address - 0x10010000;
            memory[Address] = Value;
        }

        public void WriteHalfWord(int Address, ushort Value)
        {
            if (CheckMultiplicandIfMultipleOf(2, Address))
            {
                WriteByte(Address, (byte)(Value & 0xFF));
                WriteByte(Address + 1, (byte)((Value >> 8) & 0xFF));
            }
            else
                throw new ArgumentException("The address has to be a multiple of 2");
        }

        public void WriteWord(int Address, uint Value)
        {
            if (CheckMultiplicandIfMultipleOf(4, Address))
            {
                WriteHalfWord(Address, (ushort)(Value & 0xFFFF));
                WriteHalfWord(Address + 2, (ushort)((Value >> 16) & 0xFFFF));
            }
            else
                throw new ArgumentException("The address has to be a multiple of 4");
        }

        private uint SignExtend(byte Argument)
        {
            return (((Argument & 0x10) == 1) ? ((uint.MaxValue << 24) | Argument) : Argument);
        }

        private bool CheckMultiplicandIfMultipleOf(int Multiple, int Multiplicand)
        {
            return (Multiplicand % Multiple) == 0;
        }

        public string ReadNullTerminatedString(int Address)
        {
            Address = Address - 0x10010000;
            string Result = string.Empty;
            for (int i = Address; i < memory.Length; ++i)
            {
                if (memory[i] == 0)
                    break;
                Result += Convert.ToChar(memory[i]);
            }
            return Result;
        }
    }
}
