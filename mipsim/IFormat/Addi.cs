using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Addi : IFormatInstruction
    {
        public Addi(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            uint Result = (uint)(ValueSource + (short)Immediate);
            DetectOverflow(ValueSource, Immediate, Result, ProcessorState);
            ProcessorState.Zero = (Result == 0);
            ProcessorState.WriteRegister(RegisterDestination, Result);
        }

        private void DetectOverflow(uint Source, ushort Immediate, uint Result, State ProcessorState)
        {
            if ((Source & (1 << 31)) == (Immediate & (1 << 15)))
            {
                if ((Result & (1 << 31)) != (Source & (1 << 31)))
                    ProcessorState.Overflow = true;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "ADDI " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + RegistersLookupTable.LookupRegister(RegisterSource)
                                   + ", " + (short)Immediate;
        }
    }
}
