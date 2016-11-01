using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Bne : IFormatInstruction, JumpableInstruction
    {
        public string TargetAddressLabel{get;set;}//
        public uint Target{get;private set;}//

        public Bne(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
            Target = (uint) (Address + (4 * (short)Immediate));//
        }
        

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            
            int ValueSource = (int)ProcessorState.ReadRegister(RegisterSource);
            int ValueDestination = (int)ProcessorState.ReadRegister(RegisterDestination);
            if (ValueSource != ValueDestination)
            {
                ProcessorState.UpdateProgramCounterFromOffset((short)Immediate);
                ProcessorState.Zero = true;
            }
            else
                ProcessorState.Zero = false;
        }

        public override string ToString()//
        {
            return base.ToString() + "BNE " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + RegistersLookupTable.LookupRegister(RegisterSource)
                + ", " + (string.IsNullOrEmpty(TargetAddressLabel) ? Immediate.ToString() : TargetAddressLabel);
        }
    }
}
