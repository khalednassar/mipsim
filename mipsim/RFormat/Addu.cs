using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Addu : RFormatInstruction
    {
        public Addu(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            uint ValueTemporary = ProcessorState.ReadRegister(RegisterTemporary);
            ProcessorState.WriteRegister(RegisterDestination, ValueSource + ValueTemporary);
        }

        public override string ToString()
        {
            return base.ToString() + "ADDU " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + RegistersLookupTable.LookupRegister(RegisterSource)
                                   + ", " + RegistersLookupTable.LookupRegister(RegisterTemporary);
        }
    }
}
