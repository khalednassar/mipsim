using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Jr : RFormatInstruction
    {
        public Jr(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            ProcessorState.ProgramCounter = (int)ValueSource;
        }

        public override string ToString()
        {
            return base.ToString() + "JR " + RegistersLookupTable.LookupRegister(RegisterSource);

        }
    }
}
