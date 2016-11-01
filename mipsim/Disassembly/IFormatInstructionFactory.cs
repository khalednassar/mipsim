using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace mipsim
{
    public class IFormatInstructionFactory : AbstractInstructionFactory
    {
        static Dictionary<int, Type> functions = new Dictionary<int, Type>();
        static IFormatInstructionFactory()
        {
            functions.Add(0x08, typeof(Addi));
            functions.Add(0x09, typeof(Addiu));
            functions.Add(0x0C, typeof(Andi));
            functions.Add(0x04, typeof(Beq));
            functions.Add(0x05, typeof(Bne));
            functions.Add(0x20, typeof(Lb));
            functions.Add(0x21, typeof(Lh));
            functions.Add(0x23, typeof(Lw));
            functions.Add(0x0D, typeof(Ori));
            functions.Add(0x28, typeof(Sb));
            functions.Add(0x0A, typeof(Slti));
            functions.Add(0x29, typeof(Sh));
            functions.Add(0x2B, typeof(Sw));
            functions.Add(0x14, typeof(Xori));
            functions.Add(0x0F, typeof(Lui));
        }

        public IFormatInstructionFactory()
        {

        }

        public Instruction CreateInstruction(uint InstructionWord, uint Address)
        {
            IFormatInstruction InstructionDecoded = new IFormatInstruction(InstructionWord, Address);
            Type FunctToCall = functions[InstructionDecoded.OpCode];
            return (Instruction)FunctToCall.InvokeMember("", BindingFlags.CreateInstance, null, null, new object[] { InstructionWord, Address });
        }
    }
}
