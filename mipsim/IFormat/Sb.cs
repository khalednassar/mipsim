using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Sb : IFormatInstruction
    {
        public Sb(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            ProcessorState.WriteByte((int)(ValueSource + Immediate), (byte)ProcessorState.ReadRegister(RegisterDestination));
        }

        public override string ToString()
        {
            return base.ToString() + "SB " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + Immediate + "(" + RegistersLookupTable.LookupRegister(RegisterSource) + ")";
        }
    }
}
