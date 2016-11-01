using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Syscall : RFormatInstruction
    {
        private const int V_0 = 2;

        public Syscall(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            IOInterrupts.ExecuteInterruptHandler((int)ProcessorState.ReadRegister(V_0), ProcessorState);
        }
        public override string ToString()
        {
            return base.ToString() + "SYSCALL";
        }
    }
}
