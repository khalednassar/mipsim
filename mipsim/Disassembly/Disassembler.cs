using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace mipsim
{
    public class Disassembler
    {
        private AbstractInstructionFactory instructionFactory;

        public Disassembler(AbstractInstructionFactory InstructionFactory)
        {
            instructionFactory = InstructionFactory;
        }

        public Dictionary<int, Instruction> EnumerateBinaryFile(string FilePath)
        {
            Dictionary<int, Instruction> Instructions = new Dictionary<int, Instruction>();
            using (MemoryStream Stream = new MemoryStream(File.ReadAllBytes(FilePath)))
            {
                FillInstructionDictionary(Instructions, Stream);
            }
            AddLabels(Instructions);
            return Instructions;
        }

        private void FillInstructionDictionary(Dictionary<int, Instruction> DictionaryToFill, MemoryStream FStream)
        {
            uint InstructionCounter = 0x00400000;
            if (FStream.Length % 4 == 0)
            {
                using (BinaryReader Reader = new BinaryReader(FStream))
                {
                    while (FStream.Position != FStream.Length)
                    {
                        uint InstructionWord = Reader.ReadUInt32();
                        Instruction ReadInstruction = instructionFactory.CreateInstruction(InstructionWord, InstructionCounter);
                        DictionaryToFill.Add((int)ReadInstruction.Address, ReadInstruction);
                        InstructionCounter += 4;
                    }
                }
            }
            else
                throw new ArgumentException("Invalid MIPS file");
        }

        private void AddLabels(Dictionary<int, Instruction> Instructions)//
        {
            LabelGenerator Generator = new LabelGenerator();
            foreach (var iterator in Instructions.Values)
            {
                if (iterator is JumpableInstruction)
                {
                    JumpableInstruction Jumper = (JumpableInstruction)iterator;
                    GenerateLabelForJumpee(Generator, Jumper, Instructions[(int)Jumper.Target]);
                }
            }
        }

        private void GenerateLabelForJumpee(LabelGenerator Generator, JumpableInstruction Jumper, Instruction Jumpee)
        {
            string Label = (string.IsNullOrEmpty(Jumpee.Label) ? Generator.generateLabel() : Jumpee.Label);
            Jumpee.Label = Label;
            Jumper.TargetAddressLabel = Label;
        }
    }
    
}
