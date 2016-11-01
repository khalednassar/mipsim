using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class ConcreteInstructionFactory : AbstractInstructionFactory
    {
        private AbstractInstructionFactory RFormat, IFormat, JFormat;

        public ConcreteInstructionFactory(AbstractInstructionFactory RFormatFactory, AbstractInstructionFactory IFormatFactory, AbstractInstructionFactory JFormatFactory)
        {
            RFormat = RFormatFactory;
            IFormat = IFormatFactory;
            JFormat = JFormatFactory;
        }

        public Instruction CreateInstruction(uint InstructionWord, uint Address)
        {
            Instruction newInstruction = new Instruction(InstructionWord, Address);
            return DecodeFormat(InstructionWord, newInstruction);
        }

        private Instruction DecodeFormat(uint InstructionWord, Instruction InstructionToDecode)
        {

            if (InstructionToDecode.OpCode == 0)
                return RFormat.CreateInstruction(InstructionWord, InstructionToDecode.Address);
            else if (InstructionToDecode.OpCode == 2 || InstructionToDecode.OpCode == 3)
                return JFormat.CreateInstruction(InstructionWord, InstructionToDecode.Address);
            else
                return IFormat.CreateInstruction(InstructionWord, InstructionToDecode.Address);
        }
    }
}
