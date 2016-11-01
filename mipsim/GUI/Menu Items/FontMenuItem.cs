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
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptUserForFontAndChange();
        }

        private void PromptUserForFontAndChange()
        {
            FontDialog Dialog = GenerateFontDialog();
            if (DialogResult.OK == Dialog.ShowDialog())
            {
                SetViewFontAndColor(GetFontFromDialog(Dialog), GetColorFromDialog(Dialog));
            }
        }

        private FontDialog GenerateFontDialog()
        {
            FontDialog Dialog = new FontDialog();
            Dialog.ShowColor = true;
            Dialog.ShowApply = false;
            Dialog.FontMustExist = true;
            Dialog.ShowEffects = true;
            Dialog.AllowVectorFonts = false;
            Dialog.AllowVerticalFonts = false;
            return Dialog;
        }

        private Font GetFontFromDialog(FontDialog Dialog)
        {
            return Dialog.Font;
        }

        private Color GetColorFromDialog(FontDialog Dialog)
        {
            return Dialog.Color;
        }
    }
}
