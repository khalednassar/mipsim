using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace mipsim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm RunningForm = new MainForm();
            GUISimulator Simulator = new GUISimulator(RunningForm);
            RunningForm.GSimulator = Simulator;
            
            Application.Run(RunningForm);
        }
    }
}
