using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsim
{
    public class GUISimulator
    {
        private MainForm form;
        private State state;
        private Interrupts interrupts;
        private bool running = true;

        private const int BYTES_PER_KB = 1024;
        private const int MEMORY_SIZE = 8 * BYTES_PER_KB;

        private enum InterruptIDs
        {
            PRINT_STRING = 4,
            PRINT_INTEGER = 1,
            EXIT = 10
        }

        public GUISimulator(MainForm GUIForm)
        {
            form = GUIForm;
            state = new State(MEMORY_SIZE);
            interrupts = new Interrupts();
            interrupts.AddInterruptHandler(new Interrupt() { Handler = PrintStringInterruptHandler, InterruptID = (int)InterruptIDs.PRINT_STRING });
            interrupts.AddInterruptHandler(new Interrupt() { Handler = PrintIntegerInterruptHandler, InterruptID = (int)InterruptIDs.PRINT_INTEGER });
            interrupts.AddInterruptHandler(new Interrupt() { Handler = ExitInterruptHandler, InterruptID = (int)InterruptIDs.EXIT });
        }

        public void ExecuteInstructionList(IDictionary<int, Instruction> Instructions)
        {
            ExecuteInstructionList(Instructions, string.Empty);
        }

        public void ExecuteInstructionList(IDictionary<int, Instruction> Instructions, string DataSectionPath)
        {
            if (!string.IsNullOrEmpty(DataSectionPath))
                state.LoadMemoryStateFromFile(DataSectionPath);
            while (running)
            {
                if (!Instructions.ContainsKey(state.ProgramCounter))
                {
                    ExitInterruptHandler(state);
                    break;
                }
                Instruction CurrentInstruction = Instructions[state.ProgramCounter];
                state.StepProgramCounter();
                CurrentInstruction.ExecuteInstruction(interrupts, state);
            }
        }

        private void PrintStringInterruptHandler(State ProcessorState)
        {
            form.InterruptPrintString(ProcessorState.ReadNullTerminatedString((int)ProcessorState.ReadRegister((int)Registers.a0)));
        }

        private void PrintIntegerInterruptHandler(State ProcessorState)
        {
            form.InterruptPrintInteger((int)ProcessorState.ReadRegister((int)Registers.a0));
        }

        private void ExitInterruptHandler(State ProcessorState)
        {
            running = false;
            form.InterruptPrintString(Environment.NewLine + "---------------------------" + Environment.NewLine + "The program has finished execution." + Environment.NewLine);
        }
    }
}
