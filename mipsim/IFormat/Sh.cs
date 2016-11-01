using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Sh : IFormatInstruction
    {
        public Sh(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            ProcessorState.WriteHalfWord((int)(ValueSource + Immediate), (ushort)ProcessorState.ReadRegister(RegisterDestination));
        }

        public override string ToString()
        {
            return base.ToString() + "SH " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + Immediate + "(" + RegistersLookupTable.LookupRegister(RegisterSource) + ")";
        }
    }
}
