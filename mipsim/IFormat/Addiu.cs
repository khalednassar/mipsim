﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Addiu : IFormatInstruction
    {
        public Addiu(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            ProcessorState.WriteRegister(RegisterDestination, (uint)(ValueSource + (short)Immediate));
        }

        public override string ToString()
        {
            return base.ToString() + "ADDIU " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + RegistersLookupTable.LookupRegister(RegisterSource)
                                   + ", " + (short)Immediate;
        }
    }
}
