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
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;

using Microsoft.VisualBasic;
using Microsoft.Win32;


namespace 文件分析仪
{
    public partial class SimiliarAnaliesForm : Form
    {
        public SimiliarAnaliesForm()
        {
            InitializeComponent();
        }

        private void SimiliarAnaliesForm_Load(object sender, EventArgs e)
        {
            this.AnaliseFileNameToolStripMenuItem.Checked = true;
        }

        public  DirectoryInfo g_ana_dir;

        public void analiesDir(DirectoryInfo dir)
        {
            g_ana_dir = dir;
            this.Show();
            setTipsContent("就绪");
            setTipsContent("加载子目录列表中...");
            this.showCurrentDirInfo();
            setTipsContent("子目录已加载完毕.");
        }

        class ComboxItem
        {
            public DirectoryInfo dir;
            public string text;
            public ComboxItem(DirectoryInfo dir)
            {
                this.dir=dir;
                this.text=dir.Name;
            }
            public ComboxItem(DirectoryInfo dir,string text){
                this.dir=dir;
                this.text=text;
            }

            public override string ToString(){
                return this.text;
            }
        }

        public enum AnaliesType
        {
            FileName,
            FileNameOnly,
            Size,
            FileNameAndSize,
            FileNameOnlyAndSize,
            ModifyTime,
            CreateTime,
        }

        private AnaliesType g_ana_type = AnaliesType.FileName;

        private void showCurrentDirInfo()
        {
            this.toolStripTextBoxCurrentDir.Text = g_ana_dir.FullName;
            this.toolStripComboBoxTreePathRouter.Items.Clear();

            this.toolStripComboBoxTreePathRouter.Items.Add(new ComboxItem(g_ana_dir,"."));
            DirectoryInfo parent = g_ana_dir.Parent;
            if (parent != null)
            {
                this.toolStripComboBoxTreePathRouter.Items.Add(new ComboxItem(g_ana_dir.Parent, ".."));
            }
            
            try
            {

                DirectoryInfo[] dirs = g_ana_dir.GetDirectories();
                List<DirectoryInfo> dirList = new List<DirectoryInfo>();
                foreach (DirectoryInfo pdir in dirs)
                {
                    dirList.Add(pdir);
                }
                dirList.Sort(new DirectoryInfoNameComparater());
                foreach (DirectoryInfo pdir in dirList)
                {
                    this.toolStripComboBoxTreePathRouter.Items.Add(new ComboxItem(pdir, pdir.Name));
                }
            }
            catch (Exception)
            {
                
            }
            this.toolStripComboBoxTreePathRouter.SelectedIndex = 0;

        }
        private void toolStripComboBoxTreePathRouter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboxItem item = this.toolStripComboBoxTreePathRouter.SelectedItem as ComboxItem;
            if (item.dir.FullName == g_ana_dir.FullName)
            {
                return;
            }
            g_ana_dir = item.dir;
            showCurrentDirInfo();
        }

        private void toolStripMenuItemEntryDir_Click(object sender, EventArgs e)
        {
            string path = this.toolStripTextBoxCurrentDir.Text;
            DirectoryInfo pdir = new DirectoryInfo(path);
            if (!pdir.Exists)
            {
                FileInfo pfile = new FileInfo(path);
                pdir = pfile.Directory;
            }
            if (pdir == null)
            {
                return;
            }
            g_ana_dir = pdir;
            showCurrentDirInfo();
        }

        class DirectoryInfoNameComparater : IComparer<DirectoryInfo>
        {
            public int Compare(DirectoryInfo x,DirectoryInfo y){
                return x.Name.ToLower().CompareTo(y.Name.ToLower());
            }
        }

        private List<FileInfo> sumFiles = new List<FileInfo>(1024);
        private List<FileListItem> similiarFiles = new List<FileListItem>(1024);
        private void loadSumFiles() 
        {
            if (sumFiles == null)
            {
                sumFiles = new List<FileInfo>(1024);
            }
            else
            {
                sumFiles.Clear();
            }
            bool isRegex = true;
            string regex = this.toolStripTextBoxRegexFileNameFilter.Text;
            if (regex == null || regex.Length == 0)
            {
                isRegex = false;
            }
            bool ignoreCase = this.RegexIgnoreCaseToolStripMenuItem.Checked;
            bool includeExtension = this.RegexIncludeExtensionToolStripMenuItem.Checked;
            getAllFilesInDir(g_ana_dir, sumFiles,isRegex,regex,ignoreCase,includeExtension);
        }

        private void analiseDriven()
        {
            if (sumFiles.Count == 0)
            {
                MessageBox.Show(this, "文件加载列表为空，请先加载文件！", "错误");
                return;
            }
            getSimiliarFiles();
        }

        public class FileListItem
        {
            public int groupId;
            public FileInfo file;
            public int checkSum = -1;
            public FileListItem(int groupId, FileInfo file)
            {
                this.groupId = groupId;
                this.file = file;
            }
            public FileListItem(int groupId, FileInfo file,int checkSum)
            {
                this.groupId = groupId;
                this.file = file;
                this.checkSum = checkSum;
            }
        }
        private void showSimiliarFiles2View()
        {
            this.listViewShowList.Items.Clear();
            int count = similiarFiles.Count;
            foreach (FileListItem finfo in similiarFiles)
            {
                ListViewItem item = new ListViewItem();
                if (finfo.file.Extension == null || finfo.file.Extension == "")
                {
                    item.ImageKey = "unkown";
                }
                else
                {
                    if (this.imageListFiles.Images.Keys.Contains(finfo.file.Extension) == false)
                    {
                        Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(finfo.file.FullName);
                        this.imageListFiles.Images.Add(finfo.file.Extension, icon);
                    }
                    item.ImageKey = finfo.file.Extension;
                }
                item.Text = finfo.groupId+"";
                item.Tag = finfo;
                item.ImageKey = finfo.file.Extension;
                item.SubItems.Add(finfo.file.Name);

                item.SubItems.Add(FormMain.fileSizeToString(finfo.file.Length));
                if (finfo.checkSum == -1 && this.CalcCheckSumToolStripMenuItem.Checked)
                {
                    int ckSum = FormMain.getFileCheckSumCode(finfo.file);
                    if (ckSum < 0)
                    {
                        ckSum = 0 - ckSum;
                    }

                    finfo.checkSum = ckSum%count;
                }
                item.SubItems.Add("" + finfo.checkSum);
                item.SubItems.Add(finfo.file.LastAccessTime.ToString());
                item.SubItems.Add(finfo.file.CreationTime.ToString());
                item.SubItems.Add("."+finfo.file.FullName.Substring(g_ana_dir.FullName.Length));
                this.listViewShowList.Items.Add(item);
            }
        }

        private void LoadFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setTipsContent("正在加载文件列表...");
            loadSumFiles();
            setTipsContent(sumFiles.Count + "个文件已加载完毕.");
        }

        private void StartAnaliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sumFiles.Count == 0)
            {
                setTipsContent("正在加载文件列表...");
                loadSumFiles();
                setTipsContent(sumFiles.Count+"个文件已加载完毕.");
            }
            setTipsContent("正在进行文件分析...");
            analiseDriven();
            setTipsContent("正在显示结果...");
            showSimiliarFiles2View();
            setTipsContent(similiarFiles.Count+"个文件分析已完成.");
        }

        private void doSortListByAnaliesType(List<FileInfo> sortList, AnaliesType analiesType)
        {
            if (analiesType == AnaliesType.FileName)
            {
                sortList.Sort(new FileInfoNameComparator());
            }
            else if (analiesType == AnaliesType.Size)
            {
                sortList.Sort(new FileInfoSizeComparator());
            }
            else if (analiesType == AnaliesType.ModifyTime)
            {
                sortList.Sort(new FileInfoLastWriteTimeComparator());
            }
            else if (analiesType == AnaliesType.CreateTime)
            {
                sortList.Sort(new FileInfoCreateTimeComparator());
            }
            else if (analiesType == AnaliesType.FileNameOnly)
            {
                sortList.Sort(new FileInfoNameOnlyComparator());
            }
            else if (analiesType == AnaliesType.FileNameAndSize)
            {
                sortList.Sort(new FileInfoNameAndSizeComparator());
            }
            else if (analiesType == AnaliesType.FileNameOnlyAndSize)
            {
                sortList.Sort(new FileInfoNameOnlyAndSizeComparator());
            }
        }

        private bool isSimiliarFileByAnaliesType(FileInfo one, FileInfo two, AnaliesType analiesType)
        {
            if (analiesType == AnaliesType.FileName)
            {
                return one.Name.CompareTo(two.Name) == 0;
            }
            else if (analiesType == AnaliesType.Size)
            {
                return one.Length.CompareTo(two.Length) == 0;
            }
            else if (analiesType == AnaliesType.ModifyTime)
            {
                return one.LastWriteTimeUtc.CompareTo(two.LastWriteTimeUtc) == 0;
            }
            else if (analiesType == AnaliesType.CreateTime)
            {
                return one.CreationTimeUtc.CompareTo(two.CreationTimeUtc) == 0;
            }
            else if (analiesType == AnaliesType.FileNameOnly)
            {
                string oneName = one.Name.Substring(0, one.Name.Length - one.Extension.Length);
                string twoName = two.Name.Substring(0, two.Name.Length - two.Extension.Length);
                return oneName.CompareTo(twoName) == 0;
            }
            else if (analiesType == AnaliesType.FileNameAndSize)
            {
                bool rs = one.Name.CompareTo(two.Name) == 0;
                if (rs)
                {
                    return one.Length.CompareTo(two.Length) == 0;
                }
                return rs;
            }
            else if (analiesType == AnaliesType.FileNameOnlyAndSize)
            {
                string oneName = one.Name.Substring(0, one.Name.Length - one.Extension.Length);
                string twoName = two.Name.Substring(0, two.Name.Length - two.Extension.Length);
                bool rs = oneName.CompareTo(twoName) == 0;
                if (rs)
                {
                    return one.Length.CompareTo(two.Length) == 0;
                }
                return rs;
            }
            
            return false;
        }
        private void getSimiliarFiles()
        {
            if (similiarFiles == null)
            {
                similiarFiles = new List<FileListItem>(1024);
            }
            else
            {
                similiarFiles.Clear();
            }
            

            List<FileInfo> sortList = new List<FileInfo>();
            foreach (FileInfo pfile in sumFiles)
            {
                sortList.Add(pfile);

            }

            doSortListByAnaliesType(sortList, g_ana_type);

            
            int len = 0, i = 0;

            len = sortList.Count;
            i = 0;
            int groupId = 1;
            while (i < len)
            {
                int j = i + 1;
                while (j < len)
                {
                    bool isTarget=isSimiliarFileByAnaliesType(sortList[j], sortList[i], g_ana_type);
                    if (isTarget)
                    {
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (j != i + 1)
                {
                    for (int k = i; k < j; k++)
                    {
                        similiarFiles.Add(new FileListItem(groupId,sortList[k]));
                    }
                    groupId++;
                    i = j;
                }
                else
                {
                    i++;
                }
            }


        }


        private void getAllFilesInDir(DirectoryInfo dir, List<FileInfo> list,bool isRegexFilter,string regex,bool ignoreCase,bool includeExtension)
        {
            if (!dir.Exists)
            {
                return;
            }
            RegexOptions option = RegexOptions.None;
            if (ignoreCase)
            {
                option = RegexOptions.IgnoreCase;
            }
            try
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo pfile in files)
                {
                    if (isRegexFilter)
                    {
                        string fname=pfile.Name;
                        if(!includeExtension){
                            fname=pfile.Name.Substring(0,pfile.Name.Length-pfile.Extension.Length);
                        }
                        if (Regex.IsMatch(fname, regex, option))
                        {
                            list.Add(pfile);
                        }
                    }
                    else
                    {
                        list.Add(pfile);
                    }
                }
            }
            catch (Exception)
            {

            }

            try
            {

                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo pdir in dirs)
                {
                    getAllFilesInDir(pdir, list,isRegexFilter,regex,ignoreCase,includeExtension);
                }
            }
            catch (Exception)
            {

            }
        }

        private void CheckAnaliesTypeMenuItemProxy(ToolStripMenuItem ckItem)
        {
            List<ToolStripMenuItem> analiesItems = new List<ToolStripMenuItem>();
            analiesItems.Add(this.AnaliesCreateTimeToolStripMenuItem);
            analiesItems.Add(this.AnaliesFileNameAndSizeToolStripMenuItem);
            analiesItems.Add(this.AnaliesOnlyFileNameAndSizeToolStripMenuItem);
            analiesItems.Add(this.AnaliesOnlyFileNameToolStripMenuItem);
            analiesItems.Add(this.AnaliseFileNameToolStripMenuItem);
            analiesItems.Add(this.AnaliseSizeToolStripMenuItem);
            analiesItems.Add(this.AnaliseModifyTimeToolStripMenuItem);
            foreach (ToolStripMenuItem item in analiesItems)
            {
                if (item == ckItem)
                {
                    ckItem.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }
        private void AnaliesFileNameAndSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g_ana_type = AnaliesType.FileNameAndSize;
            CheckAnaliesTypeMenuItemProxy(this.AnaliesFileNameAndSizeToolStripMenuItem);
        }

        private void AnaliseSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g_ana_type = AnaliesType.Size;
            CheckAnaliesTypeMenuItemProxy(this.AnaliseSizeToolStripMenuItem);
        }

        private void AnaliseFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g_ana_type = AnaliesType.FileName;
            CheckAnaliesTypeMenuItemProxy(this.AnaliseFileNameToolStripMenuItem);
        }

        private void AnaliseModifyTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g_ana_type = AnaliesType.ModifyTime;
            CheckAnaliesTypeMenuItemProxy(this.AnaliseModifyTimeToolStripMenuItem);
        }

        private void AnaliesCreateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g_ana_type = AnaliesType.CreateTime;
            CheckAnaliesTypeMenuItemProxy(this.AnaliesCreateTimeToolStripMenuItem);
        }

        private void AnaliesOnlyFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g_ana_type = AnaliesType.FileNameOnly;
            CheckAnaliesTypeMenuItemProxy(this.AnaliesOnlyFileNameToolStripMenuItem);
        }

        private void AnaliesOnlyFileNameAndSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g_ana_type = AnaliesType.FileNameOnlyAndSize;
            CheckAnaliesTypeMenuItemProxy(this.AnaliesOnlyFileNameAndSizeToolStripMenuItem);
        }


        private void CalcCheckSumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CalcCheckSumToolStripMenuItem.Checked = !this.CalcCheckSumToolStripMenuItem.Checked;
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem it in this.listViewShowList.SelectedItems)
                {
                    FileListItem item = it.Tag as FileListItem;
                    if (item.file.Exists)
                    {
                        Process.Start(item.file.FullName);
                    }
                    
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void OpenStrategySelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewShowList.SelectedItems.Count == 0)
            {
                return;
            }

            int shCount = 0;
            foreach (ListViewItem it in this.listViewShowList.SelectedItems)
            {
                FileListItem item = it.Tag as FileListItem;
                if (item.file.Exists)
                {
                    shCount++;
                    ProcessStartInfo sinfo = new ProcessStartInfo();
                    sinfo.FileName = "rundll32.exe";
                    sinfo.Arguments = "shell32,OpenAs_RunDLL " + item.file.FullName;
                    sinfo.WorkingDirectory = item.file.DirectoryName;
                    Process.Start(sinfo);
                }

            }
            setTipsContent("共" + shCount + "个文件已打开.");
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewShowList.SelectedItems.Count == 0)
            {
                return;
            }

            int shCount = 0;
            foreach (ListViewItem it in this.listViewShowList.SelectedItems)
            {
                FileListItem item = it.Tag as FileListItem;
                if (item.file.Exists)
                {
                    shCount++;
                    ProcessStartInfo sinfo = new ProcessStartInfo();
                    sinfo.FileName = "explorer.exe";
                    sinfo.Arguments = item.file.Directory.FullName;
                    Process.Start(sinfo);
                }

            }
            setTipsContent("共" + shCount + "个窗口打开.");
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewShowList.SelectedItems.Count == 0)
            {
                return;
            }
            int shSucCount = 0, shCount = 0, shFailCount = 0;
            foreach (ListViewItem it in this.listViewShowList.SelectedItems)
            {
                FileListItem item = it.Tag as FileListItem;
                if (item.file.Exists)
                {
                    shCount++;
                    try
                    {
                        item.file.Delete();
                        shSucCount++;
                    }
                    catch (Exception)
                    {
                        shFailCount++;
                    }
                }

            }
            setTipsContent("共" + shCount + "个文件，" + shSucCount + "个已删除，" + shFailCount + "删除失败！");
        }

        private void CopyPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewShowList.SelectedItems.Count == 0)
            {
                return;
            }
            String data = "";
            bool isFirst = true;
            int shCount = 0;
            foreach (ListViewItem it in this.listViewShowList.SelectedItems)
            {
                FileListItem item = it.Tag as FileListItem;
                if (!isFirst)
                {
                    data = data + "\n";
                }
                shCount++;
                data = data + item.file.FullName;

                isFirst = false;
            }
            Clipboard.SetDataObject(data);
            setTipsContent("共" + shCount + "个文件路径已复制.");
        }

        private void setTipsContent(string content)
        {
            this.toolStripTextBoxTipsInfo.Text = content;
        }

        private void SelectGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewShowList.SelectedItems.Count == 0)
            {
                return;
            }
            List<int> groupIds = new List<int>(1024);
            foreach (ListViewItem it in this.listViewShowList.SelectedItems)
            {
                FileListItem item = it.Tag as FileListItem;
                int groupId = item.groupId;
                bool isInGroup = false;
                foreach (int pg in groupIds)
                {
                    if (pg == groupId)
                    {
                        isInGroup = true;
                        break;
                    }
                }
                if (isInGroup == false)
                {
                    groupIds.Add(item.groupId);
                }
            }
            int shSelectCount = 0;
            foreach (ListViewItem item in this.listViewShowList.Items)
            {
                FileListItem tag = item.Tag as FileListItem;
                bool isInGroup = false;
                foreach (int gpid in groupIds)
                {
                    if (gpid == tag.groupId)
                    {
                        isInGroup = true;
                        break;
                    }
                }
                if (isInGroup)
                {
                    shSelectCount++;
                    item.Selected = true;
                }
            }
            setTipsContent("共" + groupIds.Count + "组" + shSelectCount + "个文件已选中！");

        }

        private void RegexIgnoreCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RegexIgnoreCaseToolStripMenuItem.Checked = !this.RegexIgnoreCaseToolStripMenuItem.Checked;
        }

        private void RegexIncludeExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RegexIncludeExtensionToolStripMenuItem.Checked = !this.RegexIncludeExtensionToolStripMenuItem.Checked;
        }

        private void RegexClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripTextBoxRegexFileNameFilter.Text = "";
        }

        
    }


    public class FileInfoSizeComparator : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return (int)(y.Length - x.Length);
        }
    }

    public class FileInfoNameComparator : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Name.ToLower().CompareTo(x.Name.ToLower());
        }
    }

    public class FileInfoCreateTimeComparator : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.CreationTimeUtc.CompareTo(x.CreationTimeUtc);
        }
    }

    public class FileInfoLastWriteTimeComparator : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.LastWriteTimeUtc.CompareTo(x.LastWriteTimeUtc);
        }
    }

    public class FileInfoNameOnlyComparator : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            string xName = x.Name.Substring(0, x.Name.Length - x.Extension.Length);
            string yName = y.Name.Substring(0, y.Name.Length - y.Extension.Length);
            return yName.CompareTo(xName);
        }
    }

    public class FileInfoNameAndSizeComparator : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            int rs = x.Name.CompareTo(y.Name);
            if (rs == 0)
            {
                return (int)(y.Length - x.Length);
            }
            return rs;
        }
    }

    public class FileInfoNameOnlyAndSizeComparator : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            string xName = x.Name.Substring(0, x.Name.Length - x.Extension.Length);
            string yName = y.Name.Substring(0, y.Name.Length - y.Extension.Length);
            int rs= yName.CompareTo(xName);
            if (rs == 0)
            {
                return (int)(y.Length - x.Length);
            }
            return rs;
        }
    }
}
