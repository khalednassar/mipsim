using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Lui : IFormatInstruction
    {
        public Lui(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint Result = (uint)(Immediate << 16);
            ProcessorState.WriteRegister(RegisterDestination, Result);
        }

        public override string ToString()
        {
            return base.ToString() + "LUI " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + (short)Immediate;
        }
    }
}
