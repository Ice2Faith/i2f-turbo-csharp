using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StyleSuit
{
    public partial class InputBox : Form
    {
        private string mInputText="";
        public string InputText
        {
            get { return mInputText; }
            set
            {
                if (value == null || value == "")
                    mInputText = null;
                else
                    mInputText = value;
            }
        }
        public InputBox()
        {
            InitializeComponent();
        }
        public void ShowBox(IWin32Window owner,string inputTips)
        {
            this.labelInputTips.Text = inputTips;
            this.ShowDialog(owner);
        }
        public void ShowBox(IWin32Window owner, string inputTips,string text)
        {
            this.labelInputTips.Text = inputTips;
            this.textBoxInputLine.Text = text;
            this.ShowDialog(owner);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            InputText = null;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            InputText = this.textBoxInputLine.Text;
            this.Close();
        }

        private void textBoxInputLine_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                InputText = this.textBoxInputLine.Text;
                this.Close();
            }
        }
    }
}
