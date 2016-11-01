using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class JFormatInstructionFactory : AbstractInstructionFactory
    {
        private const int J_OPCODE = 2,
                          JAL_OPCODE = 3;

        public JFormatInstructionFactory()
        {

        }

        public Instruction CreateInstruction(uint InstructionWord, uint Address)
        {
            JFormatInstruction InstructionToDecode = new JFormatInstruction(InstructionWord, Address);
            if (InstructionToDecode.OpCode == J_OPCODE)
                return new J(InstructionWord, Address);
            else
                return new Jal(InstructionWord, Address);
        }
    }
}
