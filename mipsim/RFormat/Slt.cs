using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Slt : RFormatInstruction
    {
        public Slt(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            uint ValueTemporary = ProcessorState.ReadRegister(RegisterTemporary);
            uint Result = (uint)(ValueSource < ValueTemporary ? 1 : 0);
            SetFlags(ProcessorState, ValueSource, ValueTemporary, Result);
            ProcessorState.WriteRegister(RegisterDestination, Result);
        }

        private void SetFlags(State ProcessState, uint Source, uint Temporary, uint Result)
        {
            ProcessState.Zero = (Result == 0);
        }

        public override string ToString()
        {
            return base.ToString() + "SLT " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + RegistersLookupTable.LookupRegister(RegisterSource)
                                   + ", " + RegistersLookupTable.LookupRegister(RegisterTemporary);
        }
    }
}
