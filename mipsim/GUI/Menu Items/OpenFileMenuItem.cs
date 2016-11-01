using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mipsim
{
    public partial class MainForm : Form
    {

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptUserForFileAndLoad();
        }

        private void PromptUserForFileAndLoad()
        {
            OpenFileDialog Dialog = GenerateFileDialog();
            if(PromptUserForFile(Dialog))
            {
                OpenSelectedFile(Dialog);
            }
        }

        private OpenFileDialog GenerateFileDialog()
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.CheckFileExists = true;
            Dialog.CheckPathExists = true;
            Dialog.Multiselect = false;
            return Dialog;
        }

        private bool PromptUserForFile(OpenFileDialog Dialog)
        {
            return Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK;
        }

        private void OpenSelectedFile(OpenFileDialog Dialog)
        {
            OpenFileForDisassembly(Dialog.FileName);
        }
    }
}
