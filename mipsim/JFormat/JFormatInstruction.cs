using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class JFormatInstruction : Instruction
    {
        public JFormatInstruction(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
            TargetAddress = (InstructionWord & 0x3FFFFFF);
        }

        public uint TargetAddress { get; private set; }
    }
}
