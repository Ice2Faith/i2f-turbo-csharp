using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class RandomSelector : Form
    {
        private Random rand = new Random();
        private bool IsSingle = false;
        public RandomSelector()
        {
            InitializeComponent();
        }

        private void button_ADDItem_Click(object sender, EventArgs e)
        {
            if (IsSingle)
            {
                if (!this.listBox_SumItem.Items.Contains(this.textBox_ItemInput.Text) && this.textBox_ItemInput.Text != "")
                {
                    this.listBox_SumItem.Items.Add(this.textBox_ItemInput.Text);
                    this.textBox_ItemInput.Text = "";
                }
            }else
            {
                this.listBox_SumItem.Items.Add(this.textBox_ItemInput.Text);
                this.textBox_ItemInput.Text = "";
            }
            
                
        }

        private void button_RandomSelect_Click(object sender, EventArgs e)
        {
            if(this.listBox_SumItem.Items.Count==0)
                return;
            this.listBox_result.Items.Clear();
            for (int i = 0; i < int.Parse(this.comboBox_Count.Text);i++ )
            {
                this.listBox_result.Items.Add(this.listBox_SumItem.Items[rand.Next() % (this.listBox_SumItem.Items.Count)].ToString()); 
            }

            
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            this.listBox_result.Items.Clear();
            this.listBox_SumItem.Items.Clear();
            this.textBox_ItemInput.Text = "";
        }

        private void textBox_ItemInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                button_ADDItem_Click(sender,e);
            }
        }

        private void button_Range_Click(object sender, EventArgs e)
        {
            int begin = int.Parse(comboBox_lowline.Text);
            int end = int.Parse(comboBox_upline.Text);
            int step = int.Parse(comboBox_step.Text);
            for (int i = begin; i <= end;i+=step )
            {
                if (IsSingle)
                {
                    if (!this.listBox_SumItem.Items.Contains(i.ToString()))
                        this.listBox_SumItem.Items.Add(i.ToString());
                }else
                {
                    this.listBox_SumItem.Items.Add(i.ToString());
                }
                
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            int index = this.listBox_SumItem.SelectedIndex;
            if(index!=-1)
            {
                this.listBox_SumItem.Items.RemoveAt(index);
            }
            int rindex = this.listBox_result.SelectedIndex;
            if (rindex != -1)
            {
                this.listBox_result.Items.RemoveAt(rindex);
            }
        }

        private void listBox_SumItem_DragDrop(object sender, DragEventArgs e)
        {
            Array files = (System.Array)e.Data.GetData(DataFormats.FileDrop);
            foreach(object i in files)
            {
                if (IsSingle)
                {
                    if (!this.listBox_SumItem.Items.Contains(i.ToString()))
                        this.listBox_SumItem.Items.Add(i.ToString());
                }else
                {
                    this.listBox_SumItem.Items.Add(i.ToString());
                }
                
            }
        }

        private void listBox_SumItem_DragEnter(object sender, DragEventArgs e)
        {
             if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void checkBox_single_CheckedChanged(object sender, EventArgs e)
        {
            IsSingle = !IsSingle;
        }
    }
}
