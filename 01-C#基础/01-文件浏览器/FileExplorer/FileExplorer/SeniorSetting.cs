using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileExplorer
{
    public partial class SeniorSetting : Form
    {
        private string filename;
        FileInfo file = null;
        BinaryReader br=null;
        public bool ismodifyed;
        public SeniorSetting(string filename)
        {
            InitializeComponent();
            this.filename = filename;
            ismodifyed = false;
        }

        private void SeniorSetting_Load(object sender, EventArgs e)
        {
            if (File.Exists(filename) == false)
                return;
            try
            {
                this.splitContainer3.SplitterDistance = this.splitContainer3.Width * 3 / 5;
                this.splitContainer1.SplitterDistance = this.splitContainer1.Width - this.button_nextpage.Width;
                file = new FileInfo(filename);
                this.textBox_filename.Text = file.FullName;
                this.dateTimePicker_createTime.Value = file.CreationTimeUtc;
                this.dateTimePicker_lastaccess.Value = file.LastAccessTimeUtc;
                this.dateTimePicker_lastmodify.Value = file.LastWriteTimeUtc;
                ismodifyed = false;
                br = new BinaryReader(file.OpenRead());
                LoadNextPage();
            }
            catch (Exception)
            {
                
            }
        }
        private void LoadNextPage()
        {
            if (br == null)
                return;
            this.listBox_hexcontext.Items.Clear();
            this.listBox_txtcontext.Items.Clear();
            int lineIndex = 0;
            while (lineIndex < 32)
            {
                byte[] buffer = new byte[16];
                int len = 0;
                len = br.Read(buffer, 0, 16);
                string hexstr = string.Format("{0:x2}: ", lineIndex).ToUpper();
                string txtstr = string.Format("{0:x2}: ", lineIndex).ToUpper();
                for (int i = 0; i < len; i++)
                {
                    hexstr += string.Format("{0:x2} ", buffer[i]).ToUpper();
                    txtstr += string.Format("{0} ", ((buffer[i] > 32 && buffer[i] < 128) ? (char)buffer[i] : (buffer[i]<=32?'.':'?')));
                }
                this.listBox_hexcontext.Items.Add(hexstr);
                this.listBox_txtcontext.Items.Add(txtstr);
                if (len < 16)
                {
                    MessageBox.Show("文件已读取结束！！","文件结束提示");
                    break;
                }
                lineIndex++;
            }
        }
        private void button_apply_Click(object sender, EventArgs e)
        {
            if (file == null)
                return;
            file.CreationTime = this.dateTimePicker_createTime.Value;
            file.LastAccessTimeUtc = this.dateTimePicker_lastaccess.Value;
            file.LastWriteTime = this.dateTimePicker_lastmodify.Value;
            ismodifyed = true;
            br.Close();
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            ismodifyed = false;
            this.Close();
            if(br!=null)
                br.Close();
        }

        private void button_nextpage_Click(object sender, EventArgs e)
        {
            LoadNextPage();
        }

        private void SeniorSetting_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.splitContainer1.SplitterDistance = this.splitContainer1.Width - this.button_nextpage.Width;
            }catch(Exception)
            {

            }
            
        }
    }
}
