using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace mipsim
{
    public partial class MainForm : Form
    {
        private string dp_path;
        private Thread bg_thread;

        private void simulateDataVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptUserForDataFileAndLoad();
            StartBackgroundSimulation();
        }

        private void PromptUserForDataFileAndLoad()
        {
            OpenFileDialog Dialog = GenerateFileDialog();
            if (PromptUserForFile(Dialog))
            {
                OpenSelectedDataSection(Dialog);
            }
        }

        private void OpenSelectedDataSection(OpenFileDialog Dialog)
        {
            dp_path = Dialog.FileName;
        }

        private void StartBackgroundSimulation()
        {
            if (bg_thread == null)
            {
                bg_thread = new Thread(Bg_thread_start);
                bg_thread.IsBackground = true;
                bg_thread.Start();
            }
        }

        private void Bg_thread_start()
        {
            GSimulator.ExecuteInstructionList(last_loaded, dp_path);
            bg_thread = null;
        }
    }
}
