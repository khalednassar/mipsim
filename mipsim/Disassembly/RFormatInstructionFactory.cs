using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace mipsim
{
    public class RFormatInstructionFactory : AbstractInstructionFactory
    {
        static Dictionary<int, Type> functions = new Dictionary<int, Type>();
        static RFormatInstructionFactory()
        {
            functions.Add(0x20, typeof(Add));
            functions.Add(0x21, typeof(Addu));
            functions.Add(0x24, typeof(And));
            functions.Add(0x8, typeof(Jr));
            functions.Add(0x25, typeof(Or));
            functions.Add(0x0, typeof(Sll));
            functions.Add(0x2A, typeof(Slt));
            functions.Add(0x0C, typeof(Syscall));
            functions.Add(0x26, typeof(Xor));
        }

        public RFormatInstructionFactory()
        {
            
        }

        public Instruction CreateInstruction(uint InstructionWord, uint Address)
        {
            RFormatInstruction InstructionDecoded = new RFormatInstruction(InstructionWord, Address);
            return (Instruction)functions[InstructionDecoded.Function].InvokeMember("", BindingFlags.CreateInstance, null, null, new object[] { InstructionWord, Address });
        }
    }
}
