using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mipsim
{
    public partial class MainForm : Form
    {
        public GUISimulator GSimulator { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            AlignObjectsOnResize();
        }

        private void AlignObjectsOnResize()
        {
            FixTabPages();
        }

        private void simulateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartBackgroundSimulation();
        }       

    }
}
