﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class Lh : IFormatInstruction
    {
        public Lh(uint InstructionWord, uint Address)
            : base(InstructionWord, Address)
        {
        }

        public override void ExecuteInstruction(Interrupts IOInterrupts, State ProcessorState)
        {
            uint ValueSource = ProcessorState.ReadRegister(RegisterSource);
            ProcessorState.WriteRegister(RegisterDestination, ProcessorState.ReadHalfWord((int)(ValueSource + Immediate)));
        }

        public override string ToString()
        {
            return base.ToString() + "LH " + RegistersLookupTable.LookupRegister(RegisterDestination) + ", " + Immediate + "(" + RegistersLookupTable.LookupRegister(RegisterSource) + ")";
        }
    }
}
