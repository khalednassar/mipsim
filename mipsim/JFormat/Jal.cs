using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Jal : J
    {
        private const int ra = 31;

        public Jal(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
            
        }

        public override string ToString()
        {
            return tString("JAL");
        }

        protected override void AddExtraInformation(Interrupts IOInterrupts, State ProcessState)
        {
            ProcessState.WriteRegister(ra, (uint)ProcessState.ProgramCounter);
        }
    }
}
