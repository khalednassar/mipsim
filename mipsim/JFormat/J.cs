using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class J : JFormatInstruction, JumpableInstruction
    {
        public string TargetAddressLabel { get; set; }//
        public uint Target { get; private set; }//

        public J(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
            Target = (uint)(((Address & (0xF0 << 24)) << 28) | TargetAddress << 2);//
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            AddExtraInformation(IOInterrupts, ProcessorState);
            ProcessorState.ProgramCounter = (int)(Target);
        }

        public override string ToString()
        {
            return tString("J");
        }

        protected string tString(string Instr) //
        {
            return base.ToString() + Instr + " " + (string.IsNullOrEmpty(TargetAddressLabel) ? Address.ToString() : TargetAddressLabel);
        }

        protected virtual void AddExtraInformation(Interrupts IOInterrupts, State ProcessState)
        {

        }
    }
}
