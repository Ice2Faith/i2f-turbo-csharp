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
using System.Diagnostics;

namespace StyleSuit
{
    public partial class FormSpecial : FormStyle
    {
        private string[] fileFliter;
        public string preListDir = "";
        public FormSpecial(string[] fileFliter,string nameWnd)
        {
            InitializeComponent();
            this.fileFliter = fileFliter;
            this.buttonNameWnd.Text = nameWnd;
        }
        
        public void UpdateListView(string path)
        {
            preListDir = path;
            try
            {
                this.listViewContent.Items.Clear();
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if(fileFliter[0]=="folder")
                {
                    DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
                    foreach (DirectoryInfo di in dirInfos)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = di.Name;
                        item.Tag = di.FullName;
                        item.ImageKey = "folder";
                        item.SubItems.Add("文件夹");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        this.listViewContent.Items.Add(item);
                    }
                    string[] execlist = { ".ZIP", ".TAR", ".7Z", ".RAR", ".IMG",".ISO",".TGZ" };
                    FileInfo[] fileInfos = dirInfo.GetFiles();
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        string exname = fileInfo.Extension.ToUpper();
                        bool isAddItem = false;
                        foreach (string el in execlist)
                        {
                            if (exname == el)
                            {
                                isAddItem = true;
                                break;
                            }
                        }
                        if (isAddItem)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = fileInfo.Name;
                            item.Tag = fileInfo.FullName;
                            if (this.imageListFiles.Images.Keys.Contains(fileInfo.Extension) == false)
                            {
                                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName);
                                this.imageListFiles.Images.Add(fileInfo.Extension, icon);
                            }
                            item.ImageKey = fileInfo.Extension;
                            item.SubItems.Add(fileInfo.Extension + "文件");
                            item.SubItems.Add(FileSizeToString(fileInfo.Length));
                            item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                            this.listViewContent.Items.Add(item);
                        }
                    }

                }
                else if(fileFliter[0]=="file")
                {
                    string[] execlist = { ".EXE", ".BAT", ".COM", ".VBS", ".LNK" };
                    FileInfo[] fileInfos = dirInfo.GetFiles();
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        string exname = fileInfo.Extension.ToUpper();
                        bool isAddItem = false;
                        foreach (string el in execlist)
                        {
                            if (exname == el)
                            {
                                isAddItem = true;
                                break;
                            }
                        }
                        if (!isAddItem)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = fileInfo.Name;
                            item.Tag = fileInfo.FullName;
                            if (this.imageListFiles.Images.Keys.Contains(fileInfo.Extension) == false)
                            {
                                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName);
                                this.imageListFiles.Images.Add(fileInfo.Extension, icon);
                            }
                            item.ImageKey = fileInfo.Extension;
                            item.SubItems.Add(fileInfo.Extension + "文件");
                            item.SubItems.Add(FileSizeToString(fileInfo.Length));
                            item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                            this.listViewContent.Items.Add(item);
                        }

                    }
                }
                 else if(fileFliter[0]=="exec")
                {
                     string[] execlist={".EXE",".BAT",".COM",".VBS",".LNK"};
                    FileInfo[] fileInfos = dirInfo.GetFiles();
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        string exname=fileInfo.Extension.ToUpper();
                        bool isAddItem = false;
                        foreach(string el in execlist)
                        {
                            if(exname==el)
                            {
                                isAddItem = true;
                                break;
                            }
                        }
                        if(isAddItem)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = fileInfo.Name;
                            item.Tag = fileInfo.FullName;
                            if (this.imageListFiles.Images.Keys.Contains(fileInfo.Extension) == false)
                            {
                                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName);
                                this.imageListFiles.Images.Add(fileInfo.Extension, icon);
                            }
                            item.ImageKey = fileInfo.Extension;
                            item.SubItems.Add(fileInfo.Extension + "文件");
                            item.SubItems.Add(FileSizeToString(fileInfo.Length));
                            item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                            this.listViewContent.Items.Add(item);
                        }
                        
                    }
                }
               
            }
            catch (Exception e)
            {

            }
        }
        private void ListViewShowDisks()
        {
            this.listViewContent.Items.Clear();
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in driveInfos)
            {
                ListViewItem item = new ListViewItem();
                try
                {
                    item.Text = driveInfo.VolumeLabel + "(" + driveInfo.Name.Substring(0, 2) + ")";
                }
                catch (Exception)
                {
                    item.Text = "(" + driveInfo.Name.Substring(0, 2) + ")";

                }

                item.Tag = driveInfo.RootDirectory;
                item.ImageKey = "disk";
                this.listViewContent.Items.Add(item);
            }

        }
        private string FileSizeToString(long size)
        {
            if (size > 1024 * 1024 * 1024)
                return String.Format("{0:N2}GB", (size / 1024.0 / 1024 / 1024));
            else if (size > 1024 * 1024)
                return String.Format("{0:N2}MB", (size / 1024.0 / 1024));
            else if (size > 1024)
                return String.Format("{0:N2}KB", (size / 1024.0));
            else
                return size + "Byte";
        }

        public override void buttonCloseWnd_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void OpenRunProcessFile()
        {
            if (this.listViewContent.SelectedItems.Count > 0)
            {
                bool firstDir = true;
                foreach (ListViewItem item in this.listViewContent.SelectedItems)
                {
                    string name = item.Tag.ToString().Trim();
                    if (File.Exists(name))
                    {
                        Process.Start(name);
                    }
                    else
                    {
                        if (firstDir)
                        {
                            UpdateListView(name);
                            firstDir = false;
                        }
                    }
                }
            }
        }

        private void listViewContent_DoubleClick(object sender, EventArgs e)
        {
            OpenRunProcessFile();
        }

        private void buttonIconWnd_Click(object sender, EventArgs e)
        {
            DirectoryInfo pDir = new DirectoryInfo(preListDir);
            try
            {
                UpdateListView(pDir.Parent.FullName);
            }
            catch (Exception ex)
            {
                ListViewShowDisks();
            }
        }
        private void FolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入新文件夹名");
            if (ib.InputText != null)
            {
                try
                {
                    Directory.CreateDirectory(preListDir + "\\" + ib.InputText);
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }

        private void TextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入新文本文件名（不含后缀）");
            if (ib.InputText != null)
            {
                try
                {
                    File.Create(preListDir + "\\" + ib.InputText + ".txt");
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }
        private void ReflashFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateListView(preListDir);
        }
        private void BigIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewContent.View = View.LargeIcon;
        }

        private void DetialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewContent.View = View.Details;
        }
        private void NotepadOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewContent.SelectedItems.Count > 0)
            {
                string name = this.listViewContent.SelectedItems[0].Tag.ToString().Trim();
                if (File.Exists(name))
                    Process.Start("notepad", name);
            }

        }

        private void CommandOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("cmd", "/k cd " + preListDir + " && " + preListDir.Substring(0, 2) + " && color f1");
        }


        private void RouteCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(preListDir);
        }

        private void JumpPathToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入要转到的目录");
            if (ib.InputText != null)
            {
                string str = ib.InputText.Trim();
                if (Directory.Exists(str))
                {
                    UpdateListView(str);
                }
            }
        }

        private void BrowserSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入要搜索的内容");
            if (ib.InputText != null)
            {
                string str = ib.InputText.Trim();
                Process.Start("http://www.baidu.com/s?wd="+str);
            }
        }

        private void GoogleTranslateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入要翻译的内容");
            if (ib.InputText != null)
            {
                string str = ib.InputText.Trim();
                if (str.Length > 0 && str[0] > 32 && str[0] < 128)
                    Process.Start("https://translate.google.cn/#view=home&op=translate&sl=en&tl=zh-CN&text=" + str);
                else
                    Process.Start("https://translate.google.cn/#view=home&op=translate&sl=zh-CN&tl=en&text=" + str);
            }
        }
    }
}
