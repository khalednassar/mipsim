using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Add : RFormatInstruction
    {
        public Add(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            uint ValueTemporary = ProcessorState.ReadRegister(RegisterTemporary);
            uint Result = ValueTemporary + ValueSource;
            SetFlags(ProcessorState, ValueSource, ValueTemporary, Result);
            ProcessorState.WriteRegister(RegisterDestination, Result);
        }

        private void SetFlags(State ProcessState, uint Source, uint Temporary, uint Result)
        {
            ProcessState.Zero = (Result == 0);
            if ((Source & (1 << 31)) == (Temporary & (1 << 31)))
            {
                ProcessState.Overflow = ((Source & (1 << 31)) == (Result & (1 << 31)));
            }
            else
                ProcessState.Overflow = false;
        }

        public override string ToString()
        {
            return base.ToString() + "ADD " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + RegistersLookupTable.LookupRegister(RegisterSource)
                                   + ", " + RegistersLookupTable.LookupRegister(RegisterTemporary);
        }
    }
}
