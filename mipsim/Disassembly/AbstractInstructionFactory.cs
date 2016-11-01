using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public interface AbstractInstructionFactory
    {
        Instruction CreateInstruction(uint InstructionWord, uint Address);
    }
}
