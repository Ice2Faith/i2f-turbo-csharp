using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace WinHexViewer
{
    public partial class HexViewer : UserControl
    {
        private string mCopyRight = "Ugex.Savelar";
        public string CopyRight
        {
            get { return mCopyRight; }
        }
        private string fileName;
        private string tempName;
        FileStream filein;
        FileStream fileout;
        private long pageIndex = 0;
        private int displayLine = 16;
        private int lineCount = 16;
        ArrayList pageByteArr = new ArrayList();
        public HexViewer()
        {
            InitializeComponent();
        }
        public int DisplayLineCount
        {
            get { return displayLine; }
            set
            {
                if(value>8&&value<1024)
                    displayLine=value;
            }
        }
        public int LineByteCount
        {
            get { return lineCount; }
            set
            {
                if (value > 8 && value < 512)
                    lineCount = value;
            }
        }
        public string FileName
        {
            get { return fileName; }
            set
            {
                pageIndex = 0;
                pageByteArr.Clear();
                if (filein != null)
                {
                    filein.Close();
                    filein = null;
                }
                if (fileout != null)
                {
                    fileout.Close();
                    fileout = null;
                }
                if (File.Exists(value))
                {
                    fileName = value;
                    filein = new FileStream(fileName, FileMode.Open);
                    FileInfo fi=new FileInfo(fileName);
                    tempName=fi.DirectoryName+"\\hexview.tmp";
                    fileout = new FileStream(tempName, FileMode.Create);
                    UpdateByteData();
                    UpdataListBox();
                }
                if (value == null)
                {
                    fileName = null;
                }
            }
        }
        private void SaveByteDate()
        {
            foreach(byte[] arr in pageByteArr)
            {
                fileout.Write(arr,0,arr.Length);
            }
        }
        private void UpdateByteData()
        {
            pageByteArr.Clear();
            if (filein != null)
            {
                byte[] buffer = new byte[lineCount];
                for (int i = 0; i < displayLine; i++)
                {
                    int len = filein.Read(buffer, 0, lineCount);
                    if (len == 0)
                    {
                        if(filein!=null)
                        {
                            filein.Close();
                            filein = null;
                        }
                       // MessageBox.Show(this, "文件已经读取完毕！");
                        break;
                    }
                    byte[] save = new byte[len];
                    for (int j = 0; j < len; j++)
                    {
                        save[j] = buffer[j];
                    }
                    pageByteArr.Add(save);
                }
                pageIndex++;
            }
            
        }
        private void UpdataListBox()
        {
            this.listBoxContent.Items.Clear();
            foreach(byte[] arr in pageByteArr)
            {
                this.listBoxContent.Items.Add(ByteArrToListBoxLine(arr));
            }
            if(this.listBoxContent.Items.Count==0)
            {
                if(fileout!=null)
                {
                    fileout.Close();
                    fileout = null;
                }
                this.listBoxContent.Items.Add("这里空空入也，什么也没有！");
            }
            this.buttonPageIndex.Text = pageIndex + " 页";
            UpdateSelectLineDisplay();
        }
        private void UpdateSelectLineDisplay()
        {
            this.buttonSelectLine.Text = this.listBoxContent.SelectedIndex + " 行";
        }
        private string ByteArrToListBoxLine(byte[] arr)
        {
            string ListboxLine = ByteArrToHexString(arr);
            ListboxLine += "=> ";
            ListboxLine += ByteArrToEncodeString(arr);
            return ListboxLine;
        }
        private string ByteArrToHexString(byte[] arr)
        {
            string hexBytes = "";
            foreach (byte bt in arr)
            {
                hexBytes += String.Format("{0:X2} ", bt);
            }
            return hexBytes;
        }
        private string ByteArrToEncodeString(byte[] arr)
        {
            return Encoding.ASCII.GetString(arr); ;
        }
        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            SaveByteDate();
            UpdateByteData();
            UpdataListBox();
            this.textBoxEditLine.Text = "";
        }
        private bool CheckByteStringLegal(string str)
        {
            bool ret = true;
            str = str.ToUpper();
            string[] arrs = str.Split(' ');
            foreach (string arr in arrs)
            {
                if(arr.Length!=2 || ret==false)
                {
                    ret = false;
                    break;
                }
                for(int i=0;i<2;i++)
                {
                    if ((arr[i] >= '0' && arr[i] <= '9') || (arr[i] >= 'A' && arr[i] <= 'F'))
                    {
                        continue;
                    }
                    else
                    {
                        ret = false;
                        break;
                    }
                }
            }
            return ret;
        }
        private void ApplyModifyData()
        {
            if (this.listBoxContent.SelectedIndex != -1)
            {
                string editText = this.textBoxEditLine.Text.Trim();
                if (editText.Length > 0)
                {
                    if (!CheckByteStringLegal(editText))
                        return;
                    byte[] bts = HexStringToByteArr(editText);
                    pageByteArr[this.listBoxContent.SelectedIndex] = bts;
                    UpdataListBox();
                }
                else
                {
                    pageByteArr[this.listBoxContent.SelectedIndex] = new byte[0];
                    UpdataListBox();
                }
            }
        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            ApplyModifyData();
        }
        private byte[] HexStringToByteArr(string str)
        {
            string[] arrs = str.Split(' ');
            byte[] ret = new byte[arrs.Length];
            int i = 0;
            foreach(string ts in arrs)
            {
                ret[i++] = TwoHexStringToByte(ts);
            }
            return ret;
        }
        private byte TwoHexStringToByte(string str)
        {
            str = str.ToUpper();
            byte ret = 0;
            for (int i = 0; i < 2; i++)
            {
                ret *= 16;
                if (str[i] >= '0' && str[i] <= '9')
                    ret += (byte)(str[i] - '0');
                if (str[i] >= 'A' && str[i] <= 'F')
                    ret += (byte)(str[i] - 'A' + 10);
            }
            return ret;
        }

        private void UpdateEditLineDisplay()
        {
            if (this.listBoxContent.SelectedIndex!=-1 && pageByteArr.Count>0)
                this.textBoxEditLine.Text = ByteArrToHexString(pageByteArr[this.listBoxContent.SelectedIndex] as byte[]); 
        }
        private void listBoxContent_Click(object sender, EventArgs e)
        {
            if (this.listBoxContent.SelectedIndex != -1)
            {
                UpdateEditLineDisplay();
                UpdateSelectLineDisplay();
            }
        }

        private void buttonSaveModify_Click(object sender, EventArgs e)
        {
            if (filein != null)
            {
                SaveByteDate();
                byte[] arr = new byte[2048];
                while (true)
                {
                    int len = filein.Read(arr, 0, 2048);
                    if (len == 0)
                        break;
                    fileout.Write(arr, 0, len);
                }
                filein.Close();
                filein = null;
            }
            if(fileout!=null)
            {
                fileout.Close();
                fileout = null;
            }
            pageIndex = 0;
            pageByteArr.Clear();
            this.textBoxEditLine.Clear();
            this.listBoxContent.Items.Clear();
            this.saveFileDialogSaveFile.InitialDirectory = new FileInfo(tempName).Directory.FullName;
            this.saveFileDialogSaveFile.ValidateNames = true;
            this.saveFileDialogSaveFile.FileName = new FileInfo(fileName).Name;
            DialogResult ret=this.saveFileDialogSaveFile.ShowDialog();
            if(ret==DialogResult.OK)
            {
                string newname=this.saveFileDialogSaveFile.FileName.Trim();
                if(File.Exists(newname))
                {
                    File.Delete(newname);
                }
                File.Move(tempName,newname);
            }else
            {
                File.Delete(tempName);
            }
        }

        private void textBoxEditLine_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                ApplyModifyData();
            }
        }

        private void textBoxHexCode_Leave(object sender, EventArgs e)
        {
            if (this.textBoxHexCode.Text.Trim().Length != 2)
                return;
            byte bt=TwoHexStringToByte(this.textBoxHexCode.Text.Trim());
            this.textBoxCharCode.Text = (char)bt+"";
            this.textBoxNumCode.Text = String.Format("{0:D}",bt);
        }

        private void textBoxNumCode_Leave(object sender, EventArgs e)
        {
            if (this.textBoxNumCode.Text.Trim().Length == 0)
                return;
            try
            {
                int a = int.Parse(this.textBoxNumCode.Text.Trim());
                this.textBoxHexCode.Text = String.Format("{0:X}", (int)a);
                this.textBoxCharCode.Text = (char)a + "";
            }catch(Exception)
            {

            }
            
        }

        private void textBoxCharCode_Leave(object sender, EventArgs e)
        {
            if (this.textBoxCharCode.Text.Length == 0)
                return;
            char a = this.textBoxCharCode.Text[0];
            this.textBoxHexCode.Text = String.Format("{0:X}", (int)a);
            this.textBoxNumCode.Text = String.Format("{0:D}", (int)a);
        }

        private void listBoxContent_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = e.Data.GetData(DataFormats.FileDrop,false) as string[];
            if (File.Exists(path[0]))
                FileName = path[0];
        }

        private void listBoxContent_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBoxContent_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right||e.KeyCode==Keys.Down||e.KeyCode==Keys.PageDown)
            {
                SaveByteDate();
                UpdateByteData();
                UpdataListBox();
                this.textBoxEditLine.Text = "";
            }
        }
        private void DeleteTempFile()
        {
            if (File.Exists(tempName))
                File.Delete(tempName);
        }
    }
}
