using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public struct Interrupt
    {
        public Action<State> Handler { get; set; }
        public int InterruptID { get; set; }
    }

    public class Interrupts
    {
        public void AddInterruptHandler(Interrupt IntToAdd)
        {
            if (interrupts.ContainsKey(IntToAdd.InterruptID))
                interrupts[IntToAdd.InterruptID] = IntToAdd;
            else
                interrupts.Add(IntToAdd.InterruptID, IntToAdd);
        }

        public void ExecuteInterruptHandler(int InterruptID, State ProcessorState)
        {
            interrupts[InterruptID].Handler(ProcessorState);
        }

        private Dictionary<int, Interrupt> interrupts = new Dictionary<int, Interrupt>();
    }
}
