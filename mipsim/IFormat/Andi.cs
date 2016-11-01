using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Andi : IFormatInstruction
    {
        public Andi(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            ProcessorState.WriteRegister(RegisterDestination, (uint)(ValueSource & (short)Immediate));
        }

        public override string ToString()
        {
            return base.ToString() + "ANDI " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + RegistersLookupTable.LookupRegister(RegisterSource)
                                   + ", " + (short)Immediate;
        }
    }
}
