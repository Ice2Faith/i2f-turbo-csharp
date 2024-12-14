using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class InputBox : Form
    {
        public string Text="";
        public InputBox(string tips="")
        {
            InitializeComponent();
            this.lable_tips.Text = tips;
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            Text = this.textBox_input.Text;
            Close();
        }

        private void textBox_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                Text = this.textBox_input.Text;
                Close();
            }
        }
    }
}
