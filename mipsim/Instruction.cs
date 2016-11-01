using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Instruction
    {
        public int OpCode { get; private set; }
        public uint Address { get; private set; }
        public string Label { get; set; }

        public Instruction(uint InstructionWord, uint Address)
        {
            this.OpCode = (int)((InstructionWord & (0xFC << 24)) >> 26);
            this.Address = Address;
            this.Label = string.Empty;
        }

        public virtual void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return (string.IsNullOrEmpty(Label) ? string.Empty : (Label + ": "));
        }
    }
}
