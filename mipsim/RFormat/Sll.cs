using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Sll : RFormatInstruction
    {
        public Sll(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            ProcessorState.WriteRegister(RegisterDestination, ValueSource << ShiftAmount);
        }

        public override string ToString()
        {
            return base.ToString() + "SLL " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + RegistersLookupTable.LookupRegister(RegisterTemporary)
                                   + ", " + ShiftAmount;
        }
    }
}
