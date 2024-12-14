using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _04_随机文件拷贝
{
    public partial class FormMain : Form
    {
        private string srcPath;
        private string drtPath;
        public FormMain()
        {
            InitializeComponent();
        }

        private void button_Src_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog_Src.ShowDialog();
            srcPath = this.folderBrowserDialog_Src.SelectedPath.ToString().Trim();
            if (srcPath == "")
            {
                srcPath = null;
                return;
            }
            this.toolStripStatusLabel_info.Text = "源文件夹文件正在加载";
            this.textBox_Src.Text = srcPath;
            this.listBox_Src.Items.Clear();
            DirectoryInfo srcDir = new DirectoryInfo(srcPath);
            FileInfo[] allfiles = srcDir.GetFiles();
            foreach(FileInfo file in allfiles)
            {
                this.listBox_Src.Items.Add(file.FullName);
            }
            this.numericUpDown_count.Maximum = this.listBox_Src.Items.Count;
            this.numericUpDown_count.Minimum = 0;
            this.numericUpDown_count.Value = this.listBox_Src.Items.Count / 2;
            this.toolStripStatusLabel_info.Text = "源文件夹文件已加载完毕";
        }

        private void button_Drt_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog_Src.ShowDialog();
            drtPath = this.folderBrowserDialog_Src.SelectedPath.ToString().Trim();
            if (drtPath == "")
            {
                drtPath = null;
                return;
            }
            this.textBox_Drt.Text = drtPath;
            this.toolStripStatusLabel_info.Text = "新文件夹已选择完毕";
        }

        private void button_rand_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel_info.Text = "随机任务正在执行";
            int count=int.Parse(this.numericUpDown_count.Value.ToString());
            Random rand = new Random();
            int srcCount=this.listBox_Src.Items.Count;
            this.listBox_Drt.Items.Clear();
            for(int i=0;i<count;i++)
            {
                int index = rand.Next(srcCount);
                string name = this.listBox_Src.Items[index].ToString();
                if (this.listBox_Drt.Items.Contains(name))
                    i--;
                else
                    this.listBox_Drt.Items.Add(name);
            }
            this.toolStripStatusLabel_info.Text = "随机已生成完成";
        }

        private void numericUpDown_count_ValueChanged(object sender, EventArgs e)
        {
            int val = int.Parse(this.numericUpDown_count.Value.ToString());
            if (val < 0)
                this.numericUpDown_count.Value = 0;
            if (val > this.listBox_Src.Items.Count)
                this.numericUpDown_count.Value = this.listBox_Src.Items.Count;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (drtPath == null||this.listBox_Drt.Items.Count==0)
            {
                MessageBox.Show(this, "新文件夹未选择或复制数量为0", "操作失败");
                return;
            }
            this.toolStripStatusLabel_info.Text="复制过程可能比较漫长，请耐心等待";
            bool rec=this.checkBox_recovery.Checked;
            foreach (string srcfilename in this.listBox_Drt.Items)
            {
                File.Copy(srcfilename,drtPath+"\\"+new FileInfo(srcfilename).Name,rec);
            }
            MessageBox.Show(this,"复制完成","成功提示");
            this.toolStripStatusLabel_info.Text = "文件复制已完成";
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            this.splitContainer_List.SplitterDistance = this.splitContainer_List.Width / 2;
            this.splitContainer_Main.SplitterDistance = this.button_start.Height * 3;
            this.toolStripStatusLabel_info.Text = "就绪";
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection coll=this.listBox_Drt.SelectedItems;
            for (int i = 0; i < coll.Count;i++ )
            {
                this.listBox_Drt.Items.Remove(coll[i]);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            this.textBox_Src.Text = "";
            this.textBox_Drt.Text = "";
            this.listBox_Src.Items.Clear();
            this.listBox_Drt.Items.Clear();
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            Array files = (System.Array)e.Data.GetData(DataFormats.FileDrop);
            foreach(object obj in files)
            {
                string str = obj.ToString().Trim();
                if(!this.listBox_Src.Items.Contains(str))
                {
                    this.listBox_Src.Items.Add(str);
                }
            }
            this.numericUpDown_count.Maximum = this.listBox_Src.Items.Count;
            this.numericUpDown_count.Minimum = 0;
            this.numericUpDown_count.Value = this.listBox_Src.Items.Count / 2;
            this.toolStripStatusLabel_info.Text = "拖拽文件已加载完毕";
        }
    }
}
