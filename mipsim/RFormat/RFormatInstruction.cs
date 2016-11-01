using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class RFormatInstruction : Instruction
    {
        public RFormatInstruction(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
            Function = (int)(InstructionWord & 0x3F);
            ShiftAmount = (int)((InstructionWord >> 6) & 0x1F);
            RegisterDestination = (int)((InstructionWord >> 11) & 0x1F);
            RegisterTemporary = (int)((InstructionWord >> 16) & 0x1F);
            RegisterSource = (int)((InstructionWord >> 21) & 0x1F);
        }

        public int Function { get; private set; }
        public int RegisterSource { get; private set; }
        public int RegisterTemporary { get; private set; }
        public int RegisterDestination { get; private set; }
        public int ShiftAmount { get; private set; }
    }
}
