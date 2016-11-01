using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Slti : IFormatInstruction
    {
        public Slti(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            uint Result = (uint)(((int)ValueSource < (short)Immediate) ? 1 : 0);
            ProcessorState.Zero = (Result == 0);
            ProcessorState.WriteRegister(RegisterDestination, Result);
        }

        public override string ToString()
        {
            return base.ToString() + "SLTI " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + RegistersLookupTable.LookupRegister(RegisterSource)
                                   + ", " + (short)Immediate;
        }
    }
}
