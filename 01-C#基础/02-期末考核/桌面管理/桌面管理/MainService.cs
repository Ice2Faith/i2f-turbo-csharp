using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace StyleSuit
{
    partial class FormMain
    {
        /// <summary>
        /// 桌面路径
        /// </summary>
        private string strDesktopPath = "";
        /// <summary>
        /// 当前显示的路径
        /// </summary>
        private string preListDir = "";
        /// <summary>
        /// 提供给返回上一步文件夹的栈
        /// </summary>
        private Stack<string> RouterStack = new Stack<string>();
        /// <summary>
        /// 用来记录用于复制或者剪切的路径的集合
        /// </summary>
        private List<string> SelectBuffer = new List<string>();
        /// <summary>
        /// 用来区分复制或者剪切操作的标记
        /// </summary>
        private BufferState stateBuffer = BufferState.NULL_BUFFER;
        enum BufferState
        {
            NULL_BUFFER = 0,
            COPY_BUFFER = 1,
            CUT_BUFFER = 2,
        }
        /// <summary>
        /// 分别显示不同类别的文件的三个窗体，文件夹，文件，可执行文件或快捷方式
        /// </summary>
        FormSpecial fsfolder;
        FormSpecial fsfile;
        FormSpecial fsexec;
        /// <summary>
        /// 用于记录是否进行文件分析的控制变量
        /// </summary>
        bool needAnaly = false;
        /// <summary>
        /// 用于记录子窗口是否是自由移动的活动窗口的变量，不自由就是停靠
        /// </summary>
        private bool isFreeFooMode = true;
        /// <summary>
        /// 用于控制主窗口的现实内容的类型变量
        /// </summary>
        private ViewTypeEnum preViewType = ViewTypeEnum.SHOW_ALL;
        public enum ViewTypeEnum
        {
            SHOW_ALL = 0,
            SHOW_ONLY_FOLDER = 1,
            SHOW_ONLY_FILE = 2,
            SHOW_ONLY_EXECORLINK = 3,
        };
        /// <summary>
        /// 可执行文件或快捷方式的后缀枚举数组，一律大写
        /// </summary>
        private string[] EXEC_LINK_LIST = { ".EXE", ".LNK", ".BAT", ".VBS", ".COM", ".PY", ".CLASS", ".JAR" };
        /// <summary>
        /// 用于记录当前使用的排序类型的控制变量
        /// </summary>
        private SortTypeEnum preSortType = SortTypeEnum.SORT_DEFAULT;
        /// <summary>
        /// 用于控制当前的升序降序的切换，true为从小到大
        /// </summary>
        private bool SortDirection = true;
        public enum SortTypeEnum
        {
            SORT_DEFAULT = 0,
            SORT_NAME = 1,
            SORT_SIZE = 2,
            SORT_TIME = 3,
        };
        
        /// <summary>
        /// 用于记录用来排序的数据单元的对象封装和集合定义
        /// </summary>
        class FolderInfoItem
        {
            public string Name;
            public string FullName;
            public string ImageKey;
            public string Type;
            public long Size;
            public string ShowSize;
            public DateTime LastModifyTime;
            public string ShowLastModifyTime;
        }
        private List<FolderInfoItem> itemList = new List<FolderInfoItem>();
        /// <summary>
        /// 主窗口加载响应主体
        /// </summary>
        private void MainLoad()
        {
            strDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string[] folders = { "folder" };
            fsfolder = new FormSpecial(folders, "文件夹&&压缩包");
            string[] files = { "file" };
            fsfile = new FormSpecial(files, "文件");
            string[] execs = { "exec" };
            fsexec = new FormSpecial(execs, "软件&&快捷方式");
            UpdateListView(strDesktopPath);
            fsfolder.Show();
            fsfile.Show();
            fsexec.Show();
            JoinAllChildWnd();
        }
        /// <summary>
        /// 响应选中项目的执行事件，打开文件夹或者文件
        /// </summary>
        private void OpenRunProcessFile()
        {
            if (this.listViewDesktop.SelectedItems.Count > 0)
            {
                string flashdir = preListDir;
                bool firstDir = true;
                foreach (ListViewItem item in this.listViewDesktop.SelectedItems)
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
                            flashdir = name;
                            firstDir = false;
                        }
                    }
                }
                UpdateListView(flashdir);
            }
        }
        /// <summary>
        /// 更新子窗口视图
        /// </summary>
        private void UpdataChildWnd()
        {
            fsfolder.UpdateListView(preListDir);
            fsfile.UpdateListView(preListDir);
            fsexec.UpdateListView(preListDir);
        }
        /// <summary>
        /// 获取传入路径（文件、文件夹）的大小和最后修改时间
        /// </summary>
        /// <param name="path">传入的路径</param>
        /// <param name="dt">一个最后修改的时间的引用，默认请给1940-1-1</param>
        /// <returns></returns>
        private long FileSystemSizeAndLastModifyTime(string path, ref DateTime dt)
        {
            long ret = 0;
            try
            {
                if (File.Exists(path))
                {
                    DateTime fdt = new FileInfo(path).LastWriteTime;
                    if (dt.CompareTo(fdt) < 0)
                        dt = fdt;
                    return new FileInfo(path).Length;
                }
                else if (Directory.Exists(path))
                {
                    foreach (FileInfo file in new DirectoryInfo(path).GetFiles())
                    {
                        if (dt.CompareTo(file.LastWriteTime) < 0)
                            dt = file.LastWriteTime;
                        ret += file.Length;
                    }
                    foreach (string dir in Directory.GetDirectories(path))
                    {
                        ret += FileSystemSizeAndLastModifyTime(dir, ref dt);
                    }
                }
            }
            catch (Exception)
            { }

            return ret;
        }
        /// <summary>
        /// 更新主窗体视图
        /// </summary>
        /// <param name="path">要显示的文件夹路径</param>
        public void UpdateListView(string path)
        {
            if (path == "root")
            {
                preListDir = path;
                PushPathToRouter(preListDir);
                ListViewShowDisks();
                UpdataChildWnd();
                return;
            }
            if (path == null)
            {
                path = strDesktopPath;
            }
            preListDir = path;
            PushPathToRouter(preListDir);
            UpdataChildWnd();
            GetFolderInfoList();
            SortItemList();
            PushListToView();
        }
        /// <summary>
        /// 将排序之后的项目推送到窗口上进行显示
        /// </summary>
        private void PushListToView()
        {
            foreach (FolderInfoItem it in itemList)
            {
                ListViewItem item = new ListViewItem();
                item.Text = it.Name;
                item.Tag = it.FullName;
                item.ImageKey = it.ImageKey;
                item.SubItems.Add(it.Type);
                item.SubItems.Add(it.ShowSize);
                item.SubItems.Add(it.ShowLastModifyTime);
                this.listViewDesktop.Items.Add(item);
            }
        }

        private void GetFolderInfoList()
        {
            itemList.Clear();
            double preDirSizeSum = 0;
            if (needAnaly)
            {
                DateTime pdt = new DateTime(1940, 1, 1);
                preDirSizeSum = FileSystemSizeAndLastModifyTime(preListDir, ref pdt);
            }
            try
            {
                this.listViewDesktop.Items.Clear();
                DirectoryInfo dirInfo = new DirectoryInfo(preListDir);
                if (preViewType == ViewTypeEnum.SHOW_ALL || preViewType == ViewTypeEnum.SHOW_ONLY_FOLDER)
                {
                    DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
                    foreach (DirectoryInfo di in dirInfos)
                    {
                        FolderInfoItem item = new FolderInfoItem();
                        item.Name = di.Name;
                        item.FullName = di.FullName;
                        item.ImageKey = "folder";
                        item.Type = "文件夹";
                        if (needAnaly)
                        {
                            DateTime pdt = new DateTime(1940, 1, 1);
                            long psize = FileSystemSizeAndLastModifyTime(di.FullName, ref pdt);
                            item.Size = psize;
                            item.ShowSize = (psize / preDirSizeSum * 100).ToString("0.000") + "% " + FileSizeToString(psize);
                            item.LastModifyTime = pdt;
                            item.ShowLastModifyTime = pdt.ToString();
                        }
                        else
                        {
                            item.ShowSize = "";
                            item.ShowLastModifyTime = "";
                        }
                        itemList.Add(item);
                    }
                }
                if (preViewType == ViewTypeEnum.SHOW_ALL || preViewType == ViewTypeEnum.SHOW_ONLY_FILE || preViewType == ViewTypeEnum.SHOW_ONLY_EXECORLINK)
                {
                    FileInfo[] fileInfos = dirInfo.GetFiles();
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        if (preViewType == ViewTypeEnum.SHOW_ONLY_EXECORLINK)
                        {
                            bool isTargetFiles = false;
                            foreach (string tail in EXEC_LINK_LIST)
                            {
                                if (fileInfo.Extension.ToUpper() == tail)
                                {
                                    isTargetFiles = true;
                                    break;
                                }
                            }
                            if (!isTargetFiles)
                                return;
                        }
                        FolderInfoItem item = new FolderInfoItem();
                        item.Name = fileInfo.Name;
                        item.FullName = fileInfo.FullName;
                        if (fileInfo.Extension == "")
                        {
                            item.ImageKey = "null";
                            item.Type = "未知类型";
                        }
                        else
                        {
                            if (this.imageListFiles.Images.Keys.Contains(fileInfo.Extension) == false)
                            {
                                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName);
                                this.imageListFiles.Images.Add(fileInfo.Extension, icon);
                            }
                            item.ImageKey = fileInfo.Extension;
                            item.Type = fileInfo.Extension + "文件";
                        }
                        if (needAnaly)
                        {
                            DateTime pdt = new DateTime(1940, 1, 1);
                            long psize = FileSystemSizeAndLastModifyTime(fileInfo.FullName, ref pdt);
                            item.Size = psize;
                            item.ShowSize = ((psize / preDirSizeSum * 100).ToString("0.000") + "% " + FileSizeToString(psize));
                            item.LastModifyTime = pdt;
                            item.ShowLastModifyTime = (pdt.ToString());
                        }
                        else
                        {
                            item.Size = fileInfo.Length;
                            item.ShowSize = (FileSizeToString(fileInfo.Length));
                            item.LastModifyTime = fileInfo.LastWriteTime;
                            item.ShowLastModifyTime = (fileInfo.LastWriteTime.ToString());
                        }
                        itemList.Add(item);
                    }
                }

            }
            catch (Exception e)
            {

            }
        }
        /// <summary>
        /// 根据当前的排序规则，返回一个比较结果，=0：相等，<0:参数2更小，>0：参数1更小
        /// </summary>
        /// <param name="item1">保存显示信息的类对象</param>
        /// <param name="item2">保存显示信息的类对象</param>
        /// <returns></returns>
        private int CompareFolderInfoItem(FolderInfoItem item1, FolderInfoItem item2)
        {
            if (preSortType == SortTypeEnum.SORT_NAME)
            {
                return item1.Name.CompareTo(item2.Name);
            }
            else if (preSortType == SortTypeEnum.SORT_SIZE)
            {
                return (int)(item2.Size-item1.Size);
            }
            else if (preSortType == SortTypeEnum.SORT_TIME)
            {
                if (item1.LastModifyTime == item2.LastModifyTime)
                    return 0;
                else if (item1.LastModifyTime < item2.LastModifyTime)
                    return -1;
                else
                    return 1;
            }
            else
                return -1;
        }
        /// <summary>
        /// 对获取的数据集合进行排序
        /// </summary>
        private void SortItemList()
        {
            if (preSortType == SortTypeEnum.SORT_DEFAULT)
                return;
            for (int i = 0; i < itemList.Count; i++)
            {
                bool swap = false;
                for (int j = 0; j < itemList.Count - 1; j++)
                {
                    if ((CompareFolderInfoItem(itemList[j], itemList[j + 1]) > 0) == SortDirection)
                    {
                        FolderInfoItem temp = itemList[j + 1];
                        itemList[j + 1] = itemList[j];
                        itemList[j] = temp;
                        swap = true;
                    }
                }
                if (!swap)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 显示系统全部磁盘到界面上
        /// </summary>
        private void ListViewShowDisks()
        {
            this.listViewDesktop.Items.Clear();
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
                this.listViewDesktop.Items.Add(item);
            }

        }
        /// <summary>
        /// 根据传入的文件大小，转换为可读的文件大小，自适应单位
        /// </summary>
        /// <param name="size">文件大小（字节）</param>
        /// <returns></returns>
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
        /// <summary>
        /// 返回当前路径的父路径
        /// </summary>
        private void GotoParentDirectory()
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
        /// <summary>
        /// 返回上次访问的路径
        /// </summary>
        private void BackToHistoryDirectory()
        {
            if (RouterStack.Peek() == preListDir)
                RouterStack.Pop();
            if (RouterStack.Count > 0)
                UpdateListView(RouterStack.Pop());
            else
                UpdateListView(strDesktopPath);
        }
        /// <summary>
        /// 将排序完的信息显示到界面上
        /// </summary>
        /// <param name="path"></param>
        private void PushPathToRouter(string path)
        {
            if (RouterStack.Count > 0)
            {
                if (RouterStack.Peek() != path)
                    RouterStack.Push(path);
            }
            else
            {
                RouterStack.Push(path);
            }
        }
        /// <summary>
        /// 删除已选择的文件（多个）
        /// </summary>
        private void DeleteSelectedFiles()
        {
            if (this.listViewDesktop.SelectedItems.Count > 0)
            {
                DialogResult ret = MessageBox.Show(this, this.listViewDesktop.SelectedItems.Count + "个文件将被删除，不可恢复，是否删除？", "文件删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ret == DialogResult.OK)
                {
                    foreach (ListViewItem item in this.listViewDesktop.SelectedItems)
                    {
                        string name = item.Tag.ToString().Trim();
                        if (File.Exists(name) == true)
                        {
                            File.Delete(name);
                        }
                        else if (Directory.Exists(name) == true)
                        {
                            Directory.Delete(name, true);
                        }
                    }
                    UpdateListView(preListDir);
                }

            }
        }
        /// <summary>
        /// 新建文件夹
        /// </summary>
        private void NewFolder()
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
        /// <summary>
        /// 新建文本文件
        /// </summary>
        private void NewTextFile()
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
        /// <summary>
        /// 新建Cpp源代码文件
        /// </summary>
        private void NewCppFile()
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入Cpp文件名（不含后缀）");
            if (ib.InputText != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(new FileStream(preListDir + "\\" + ib.InputText + ".cpp", FileMode.CreateNew));
                    string[] content = { "#include<iostream>",
                                       "//#include<cstdio>",
                                       "//#include<string>",
                                       "//#include<cstring>",
                                       "//#include<cmath>",
                                       "//#include<ctime>",
                                       "//#include<cstdlib>",
                                       "using namespace std;",
                                       "/**/",
                                       "",
                                       "int main(int argc,char * argv[])",
                                       "{",
                                       "\tcout << \"Hello\" << endl;",
                                       "\treturn 0;",
                                       "}",
                                       ""};
                    foreach (string line in content)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }
        /// <summary>
        /// 创建C源代码文件
        /// </summary>
        private void NewCFile()
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入C文件名（不含后缀）");
            if (ib.InputText != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(new FileStream(preListDir + "\\" + ib.InputText + ".c", FileMode.CreateNew));
                    string[] content = { "#include<stdio.h>",
                                       "//#include<string.h>",
                                       "//#include<math.h>",
                                       "//#include<time.h>",
                                       "//#include<stdlib.h>",
                                       "/**/",
                                       "",
                                       "int main(int argc,char * argv[])",
                                       "{",
                                       "\tprintf(\"Hello\");",
                                       "\treturn 0;",
                                       "}",
                                       ""};
                    foreach (string line in content)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }
        /// <summary>
        /// 创建C或Cpp头文件
        /// </summary>
        private void NewCorCppHeadFile()
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入C/C++头文件名（不含后缀）");
            if (ib.InputText != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(new FileStream(preListDir + "\\" + ib.InputText + ".h", FileMode.CreateNew));
                    string[] content = { "//#pragma once",
                                       "#ifndef _"+ib.InputText.ToUpper()+"_H_",
                                       "#define _"+ib.InputText.ToUpper()+"_H_",
                                       "/**/",
                                       "",
                                       "#endif // _"+ib.InputText.ToUpper()+"_H_",
                                       };
                    foreach (string line in content)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }
        /// <summary>
        /// 创建Java源代码文件
        /// </summary>
        private void NewJavaFile()
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入Java文件名（不含后缀）");
            if (ib.InputText != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(new FileStream(preListDir + "\\" + ib.InputText + ".java", FileMode.CreateNew));
                    string[] content = { "//package "+ib.InputText+";",
                                       "/**/",
                                       "public class "+ib.InputText+" {",
                                       "\t",
                                       "\tpublic static void main(String[] args) {",
                                       "\t\tSystem.out.println(\"Hello\");",
                                       "\t}",
                                       "}",
                                       };
                    foreach (string line in content)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }
        /// <summary>
        /// 创建Html文件
        /// </summary>
        private void NewHtmlFile()
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入Html文件名（不含后缀）");
            if (ib.InputText != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(new FileStream(preListDir + "\\" + ib.InputText + ".html", FileMode.CreateNew));
                    string[] content = { "<!DOCTYPE html>",
                                       "<!--  -->",
                                       "<html>",
                                       "<head>",
                                       "<meta charset=\"UTF-8\">",
                                       "<title>"+ib.InputText+"</title>",
                                       "</head>",
                                       "<body>",
                                       "\tHello",
                                       "</body>",
                                       "<style type=\"text/css\">",
                                       "\t",
                                       "</style>",
                                       "<script type=\"text/javascript\">",
                                       "\t",
                                       "</script>",
                                       "</html>"
                                       };
                    foreach (string line in content)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }
        /// <summary>
        /// 创建Python源代码文件
        /// </summary>
        private void NewPythonFile()
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入Python文件名（不含后缀）");
            if (ib.InputText != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(new FileStream(preListDir + "\\" + ib.InputText + ".py", FileMode.CreateNew));
                    string[] content = { "#-*-coding:gbk-*-",
                                       "'''",
                                       "'''",
                                       "import os",
                                       "",
                                       "def main():",
                                       "\tprint('Hello')",
                                       "",
                                       "if __name__=='__main__':",
                                       "\tmain()"
                                       };
                    foreach (string line in content)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }
        /// <summary>
        /// 创建Bat脚本文件
        /// </summary>
        private void NewBatFile()
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入Bat(Command)文件名（不含后缀）");
            if (ib.InputText != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(new FileStream(preListDir + "\\" + ib.InputText + ".bat", FileMode.CreateNew));
                    string[] content = { "@echo off",
                                       "title "+ib.InputText+"",
                                       "echo "+ib.InputText,
                                       "echo %0",
                                       "echo del %0",
                                       "exit",
                                       };
                    foreach (string line in content)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }
        /// <summary>
        /// 创建Bash脚本文件
        /// </summary>
        private void NewBashFile()
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入Bash文件名（不含后缀）");
            if (ib.InputText != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(new FileStream(preListDir + "\\" + ib.InputText + ".sh", FileMode.CreateNew));
                    string[] content = { "#!/bin/sh",
                                       "echo "+ib.InputText+";",
                                       "",
                                       };
                    foreach (string line in content)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }
        /// <summary>
        /// 创建所有类型的文件（类型后缀自定义）
        /// </summary>
        private void NewAllTypeFile()
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入新文件名（含后缀）");
            if (ib.InputText != null)
            {
                try
                {
                    File.Create(preListDir + "\\" + ib.InputText);
                    UpdateListView(preListDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件已存在或权限不足！！");
                }
            }
        }
        /// <summary>
        /// 用记事本方式打开选中的文件
        /// </summary>
        private void OpenSelectByNotepad()
        {
            if (this.listViewDesktop.SelectedItems.Count > 0)
            {
                string name = this.listViewDesktop.SelectedItems[0].Tag.ToString().Trim();
                if (File.Exists(name))
                    Process.Start("notepad", name);
            }

        }
        /// <summary>
        /// 在单签路径打开CMD
        /// </summary>
        private void OpenCmdOnPresentDirectory()
        {
            Process.Start("cmd", "/k cd " + preListDir + " && " + preListDir.Substring(0, 2) + " && color f1");
        }
        /// <summary>
        /// 在当前路径打开Powershell
        /// </summary>
        private void OpenPowershellOnPresentDirectory()
        {
            Process.Start("cmd", "/c cd " + preListDir + " && " + preListDir.Substring(0, 2) + " && start powershell");
        }
        /// <summary>
        /// 复制当前显示路径到剪切板
        /// </summary>
        private void CopyPrensentDirectoryFullNameToClipBord()
        {
            Clipboard.SetText(preListDir);
        }
        /// <summary>
        /// 选中的内容复制路径到缓冲
        /// </summary>
        private void CutSelectedPaths()
        {
            SelectBuffer.Clear();
            stateBuffer =BufferState.CUT_BUFFER;
            if (this.listViewDesktop.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.listViewDesktop.SelectedItems)
                {
                    string path = item.Tag.ToString().Trim();
                    SelectBuffer.Add(path);
                }
            }
        }
        /// <summary>
        /// 选中的内容剪切路径到缓冲
        /// </summary>
        private void CopySelectedPaths()
        {
            SelectBuffer.Clear();
            stateBuffer =BufferState.COPY_BUFFER;
            if (this.listViewDesktop.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.listViewDesktop.SelectedItems)
                {
                    string path = item.Tag.ToString().Trim();
                    SelectBuffer.Add(path);
                }
            }
        }
        /// <summary>
        /// 粘贴复制或者剪切的内容
        /// </summary>
        private void PasteSelectedPaths()
        {
            if (stateBuffer == BufferState.COPY_BUFFER)
            {
                foreach (string name in SelectBuffer)
                {
                    FileInfo fi = new FileInfo(name);
                    string drtname = preListDir + "\\" + fi.Name;
                    if (File.Exists(name))
                    {
                        if (!File.Exists(drtname))
                            File.Copy(name, drtname);
                    }
                    else if (Directory.Exists(name))
                    {
                        CopyDirectory(name, drtname);
                    }
                }
                UpdateListView(preListDir);
            }
            else if (stateBuffer == BufferState.CUT_BUFFER)
            {
                foreach (string name in SelectBuffer)
                {
                    FileInfo fi = new FileInfo(name);
                    string drtname = preListDir + "\\" + fi.Name;
                    if (File.Exists(name))
                    {
                        if (!File.Exists(drtname))
                            File.Move(name, drtname);
                    }
                    else if (Directory.Exists(name))
                    {
                        if (!Directory.Exists(drtname))
                            Directory.Move(name, drtname);
                    }
                }
                UpdateListView(preListDir);
                SelectBuffer.Clear();
                stateBuffer = BufferState.NULL_BUFFER;
            }
        }
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="srcpath">源文件夹路径</param>
        /// <param name="drtpath">目标文件夹路径</param>
        private void CopyDirectory(string srcpath, string drtpath)
        {
            Directory.CreateDirectory(drtpath);
            string[] names = Directory.GetFiles(srcpath);
            foreach (string str in names)
            {
                if (!File.Exists(drtpath + "\\" + new FileInfo(str).Name))
                    File.Copy(str, drtpath + "\\" + new FileInfo(str).Name);
            }
            string[] dirs = Directory.GetDirectories(srcpath);
            foreach (string str in dirs)
            {
                CopyDirectory(str, drtpath + "\\" + new FileInfo(str).Name);
            }
        }
        /// <summary>
        /// 在系统的文件浏览器中查看当前文件夹
        /// </summary>
        private void OpenPresentDirectoryInSysExplorer()
        {
            Process.Start("Explorer", preListDir);
        }
        /// <summary>
        /// 重命名选中的文件（可以多个）
        /// </summary>
        private void RenameSelectPaths()
        {
            if (this.listViewDesktop.SelectedItems.Count > 0)
            {
                if (this.listViewDesktop.SelectedItems.Count == 1)
                {
                    string name = this.listViewDesktop.SelectedItems[0].Tag.ToString().Trim();
                    InputBox ib = new InputBox();
                    ib.ShowBox(this, "请输入新文件（夹）名（包含后缀）：", new FileInfo(name).Name);
                    if (ib.InputText != null)
                    {
                        if (File.Exists(name))
                        {
                            File.Move(name, preListDir + "\\" + ib.InputText.Trim());
                        }
                        else
                        {
                            Directory.Move(name, preListDir + "\\" + ib.InputText.Trim());
                        }
                    }
                }
                else
                {
                    InputBox ib = new InputBox();
                    ib.ShowBox(this, "请输入新文件(夹)名(不会修改后缀)：");
                    if (ib.InputText != null)
                    {
                        int i = 0;
                        foreach (ListViewItem item in this.listViewDesktop.SelectedItems)
                        {
                            string name = item.Tag.ToString().Trim();
                            string newname = preListDir + "\\" + ib.InputText;
                            string exname = new FileInfo(name).Extension;
                            if (File.Exists(newname + exname) || Directory.Exists(newname + exname))
                            {
                                newname += i + "";
                            }
                            newname += exname;
                            if (File.Exists(name))
                            {
                                File.Move(name, newname);
                            }
                            else if (Directory.Exists(name))
                            {
                                Directory.Move(name, newname);
                            }
                            i++;
                        }
                    }
                }
                UpdateListView(preListDir);
            }
        }
        /// <summary>
        /// 窗口快捷键的实现
        /// </summary>
        /// <param name="e">窗口发生keydown事的参数</param>
        private void HotKeyDownInListView(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.C:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        CopySelectedPaths();
                    break;
                case Keys.X:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        CutSelectedPaths();
                    break;
                case Keys.V:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        PasteSelectedPaths();
                    break;
                case Keys.Delete:
                    DeleteSelectedFiles();
                    break;
                case Keys.Enter:
                    if ((Control.ModifierKeys & Keys.Shift) != 0)
                        OpenRunProcessFile();
                    break;
                case Keys.F5:
                    UpdateListView(preListDir);
                    break;
                case Keys.D:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        NewFolder();
                    break;
                case Keys.F:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        NewAllTypeFile();
                    break;
                case Keys.P:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        HalfTransparentAllWnd();
                    break;
                case Keys.A:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        CheackedAllItem();
                    break;
                case Keys.H:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        HideAllChildWnd();
                    break;
                case Keys.M:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        FullScreenFoo();
                    break;
                case Keys.L:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        LockFooJoinAllChildWnd();
                    break;
                case Keys.S:
                    if ((Control.ModifierKeys & Keys.Shift) != 0)
                        ShowAllChildWnd();
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        BrowserSearch();
                    break;
                case Keys.T:
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                        GoogleTeanslate();
                    break;
            }
        }
        /// <summary>
        /// 全选操作
        /// </summary>
        private void CheackedAllItem()
        {
            foreach (ListViewItem item in this.listViewDesktop.Items)
            {
                item.Selected = true;
            }
        }
        /// <summary>
        /// 显示所有子窗口
        /// </summary>
        private void ShowAllChildWnd()
        {
            fsfolder.Show();
            fsfile.Show();
            fsexec.Show();
        }
        /// <summary>
        /// 获取文件夹的大小
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <returns></returns>
        private long GetDirectorySize(DirectoryInfo path)
        {
            long size = 0;
            try
            {
                FileInfo[] fis = path.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                DirectoryInfo[] dis = path.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += GetDirectorySize(di);
                }
            }
            catch (Exception)
            {

            }

            return size;
        }
        /// <summary>
        /// 计算选中项目的总大小
        /// </summary>
        /// <returns></returns>
        private long GetSelectedPathsSize()
        {
            if (this.listViewDesktop.SelectedItems.Count > 0)
            {
                long size = 0;
                foreach (ListViewItem item in this.listViewDesktop.SelectedItems)
                {
                    string path = item.Tag.ToString().Trim();
                    if (File.Exists(path))
                    {
                        size += new FileInfo(path).Length;
                    }
                    else if (Directory.Exists(path))
                    {
                        DirectoryInfo di = new DirectoryInfo(path);
                        size += GetDirectorySize(di);
                    }
                }
                return size;
            }
            return 0;
        }
        /// <summary>
        /// 停靠子窗口
        /// </summary>
        private void JoinAllChildWnd()
        {
            if (this.Size.Width > SystemInformation.WorkingArea.Width / 3)
            {
                fsfolder.Size = new Size(this.Size.Width / 2, this.Height / 2);
                fsfile.Size = new Size(this.Size.Width / 2, this.Height / 2);
                fsexec.Size = new Size(this.Size.Width / 2, this.Size.Height);
            }
            else
            {
                fsfolder.Size = new Size(this.Size.Width, this.Height / 2);
                fsfile.Size = new Size(this.Size.Width, this.Height / 2);
                fsexec.Size = new Size(this.Size.Width, this.Size.Height);
            }
            fsfolder.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            fsfile.Location = new Point(this.Location.X + this.Width, this.Location.Y + this.Height / 2);
            fsexec.Location = new Point(this.Location.X + this.Width + fsfolder.Width, this.Location.Y);
            fsfolder.Activate();
            fsfile.Activate();
            fsexec.Activate();
        }
        /// <summary>
        /// 主窗口显示半屏幕（纵向分割）
        /// </summary>
        private void HalfScreenMainWnd()
        {
            int scWid = SystemInformation.WorkingArea.Width;
            int scHei = SystemInformation.WorkingArea.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(scWid / 3, scHei);
        }
        /// <summary>
        /// 全屏停靠
        /// </summary>
        private void FullScreenFoo()
        {
            fsfolder.Show();
            fsfile.Show();
            fsexec.Show();
            HalfScreenMainWnd();
            JoinAllChildWnd();
        }
        /// <summary>
        /// 锁定停靠
        /// </summary>
        private void LockFooJoinAllChildWnd()
        {
            isFreeFooMode = false;
            if (!isFreeFooMode)
            {
                JoinAllChildWnd();
            }
        }
        /// <summary>
        /// 视窗更新为输入的路径
        /// </summary>
        private void JumpToInputPath()
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
        /// <summary>
        /// 用百度进行搜索
        /// </summary>
        private void BrowserSearch()
        {
            InputBox ib = new InputBox();
            ib.ShowBox(this, "请输入要搜索的内容");
            if (ib.InputText != null)
            {
                string str = ib.InputText.Trim();
                Process.Start("http://www.baidu.com/s?wd=" + str);
            }
        }
        /// <summary>
        /// 用谷歌进行翻译
        /// </summary>
        private void GoogleTeanslate()
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
        /// <summary>
        /// 复制当前选中的所有项目的路径到剪切板
        /// </summary>
        private void CopySelectPathsFullNameToClipbord()
        {
            if (this.listViewDesktop.SelectedItems.Count > 0)
            {
                string ret = "";
                foreach (ListViewItem item in this.listViewDesktop.SelectedItems)
                {
                    ret += item.Text + "\n";
                }
                Clipboard.SetText(ret);
            }
        }
        /// <summary>
        /// 所有窗口半透明
        /// </summary>
        private void HalfTransparentAllWnd()
        {
            if (this.Opacity > 0.8)
            {
                this.Opacity = 0.628;
                fsfolder.Opacity = 0.628;
                fsfile.Opacity = 0.628;
                fsexec.Opacity = 0.628;
            }
            else
            {
                this.Opacity = 1;
                fsfolder.Opacity = 1;
                fsfile.Opacity = 1;
                fsexec.Opacity = 1;
            }
        }
        /// <summary>
        /// 通过listview的editlabel方式重命名
        /// </summary>
        /// <param name="e">editlabel发生事的参数</param>
        private void RenameByListViewLable(LabelEditEventArgs e)
        {
            if (e.Label == null)
                return;
            string name = this.listViewDesktop.Items[e.Item].Tag.ToString();
            string newname = preListDir + "\\" + e.Label;
            if (name == newname)
                return;
            if (File.Exists(name))
            {
                File.Move(name, newname);
            }
            else if (Directory.Exists(name))
            {
                Directory.Move(name, newname);
            }
        }
        /// <summary>
        /// 隐藏所有子窗体
        /// </summary>
        private void HideAllChildWnd()
        {
            this.fsexec.Hide();
            this.fsfile.Hide();
            this.fsfolder.Hide();
        }
        /// <summary>
        /// 文件拖动响应核心--执行移动操作
        /// </summary>
        /// <param name="arrs">拖入的文件路径数组</param>
        private void DropFilesIn(Array arrs)
        {
            if (arrs.Length == 0)
                return;
            if (MessageBox.Show("将会移动" + arrs.Length + "个文件（夹）到当前路径，确认操作吗？", "移动确认提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < arrs.Length; i++)
                {
                    string name = arrs.GetValue(i).ToString();
                    string newname = preListDir + "\\" + new FileInfo(name).Name;
                    if (Directory.Exists(name))
                    {
                        Directory.Move(name, newname);
                    }
                    if (File.Exists(name))
                    {
                        if (!File.Exists(newname))
                        {
                            File.Move(name, newname);
                        }
                    }
                }
                UpdateListView(preListDir);
            }
        }
    }
}
