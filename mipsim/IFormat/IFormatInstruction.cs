using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class IFormatInstruction : Instruction
    {
        public IFormatInstruction(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
            Immediate = (ushort)(InstructionWord & 0xFFFF);
            RegisterDestination = (int)((InstructionWord >> 16) & 0x1F);
            RegisterSource = (int)((InstructionWord >> 21) & 0x1F);
        }

        public ushort Immediate { get; private set; }
        public int RegisterSource { get; private set; }
        public int RegisterDestination { get; private set; }
    }
}
