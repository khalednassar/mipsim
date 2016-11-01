using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace mipsim
{
    public partial class MainForm : Form
    {
        private IDictionary<int, Instruction> last_loaded;
        private void OpenFileForDisassembly(string Path)
        {
            ResetView();
            ConcreteInstructionFactory IF = new ConcreteInstructionFactory(new RFormatInstructionFactory(), new IFormatInstructionFactory(), new JFormatInstructionFactory());
            Disassembler DisAsm = new Disassembler(IF);
            last_loaded = DisAsm.EnumerateBinaryFile(Path);
            foreach (var item in last_loaded)
            {
                AppendObjectToView(item.Value);
            }
        }

        private void AppendObjectToView(object Argument)
        {
            textBox1.AppendText(Argument + Environment.NewLine);
        }

        private void SetViewFontAndColor(Font SelectedFont, Color SelectedColor)
        {
            textBox1.Font = SelectedFont;
            textBox1.ForeColor = SelectedColor;
        }

        private void ResetView()
        {
            textBox1.Text = string.Empty;
        }
    }
}
