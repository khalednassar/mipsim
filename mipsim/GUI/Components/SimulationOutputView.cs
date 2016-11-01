using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mipsim
{
    public partial class MainForm : Form
    {
        public void InterruptPrintString(string Argument)
        {
            this.Invoke(new Action<string>(textBox2.AppendText) , Argument);
        }

        public void InterruptPrintInteger(int Argument)
        {
            InterruptPrintString(Argument.ToString());
        }
    }
}
