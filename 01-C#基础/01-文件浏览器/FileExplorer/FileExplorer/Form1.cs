using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        Stack<string> pathStack=new Stack<string>();
        string preListDir="root";
        ArrayList preSelFiles = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            this.treeView_dirs.Nodes[0].Tag = "root";
            this.treeView_dirs.Nodes[0].ImageKey = "driver";
            pathStack.Push("root");
            foreach (DriveInfo driveInfo in driveInfos)
            {
                TreeNode tn = new TreeNode();
                try
                {
                    tn.Text = driveInfo.VolumeLabel + "(" + driveInfo.Name.Substring(0,2)+")";
                }
                catch (Exception)
                {
                    tn.Text = "(" + driveInfo.Name.Substring(0, 2) + ")";
                    
                }
                
                tn.Tag = driveInfo.RootDirectory;
                tn.ImageKey = "driver";
                this.treeView_dirs.Nodes[0].Nodes.Add(tn);
                UpdateTreeView(tn, 2);
            }
            ListViewShowDisks();
        }
        private void UpdateTreeView(TreeNode node, int Level)
        {
            if (Level == 0)
                return;
            if (node.Level == 0)
                return;
            node.Nodes.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(node.Tag.ToString().Trim());
            try
            {

                DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
                foreach (DirectoryInfo tn in dirInfos)
                {
                    TreeNode temp = new TreeNode();
                    temp.Text = tn.Name;
                    temp.Tag = tn.FullName;
                    temp.ImageKey = "floder";
                    node.Nodes.Add(temp);
                    UpdateTreeView(temp, Level - 1);
                }
            }
            catch (Exception e)
            {
                
            }
        }
        private void UpdateListView(string path)
        {
            try
            {
                preListDir = path;
                this.listView_files.Items.Clear();
                DirectoryInfo dirInfo = new DirectoryInfo(path);
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
                    this.listView_files.Items.Add(item);
                }
                FileInfo[] fileInfos = dirInfo.GetFiles();
                foreach (FileInfo fileInfo in fileInfos)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = fileInfo.Name;
                    item.Tag = fileInfo.FullName;
                    if (this.imageList_icon.Images.Keys.Contains(fileInfo.Extension) == false)
                    {
                        Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName);
                        this.imageList_icon.Images.Add(fileInfo.Extension, icon);
                    }
                    item.ImageKey = fileInfo.Extension;
                    item.SubItems.Add(fileInfo.Extension+"文件");
                    item.SubItems.Add(fileInfo.Length>1024?(fileInfo.Length/1024+"kb"):(fileInfo.Length+"byte"));
                    item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                    this.listView_files.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                
            }
        }
        private void ListViewShowDisks()
        {
            this.listView_files.Items.Clear();
            foreach (TreeNode tn in this.treeView_dirs.Nodes[0].Nodes)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tn.Text;
                item.Tag = tn.Tag;
                item.ImageKey = "driver";
                this.listView_files.Items.Add(item);
            }
        }
        private void treeView_dirs_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            UpdateTreeView(e.Node, 2);
            pathStack.Push(e.Node.Tag.ToString().Trim());
        }

        private void treeView_dirs_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            UpdateTreeView(e.Node, 2);
            pathStack.Push(e.Node.Tag.ToString().Trim());
        }

        private void treeView_dirs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                ListViewShowDisks();
                return;
            }
            TreeNode selNode = e.Node;
            UpdateListView(e.Node.Tag.ToString().Trim());
            pathStack.Push(e.Node.Tag.ToString().Trim());
        }

        private void listView_files_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem it in this.listView_files.SelectedItems)
                {
                    if (Directory.Exists(it.Tag.ToString().Trim()))
                    {
                        UpdateListView(it.Tag.ToString().Trim());
                        pathStack.Push(it.Tag.ToString().Trim());
                    }
                    else
                    {
                        Process.Start(it.Tag.ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void toolStripButton_GotoParent_Click(object sender, EventArgs e)
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

        private void toolStripButton_backPath_Click(object sender, EventArgs e)
        {
            if (pathStack.Count == 0)
            {
                pathStack.Push("root");
                return;
            }
            string path=pathStack.Pop();
            if (path == "root")
            {
                ListViewShowDisks();
                return;
            }
            UpdateListView(path);
        }

        private void 详细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView_files.View = View.Details;
        }

        private void 列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView_files.View = View.List;
        }

        private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView_files.View = View.SmallIcon;
        }

        private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView_files.View = View.LargeIcon;
        }

        private void 尾部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView_files.View = View.Tile;
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string context = "";
            int count=this.listView_files.SelectedItems.Count;
            if(count==1)
            {
                FileInfo it=new FileInfo(this.listView_files.SelectedItems[0].Tag.ToString().Trim());
                if(it.Exists)
                {
                    context += "\n文件名："+it.Name;
                    context += "\n文件路径：" + it.FullName;
                    context += "\n文件大小：" + it.Length+"byte";
                    context += "\n创建时间：" + it.CreationTime.ToString();
                    context += "\n最后访问时间：" + it.LastAccessTime.ToString();
                    context += "\n最后修改时间：" + it.LastWriteTime.ToString();
                    MessageBox.Show(context);
                }
                else
                {
                    MessageBox.Show("已选中一个项目\n" + it.Name);
                }
            }else if(count>1)
            {
                context += "你已选中："+count+"个文件（夹）";
                MessageBox.Show(context);
            }else
            {
                MessageBox.Show("当前没有选中项目");
            }
            
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FileExplorer version1.0\nCopyright @ Ugex - 2019");
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selItems = this.listView_files.SelectedItems;
            foreach(ListViewItem item in selItems)
            {
                string path = item.Tag.ToString().Trim();
               if( Directory.Exists(path))
               {
                   Directory.Delete(path);
               }else if(File.Exists(path))
               {
                   File.Delete(path);
               }
            }
            UpdateListView(preListDir);
        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("请输入文件名(包含后缀)");
            ib.ShowDialog();
            File.Create(preListDir+"\\"+ib.Text);
            UpdateListView(preListDir);
        }

        private void 文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("请输入文件名");
            ib.ShowDialog();
            Directory.CreateDirectory(preListDir + "\\" + ib.Text);
            UpdateListView(preListDir);
        }

        private void cmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("cmd", "/k cd "+preListDir+" && "+preListDir.Substring(0,2)+" && color f1");
        }

        private void powerShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("cmd", "/c cd " + preListDir + " && " + preListDir.Substring(0, 2)+" && start powershell");
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preSelFiles.Clear();
            foreach(ListViewItem item in this.listView_files.SelectedItems)
            {
                preSelFiles.Add(item.Tag.ToString().Trim());
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(string oldpath in preSelFiles)
            {
                if (File.Exists(oldpath))
               {
                   FileInfo file = new FileInfo(oldpath);
                   file.MoveTo(preListDir+"\\"+file.Name);
                   
               }
                else if (Directory.Exists(oldpath))
               {
                   DirectoryInfo dir = new DirectoryInfo(oldpath);
                   dir.MoveTo(preListDir + "\\" + dir.Name);
               }
            }
            UpdateListView(preListDir);
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateListView(preListDir);
        }

        private void 用记事本打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.listView_files.SelectedItems.Count>0)
            {
                string file = this.listView_files.SelectedItems[0].Tag.ToString().Trim();
                if(File.Exists(file))
                    Process.Start("notepad", file);
            }
            
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView_files.SelectedItems.Count == 1)
            {
                InputBox ib=new InputBox("请输入新文件（夹）名称（含后缀）");
                ib.ShowDialog();
                string path = this.listView_files.SelectedItems[0].Tag.ToString().Trim();
                if (File.Exists(path))
                {
                    FileInfo file = new FileInfo(path);
                    file.MoveTo(preListDir+"\\"+ib.Text);
                }else if(Directory.Exists(path))
                {
                    DirectoryInfo dir = new DirectoryInfo(path);
                    dir.MoveTo(preListDir + "\\" + ib.Text);
                }
                UpdateListView(preListDir);
            }else
            {
                MessageBox.Show("当前没有选中或选中多个文件！！！");
            }
           
        }

        private void toolStripSeparator8_Click(object sender, EventArgs e)
        {
            if (this.listView_files.SelectedItems.Count == 1)
            {
                string path = this.listView_files.SelectedItems[0].Tag.ToString().Trim();
                SeniorSetting ss = new SeniorSetting(path);
                ss.ShowDialog();
                if (ss.ismodifyed)
                    UpdateListView(preListDir);
            }
            
        }

        private void cC头文件hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("请输入文件名(不包含后缀)");
            ib.ShowDialog();
            string name=ib.Text.Trim();
            StreamWriter sw = new StreamWriter(preListDir + "\\" + name+".h");
            sw.WriteLine("//#pragma once");
            string head="_"+name.ToUpper()+"_H_";
            sw.WriteLine("#ifndef "+head);
            sw.WriteLine("#define "+head);
            sw.WriteLine();
            sw.WriteLine("#endif // "+head);
            sw.Close();
            UpdateListView(preListDir);
        }

        private void cC源文件cppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("请输入文件名(不包含后缀)");
            ib.ShowDialog();
            string name = ib.Text.Trim();
            StreamWriter sw = new StreamWriter(preListDir + "\\" + name + ".cpp");
            sw.WriteLine("/*");
            sw.WriteLine("#include<iostream>");
            sw.WriteLine("using namespace std;");
            sw.WriteLine("*/");
            sw.WriteLine("#include<stdio.h>");
            sw.WriteLine();
            sw.WriteLine("int main(int argc,char * argv[])");
            sw.WriteLine("{");
            sw.WriteLine("\t");
            sw.WriteLine("\treturn 0;");
            sw.WriteLine("}");
            sw.Close();
            UpdateListView(preListDir);
        }

        private void java源文件javaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("请输入文件名(不包含后缀)");
            ib.ShowDialog();
            string name = ib.Text.Trim();
            StreamWriter sw = new StreamWriter(preListDir + "\\" + name + ".java");
            sw.WriteLine("//package "+name+";");
            sw.WriteLine("public class "+name+" {");
            sw.WriteLine("\t");
            sw.WriteLine("\tpublic static void main(String[] args) {");
            sw.WriteLine("\t\t");
            sw.WriteLine("\t}");
            sw.WriteLine("}");
            sw.Close();
            UpdateListView(preListDir);
        }

        private void python源文件pyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("请输入文件名(不包含后缀)");
            ib.ShowDialog();
            string name = ib.Text.Trim();
            StreamWriter sw = new StreamWriter(preListDir + "\\" + name + ".py");
            sw.WriteLine("#-*-coding=gbk-*-");
            sw.WriteLine("import os,sys");
            sw.WriteLine();
            sw.WriteLine("def main():");
            sw.WriteLine("\tpass");
            sw.WriteLine();
            sw.WriteLine("if __name__==\'__main__\':");
            sw.WriteLine("\tmain()");
            sw.Close();
            UpdateListView(preListDir);
        }

        private void hTML源文件htmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("请输入文件名(不包含后缀)");
            ib.ShowDialog();
            string name = ib.Text.Trim();
            StreamWriter sw = new StreamWriter(preListDir + "\\" + name + ".html");
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html>");
            sw.WriteLine("<head>");
            sw.WriteLine("<meta charset=\"UTF-8\">");
            sw.WriteLine("<title>"+name+"</title>");
            sw.WriteLine();
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            sw.WriteLine("\t");
            sw.WriteLine("</body>");
            sw.WriteLine("\t<style type=\"text/css\">");
            sw.WriteLine("\t\t");
            sw.WriteLine("\t</style>");
            sw.WriteLine("\t<script type=\"text/javascript\">");
            sw.WriteLine("\t\t");
            sw.WriteLine("\t</script>");
            sw.WriteLine("</html>");
            sw.Close();
            UpdateListView(preListDir);
        }

        private void 批处理文件batToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("请输入文件名(不包含后缀)");
            ib.ShowDialog();
            string name = ib.Text.Trim();
            StreamWriter sw = new StreamWriter(preListDir + "\\" + name + ".bat");
            sw.WriteLine("@echo off");
            sw.WriteLine("color f1");
            sw.WriteLine("title "+name);
            sw.WriteLine();
            sw.WriteLine("exit");
            sw.WriteLine("echo del %0");
            sw.Close();
            UpdateListView(preListDir);
        }

        private void vB脚本vbsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("请输入文件名(不包含后缀)");
            ib.ShowDialog();
            string name = ib.Text.Trim();
            StreamWriter sw = new StreamWriter(preListDir + "\\" + name + ".vbs");
            sw.WriteLine("msgbox(\""+name+"\")");
            sw.WriteLine();
            sw.Close();
            UpdateListView(preListDir);
        }

        private void bash脚本shToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("请输入文件名(不包含后缀)");
            ib.ShowDialog();
            string name = ib.Text.Trim();
            StreamWriter sw = new StreamWriter(preListDir + "\\" + name + ".sh");
            sw.WriteLine("#!/bin/sh");
            sw.WriteLine("echo "+name+";");
            sw.WriteLine();
            sw.Close();
            UpdateListView(preListDir);
        }

        private void explorer打开路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "\"" + preListDir + "\"");
        }

    }
}
