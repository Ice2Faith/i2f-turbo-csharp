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
using System.Text.RegularExpressions;
using System.Threading;

using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace 文件分析仪
{
    
    public partial class FormMain : Form
    {
        public class FileSpecies
        {
            public static string[] pictures = { ".jpg",
                                ".jpeg",
                                ".png",
                                ".gif",
                                ".tif",
                                ".bmp",
                                ".ico",
                                ".raw",
                                ".exif",
                                ".webp",
                                ".wmf",
                                ".svg",
                                ".psd"};
            public static string[] videos = { ".mp4",
                              ".mkv",
                              ".rmvb",
                              ".flv",
                              ".avi",
                              ".mov",
                              ".wmv",
                              ".m3u8",
                              ".3gp",
                              ".yuv"};
            public static string[] audios ={".mp3",
                            ".ogg",
                            ".wav",
                            ".aac",
                            ".pcm",
                            ".flac",
                            ".wma",
                            ".vqf",
                            ".amr",
                            ".ape"};
            public static string[] documents = { ".txt",
                                 ".log",
                                 ".doc",
                                 ".docx",
                                 ".xls",
                                 ".xlsx",
                                 ".ppt",
                                 ".pptx",
                                 ".pdf",
                                 ".html",
                                 ".htm",
                                 ".xml",
                                 ".json",
                                 ".php",
                                 ".asp",
                                 ".config",
                                 ".c",
                                 ".h",
                                 ".cpp",
                                 ".hpp",
                                 ".asm",
                                 ".py",
                                 ".java",
                                 ".cs",
                                 ".ini",
                                 ".bat",
                                 ".sh",
                                 ".sql",
                                 ".css",
                                 ".js",
                                 ".go",
                                 ".jsp"};
            public static string[] execuables = { ".exe",
                                  ".msc",
                                  ".elf",
                                  ".apk",
                                  ".bat",
                                  ".vbs",
                                  ".msi",
                                  ".jar",
                                  ".py",
                                  ".sh",
                                  ".class"};
            public static string[] compresses = { ".zip",
                                  ".rar",
                                  ".gz",
                                  ".tar",
                                  ".7z",
                                  ".iso",
                                  ".apk",
                                  ".bin",
                                  ".zipx",
                                  ".tgz",
                                  ".xz",
                                  ".war",
                                  ".img",
                                  ".wim",
                                  ".udf"};
            public static string[] links = { ".lnk" };
            public static string[] libdlls = { ".lib",
                               ".dll",
                               ".sys",
                               ".so",
                               ".a",};
            public static string getFileSpecies(string fileName)
            {
                FileInfo file = new FileInfo(fileName);
                string suffix = file.Extension.ToLower();
                foreach (string psuf in pictures)
                {
                    if (psuf == suffix)
                    {
                        return "pictures";
                    }
                }
                foreach (string psuf in videos)
                {
                    if (psuf == suffix)
                    {
                        return "videos";
                    }
                }
                foreach (string psuf in audios)
                {
                    if (psuf == suffix)
                    {
                        return "audios";
                    }
                }
                foreach (string psuf in documents)
                {
                    if (psuf == suffix)
                    {
                        return "documents";
                    }
                }
                foreach (string psuf in execuables)
                {
                    if (psuf == suffix)
                    {
                        return "execuables";
                    }
                }
                foreach (string psuf in compresses)
                {
                    if (psuf == suffix)
                    {
                        return "compresses";
                    }
                }
                foreach (string psuf in links)
                {
                    if (psuf == suffix)
                    {
                        return "links";
                    }
                }
                foreach (string psuf in libdlls)
                {
                    if (psuf == suffix)
                    {
                        return "libdlls";
                    }
                }
                return "other";
            }
        }
       
        private void setOnCommondDisplayPage()
        {
            try
            {

                string[] cmdArgs = System.Environment.GetCommandLineArgs();

                if (cmdArgs.Length >= 2)
                {
                    DirectoryInfo indir = new DirectoryInfo(cmdArgs[1]);
                    if (indir.Exists)
                    {
                        showDirectory(indir.FullName);
                    }
                    else
                    {
                        FileInfo infile = new FileInfo(cmdArgs[1]);
                        if (infile.Exists)
                        {
                            indir = infile.Directory;
                            showDirectory(indir.FullName);
                        }
                    }

                }
            }
            catch (Exception)
            {

            }
        }
        private void convertFileEncodeTo(string path,Encoding encode)
        {
            try
            {
                //if(isTextFileType(path)==false)
                //{
                //    return;
                //}

                Encoding srcCode = getTextFileEncodingType(path);

                string content = File.ReadAllText(path, srcCode);
                File.WriteAllText(path, content, encode);
            }
            catch (Exception)
            {
                
            }
            
        }
        private bool isTextFileType(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Exists == false)
                return false;
            bool ret = true;
            try
            {

                FileStream fs = new FileStream(path, FileMode.Open);
                while (fs.Position < fs.Length)
                {
                    int b = fs.ReadByte();
                    if (b > 0 && b < 32) //判断是否包含空字符和控制字符，这些字符不应该出现在文本文件中
                    {
                        if (b != '\r' && b != '\n' && b != '\t' && b != '\v' && b != '\a' && b != '\b' && b != '\f')
                        {
                            ret = false;
                            break;
                        }
                    }
                }
                fs.Close();
            }
            catch (Exception)
            {
                
            }
            return ret;
        }
        private Encoding getTextFileEncodingType(string path)
        {
            Encoding gbk = Encoding.GetEncoding("GBK");
            Encoding iso8859 = Encoding.GetEncoding("ISO-8859-1");
            Encoding gb2312 = Encoding.GetEncoding("GB2312"); 
            Encoding[] allSupports = new Encoding[] {
                Encoding.UTF8,
                gbk,
                gb2312,
                iso8859,
                Encoding.ASCII,
                Encoding.Default,
                Encoding.Unicode,
                Encoding.UTF32,
                Encoding.BigEndianUnicode,
                Encoding.UTF7
            };

            byte[] buffer=new byte[1024*1024*2];//2M缓冲
            int sindex = 0;
            int rsplit = 0;
            int pcount = 0;
            FileStream fs = new FileStream(path, FileMode.Open);
            //读取几行有效数据，尝试进行编码，编码成功则表示是此编码类型
            while (fs.Position < fs.Length)
            {
                int b = fs.ReadByte();

                buffer[sindex] = (byte)b;
                sindex++;
                //由于所有编码都兼容ASCII，因此直接使用ASCII测试其中的文本分隔符即可
                if (b == '\r' || b == '\n' || b == '\t' || b==' ')
                {
                    rsplit++;
                    if (rsplit > 100 && pcount>0)
                    {
                        break;
                    }
                }
                else
                {
                    pcount++;
                }

            }
            
            fs.Close();

            for (int i = 0; i < allSupports.Length; i++)
            {
                Encoding code = allSupports[i];
                try
                {
                    string str=code.GetString(buffer, 0, sindex);
                    byte[] recBuf=code.GetBytes(str);
                    bool isCodeType = true;
                    for(int j=0;j<sindex && j<recBuf.Length;j++)
                    {
                        if(recBuf[j]!=buffer[j])
                        {
                            isCodeType = false;
                            break;
                        }
                    }
                    if(isCodeType)
                    {
                        return code;
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception)//编码类型不对
                {
                    continue;
                }
                
            }
            throw new Exception("unsupport encoding definition");
        }
        class FileItemInfo
        {
            public string path;
            public string name;
            public string extension;
            public bool isFile;
            public long size;
            public string type;
            public FileAttributes attribute;
            public DateTime createTime;
            public DateTime lastWriteTime;
            public DateTime lastAccessTime;
            public string checkCode;
            public FileItemInfo()
            {

            }

            public FileItemInfo(string path, bool useCache, Dictionary<string, FileItemInfo> fileInfoCache, bool needDir = false, bool needFileCode = false)
            {
                try
                {

                    this.path = path;
                    FileInfo fi = new FileInfo(path);
                    DirectoryInfo di = new DirectoryInfo(path);
                    this.name = fi.Name;
                    this.extension = fi.Extension;
                    this.isFile = fi.Exists;

                    if (this.isFile)
                    {
                        this.size = fi.Length;
                        this.type = fi.Extension + "文件";
                        this.attribute = fi.Attributes;
                        this.createTime = fi.CreationTimeUtc;
                        this.lastWriteTime = fi.LastWriteTimeUtc;
                        this.lastAccessTime = fi.LastAccessTimeUtc;
                        if (needFileCode)
                        {
                            ;
                            int pckcode = getFileCheckSumCode(fi);
                            // this.checkCode = String.Format("{0:X8}-{1:D3}",pckcode,(long)(pckcode&0xffffffff)%1000); 
                            this.checkCode = String.Format("{0:D3}-{1:X8}", (long)(pckcode & 0xffffffff) % 1000, pckcode);
                        }
                        else
                            this.checkCode = "-";
                    }
                    else
                    {
                        this.size = 0;
                        this.type = getFloderType(di, "文件夹");
                        this.attribute = FileAttributes.Directory;
                        this.createTime = di.CreationTimeUtc;
                        this.lastAccessTime = new DateTime(0);
                        this.lastWriteTime = new DateTime(0);
                        this.checkCode = "-";
                        if (needDir)
                        {
                            this.lastAccessTime = new DateTime(0);
                            this.lastWriteTime = new DateTime(0);
                            try
                            {
                                getDirectoryInfos(this.path,this,useCache,fileInfoCache);
                            }
                            catch (Exception)
                            {

                                //throw;
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            public static void getDirectoryInfos(string path, FileItemInfo result, bool useCache, Dictionary<string, FileItemInfo> fileInfoCache)
            {
                try
                {
                    FileItemInfo item = null;
                    if (useCache)
                    {
                        if (fileInfoCache != null)
                        {
                            if (fileInfoCache.ContainsKey(path))
                            {
                                item = fileInfoCache[path];

                            }
                        }
                    }

                    DirectoryInfo fdir = new DirectoryInfo(path);
                    if (fdir.Exists == false)
                        return;
                    if (item == null)
                    {
                        item = new FileItemInfo();
                        item.path = path;
                        item.lastAccessTime = new DateTime(0);
                        item.lastWriteTime = new DateTime(0);
                        foreach (FileInfo file in fdir.GetFiles())
                        {
                            item.size += file.Length;
                            if (file.LastAccessTimeUtc > item.lastAccessTime)
                                item.lastAccessTime = file.LastAccessTimeUtc;
                            if (file.LastWriteTimeUtc > item.lastWriteTime)
                                item.lastWriteTime = file.LastWriteTimeUtc;
                        }
                        foreach (DirectoryInfo dir in fdir.GetDirectories())
                        {
                            getDirectoryInfos(dir.FullName, item, useCache, fileInfoCache);
                        }
                        if (useCache)
                        {
                            if (fileInfoCache != null)
                            {
                                fileInfoCache.Remove(path);
                                fileInfoCache.Add(path, item);
                            }
                        }
                    }
                    
                    result.size += item.size;
                    if (item.lastAccessTime > result.lastAccessTime)
                        result.lastAccessTime = item.lastAccessTime;
                    if (item.lastWriteTime > result.lastWriteTime)
                        result.lastWriteTime = item.lastWriteTime;
                }
                catch (Exception)
                {
                    
                }
            }
            public override string ToString()
            {
                return this.path;
            }
        }

        private  const string PATH_COMPUTER = "Computer";
        private string m_currentPath = PATH_COMPUTER;
        public enum FilterType
        {
            All = 0,
            OnlyRegular=1,
            OnlyDirectory = 2,
            OnlyFile = 3,
            Picture = 4,
            Video = 5,
            Audio = 6,
            Document = 7,
            Execuable = 8,
            Compress=9,
            LinkFile=10,
            LibDll=11,
           
        }
        private FilterType m_filterType = FilterType.All;

        public enum SortType
        {
            None,
            Name,
            Type,
            Size,
            Attr,
            LModify,
            Create,
            LAccess,
            CheckCode,
        }
        private SortType m_sortType=SortType.None;
        private bool m_isSortRaise = true;

        public enum RegexSearchTargetType
        {
            FileName,
            FullPath,
            PathOnly,
            ExtensionOnly,
            FileNameOnly
        }
        private RegexSearchTargetType regexType = RegexSearchTargetType.FileNameOnly;

        private static string[] g_clipbordItems = null;
        public enum ClipType { None,Copy, Cut };
        private static ClipType g_clipType = ClipType.None;

        private bool m_isAnaliesDirectory = false;
        private bool m_isNeedFileCheckCode = false;
        private bool m_isAnaliesCache = false;
        private Dictionary<string, FileItemInfo> m_analiesFileInfoCache = new Dictionary<string, FileItemInfo>();

        private LinkedList<string> m_historyPathList = new LinkedList<string>();
        private LinkedListNode<string> m_currentHistoryNode = null;
        private void addHistoryPath(string path)
        {
            if(m_currentHistoryNode==null)
            {
                m_historyPathList.AddLast(path);
                m_currentHistoryNode = m_historyPathList.Last;
            }
            else
            {
                string previous = m_currentHistoryNode.Previous==null?"":m_currentHistoryNode.Previous.Value;
                string next = m_currentHistoryNode.Next == null ? "" : m_currentHistoryNode.Next.Value;
                if(path!=previous && path!=next)
                {
                    m_historyPathList.AddAfter(m_currentHistoryNode, path);
                    m_currentHistoryNode = m_currentHistoryNode.Next;
                }
            }
        }


        private string getNextHistoryPath(string defPath)
        {
            if(m_currentHistoryNode.Next==null)
            {
                addHistoryPath(defPath);
                return defPath;
            }
            m_currentHistoryNode = m_currentHistoryNode.Next;
            return m_currentHistoryNode.Value;
        }

        private string getPreviousHistoryPath(string defPath)
        {
            if (m_currentHistoryNode.Previous == null)
            {
                addHistoryPath(defPath);
                return defPath;
            }
            m_currentHistoryNode = m_currentHistoryNode.Previous;
            return m_currentHistoryNode.Value;
        }

        private void ToPreviousHistoryPath()
        {
            string path = getPreviousHistoryPath(m_currentPath);
            if (path == PATH_COMPUTER)
                showDirvers();
            else
                showDirectory(path);
        }
        private void ToPreviousHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToPreviousHistoryPath();
        }

        private void ToNextHistoryPath()
        {
            string path = getNextHistoryPath(m_currentPath);
            if (path == PATH_COMPUTER)
                showDirvers();
            else
                showDirectory(path);
        }

        private void ToNextHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToNextHistoryPath();
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1080, 720);
            showDirvers();
            this.textBoxCurrentPath.Text = m_currentPath;

            this.AnaliesFileOnlyToolStripMenuItem.Checked = true;
            this.SortTypeNoneToolStripMenuItem.Checked = true;
            this.JumpToDesktopToolStripMenuItem_Click(this, null);

            this.ShowFloderCheckStateToolStripMenuItem.Checked = true;

            this.StateTipstoolStripStatusLabel.Text = "就绪";

            setOnCommondDisplayPage();
        }

        private void listViewFiles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach(ListViewItem it in this.listViewFiles.SelectedItems)
                {
                    string selPath = it.Tag.ToString().Trim();
                    if (new DirectoryInfo(selPath).Exists)
                    {
                        showDirectory(selPath);
                    }
                    else
                    {
                        Process.Start(selPath);
                    }
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
           
        }

        /////////////////////////////////////////////////////////////////////////
        private void refreshCurrentDirectory()
        {
            if (!m_isAnaliesCache)
            {
                m_analiesFileInfoCache.Clear();
            }
            if (m_currentPath == PATH_COMPUTER)
                showDirvers();
            else
            {
                showDirectory(m_currentPath);
            }
        }
        private string[] getFilterExtendsArray(FilterType type)
        {
            
            string[] ret = null;
            if(type==FilterType.Picture)
            {
                ret = FileSpecies.pictures;
            }
            else if(type==FilterType.Video)
            {
                ret = FileSpecies.videos;
            }
            else if (type == FilterType.Audio)
            {
                ret = FileSpecies.audios;
            }
            else if (type == FilterType.Document)
            {
                ret = FileSpecies.documents;
            }
            else if (type == FilterType.Execuable)
            {
                ret = FileSpecies.execuables;
            }
            else if (type == FilterType.Compress)
            {
                ret = FileSpecies.compresses;
            }
            else if (type == FilterType.LinkFile)
            {
                ret = FileSpecies.links;
            }
            else if (type == FilterType.LibDll)
            {
                ret = FileSpecies.libdlls;
            }
            return ret;
        }
        private bool isPassedFilter(string path)
        {
            if(m_filterType==FilterType.All)
            {
                return true;
            }
            else if (m_filterType == FilterType.OnlyRegular)
            {
                FileInfo fsi = new FileInfo(path);
                DirectoryInfo dsi = new DirectoryInfo(path);
                if(fsi.Exists)
                {
                    if (((int)fsi.Attributes & (int)FileAttributes.Hidden )!=0 || ((int)fsi.Attributes & (int)FileAttributes.System) !=0)
                        return false;
                }
                else
                {
                    if (((int)dsi.Attributes & (int)FileAttributes.Hidden) != 0 || ((int)dsi.Attributes & (int)FileAttributes.System) != 0)
                        return false;
                }
                return true;

            }
            else if (m_filterType == FilterType.OnlyDirectory)
            {
                return new DirectoryInfo(path).Exists;
            }else if(m_filterType==FilterType.OnlyFile)
            {
                return new FileInfo(path).Exists;
            }else
            {
                string[] filter = getFilterExtendsArray(m_filterType);
                if (filter == null)
                    return true;


                bool ret = false;
                FileInfo pfile=new FileInfo(path);
                if (pfile.Exists == false)
                {
                    if (this.ShowFloderCheckStateToolStripMenuItem.Checked &&  new DirectoryInfo(path).Exists)
                        return true;
                    return false;
                }
                   
                string ptil=pfile.Extension.ToLower();
                foreach(string til in filter)
                {
                    if(til==ptil)
                    {
                        ret = true;
                        break;
                    }
                }
                return ret;
            }
            
        }
        private void updateCurrentPath(string path)
        {
            addHistoryPath(path);

            m_currentPath = path;
            this.textBoxCurrentPath.Text = m_currentPath;

        }
        private static string getFloderType(DirectoryInfo dir,string tips="文件夹")
        {
            FileSystemInfo[] flinfos = null;
            try
            {
                flinfos=dir.GetFileSystemInfos();
            }
            catch (Exception)
            {
                
                //throw;
            }
            int len = 0;
            if (flinfos != null)
                len=flinfos.Length;
            return tips+"[" +len+ "]";
        }

        public static int getFileCheckSumCode(FileInfo file)
        {
            int ret = 0;
            if (file.Exists == false)
                return 0;
            try
            {
                ret = (int)(file.Length*3/7);
                FileStream fs = file.OpenRead();
                if (fs == null || fs.CanRead == false)
                    return ret;

                int fac = 0x23571113;
                int temp = 0;
                while ((temp = fs.ReadByte())>=0)
                {

                    ret = (int)(ret * 7 + (temp * 31)) ^ fac;
                    fac = (int)(fac + 19);

                }
                fs.Close();
                return ret;
            }
            catch (Exception)
            {
                return ret;   
                //throw;
            }
            return ret;
        }
        private void showDirvers()
        {
            updateCurrentPath(PATH_COMPUTER);

            this.listViewFiles.Items.Clear();
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in driveInfos)
            {
                ListViewItem tn = new ListViewItem();
                try
                {
                    tn.Text = driveInfo.VolumeLabel + "(" + driveInfo.Name.Substring(0, 2) + ")";
                }
                catch (Exception)
                {
                    tn.Text = "(" + driveInfo.Name.Substring(0, 2) + ")";

                }

                tn.Tag = driveInfo.RootDirectory;
                tn.ImageKey = "floder";
                tn.SubItems.Add(getFloderType(driveInfo.RootDirectory,"驱动器"));
                tn.SubItems.Add("-");
                tn.SubItems.Add("磁盘根");
                tn.SubItems.Add("-");
                tn.SubItems.Add("-");
                tn.SubItems.Add("-");
                tn.SubItems.Add("-");
                this.listViewFiles.Items.Add(tn);

            }

            this.StateTipstoolStripStatusLabel.Text = "总："+listViewFiles.Items.Count;
        }
        private void showDirectory(string path)
        {
            updateCurrentPath(path);

            string searchContent = this.textBoxSearchContent.Text.Trim();
            if (searchContent == null || searchContent.Length==0)
                getAllDirectoryItems(path);
            else
            {
                this.listViewFiles.Items.Clear();
                this.StateTipstoolStripStatusLabel.Text = "搜索中...";

                bool isRegexSearch = this.RegexSearchOpenToolStripMenuItem.Checked;
                string[] content = searchContent.Split(new string[] { " ", "\t", "\n", "\r", "\v" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < content.Length; i++)
                {
                    content[i] = content[i].ToLower();
                }
                getSearchDirectoryItems(path,isRegexSearch,searchContent, content);
                
               
                
                this.StateTipstoolStripStatusLabel.Text = "搜索结束";
            }

            onlyShowExistFilter();

            this.StateTipstoolStripStatusLabel.Text = "总：" + listViewFiles.Items.Count;

            if (m_sortType == SortType.None)
                return;

            int itemsCount=listViewFiles.Items.Count;
            ListViewItem[] itemsArr=new ListViewItem[itemsCount];
            for (int i = 0; i < itemsArr.Length;i++ )
            {
                itemsArr[i]=listViewFiles.Items[i];
            }

            sortItemsArray(itemsArr);

            listViewFiles.Items.Clear();
           
            listViewFiles.Items.AddRange(itemsArr);

            
        }

        private void getRegexSearchDirectoryItems(string path,string regex)
        {

        }

        
        bool isSearchContent(string path,string[] content)
        {
            path = path.ToLower();
            for (int i = 0; i < content.Length;i++ )
            {
                if(path.IndexOf(content[i])>=0)
                {
                    return true;
                }
            }
            return false;
        }

        bool isRegexSearchContent(bool isFile,string path, string regex)
        {
            bool isIgnoreCase = this.RegexIgnoreCaseToolStripMenuItem.Checked;
            string fileName = null;
            string fileNameOnly = null;
            string fullPath = null;
            string pathOnly = null;
            string extensionOnly = null;
            if (isFile)
            {
                FileInfo pfile = new FileInfo(path);
                fileName = pfile.Name;
                if (pfile.Extension != null)
                {
                    fileNameOnly = pfile.Name.Substring(0, pfile.Name.Length - pfile.Extension.Length);
                }
                else
                {
                    fileNameOnly = pfile.Name;
                }
                
                fullPath = pfile.FullName;
                pathOnly = pfile.Directory.FullName;
                if (pfile.Extension != null && pfile.Extension.Length > 0)
                {
                    extensionOnly = pfile.Extension.Substring(1);
                }
                else
                {
                    extensionOnly = null;
                }
                
            }
            else
            {
                DirectoryInfo pdir = new DirectoryInfo(path);
                fileName = pdir.Name;
                fileNameOnly = pdir.Name;
                fullPath = pdir.FullName;
                if (pdir.Parent != null)
                {
                    pathOnly = pdir.Parent.FullName;
                }
                else
                {
                    pathOnly = null;
                }
                
                extensionOnly = null;
            }

            RegexOptions regexOption = RegexOptions.None;
            if (isIgnoreCase)
            {
                regexOption = RegexOptions.IgnoreCase;
            }

            if (regexType == RegexSearchTargetType.FileName)
            {
                if (fileName != null)
                {
                    return Regex.IsMatch(fileName, regex, regexOption);
                }
            }
            else if (regexType == RegexSearchTargetType.FileNameOnly)
            {
                if (fileNameOnly != null)
                {
                    return Regex.IsMatch(fileNameOnly, regex, regexOption);
                }
            }
            else if (regexType == RegexSearchTargetType.PathOnly)
            {
                if (pathOnly != null)
                {
                    return Regex.IsMatch(pathOnly, regex, regexOption);
                }
            }
            else if (regexType == RegexSearchTargetType.FullPath)
            {
                if (fullPath != null)
                {
                    return Regex.IsMatch(fullPath, regex, regexOption);
                }
            }
            else if (regexType == RegexSearchTargetType.ExtensionOnly)
            {
                if (extensionOnly != null)
                {
                    return Regex.IsMatch(extensionOnly, regex, regexOption);
                }
            }
            return false;
        }
        void getSearchDirectoryItems(string path,bool isRegexSearch,string searchContent,string[] content)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (DirectoryInfo pdir in dir.GetDirectories())
                {
                     if (isPassedFilter(pdir.FullName)) 
                    {
                        bool isSearchTarget = false;
                        if (isRegexSearch)
                        {
                            isSearchTarget = isRegexSearchContent(false,pdir.FullName, searchContent);
                        }
                        else
                        {
                            isSearchTarget=isSearchContent(pdir.Name, content);
                        }

                        if (isSearchTarget)
                        {
                            ListViewItem item = new ListViewItem();
                            FileItemInfo finfo = new FileItemInfo(pdir.FullName,m_isAnaliesCache,m_analiesFileInfoCache, m_isAnaliesDirectory,m_isNeedFileCheckCode);
                            item.Text = finfo.name;
                            item.Tag = finfo;
                            item.ImageKey = "floder";
                            item.SubItems.Add(finfo.type);

                            item.SubItems.Add(fileSizeToString(finfo.size));
                            item.SubItems.Add(fileAttributeToString(finfo.attribute));
                            item.SubItems.Add(finfo.lastWriteTime.ToString());
                            item.SubItems.Add(finfo.createTime.ToString());
                            item.SubItems.Add(finfo.lastAccessTime.ToString());
                            item.SubItems.Add(finfo.checkCode);
                            this.listViewFiles.Items.Add(item);
                        }
                        getSearchDirectoryItems(pdir.FullName,isRegexSearch,searchContent,content);
                       
                    }

                }

                foreach (FileInfo pfile in dir.GetFiles())
                {
                    if (isPassedFilter(pfile.FullName)) 
                    {
                        bool isSearchTarget = false;
                        if (isRegexSearch)
                        {
                            isSearchTarget = isRegexSearchContent(true,pfile.FullName, searchContent);
                        }
                        else
                        {
                            isSearchTarget = isSearchContent(pfile.Name, content);
                        }

                        if (isSearchTarget)
                        {
                                ListViewItem item = new ListViewItem();
                                FileItemInfo finfo = new FileItemInfo(pfile.FullName,m_isAnaliesCache,m_analiesFileInfoCache, m_isAnaliesDirectory,m_isNeedFileCheckCode);
                                item.Text = pfile.Name;
                                item.Tag = finfo;
                                if (pfile.Extension == null || pfile.Extension == "")
                                {
                                    item.ImageKey = "unkown";
                                }
                                else
                                {
                                    if (this.imageListMain.Images.Keys.Contains(pfile.Extension) == false)
                                    {
                                        Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(pfile.FullName);
                                        this.imageListMain.Images.Add(pfile.Extension, icon);
                                    }
                                    item.ImageKey = pfile.Extension;
                                }
                                item.SubItems.Add(finfo.type);

                                item.SubItems.Add(fileSizeToString(finfo.size));
                                item.SubItems.Add(fileAttributeToString(finfo.attribute));
                                item.SubItems.Add(finfo.lastWriteTime.ToString());
                                item.SubItems.Add(finfo.createTime.ToString());
                                item.SubItems.Add(finfo.lastAccessTime.ToString());
                                item.SubItems.Add(finfo.checkCode);
                                this.listViewFiles.Items.Add(item);
                        }
                     
                    }
                }
            }
            catch (Exception)
            {

                // throw;
            }
            
        }
        void getAllDirectoryItems(string path)
        {

            this.listViewFiles.Items.Clear();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (DirectoryInfo pdir in dir.GetDirectories())
                {
                    if (isPassedFilter(pdir.FullName))
                    {
                        ListViewItem item = new ListViewItem();
                        FileItemInfo finfo = new FileItemInfo(pdir.FullName,m_isAnaliesCache,m_analiesFileInfoCache, m_isAnaliesDirectory,m_isNeedFileCheckCode);
                        item.Text = finfo.name;
                        item.Tag = finfo;
                        item.ImageKey = "floder";
                        item.SubItems.Add(finfo.type);

                        item.SubItems.Add(fileSizeToString(finfo.size));
                        item.SubItems.Add(fileAttributeToString(finfo.attribute));
                        item.SubItems.Add(finfo.lastWriteTime.ToString());
                        item.SubItems.Add(finfo.createTime.ToString());
                        item.SubItems.Add(finfo.lastAccessTime.ToString());
                        item.SubItems.Add(finfo.checkCode);
                        this.listViewFiles.Items.Add(item);
                    }

                }

                foreach (FileInfo pfile in dir.GetFiles())
                {
                    if (isPassedFilter(pfile.FullName))
                    {
                        ListViewItem item = new ListViewItem();
                        FileItemInfo finfo = new FileItemInfo(pfile.FullName,m_isAnaliesCache,m_analiesFileInfoCache, m_isAnaliesDirectory,m_isNeedFileCheckCode);
                        item.Text = pfile.Name;
                        item.Tag = finfo;
                        if (pfile.Extension == null || pfile.Extension == "")
                        {
                            item.ImageKey = "unkown";
                        }
                        else
                        {
                            if (this.imageListMain.Images.Keys.Contains(pfile.Extension) == false)
                            {
                                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(pfile.FullName);
                                this.imageListMain.Images.Add(pfile.Extension, icon);
                            }
                            item.ImageKey = pfile.Extension;
                        }
                        item.SubItems.Add(finfo.type);

                        item.SubItems.Add(fileSizeToString(finfo.size));
                        item.SubItems.Add(fileAttributeToString(finfo.attribute));
                        item.SubItems.Add(finfo.lastWriteTime.ToString());
                        item.SubItems.Add(finfo.createTime.ToString());
                        item.SubItems.Add(finfo.lastAccessTime.ToString());
                        item.SubItems.Add(finfo.checkCode);
                        this.listViewFiles.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {

                // throw;
            }
        }
        private long comparator4Sort(ListViewItem it1,ListViewItem it2)
        {
            FileItemInfo info1=(FileItemInfo)it1.Tag;
            FileItemInfo info2=(FileItemInfo)it2.Tag;
            if(m_sortType==SortType.None)
            {
                return -1;
            }
            else if(m_sortType==SortType.Name)
            {
                string st1 = info1.name.ToLower();
                string st2 = info2.name.ToLower();
                return st1.CompareTo(st2);
            }
            else if(m_sortType==SortType.Type)
            {
                return info1.type.CompareTo(info2.type);
            }
            else if(m_sortType==SortType.Attr)
            {
                return (long)info1.attribute - (long)info2.attribute;
            }
            else if(m_sortType==SortType.Size)
            {
                return info1.size - info2.size;
            }
            else if(m_sortType==SortType.LModify)
            {
                return info1.lastWriteTime.Ticks - info2.lastWriteTime.Ticks;
            }
            else if(m_sortType==SortType.Create)
            {
                return info1.createTime.Ticks - info2.createTime.Ticks;
            }
            else if(m_sortType==SortType.LAccess)
            {
                return info1.lastAccessTime.Ticks - info2.lastAccessTime.Ticks;
            }
            else if(m_sortType==SortType.CheckCode)
            {
                return info1.checkCode.CompareTo(info2.checkCode);
            }
            else
            {
                return 0;
            }
        }
        private void sortItemsArray(ListViewItem[] arr)
        {
            for(int i=0;i<arr.Length;i++)
            {
                bool swap = false;
                for(int j=1;j<arr.Length;j++)
                {
                    if (comparator4Sort(arr[j-1],arr[j])>0 == m_isSortRaise)
                    {
                        ListViewItem tp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = tp;
                        swap=true;
                    }
                }
                if (swap == false)
                    break;
            }
        }
        private string fileAttributeToString(FileAttributes attr)
        {
            string ret = "";
            if((((int)attr)&((int)FileAttributes.Normal))!=0)
            {
                ret += "[常规]";
            }
            if ((((int)attr) & ((int)FileAttributes.Compressed)) != 0)
            {
                ret += "[压缩]";
            }
            if ((((int)attr) & ((int)FileAttributes.Device)) != 0)
            {
                ret += "[设备]";
            }
            if ((((int)attr) & ((int)FileAttributes.Directory)) != 0)
            {
                ret += "[目录]";
            }
            if ((((int)attr) & ((int)FileAttributes.Encrypted)) != 0)
            {
                ret += "[加密]";
            }
            if ((((int)attr) & ((int)FileAttributes.Hidden)) != 0)
            {
                ret += "[隐藏]";
            }
            if ((((int)attr) & ((int)FileAttributes.ReadOnly)) != 0)
            {
                ret += "[只读]";
            }
            if ((((int)attr) & ((int)FileAttributes.System)) != 0)
            {
                ret += "[系统]";
            }

            if ((((int)attr) & ((int)FileAttributes.Temporary)) != 0)
            {
                ret += "临时";
            }
            if ((((int)attr) & ((int)FileAttributes.IntegrityStream)) != 0)
            {
                ret += "[完整性支持]";
            }
            if ((((int)attr) & ((int)FileAttributes.NoScrubData)) != 0)
            {
                ret += "[排除完整性]";
            }
            if ((((int)attr) & ((int)FileAttributes.NotContentIndexed)) != 0)
            {
                ret += "[无内容索引]";
            }
            if ((((int)attr) & ((int)FileAttributes.Offline)) != 0)
            {
                ret += "[脱机状态]";
            }
            
            if ((((int)attr) & ((int)FileAttributes.ReparsePoint)) != 0)
            {
                ret += "[重新分析点]";
            }

            if ((((int)attr) & ((int)FileAttributes.SparseFile)) != 0)
            {
                ret += "[稀疏]";
            }


            if (ret.Length == 0)
                ret = "[文件]";
            return ret;
        }
        public static string fileSizeToString(long size)
        {
            string ret = "";
            if(size<1024)
            {
                ret = size + " Byte";
            }
            else if(size<1024*1024)
            {
                ret = (size/1024) + " Kb";
            }
            else if (size < 1024 * 1024*1024)
            {
                ret = (size/1024/1024) + " Mb";
            }
            else //if (size < 1024 * 1024*1024*1024L)
            {
                ret = (size/1024/1024/1024) + " Gb";
            }
            return ret;
        }

        private void JumpToParentDirectory()
        {
            if (m_currentPath == PATH_COMPUTER)
            {
                showDirvers();
                return;
            }
            DirectoryInfo pdir = new DirectoryInfo(m_currentPath).Parent;
            if (pdir != null && pdir.Exists)
            {
                showDirectory(pdir.FullName);
            }
            else
            {
                showDirvers();
            }
        }
        private void ParentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToParentDirectory();
        }

        private void DisplayIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewFiles.View = View.LargeIcon;
        }

        private void DisplayDetialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewFiles.View = View.Details;
        }

        private void DisplayListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewFiles.View = View.List;
        }

        private void DisplayTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewFiles.View = View.Tile;
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            try
            {

                this.splitContainerControl.SplitterDistance = this.textBoxCurrentPath.Height;
                this.splitContainerHeadLine.SplitterDistance = (int)(this.splitContainerHeadLine.Width * 0.66);
            }
            catch (Exception)
            {
                
            }
        }

        private void EnterPath()
        {
            string ppath = this.textBoxCurrentPath.Text.Trim();
            if (ppath.Length == 0 || ppath == PATH_COMPUTER)
            {
                showDirvers();
            }
            else if (new DirectoryInfo(ppath).Exists)
            {
                showDirectory(ppath);
            }
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            EnterPath();
        }

        private void OpenInSysExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.listViewFiles.SelectedItems.Count==0)
            {
                if (new DirectoryInfo(m_currentPath).Exists)
                {
                    Process.Start("explorer", m_currentPath);
                }
            }
            else
            {
                foreach(ListViewItem it in listViewFiles.SelectedItems)
                {
                    Process.Start("explorer", it.Tag.ToString());
                }
            }
            
        }

        private void FilterAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.All;
            refreshCurrentDirectory();
        }

        private void FilterOnlyRegularUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.OnlyRegular;
            refreshCurrentDirectory();
        }
        private void FilterDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.OnlyDirectory;
            refreshCurrentDirectory();
        }

        private void FilterFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.OnlyFile;
            refreshCurrentDirectory();
        }

        private void FilterPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Picture;
            refreshCurrentDirectory();
        }

        private void FilterVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Video;
            refreshCurrentDirectory();
        }

        private void FilterAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Audio;
            refreshCurrentDirectory();
        }

        private void FilterDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Document;
            refreshCurrentDirectory();
        }

        private void FilterExecuableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Execuable;
            refreshCurrentDirectory();
        }

        private void FilterCompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.Compress;
            refreshCurrentDirectory();
        }
        private void FilterLinkFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.LinkFile;
            refreshCurrentDirectory();
        }
        private void FilterLibDllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_filterType = FilterType.LibDll;
            refreshCurrentDirectory();
        }

        private void RefereshDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshCurrentDirectory();
        }

        private void OpenLocalDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;
            foreach(ListViewItem it in listViewFiles.SelectedItems)
            {
                DirectoryInfo parent = new DirectoryInfo(it.Tag.ToString().Trim()).Parent;
                showDirectory(parent.FullName);
            }
        }

        private void StartWithParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;
            string str = Interaction.InputBox("请输入命令行参数：\n实际上执行的命令：\n\t选中的每一项的完整路径 输入的参数", "带参数启动输入框", "", -1, -1);
            str = str.Trim();
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                ProcessStartInfo sinfo = new ProcessStartInfo();
                sinfo.FileName = it.Tag.ToString();
                sinfo.Arguments = str;
                sinfo.WorkingDirectory = m_currentPath;
                Process.Start(sinfo);
            }
        }

        private void RunOnCmdlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;
            string str = Interaction.InputBox("请输入命令行参数：\n"+
                "这实际上是对每一项执行：\n"+
                "cmd /k 选中的每一项完整路径 你输入的参数", "带参数启动输入框", "", -1, -1);
            str = str.Trim();
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                ProcessStartInfo sinfo = new ProcessStartInfo();
                sinfo.FileName = "cmd";
                sinfo.Arguments = "/k "+it.Tag.ToString()+" "+str;
                sinfo.WorkingDirectory = m_currentPath;
                Process.Start(sinfo);
            }
        }
        private void RunCmdAsArgumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;
            string str = Interaction.InputBox("请输入运行命令，其中[%$]符号代表填充的占位符，\n"+
                "这个占位符即代表你当前选中的每一项的完整路径\n"+
                "这将会将每一项带入命令格式中进行运行：\n"+
                "实际上执行：\n"+
                "cmd /c copy \"D:\\a.txt\" D:\\test\\\n"+
                "例如：\n"+
                "cmd /c copy %$ D:\\test\\", "命令输入框", "", -1, -1);
            str = str.Trim();
            string[] cmds = str.Split(new string[] { " ", "\t", "\n", "\r" }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (cmds.Length < 2)
            {
                MessageBox.Show("参数不满足条件，至少一个运行程序和一个参数","参数提示");
                return;
            }

            if(cmds[1].IndexOf("%$")<0)
            {
                MessageBox.Show("参数不满足条件，未找到占位符","参数提示");
                return;
            }

            string program=cmds[0];
            string argsfmt=cmds[1].Replace("%$","\"{0}\"");

            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                string args=String.Format(argsfmt,it.Tag.ToString());
                ProcessStartInfo sinfo = new ProcessStartInfo();
                sinfo.FileName = program;
                sinfo.Arguments = args;
                sinfo.WorkingDirectory = m_currentPath;
                Process.Start(sinfo);
            }
        }

        private void RunCmdAllAsArgumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;
            string str = Interaction.InputBox("请输入运行命令，其中[%$]符号代表填充的占位符，\n"+
                "这个占位符即代表你当前选中的每一项的完整路径的集合\n"+
                "这将会将每一项填入命令中占位符位置作为参数：\n"+
                "实际上执行：\n"+
                "压缩工具.exe D:\\save.zip \"D:\\a.txt\" \"D:\\b.txt\"\n"+
                "例如：\n压缩工具.exe %$ D:\\save.zip %$", "命令输入框", "", -1, -1);
            str = str.Trim();
            string[] cmds = str.Split(new string[] { " ", "\t", "\n", "\r" }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (cmds.Length < 2)
            {
                MessageBox.Show("参数不满足条件，至少一个运行程序和一个参数", "参数提示");
                return;
            }

            if (cmds[1].IndexOf("%$") < 0)
            {
                MessageBox.Show("参数不满足条件，未找到占位符", "参数提示");
                return;
            }

            string program = cmds[0];
            string argsfmt = cmds[1].Replace("%$", "{0}");

            string argstr = "";
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                argstr += " \"" + it.Tag.ToString() + "\"";
            }
            string args = String.Format(argsfmt, argstr);

            ProcessStartInfo sinfo=new ProcessStartInfo();
            sinfo.FileName=program;
            sinfo.Arguments=args;
            sinfo.WorkingDirectory = m_currentPath;
            Process.Start(sinfo);
        }
        private void RunCmdDirectHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入CMD命令:\n"+
                "多条命令使用[&&]符号拼接\n"+
                "例如：\n"+
                "color f5 && title CMDLINE", "命令输入框", "", -1, -1);
            ProcessStartInfo sinfo = new ProcessStartInfo();
            sinfo.WorkingDirectory = m_currentPath;
            sinfo.FileName = "cmd";
            sinfo.Arguments ="/c "+ str;
            sinfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(sinfo);
        }
        private void OpenCmdInHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info=new ProcessStartInfo();
            if (m_currentPath == PATH_COMPUTER)
                info.WorkingDirectory = "C:\\";
            else
                info.WorkingDirectory = m_currentPath;
            info.FileName="cmd";
            Process.Start(info);
        }


        private void JumpToSpecialFloder(string subName)
        {
            string pk = "HKEY_CURRENT_USER";
            string ck = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders";

            string keyName = pk + "\\" + ck;

            string val = (string)Registry.GetValue(keyName, subName, "C:\\");
            showDirectory(val);
        }
        private void JumpToDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("Desktop");
        }

        private void JumpToMyComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDirvers();
        }

        private void JumpToMyDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("Personal");
        }

        private void JumpToMyPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("My Pictures");
        }

        private void JumpToMyVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("My Video");
        }

        private void JumpToMyFavorateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("Favorites");
        }

        private void JumpToMyMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToSpecialFloder("My Music");
        }

        private void OpenItByNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
            {
                FormMain fm = new FormMain();
                fm.Show();
                fm.Text += " - 子窗口";
                fm.showDirectory(m_currentPath);
                return;
            }   
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                FormMain fm = new FormMain();
                fm.Show();
                fm.Text += " - 子窗口";
                fm.showDirectory(it.Tag.ToString());
            }
        }
        /*
         复制或剪切文件到系统剪切板中，在系统文件管理中可以直接粘贴文件
         */
        public static void copyFileToClipboard(string[] files, bool cut)
        {
            if (files == null) return;
            IDataObject data = new DataObject(DataFormats.FileDrop, files);
            MemoryStream memo = new MemoryStream(4);
            byte[] bytes = new byte[] { (byte)(cut ? 2 : 5), 0, 0, 0 };
            memo.Write(bytes, 0, bytes.Length);
            data.SetData("Preferred DropEffect", memo);
            Clipboard.SetDataObject(data);
        }
        /*
         尝试从剪切板保存系统中复制或者剪贴的文件，保存到dstPath目录下，根据指定的是否cut
         */
        public static void pauseFileFromClipboard(string dstPath,bool cut)
        {
            if (Clipboard.ContainsFileDropList())
            {
                System.Collections.Specialized.StringCollection sc=Clipboard.GetFileDropList();
                foreach (string fileName in sc)
                {
                    FileInfo srcFile = new FileInfo(fileName);
                    FileInfo dstFile = new FileInfo(dstPath + "\\" + srcFile.Name);
                    try
                    {
                        if (cut)
                        {
                            srcFile.MoveTo(dstFile.FullName);
                        }
                        else
                        {
                            srcFile.CopyTo(dstFile.FullName);
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                Clipboard.Clear();
            }
        }

        private void copySelectedItems()
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
                return;
            List<string> list = new List<string>();
            g_clipType = ClipType.Copy;
            g_clipbordItems = new string[selCount];
            for (int i = 0; i < selCount; i++)
            {
                string path=listViewFiles.SelectedItems[i].Tag.ToString().Trim();
                g_clipbordItems[i] = path;
                list.Add(path);
            }
            string[] files=list.ToArray();
            copyFileToClipboard(files, false);
        }
        private void CopySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copySelectedItems();
        }
        private void cutSelectedItems()
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
                return;
            List<string> list = new List<string>();
            g_clipType = ClipType.Cut;
            g_clipbordItems = new string[selCount];
            for (int i = 0; i < selCount; i++)
            {
                string path = listViewFiles.SelectedItems[i].Tag.ToString().Trim();
                g_clipbordItems[i] = path;
                list.Add(path);
            }
            string[] files = list.ToArray();
            copyFileToClipboard(files, true);
        }
        private void CutSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutSelectedItems();
        }
        
        private void paustSelectedItems()
        {
            if (g_clipType != ClipType.None && g_clipbordItems != null)
            {
                foreach (string ppath in g_clipbordItems)
                {
                    FileInfo pfile = new FileInfo(ppath);
                    if (pfile.Exists)
                    {
                        if (g_clipType == ClipType.Copy)
                        {
                           // pfile.CopyTo(m_currentPath + "\\" + pfile.Name, true);
                            pfile.CopyTo(getUseableFileName(m_currentPath, getSingleFileNameFromFileInfo(pfile), pfile.Extension));
                        }
                        else if (g_clipType == ClipType.Cut)
                        {
                            //pfile.MoveTo(m_currentPath + "\\" + pfile.Name);
                            pfile.MoveTo(getUseableFileName(m_currentPath, getSingleFileNameFromFileInfo(pfile), pfile.Extension));
                        }
                    }
                    else
                    {
                        DirectoryInfo pdir = new DirectoryInfo(ppath);
                        if (pdir.Exists)
                        {
                            if (g_clipType == ClipType.Copy)
                            {
                                CopyDirectoryTo(pdir.FullName, m_currentPath + "\\" + pdir.Name);
                            }
                            else if (g_clipType == ClipType.Cut)
                            {
                                //pdir.MoveTo(m_currentPath + "\\" + pdir.Name);
                                pdir.MoveTo(getUseableFileName(m_currentPath, getSingleFileNameFromFileInfo(new FileInfo(ppath)), pdir.Extension));
                            }
                        }
                    }
                }

            }
            else
            {
                if (Clipboard.ContainsFileDropList())
                {
                    DialogResult rs = MessageBox.Show("检测到系统文件粘贴，是否执行移动？\n是：移动\n否：复制\n取消：不操作", "文件粘贴选项", MessageBoxButtons.YesNoCancel);
                    if (rs != DialogResult.Cancel)
                    {
                        bool cutFlag = true;
                        if (rs == DialogResult.Yes)
                        {
                            cutFlag = true;
                        }
                        else if (rs == DialogResult.No)
                        {
                            cutFlag = false;
                        }
                        pauseFileFromClipboard(m_currentPath, cutFlag);
                    }
                }
            }
            refreshCurrentDirectory();
            g_clipType = ClipType.None;
            g_clipbordItems = null;
        }
        private void PaustSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paustSelectedItems();

        }
        private void CopyDirectoryTo(string srcPath,string destPath)
        {
            DirectoryInfo dstDir = new DirectoryInfo(destPath);
            dstDir.Create();

            DirectoryInfo srcDir=new DirectoryInfo(srcPath);
            foreach(FileInfo fi in srcDir.GetFiles())
            {
               // fi.CopyTo(destPath + "\\" + fi.Name, true);
                fi.CopyTo(getUseableFileName(destPath, getSingleFileNameFromFileInfo(fi), fi.Extension));
            }
            foreach(DirectoryInfo di in srcDir.GetDirectories())
            {
                CopyDirectoryTo(di.FullName, destPath + "\\" + di.Name);
            }
        }
        private void deleteSelectedItems()
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
                return;
            try
            {
                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo file = new FileInfo(it.Tag.ToString().Trim());
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    else
                    {
                        DirectoryInfo dir = new DirectoryInfo(file.FullName);
                        dir.Delete(true);
                    }
                }

                refreshCurrentDirectory();
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }
        private void DeleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteSelectedItems();
        }

        private void selectedAllItems()
        {
            foreach(ListViewItem it in listViewFiles.Items)
            {
                it.Selected = true;
            }
        }
        private void de_selectedAllItems()
        {
            foreach (ListViewItem it in listViewFiles.Items)
            {
                it.Selected = false;
            }
        }
        private void anti_selectedAllItems()
        {
            foreach (ListViewItem it in listViewFiles.Items)
            {
                it.Selected = !it.Selected;
            }
        }

        private void SelectedAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedAllItems();
        }

        private void SelectedNothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            de_selectedAllItems();
        }

        private void SelectedAntiFaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anti_selectedAllItems();
        }


        private void listViewFiles_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.C:
                    if (e.Control)
                    {
                        copySelectedItems();
                    }
                    break;
                case Keys.X:
                    if (e.Control)
                    {
                        cutSelectedItems();
                    }
                    break;
                case Keys.V:
                    if (e.Control)
                    {
                        paustSelectedItems();
                    }
                    break;
                case Keys.A:
                    if (e.Control)
                    {
                        selectedAllItems();
                    }
                    break;
                case Keys.Q:
                    if (e.Control)
                    {
                        de_selectedAllItems();
                    }
                    break;
                case Keys.W:
                    if (e.Control)
                    {
                        anti_selectedAllItems();
                    }
                    break;
                case Keys.Delete:
                    if (e.Control)
                    {
                        deleteSelectedItems();
                    }
                    break;
                case Keys.F5:
                    refreshCurrentDirectory();
                    break;
                case Keys.Escape:
                    JumpToParentDirectory();
                    break;
                case Keys.Left:
                    ToPreviousHistoryPath();
                    break;
                case Keys.Right:
                    ToNextHistoryPath();
                    break;
                case  Keys.F1:
                        MessageBox.Show("Copyright @ Ugex.Savelar -2020","文件分析仪");
                        break;
                    
            }
        }

        private void renameSelectedItems(string newName)
        {
             int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
                return;
            try
            {
                if (selCount == 1)
                {
                    foreach (ListViewItem it in listViewFiles.SelectedItems)
                    {
                        FileInfo file = new FileInfo(it.Tag.ToString().Trim());
                        if (file.Exists)
                        {
                            //file.MoveTo(file.DirectoryName +"\\"+ newName);
                            file.MoveTo(getUseableFileName(file.DirectoryName, getSingleFileNameFromFileInfo(new FileInfo(newName)), new FileInfo(newName).Extension));
                        }
                        else
                        {
                            DirectoryInfo dir = new DirectoryInfo(file.FullName);
                            //dir.MoveTo(dir.Parent.FullName + "\\" + newName);
                            dir.MoveTo(getUseableFileName(dir.Parent.FullName, getSingleFileNameFromFileInfo(new FileInfo(newName)), new FileInfo(newName).Extension));
                        }
                    }
                }
                else
                {
                    FileInfo pf = new FileInfo(newName);

                    string pname = getSingleFileNameFromFileInfo(pf);

                    foreach (ListViewItem it in listViewFiles.SelectedItems)
                    {
                        FileInfo file = new FileInfo(it.Tag.ToString().Trim());
                        if (file.Exists)
                        {
                            //file.MoveTo(file.DirectoryName + "\\" + pname+file.Extension)
                            file.MoveTo(getUseableFileName(file.DirectoryName, pname, file.Extension));
                        }
                        else
                        {
                            DirectoryInfo dir = new DirectoryInfo(file.FullName);
                            //dir.MoveTo(dir.Parent.FullName + "\\" + pname+dir.Extension);
                            dir.MoveTo(getUseableFileName(dir.Parent.FullName, pname, dir.Extension));
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }

            refreshCurrentDirectory();
        }

        private string getSingleFileNameFromFileInfo(FileInfo pf)
        {
            string pname = pf.Name;
            if (pf.Extension != null && pf.Extension.Length > 0)
                pname = pname.Remove(pf.Name.LastIndexOf(pf.Extension));
            return pname;
        }

        private string getUseableFileName(string parent,string name,string extension)
        {
            string ret = parent + "\\" + name + extension;
            if(new FileInfo(ret).Exists || new DirectoryInfo(ret).Exists)
            {
                int i = 1;
                while(new FileInfo(ret).Exists || new DirectoryInfo(ret).Exists)
                {
                    ret = parent + "\\" + name + "-" + i + extension;
                    i++;
                }
            }
            return ret;
        }
        private void RenameSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
             int selCount = listViewFiles.SelectedItems.Count;
             if (selCount == 0)
                 return;
             listViewFiles.SelectedItems[0].BeginEdit();
        }


        private void listViewFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            renameSelectedItems(e.Label);
        }

        private void TouchNewFloderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo pdir = new DirectoryInfo(getUseableFileName(m_currentPath,"新建文件夹",""));
            pdir.Create();
           
            ListViewItem item = new ListViewItem();
            item.Text = pdir.Name;
            item.Tag = new FileItemInfo(pdir.FullName,m_isAnaliesCache,m_analiesFileInfoCache,m_isAnaliesDirectory,m_isNeedFileCheckCode);
            item.ImageKey = "floder";
            item.SubItems.Add(getFloderType(pdir, "文件夹"));
            item.SubItems.Add("-");
            item.SubItems.Add(fileAttributeToString(pdir.Attributes));
            item.SubItems.Add("-");
            item.SubItems.Add("-");
            item.SubItems.Add("-");
            this.listViewFiles.Items.Add(item);
            item.BeginEdit();
        }
        private void addNewFileItem(FileInfo pfile,bool needRename=false)
        {

            ListViewItem item = new ListViewItem();
            item.Text = pfile.Name;
            item.Tag = new FileItemInfo(pfile.FullName,m_isAnaliesCache,m_analiesFileInfoCache,m_isAnaliesDirectory,m_isNeedFileCheckCode);
            if (this.imageListMain.Images.Keys.Contains(pfile.Extension) == false)
            {
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(pfile.FullName);
                this.imageListMain.Images.Add(pfile.Extension, icon);
            }
            item.ImageKey = pfile.Extension;
            item.SubItems.Add(pfile.Extension + "文件");
            item.SubItems.Add(fileSizeToString(pfile.Length));
            item.SubItems.Add(fileAttributeToString(pfile.Attributes));
            item.SubItems.Add(pfile.LastWriteTime.ToString());
            item.SubItems.Add(pfile.CreationTime.ToString());
            item.SubItems.Add(pfile.LastAccessTime.ToString());

            this.listViewFiles.Items.Add(item);
            if(needRename)
                item.BeginEdit();
        }
        private void TouchNewTxtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, "文本文档", ".txt"));
            FileStream fs=pfile.Create();
            fs.Close();

            addNewFileItem(pfile,true);
        }

        private void TouchNewBatFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, "批处理文件", ".bat"));
            StreamWriter fs = pfile.CreateText();
            fs.WriteLine("@echo off");
            fs.WriteLine();
            fs.WriteLine("exit");
            fs.Close();

            addNewFileItem(pfile,true);
        }

        private void TouchNewClangFileGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入C语言文件名：", "文件名输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            string upstr = str.ToUpper();
            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, str, ".h"));
            StreamWriter fs = pfile.CreateText();
            fs.WriteLine("/*  */");
            fs.WriteLine("#ifndef _"+upstr+"_H_");
            fs.WriteLine("#define _"+upstr+"_H_");
            fs.WriteLine();
            fs.WriteLine("#endif // _"+upstr+"_H_");
            fs.WriteLine();
            fs.Close();

            addNewFileItem(pfile,false);

            pfile = new FileInfo(getUseableFileName(m_currentPath, str, ".c"));
            fs = pfile.CreateText();
            fs.WriteLine("/*  */");
            fs.WriteLine("#include\""+str+".h\"");
            fs.WriteLine("//#include<stdio.h>");
            fs.WriteLine("//#include<stdlib.h>");
            fs.WriteLine("//#include<string.h>");
            fs.WriteLine();
            fs.Close();

            addNewFileItem(pfile, false);

        }

        private void TouchNewCppFileGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入CPP文件名：", "文件名输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            string upstr = str.ToUpper();
            string fupStr = ""+upstr[0]+str.Substring(1);
            

            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, str, ".h"));
            StreamWriter fs = pfile.CreateText();
            fs.WriteLine("/*  */");
            fs.WriteLine("#ifndef _" + upstr + "_H_");
            fs.WriteLine("#define _" + upstr + "_H_");
            fs.WriteLine("class "+fupStr+" // : public Object");
            fs.WriteLine("{");
            fs.WriteLine("public:");
            fs.WriteLine("\t"+fupStr+"();");
            fs.WriteLine("\tvirtual ~" + fupStr + "();");
            fs.WriteLine("\t"+fupStr+"(const "+fupStr+" & obj);");
            fs.WriteLine("\t" + fupStr + "& operator=(const " + fupStr + " & obj);");
            fs.WriteLine("private:");
            fs.WriteLine("};");
            fs.WriteLine("#endif // _" + upstr + "_H_");
            fs.WriteLine();
            fs.Close();

            addNewFileItem(pfile, false);

            pfile = new FileInfo(getUseableFileName(m_currentPath, str, ".cpp"));
            fs = pfile.CreateText();
            fs.WriteLine("/*  */");
            fs.WriteLine("#include\"" + str + ".h\"");
            fs.WriteLine("//#include<iostream>");
            fs.WriteLine("//#include<string>");
            fs.WriteLine("//#include<cstdlib>");
            fs.WriteLine("//using namespace::std;");
            fs.WriteLine();
            fs.WriteLine(fupStr + "::" + fupStr + "()\n{\n\t\n}\n");
            fs.WriteLine(fupStr+"::~"+fupStr+"()\n{\n\t\n}\n");
            fs.WriteLine(fupStr+"::"+fupStr+"(const "+fupStr+" & obj)\n{\n\t\n}\n");
            fs.WriteLine(fupStr + " & " + fupStr + "::" + "operator=(const " + fupStr + " & obj)\n{\n\t\n\treturn *this;\n}\n");
            fs.Close();

            addNewFileItem(pfile, false);
        }

        private void TouchNewJavaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入Java文件名：", "文件名输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            string upstr = str.ToUpper();
            string fupStr = "" + upstr[0] + str.Substring(1);


            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, fupStr, ".java"));
            StreamWriter fs = pfile.CreateText();
            fs.WriteLine("/*  */");
            fs.WriteLine("public class "+fupStr+" //extends Object //implements Runnable{");
            fs.WriteLine("\tpublic static void main(String[] args){");
            fs.WriteLine("\t\t//System.out.println(\"hello java\");");
            fs.WriteLine("\t\t");
            fs.WriteLine("\t}");
            fs.WriteLine("\t");
            fs.WriteLine("}");
            fs.WriteLine();
            fs.Close();

            addNewFileItem(pfile, false);
        }

        private void TouchNewPythonFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入Python文件名：", "文件名输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            string upstr = str.ToUpper();
            string fupStr = "" + upstr[0] + str.Substring(1);


            FileInfo pfile = new FileInfo(getUseableFileName(m_currentPath, fupStr, ".py"));
            StreamWriter fs = pfile.CreateText();
            fs.WriteLine("# -- coding: gbk --");
            fs.WriteLine("'''\n\n'''");
            fs.WriteLine("def main():\n\tprint('hello py')\n\t");
            fs.WriteLine("\n\n");
            fs.WriteLine("if __name__=='__main__':\n\tmain()\n\t");
            fs.WriteLine();
            fs.Close();

            addNewFileItem(pfile, false);
        }

        private void AnaliesFileOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_isAnaliesDirectory = false;
            this.AnaliesFileOnlyToolStripMenuItem.Checked = true;
            this.AnaliesFlodersInfoToolStripMenuItem.Checked = false;
            refreshCurrentDirectory();
        }

        private void AnaliesFlodersInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_isAnaliesDirectory = true;
            this.AnaliesFileOnlyToolStripMenuItem.Checked = false;
            this.AnaliesFlodersInfoToolStripMenuItem.Checked = true;
            refreshCurrentDirectory();
        }

        private void AnaliesFileCheckCodeFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_isNeedFileCheckCode = !m_isNeedFileCheckCode;
            this.AnaliesFileCheckCodeFToolStripMenuItem.Checked = m_isNeedFileCheckCode;
            refreshCurrentDirectory();
        }

        private void listViewFiles_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int coli = e.Column;
            switch(coli)
            {
                case 0:
                    m_sortType = SortType.Name;
                    break;
                case 1:
                    m_sortType = SortType.Type;
                    break;
                case 2:
                    m_sortType = SortType.Size;
                    break;
                case 3:
                    m_sortType = SortType.Attr;
                    break;
                case 4:
                    m_sortType = SortType.LModify;
                    break;
                case 5:
                    m_sortType = SortType.Create;
                    break;
                case 6:
                    m_sortType = SortType.LAccess;
                    break;
                case 7:
                    m_sortType = SortType.CheckCode;
                    break;
                default:
                    m_sortType = SortType.None;
                    break;
            }
            refreshCurrentDirectory();
        }

        private void SortTypeNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SortTypeNoneToolStripMenuItem.Checked = true;
            this.RaiseSortModeToolStripMenuItem.Checked = false;
            this.DescSortModeToolStripMenuItem.Checked = false;
             m_sortType = SortType.None;
             refreshCurrentDirectory();
        }

        private void RaiseSortModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SortTypeNoneToolStripMenuItem.Checked = false;
            this.RaiseSortModeToolStripMenuItem.Checked = true;
            this.DescSortModeToolStripMenuItem.Checked = false;
            m_isSortRaise = true;
            refreshCurrentDirectory();
        }
        
        private void DescSortModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SortTypeNoneToolStripMenuItem.Checked = false;
            this.RaiseSortModeToolStripMenuItem.Checked = false;
            this.DescSortModeToolStripMenuItem.Checked = true;
            m_isSortRaise = false;
            refreshCurrentDirectory();
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (MessageBox.Show("即将进行文件拖拽，是否继续？", "文件拖拽确认", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            bool isCut=false;
            if (MessageBox.Show("是复制文件还是剪切文件？\n确定==剪切，取消==复制", "文件拖拽询问", MessageBoxButtons.OKCancel) == DialogResult.OK)
                isCut = true;

            Array paths = ((Array)e.Data.GetData(DataFormats.FileDrop));
           for(int i=0;i<paths.Length;i++)
           {
               string ppath = paths.GetValue(i).ToString().Trim();
               FileInfo fi = new FileInfo(ppath);
               DirectoryInfo di = new DirectoryInfo(ppath);
               string newpath=getUseableFileName(m_currentPath,getSingleFileNameFromFileInfo(fi),fi.Extension);
               if (newpath == ppath)
                   continue;
               if(fi.Exists)
               {
                   if (isCut)
                       fi.MoveTo(newpath);
                   else
                       fi.CopyTo(newpath);
               }else if(di.Exists)
               {
                   if (isCut)
                       di.MoveTo(newpath);
                   else
                       CopyDirectoryTo(ppath, newpath);
               }
           }

           refreshCurrentDirectory();
        }

        private void listViewFiles_DragEnter(object sender, DragEventArgs e)
        {
            
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void OpenItByNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
                return;
            foreach(ListViewItem it in listViewFiles.SelectedItems)
            {
                ProcessStartInfo sinfo = new ProcessStartInfo();
                sinfo.FileName = "notepad";
                sinfo.Arguments = it.Tag.ToString();
                sinfo.WorkingDirectory = m_currentPath;
                Process.Start(sinfo);
            }
        }

        private void CopyFullPathToClipbordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                Clipboard.SetDataObject(m_currentPath);
                return;
            }
            string str = "";
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                str += it.Tag.ToString() + "\n";
            }
            Clipboard.SetDataObject(str);
        }

        private void SearchPath()
        {
            refreshCurrentDirectory();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchPath();
        }

        private void RandomSelectNumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sum = listViewFiles.Items.Count;
            if (sum == 0)
                return;

            string str = Interaction.InputBox("请输入随机选择的项数：\n总：" + sum, "数量输入框", "" + (sum/2), -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;
            try
            {
                int count = Convert.ToInt32(str);
                foreach(ListViewItem it in listViewFiles.Items)
                {
                     it.Selected=false;
                }
                if (count <= 0)
                    return;

                
                if(count>=sum)
                {
                    selectedAllItems();
                    return;
                }

                
                Random rand=new Random();
                int pcount = 0;
                while(pcount <count)
                {
                    int i = rand.Next(0, sum);
                    if(listViewFiles.Items[i].Selected==false)
                    {
                        listViewFiles.Items[i].Selected = true;
                        pcount++;
                    }
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        private void listViewFiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.StateTipstoolStripStatusLabel.Text = "总："+listViewFiles.Items.Count+" 选："+listViewFiles.SelectedItems.Count;
        }

        private void ProMkdirsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strs = Interaction.InputBox("请输入多级目录：\n增强：多个多级目录之间用|分隔\n例如：\naaa/bbb\na\\b\\c", "目录输入框", "", -1, -1);
            strs = strs.Trim();
            if (strs.Length == 0)
                return;
            string[] arr=strs.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string str in arr){
                string[] paths = str.Split(new string[] { "\\", "/" }, StringSplitOptions.RemoveEmptyEntries);
                string ppath = m_currentPath;
                for(int i=0;i<paths.Length;i++)
                {
                    ppath = ppath + "\\" + paths[i];
                    DirectoryInfo pdir = new DirectoryInfo(ppath);
                    pdir.Create();
                }
            }
            refreshCurrentDirectory();
        }

        private void NameToUpperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }

            foreach(ListViewItem it in listViewFiles.SelectedItems)
            {
                FileInfo fi = new FileInfo(it.Tag.ToString());
                DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                string tpname = getUseableFileName(di.Parent.FullName, "_temp_file", ".tmp");
                if(fi.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    string suffix = fi.Extension;
                    fi.MoveTo(tpname);
                    new FileInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToUpper(), suffix));

                }else if(di.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    string suffix = fi.Extension;
                    di.MoveTo(tpname);
                    new DirectoryInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToUpper(), suffix));
                }
            }

            refreshCurrentDirectory();
        }

        private void NameToLowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }

            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                FileInfo fi = new FileInfo(it.Tag.ToString());
                DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                string tpname = getUseableFileName(di.Parent.FullName, "_temp_file", ".tmp");
                if (fi.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    string suffix = fi.Extension;
                    fi.MoveTo(tpname);
                    new FileInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToLower(), suffix));

                }
                else if (di.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    string suffix = fi.Extension;
                    di.MoveTo(tpname);
                    new DirectoryInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToLower(), suffix));
                }
            }

            refreshCurrentDirectory();
        }

        private void NameUnifySuffixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            string suffix = Interaction.InputBox("请输入后缀：\n例如：\n.mp3\npng", "后缀输入框", "", -1, -1);
            suffix = suffix.Trim();
            if (suffix.Length == 0)
                return;
            if(suffix[0]!='.')
            {
                suffix = '.' + suffix;
            }

            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                FileInfo fi = new FileInfo(it.Tag.ToString());
                DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                string tpname = getUseableFileName(di.Parent.FullName, "_temp_file", ".tmp");
                if (fi.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    
                    fi.MoveTo(tpname);
                    new FileInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToLower(), suffix));

                }
                else if (di.Exists)
                {
                    string name = getSingleFileNameFromFileInfo(fi);
                    di.MoveTo(tpname);
                    new DirectoryInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name.ToLower(), suffix));
                }
            }

            refreshCurrentDirectory();
        }

        private void NameHeadAddNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            string str = Interaction.InputBox("请输入起始序号：\n例如：\n1\n010\n0001", "序号输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            try
            {
                int num = Convert.ToInt32(str);
                int wid = str.Length;
                string fmt = "{0:D"+wid+"}";

                int count = 0;
                for(int i=0;i<listViewFiles.Items.Count;i++)
                {
                    if(listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi=new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, String.Format(fmt, (num + count)) + getSingleFileNameFromFileInfo(fi), fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

               // throw;
            }

        }

        private void NameTialAddNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            string str = Interaction.InputBox("请输入起始序号：\n例如：\n1\n010\n0001", "序号输入框", "", -1, -1);
            str = str.Trim();
            if (str.Length == 0)
                return;

            try
            {
                int num = Convert.ToInt32(str);
                int wid = str.Length;
                string fmt = "{0:D" + wid + "}";

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, getSingleFileNameFromFileInfo(fi) + String.Format(fmt, (num + count)), fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameHeadAddTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            

            try
            {
                DateTime tm = DateTime.Now;
                string tmstr=tm.ToString("HHmmss");

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, tmstr + getSingleFileNameFromFileInfo(fi), fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameTialAddTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                DateTime tm = DateTime.Now;
                string tmstr = tm.ToString("HHmmss");

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, getSingleFileNameFromFileInfo(fi) + tmstr, fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameHeadAddDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                DateTime tm = DateTime.Now;
                string tmstr = tm.ToString("yyyyMMdd");

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, tmstr + getSingleFileNameFromFileInfo(fi), fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameTialAddDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                DateTime tm = DateTime.Now;
                string tmstr = tm.ToString("yyyyMMdd");

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, getSingleFileNameFromFileInfo(fi) + tmstr, fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameHeadAddStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }

            string str = Interaction.InputBox("请输入要添加的字符串：", "字符串输入框", "", -1, -1);
            if (str.Length == 0)
                return;

            try
            {
                
                

                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, str + getSingleFileNameFromFileInfo(fi), fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void NameTialAddStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }

            string str = Interaction.InputBox("请输入要添加的字符串：", "字符串输入框", "", -1, -1);
            if (str.Length == 0)
                return;

            try
            {



                int count = 0;
                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    if (listViewFiles.Items[i].Selected)
                    {
                        FileInfo fi = new FileInfo(listViewFiles.Items[i].Tag.ToString());
                        string ppath = getUseableFileName(fi.DirectoryName, getSingleFileNameFromFileInfo(fi) + str, fi.Extension);
                        fi.MoveTo(ppath);
                        count++;
                    }
                }
                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void AttriAddReadOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                foreach(ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    if(fi.Exists)
                    {
                        fi.Attributes=(FileAttributes)((int)FileAttributes.ReadOnly | (int)fi.Attributes);
                    }else if(di.Exists)
                    {
                        di.Attributes = (FileAttributes)((int)FileAttributes.ReadOnly | (int)di.Attributes);
                    }
                }

                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void AttriCancelReadOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    if (fi.Exists)
                    {
                        fi.Attributes = (FileAttributes)((~((int)FileAttributes.ReadOnly)) & (int)fi.Attributes);
                    }
                    else if (di.Exists)
                    {
                        di.Attributes = (FileAttributes)((~((int)FileAttributes.ReadOnly)) & (int)di.Attributes);
                    }
                }

                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void AttriAddHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    if (fi.Exists)
                    {
                        fi.Attributes = (FileAttributes)((int)FileAttributes.Hidden | (int)fi.Attributes);
                    }
                    else if (di.Exists)
                    {
                        di.Attributes = (FileAttributes)((int)FileAttributes.Hidden | (int)di.Attributes);
                    }
                }

                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void AttriCancelHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }


            try
            {
                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    if (fi.Exists)
                    {
                        fi.Attributes = (FileAttributes)((~((int)FileAttributes.Hidden)) & (int)fi.Attributes);
                    }
                    else if (di.Exists)
                    {
                        di.Attributes = (FileAttributes)((~((int)FileAttributes.Hidden)) & (int)di.Attributes);
                    }
                }

                refreshCurrentDirectory();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void ShowFloderCheckStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowFloderCheckStateToolStripMenuItem.Checked = !this.ShowFloderCheckStateToolStripMenuItem.Checked;
            refreshCurrentDirectory();
        }

        private void textBoxCurrentPath_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                 EnterPath();
        }

        private void textBoxSearchContent_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchPath();
        }

        private void NameReplaceStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            string oldstr = Interaction.InputBox("请输入要被替换字符串：", "字符串输入框", "", -1, -1);
            if (oldstr.Length == 0)
                return;
            string newstr = Interaction.InputBox("请输入替换字符串：", "字符串输入框", "", -1, -1);

            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                try
                {

                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    string suffix = fi.Extension;
                    string tpname = getUseableFileName(di.Parent.FullName, "_temp_file", ".tmp");
                    if (fi.Exists)
                    {
                        string name = getSingleFileNameFromFileInfo(fi);
                        name = name.Replace(oldstr, newstr);

                        fi.MoveTo(tpname);
                        new FileInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name, suffix));

                    }
                    else if (di.Exists)
                    {
                        string name = getSingleFileNameFromFileInfo(fi);
                        name = name.Replace(oldstr, newstr);

                        di.MoveTo(tpname);
                        new DirectoryInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name, suffix));
                    }
                }
                catch (Exception)
                {

                }
            }

            refreshCurrentDirectory();
        }

        private void FileNameReplaceStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            string oldstr = Interaction.InputBox("请输入要被替换字符串：", "字符串输入框", "", -1, -1);
            if (oldstr.Length == 0)
                return;
            string newstr = Interaction.InputBox("请输入替换字符串：", "字符串输入框", "", -1, -1);

            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                try
                {

                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    string suffix = fi.Extension;
                    string tpname = getUseableFileName(di.Parent.FullName, "_temp_file", ".tmp");
                    if (fi.Exists)
                    {
                        string name = fi.Name;
                        name = name.Replace(oldstr, newstr);

                        fi.MoveTo(tpname);
                        new FileInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name, ""));

                    }
                    else if (di.Exists)
                    {
                        string name = di.Name;
                        name = name.Replace(oldstr, newstr);

                        di.MoveTo(tpname);
                        new DirectoryInfo(tpname).MoveTo(getUseableFileName(di.Parent.FullName, name, ""));
                    }
                }
                catch (Exception)
                {
                    
                }
            }

            refreshCurrentDirectory();
        }

        private void ChoiceOpenMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listViewFiles.SelectedItems.Count==0)
            {
                return;
            }

            foreach(ListViewItem it in listViewFiles.SelectedItems)
            {
                FileInfo fi=new FileInfo(it.Tag.ToString());
                if(fi.Exists)
                {
                    ProcessStartInfo sinfo = new ProcessStartInfo();
                    sinfo.FileName = "rundll32.exe";
                    sinfo.Arguments = "shell32,OpenAs_RunDLL " + fi.FullName;
                    sinfo.WorkingDirectory = fi.DirectoryName;
                    Process.Start(sinfo);
                }
                
            }
        }

        private void cleanEmptyDirectories(DirectoryInfo dir,ref int sumCount,ref int delCount)
        {
            try
            {
                if (dir.Exists == false)
                {
                    return;
                }

                if (dir.GetFileSystemInfos().Length == 0)
                {
                    try
                    {
                        dir.Delete(false);
                        delCount++;
                    }
                    catch (Exception)
                    {
                       
                    }
                    
                }
                else
                {
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo pdir in dirs)
                    {
                        sumCount++;
                        cleanEmptyDirectories(pdir,ref sumCount,ref delCount);
                    }
                }
            }
            catch (Exception)
            {

                
            }
            
        }
        private void cleanEmptyFiles(DirectoryInfo dir, ref int sumCount, ref int delCount)
        {
            try
            {
                if (dir.Exists == false)
                {
                    return;
                }

                if (dir.GetFileSystemInfos().Length > 0)
                {
                    FileInfo[] files = dir.GetFiles();
                    foreach(FileInfo pfile in files)
                    {
                        sumCount++;
                        if (pfile.Length == 0)
                        {
                            try
                            {
                                pfile.Delete();
                                delCount++;
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo pdir in dirs)
                    {
                        cleanEmptyFiles(pdir, ref sumCount, ref delCount);
                    }
                }
            }
            catch (Exception)
            {


            }

        }


        private void CleanEmptyDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"确认对当前显示路径下所有文件树执行【空文件夹清理】操作吗？", "空文件夹清理询问", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            this.StateTipstoolStripStatusLabel.Text = "空文件夹清理正在进行中...";
            int sumCount = 0, delCount = 0;
            cleanEmptyDirectories(new DirectoryInfo(m_currentPath),ref sumCount,ref delCount);
            MessageBox.Show(this,"总共扫描文件夹【" + sumCount + "】，清理空文件夹【" + delCount + "】", "空文件夹清理提示");
            this.StateTipstoolStripStatusLabel.Text = "就绪";
        }

        private void CleanEmptyFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"确认对当前显示路径下所有文件树执行【空文件清理】操作吗？", "空文件清理询问", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            this.StateTipstoolStripStatusLabel.Text = "空文件清理正在进行中...";
            int sumCount = 0, delCount = 0;
            cleanEmptyFiles(new DirectoryInfo(m_currentPath), ref sumCount, ref delCount);
            MessageBox.Show(this,"总共扫描文件【" + sumCount + "】，清理空文件【" + delCount + "】", "空文件清理提示");
            this.StateTipstoolStripStatusLabel.Text = "就绪";
        }

        private void cleanFilesBySuffixes(DirectoryInfo dir,String[] suffixes, ref int sumCount, ref int delCount)
        {
            try
            {
                if (dir.Exists == false)
                {
                    return;
                }

                if (dir.GetFileSystemInfos().Length > 0)
                {
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo pfile in files)
                    {
                        sumCount++;
                        string psuffix = pfile.Extension.ToLower();
                        foreach (string suffix in suffixes)
                        {
                            if (psuffix == suffix.ToLower())
                            {
                                try
                                {
                                    pfile.Delete();
                                    delCount++;
                                }
                                catch (Exception)
                                {

                                }
                                break;
                            }
                        }
                        
                    }
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo pdir in dirs)
                    {
                        cleanFilesBySuffixes(pdir,suffixes, ref sumCount, ref delCount);
                    }
                }
            }
            catch (Exception)
            {


            }

        }
        private void CleanFilesOfSuffixiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确认对当前显示路径下所有文件树执行【指定文件后缀清理】操作吗？", "指定文件后缀清理询问", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            string iline="";
            InputDialog.Show(this,out iline, "请按照如下形式输入你要清理的后缀列表，以换行分割，例如：\r\n.txt\r\n.png\r\n.ogg\r\njpg\r\nlog","后缀输入框");
            iline = iline.Trim();
            if (iline == "")
            {
                MessageBox.Show(this, "无效的输入，执行取消", "检查提示");
                return;
            }

            string sureSuffix = "";
            string[]  suffixes = iline.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < suffixes.Length;i++ )
            {
                if (suffixes[i].StartsWith(".") == false)
                {
                    suffixes[i] = "." + suffixes[i];
                }
                sureSuffix = sureSuffix + " "+suffixes[i];
            }
            if (MessageBox.Show(this, "确认删除这些后缀文件吗？" + "\r\n" + sureSuffix, "确认提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                MessageBox.Show(this, "用户操作终止，执行取消", "检查提示");
                return;
            }


            this.StateTipstoolStripStatusLabel.Text = "指定文件后缀清理正在进行中...";
            int sumCount = 0, delCount = 0;
            cleanFilesBySuffixes(new DirectoryInfo(m_currentPath),suffixes, ref sumCount, ref delCount);
            MessageBox.Show(this, "总共扫描文件【" + sumCount + "】，清理指定文件后缀【" + delCount + "】", "指定文件后缀清理提示");
            this.StateTipstoolStripStatusLabel.Text = "就绪";
        }


        private void WindowToTopmostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !WindowToTopmostToolStripMenuItem.Checked;
            WindowToTopmostToolStripMenuItem.Checked = !WindowToTopmostToolStripMenuItem.Checked;
        }

        double transparentRate = 0.7;
       
        private void WindowToTransparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowToTransparentToolStripMenuItem.Checked == false)
            {
                this.Opacity = transparentRate;
            }
            else
            {
                this.Opacity = 1.0;
            }
            WindowToTransparentToolStripMenuItem.Checked = !WindowToTransparentToolStripMenuItem.Checked;
        }

        private void WindowTransParentRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string outtext=""+transparentRate;
            InputDialog.Show(this, out outtext, "请输入不透明度（0.0-1.0，值越大越不透明），当前：" + transparentRate, "不透明度输入");
            try
            {
                double prate = Convert.ToDouble(outtext);
                if (prate >= 0.0 && prate <= 1.0)
                {
                    transparentRate = prate;
                }
                if (WindowToTransparentToolStripMenuItem.Checked == true)
                {
                    this.Opacity = transparentRate;
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        private void WindowWhiteBecomeFullTransparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowWhiteBecomeFullTransparentToolStripMenuItem.Checked == false)
            {
                this.BackColor = Color.FromArgb(255,0,1,1);
                this.panelMainView.BackColor = this.BackColor;
                this.listViewFiles.BackColor = this.BackColor;
                this.menuStripMain.BackColor = this.BackColor;
                this.splitContainerControl.BackColor = this.BackColor;
                this.statusStripMain.BackColor = this.BackColor;
               
                this.TransparencyKey = this.BackColor;
            }
            else
            {
                this.BackColor = Color.White;
                this.panelMainView.BackColor = this.BackColor;
                this.listViewFiles.BackColor = this.BackColor;
                this.menuStripMain.BackColor = this.BackColor;
                this.splitContainerControl.BackColor = this.BackColor;
                this.statusStripMain.BackColor = this.BackColor;

                this.TransparencyKey = Color.FromArgb(0,0,1,1);
            }
            WindowWhiteBecomeFullTransparentToolStripMenuItem.Checked = !WindowWhiteBecomeFullTransparentToolStripMenuItem.Checked;
        }

        public enum ViewSubTreeFlag
        {
            MaxSize,
            LastModify,
            OldestCreate,
            LastAccess,
            OldestNotModify
        }
        private void ViewBigFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewFilesProxy(ViewSubTreeFlag.MaxSize, 256);
        }
        private void ViewLastModifyFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewFilesProxy(ViewSubTreeFlag.LastModify,512);
        }

        private void ViewOldestCreateFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewFilesProxy(ViewSubTreeFlag.OldestCreate,512);
        }
        private void ViewLastAccessFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewFilesProxy(ViewSubTreeFlag.LastAccess, 512);
        }
        private void ViewOldestNotModifyFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewFilesProxy(ViewSubTreeFlag.OldestNotModify, 512);
        }
        private void ViewFilesProxy(ViewSubTreeFlag flag,int maxCount)
        {
            this.listViewFiles.Items.Clear();
            List<FileInfo> maxSiseDescList = new List<FileInfo>();

            getTargetViewList(flag, new DirectoryInfo(m_currentPath), ref maxSiseDescList, maxCount);

            for (int i = 0; i < maxSiseDescList.Count; i++)
            {
                FileInfo pfile = maxSiseDescList[i];

                ListViewItem item = new ListViewItem();
                FileItemInfo finfo = new FileItemInfo(pfile.FullName,m_isAnaliesCache,m_analiesFileInfoCache, m_isAnaliesDirectory, m_isNeedFileCheckCode);
                item.Text = pfile.Name;
                item.Tag = finfo;
                if (pfile.Extension == null || pfile.Extension == "")
                {
                    item.ImageKey = "unkown";
                }
                else
                {
                    if (this.imageListMain.Images.Keys.Contains(pfile.Extension) == false)
                    {
                        Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(pfile.FullName);
                        this.imageListMain.Images.Add(pfile.Extension, icon);
                    }
                    item.ImageKey = pfile.Extension;
                }
                item.SubItems.Add(finfo.type);

                item.SubItems.Add(fileSizeToString(finfo.size));
                item.SubItems.Add(fileAttributeToString(finfo.attribute));
                item.SubItems.Add(finfo.lastWriteTime.ToString());
                item.SubItems.Add(finfo.createTime.ToString());
                item.SubItems.Add(finfo.lastAccessTime.ToString());
                item.SubItems.Add(finfo.checkCode);
                this.listViewFiles.Items.Add(item);
            }
        }
        private bool isViewFlagFile(ViewSubTreeFlag flag,bool isLast,FileInfo inListFile, FileInfo currentFile)
        {
            bool ret = false;
            if(flag==ViewSubTreeFlag.MaxSize)
            {
                if (isLast)
                    ret = inListFile.Length >= currentFile.Length;
                else
                    ret = inListFile.Length <= currentFile.Length;
            }else if(flag==ViewSubTreeFlag.LastModify)
            {
                if (isLast)
                    ret = inListFile.LastWriteTimeUtc >= currentFile.LastWriteTimeUtc;
                else
                    ret = inListFile.LastWriteTimeUtc <= currentFile.LastWriteTimeUtc;
            }
            else if (flag == ViewSubTreeFlag.OldestCreate)
            {
                if (isLast)
                    ret = inListFile.CreationTimeUtc <= currentFile.CreationTimeUtc;
                else
                    ret = inListFile.CreationTimeUtc >= currentFile.CreationTimeUtc;
            }
            else if (flag == ViewSubTreeFlag.LastAccess)
            {
                if (isLast)
                    ret = inListFile.LastAccessTimeUtc >= currentFile.LastAccessTimeUtc;
                else
                    ret = inListFile.LastAccessTimeUtc <= currentFile.LastAccessTimeUtc;
            }
            else if (flag == ViewSubTreeFlag.OldestNotModify)
            {
                if (isLast)
                    ret = inListFile.LastWriteTimeUtc <= currentFile.LastWriteTimeUtc;
                else
                    ret = inListFile.LastWriteTimeUtc >= currentFile.LastWriteTimeUtc;
            }
            return ret;
        }
        private void getTargetViewList(ViewSubTreeFlag flag,DirectoryInfo inDir, ref List<FileInfo> maxSiseDescList, int maxCount)
        {
            try
            {
                if (inDir.Exists == false)
                    return;
                FileInfo[] files = inDir.GetFiles();
                foreach (FileInfo pfile in files)
                {
                    if(maxSiseDescList.Count==0)
                    {
                        maxSiseDescList.Add(pfile);
                        continue;
                    }
                    if (maxSiseDescList.Count < maxCount && isViewFlagFile(flag,true,maxSiseDescList[maxSiseDescList.Count - 1], pfile))
                    {
                        maxSiseDescList.Add(pfile);
                        continue;
                    }
                    for (int i = 0; i < maxSiseDescList.Count; i++)
                    {
                        if (isViewFlagFile(flag,false,maxSiseDescList[i] , pfile))
                        {
                           if(maxSiseDescList.Count<maxCount)
                           {
                               maxSiseDescList.Insert(i, pfile);
                           }
                           else
                           {
                               maxSiseDescList[i] = pfile;
                           }
                           break;
                        }
                    }


                }

                DirectoryInfo[] dirs = inDir.GetDirectories();
                foreach (DirectoryInfo pdir in dirs)
                {
                    getTargetViewList(flag,pdir, ref maxSiseDescList, maxCount);
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        private void listViewFiles_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            try
            {

                FileItemInfo fitem = e.Item.Tag as FileItemInfo;
                e.Item.ToolTipText = fitem.path;
            }
            catch (Exception)
            {
                
            }
        }

        private void ConvertEncodingUTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyConvertEncodingTo(Encoding.UTF8);
        }

        private void ConvertEncodingASCIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyConvertEncodingTo(Encoding.ASCII);
        }

        private void ConvertEncodingUnicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyConvertEncodingTo(Encoding.Unicode);
        }

        private void ConvertEncodingGBKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyConvertEncodingTo(Encoding.GetEncoding("GBK"));
        }

        private void ConvertEncodingGB2312ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyConvertEncodingTo(Encoding.GetEncoding("GB2312"));
        }

        private void ConvertEncodingISO8859ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyConvertEncodingTo(Encoding.GetEncoding("ISO-8859-1"));
        }

        private void ConvertEncodingUnicodeBigEndianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyConvertEncodingTo(Encoding.BigEndianUnicode);
        }

        private void ConvertEncodingUTF32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyConvertEncodingTo(Encoding.UTF32);
        }

        private void ConvertEncodingUTF7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyConvertEncodingTo(Encoding.UTF7);
        }

        private void proxyConvertEncodingTo(Encoding descEncode)
        {
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }
            if (MessageBox.Show(this,
                            "是否需要进行编码转换？\n\t此操作不可逆，可能会转码失败，你可能需要提前备份源文件\n\t否则一旦转码失败，文件将会乱码，无法恢复",
                            "文件编码转换为：" + descEncode.WebName,
                            MessageBoxButtons.YesNo) == DialogResult.No)
            {
                MessageBox.Show(this, "编码转换已取消", "编码转换提示");
                return;
            }

            bool firstRequireDirectoryState = true;
            bool needProcessDirectory = false;
            foreach (ListViewItem it in listViewFiles.SelectedItems)
            {
                try
                {

                    FileInfo fi = new FileInfo(it.Tag.ToString());
                    DirectoryInfo di = new DirectoryInfo(it.Tag.ToString());
                    if (fi.Exists)
                    {
                        convertFileEncodeTo(fi.FullName, descEncode);
                    }
                    else if (di.Exists)
                    {
                        if (firstRequireDirectoryState)
                        {
                            if (MessageBox.Show(this,
                                "是否需要处理整个文件夹的编码？\n\t除非你确定要这样做，否则不建议你同意此操作",
                                "文件编码转换为：" + descEncode.WebName,
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                needProcessDirectory = true;
                            }
                        }
                        if (needProcessDirectory)
                        {
                            //do process directories encode
                            convertEncoding4DirectoryFilesTo(di, descEncode);
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
            }

            refreshCurrentDirectory();
        }

        private void convertEncoding4DirectoryFilesTo(DirectoryInfo dir,Encoding descEncode)
        {
            try
            {

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo pfile in files)
                {
                    convertFileEncodeTo(pfile.FullName, descEncode);
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo pdir in dirs)
                {
                    convertEncoding4DirectoryFilesTo(pdir, descEncode);
                }

            }
            catch (Exception)
            {
                
            }
        }

        private void SearchInNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string keyWd = "";
            int selCount = listViewFiles.SelectedItems.Count;
            if (selCount == 0)
            {
                keyWd = Interaction.InputBox("请输入搜索内容：", "搜索输入框", "", -1, -1);

            }
            else
            {
                foreach (ListViewItem it in listViewFiles.SelectedItems)
                {
                    FileInfo fi = new FileInfo(it.Tag.ToString());

                    keyWd = fi.Name;
                    

                    break;
                }
            }
            ProcessStartInfo si=new ProcessStartInfo("cmd","/c explorer \"https://www.baidu.com/s?wd=" + keyWd + "\"");
            si.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(si);
        }

        class TipsItemInfo
        {
            public string name;
            public string path;
            public bool isFile;
            public TipsItemInfo(string path,string prefix="")
            {
                FileInfo fi = new FileInfo(path);
                if (fi.Exists)
                {
                    isFile = true;
                }
                else
                {
                    isFile = false;
                }
                this.name = (isFile?"- ":"+ ")+prefix+fi.Name;
                this.path = fi.FullName;
               
            }
            public override string ToString()
            {
                return this.name;
            }
        }

        private void textBoxCurrentPath_TextChanged(object sender, EventArgs e)
        {
            string curPath = this.textBoxCurrentPath.Text;
            this.TipRelativePathsToolStripComboBox.Items.Clear();

            List<TipsItemInfo> rel = getRelativeFileInfos(curPath);
            int maxLen=0;
            if (rel.Count > 0)
            {
                foreach (TipsItemInfo p in rel)
                {
                    if(p.name.Length>maxLen){
                        maxLen=p.name.Length;
                    }
                    this.TipRelativePathsToolStripComboBox.Items.Add(p);
                }

                this.TipRelativePathsToolStripComboBox.DropDownWidth = 9 * maxLen;
            }

        }
        private void TipRelativePathsToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TipRelativePathsToolStripComboBox.SelectedItem != null)
            {
                TipsItemInfo ti=this.TipRelativePathsToolStripComboBox.SelectedItem as TipsItemInfo;
                updateCurrentPath(ti.path);
                EnterPath();
            }
        }


        private List<TipsItemInfo> getRelativeFileInfos(string path)
        {
            List<TipsItemInfo> ret = new List<TipsItemInfo>();
            if (path == null || path.Length == 0)
            {
                return ret;
            }
            try
            {
                //直接就是文件
                FileInfo inPath = new FileInfo(path);
                if (inPath.Exists)
                {
                    ret.Add(new TipsItemInfo(inPath.FullName));
                    return ret;
                }
                //直接是文件夹
                DirectoryInfo inDir = new DirectoryInfo(path);
                if (inDir.Exists)
                {
                    ret.Add(new TipsItemInfo(inDir.FullName));
                    string prefix = inDir.Name+"\\";

                    FileInfo[] cfiles = inDir.GetFiles();
                    foreach (FileInfo pf in cfiles)
                    {
                        ret.Add(new TipsItemInfo(pf.FullName, prefix));
                    }

                    DirectoryInfo[] cdirs = inDir.GetDirectories();
                    foreach (DirectoryInfo pd in cdirs)
                    {
                        ret.Add(new TipsItemInfo(pd.FullName,prefix));
                    }

                    return ret;
                }
                //执行同文件夹下模糊查询
                string keywd = inPath.Name.ToLower();
                DirectoryInfo parent = inDir.Parent;

                FileInfo[] files = parent.GetFiles();
                foreach (FileInfo pf in files)
                {
                    string name = pf.Name.ToLower();
                    if (name.IndexOf(keywd) >= 0)
                    {
                        ret.Add(new TipsItemInfo(pf.FullName));
                    }

                }

                DirectoryInfo[] dirs = parent.GetDirectories();
                foreach (DirectoryInfo pd in dirs)
                {
                    string name = pd.Name.ToLower();
                    if (name.IndexOf(keywd) >= 0)
                    {
                        ret.Add(new TipsItemInfo(pd.FullName));
                    }
                }

            }
            catch (Exception)
            {

            }
            return ret;
        }

        private void OnlyExistFileSizeEqualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OnlyExistFileSizeEqualToolStripMenuItem.Checked = !this.OnlyExistFileSizeEqualToolStripMenuItem.Checked;
            if(!this.OnlyExistFileSizeEqualToolStripMenuItem.Checked
                && this.OnlyExistCheckCodeEqualToolStripMenuItem.Checked)
            {
                this.OnlyExistCheckCodeEqualToolStripMenuItem.Checked = false;
            }
            refreshCurrentDirectory();
        }

        private void OnlyExistCheckCodeEqualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OnlyExistCheckCodeEqualToolStripMenuItem.Checked = !this.OnlyExistCheckCodeEqualToolStripMenuItem.Checked;
            if (this.OnlyExistCheckCodeEqualToolStripMenuItem.Checked)
            {
                this.OnlyExistFileSizeEqualToolStripMenuItem.Checked = true;
            }
            m_isNeedFileCheckCode = this.OnlyExistCheckCodeEqualToolStripMenuItem.Checked;
            this.AnaliesFileCheckCodeFToolStripMenuItem.Checked = m_isNeedFileCheckCode;
            refreshCurrentDirectory();
        }

        private void onlyShowExistFilter()
        {
            SortType sortType = SortType.None;
            if (this.OnlyExistFileSizeEqualToolStripMenuItem.Checked)
            {
                sortType = SortType.Size;
            }
            if (this.OnlyExistCheckCodeEqualToolStripMenuItem.Checked)
            {
                sortType = SortType.CheckCode;
            }
            if (sortType==SortType.None)
            {
                return;
            }

            int itemsCount=listViewFiles.Items.Count;
            if (itemsCount == 0)
            {
                return;
            }
            ListViewItem[] itemsArr=new ListViewItem[itemsCount];
            for (int i = 0; i < itemsArr.Length;i++ )
            {
                itemsArr[i]=listViewFiles.Items[i];
            }

            SortType oldSort = m_sortType;
            m_sortType = sortType;
            sortItemsArray(itemsArr);
            m_sortType = oldSort;

            if (sortType == SortType.CheckCode)
            {
                m_isNeedFileCheckCode = false;
                this.AnaliesFileCheckCodeFToolStripMenuItem.Checked = m_isNeedFileCheckCode;
                this.OnlyExistCheckCodeEqualToolStripMenuItem.Checked = false;
            }

            this.listViewFiles.Items.Clear();

            List<ListViewItem> items = new List<ListViewItem>();
            int index = 0;
            while (index < itemsArr.Length)
            {
                FileItemInfo pit = itemsArr[index].Tag as FileItemInfo;
                if (!pit.isFile)
                {
                    this.listViewFiles.Items.Add(itemsArr[index]);
                    index++;
                    continue;
                }

                if (sortType == SortType.Size)
                {
                    int jx = index+1;
                    while (jx < itemsArr.Length)
                    {
                        FileItemInfo pjx = itemsArr[jx].Tag as FileItemInfo;
                        if (pjx.size == pit.size)
                        {
                            itemsArr[jx].Selected = true;
                            this.listViewFiles.Items.Add(itemsArr[jx]);
                        }
                        else
                        {
                            break;
                        }
                        jx++;
                    }
                    if (jx != index + 1)
                    {
                        itemsArr[index].Selected = false;
                        this.listViewFiles.Items.Add(itemsArr[index]);
                        index = jx;
                    }
                    index = jx;
                }
                else if (sortType == SortType.CheckCode)
                {
                    int jx = index + 1;
                    while (jx < itemsArr.Length)
                    {
                        FileItemInfo pjx = itemsArr[jx].Tag as FileItemInfo;
                        if (pjx.checkCode == pit.checkCode)
                        {
                            itemsArr[jx].Selected = true;
                            this.listViewFiles.Items.Add(itemsArr[jx]);
                        }
                        else
                        {
                            break;
                        }
                        jx++;
                    }
                    if (jx != index + 1)
                    {
                        itemsArr[index].Selected = false;
                        this.listViewFiles.Items.Add(itemsArr[index]);
                    }
                    index = jx;
                }

            }

        }

        private bool needClosepleChildren=false;
        private string m_timeClosepleFormat = "yyyy-MM";

        private void ClosepleByTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir=new DirectoryInfo(m_currentPath);
            closepleFiles(dir, ClosepleType.Type, needClosepleChildren);
            this.ClosepleChildrenToolStripMenuItem.Checked = false;
            this.needClosepleChildren = false;
            this.refreshCurrentDirectory();
        }

        private void ClosepleByUpdateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(m_currentPath);
            closepleFiles(dir, ClosepleType.UpdateTime, needClosepleChildren);
            this.ClosepleChildrenToolStripMenuItem.Checked = false;
            this.needClosepleChildren = false;
            this.refreshCurrentDirectory();
        }

        private void ClosepleByCreateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(m_currentPath);
            closepleFiles(dir, ClosepleType.CreateTime, needClosepleChildren);
            this.ClosepleChildrenToolStripMenuItem.Checked = false;
            this.needClosepleChildren = false;
            this.refreshCurrentDirectory();
        }

        private void ClosepleChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ClosepleChildrenToolStripMenuItem.Checked=!this.ClosepleChildrenToolStripMenuItem.Checked;
            this.needClosepleChildren = this.ClosepleChildrenToolStripMenuItem.Checked;
        }

        public enum ClosepleType
        {
            Type = 1,
            CreateTime = 2,
            UpdateTime = 3
        }
        public void closepleFiles(DirectoryInfo dir, ClosepleType closepleType, bool needChildren)
        {
            if (dir == null || !dir.Exists)
            {
                return;
            }
            if (needChildren)
            {
                try
                {
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo pdir in dirs)
                    {
                        closepleFiles(pdir, closepleType, needChildren);
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            try
            {

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo item in files)
                {
                    if (closepleType == ClosepleType.Type)
                    {
                        string type = FileSpecies.getFileSpecies(item.FullName);
                        fileMove2ClosepleDir(item, type, dir);
                    }
                    else if (closepleType == ClosepleType.CreateTime)
                    {
                        DateTime date = item.CreationTime;
                        string str = date.ToString(m_timeClosepleFormat);
                        fileMove2ClosepleDir(item, str, dir);
                    }
                    else if (closepleType == ClosepleType.UpdateTime)
                    {
                        DateTime date = item.LastWriteTime;
                        string str = date.ToString(m_timeClosepleFormat);
                        fileMove2ClosepleDir(item, str, dir);
                    }

                }
            }
            catch (Exception)
            {
                
            }
            
        }
        public void fileMove2ClosepleDir(FileInfo item, string closepleDir, DirectoryInfo saveDir)
        {
            try
            {
                DirectoryInfo newDir = new DirectoryInfo(saveDir.FullName + '\\' + closepleDir);
                if (!newDir.Exists)
                {
                    newDir.Create();
                }
                FileInfo newFile = new FileInfo(newDir.FullName + '\\' + item.Name);
                item.MoveTo(newFile.FullName);
            }
            catch (Exception)
            {
                
            }
        }

        private void TimeInYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_timeClosepleFormat = "yyyy";
            this.TimeInYearToolStripMenuItem.Checked = true;
            this.TimeInMonthToolStripMenuItem.Checked = false;
            this.TimeInDayToolStripMenuItem.Checked = false;
            this.TimeInHourToolStripMenuItem.Checked = false;
        }

        private void TimeInMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_timeClosepleFormat = "yyyy-MM";
            this.TimeInYearToolStripMenuItem.Checked = false;
            this.TimeInMonthToolStripMenuItem.Checked = true;
            this.TimeInDayToolStripMenuItem.Checked = false;
            this.TimeInHourToolStripMenuItem.Checked = false;
        }

        private void TimeInDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_timeClosepleFormat = "yyyy-MM-dd";
            this.TimeInYearToolStripMenuItem.Checked = false;
            this.TimeInMonthToolStripMenuItem.Checked = false;
            this.TimeInDayToolStripMenuItem.Checked = true;
            this.TimeInHourToolStripMenuItem.Checked = false;
        }

        private void TimeInHourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_timeClosepleFormat = "yyyy-MM-dd-HH";
            this.TimeInYearToolStripMenuItem.Checked = false;
            this.TimeInMonthToolStripMenuItem.Checked = false;
            this.TimeInDayToolStripMenuItem.Checked = false;
            this.TimeInHourToolStripMenuItem.Checked = true;
        }


        private bool m_needJoinChildren=false;
        private JoinType m_joinType = JoinType.All;
        private void JoinFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(m_currentPath);
            joinFiles(dir, dir, m_needJoinChildren?-1:2,m_joinType);
            this.JoinChildrenToolStripMenuItem.Checked = false;
            this.m_needJoinChildren = false;
            this.refreshCurrentDirectory();
        }

        private void JoinChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.JoinChildrenToolStripMenuItem.Checked = !this.JoinChildrenToolStripMenuItem.Checked;
            this.m_needJoinChildren = this.JoinChildrenToolStripMenuItem.Checked;
        }

        public enum JoinType
        {
            All=0,
            Pictures=1,
            Videos=2,
            Audios=3,
            Documents=4,
            Compresses=5,
            Executeables=6
        }
        /// <summary>
        /// level >=2 时，按照level进行聚合对应的层次
        /// level==-1时，递归聚合所有层次
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="joinTo"></param>
        /// <param name="level"></param>
        public void joinFiles(DirectoryInfo dir,DirectoryInfo joinTo, int level,JoinType joinType)
        {
            if (level == 0)
            {
                return;
            }
            if (dir == null || !dir.Exists)
            {
                return;
            }


            try
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo pdir in dirs)
                {
                    joinFiles(pdir, joinTo, level - 1,joinType);
                }
            }
            catch (Exception)
            {
                
            }
            
            if (dir.FullName == joinTo.FullName)
            {
                return;
            }
            try
            {
                string[] suffixArr = null;
                if (joinType == JoinType.All)
                {
                    suffixArr = null;
                }
                else if (joinType == JoinType.Pictures)
                {
                    suffixArr = FileSpecies.pictures;
                }
                else if (joinType == JoinType.Videos)
                {
                    suffixArr = FileSpecies.videos;
                }
                else if (joinType == JoinType.Audios)
                {
                    suffixArr = FileSpecies.audios;
                }
                else if (joinType == JoinType.Documents)
                {
                    suffixArr = FileSpecies.documents;
                }
                else if (joinType == JoinType.Compresses)
                {
                    suffixArr = FileSpecies.compresses;
                }
                else if (joinType == JoinType.Executeables)
                {
                    suffixArr = FileSpecies.execuables;
                }
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo pfile in files)
                {
                    bool isTar = false;
                    if (suffixArr == null)
                    {
                        isTar = true;
                    }
                    else
                    {
                        string suffix = pfile.Extension.ToLower();
                        foreach (string isuffix in suffixArr)
                        {
                            if (isuffix == suffix)
                            {
                                isTar = true;
                                break;
                            }
                        }
                    }
                    if (isTar)
                    {
                        move2JoinPath(pfile, joinTo);
                    }
                }
                dir.Delete();
            }
            catch (Exception)
            {
                
            }
        }

        private void move2JoinPath(FileInfo pfile,DirectoryInfo joinTo)
        {
            FileInfo newFile = new FileInfo(joinTo.FullName + '\\' + pfile.Name);
            if (newFile.Exists)
            {
                string suffix = pfile.Extension;
                string name = pfile.Name;
                if (suffix.Length > 0)
                {
                    name = name.Substring(0, name.Length - suffix.Length);
                }
                int i = 1;
                while (true)
                {
                    newFile = new FileInfo(joinTo.FullName + '\\' + name + '-' + i + suffix);
                    if (!newFile.Exists)
                    {
                        pfile.MoveTo(newFile.FullName);
                        break;
                    }
                    i++;
                }
            }
            else
            {
                pfile.MoveTo(newFile.FullName);
            }
        }
        private void JoinTypeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_joinType = JoinType.All;
            this.JoinTypeAllToolStripMenuItem.Checked = true;
            this.JoinTypePicturesToolStripMenuItem.Checked = false;
            this.JoinTypeVideosToolStripMenuItem.Checked = false;
            this.JoinTypeAudiosToolStripMenuItem.Checked = false;
            this.JoinTypeDocumentsToolStripMenuItem.Checked = false;
            this.JoinTypeCompressesToolStripMenuItem.Checked = false;
            this.JoinTypeExcuteablesToolStripMenuItem.Checked = false;
        }

        private void JoinTypePicturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_joinType = JoinType.Pictures;
            this.JoinTypeAllToolStripMenuItem.Checked = false;
            this.JoinTypePicturesToolStripMenuItem.Checked = true;
            this.JoinTypeVideosToolStripMenuItem.Checked = false;
            this.JoinTypeAudiosToolStripMenuItem.Checked = false;
            this.JoinTypeDocumentsToolStripMenuItem.Checked = false;
            this.JoinTypeCompressesToolStripMenuItem.Checked = false;
            this.JoinTypeExcuteablesToolStripMenuItem.Checked = false;
        }

        private void JoinTypeVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_joinType = JoinType.Videos;
            this.JoinTypeAllToolStripMenuItem.Checked = false;
            this.JoinTypePicturesToolStripMenuItem.Checked = false;
            this.JoinTypeVideosToolStripMenuItem.Checked = true;
            this.JoinTypeAudiosToolStripMenuItem.Checked = false;
            this.JoinTypeDocumentsToolStripMenuItem.Checked = false;
            this.JoinTypeCompressesToolStripMenuItem.Checked = false;
            this.JoinTypeExcuteablesToolStripMenuItem.Checked = false;
        }

        private void JoinTypeAudiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_joinType = JoinType.Audios;
            this.JoinTypeAllToolStripMenuItem.Checked = false;
            this.JoinTypePicturesToolStripMenuItem.Checked = false;
            this.JoinTypeVideosToolStripMenuItem.Checked = false;
            this.JoinTypeAudiosToolStripMenuItem.Checked = true;
            this.JoinTypeDocumentsToolStripMenuItem.Checked = false;
            this.JoinTypeCompressesToolStripMenuItem.Checked = false;
            this.JoinTypeExcuteablesToolStripMenuItem.Checked = false;
        }

        private void JoinTypeDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_joinType = JoinType.Documents;
            this.JoinTypeAllToolStripMenuItem.Checked = false;
            this.JoinTypePicturesToolStripMenuItem.Checked = false;
            this.JoinTypeVideosToolStripMenuItem.Checked = false;
            this.JoinTypeAudiosToolStripMenuItem.Checked = false;
            this.JoinTypeDocumentsToolStripMenuItem.Checked = true;
            this.JoinTypeCompressesToolStripMenuItem.Checked = false;
            this.JoinTypeExcuteablesToolStripMenuItem.Checked = false;
        }

        private void JoinTypeCompressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_joinType = JoinType.Compresses;
            this.JoinTypeAllToolStripMenuItem.Checked = false;
            this.JoinTypePicturesToolStripMenuItem.Checked = false;
            this.JoinTypeVideosToolStripMenuItem.Checked = false;
            this.JoinTypeAudiosToolStripMenuItem.Checked = false;
            this.JoinTypeDocumentsToolStripMenuItem.Checked = false;
            this.JoinTypeCompressesToolStripMenuItem.Checked = true;
            this.JoinTypeExcuteablesToolStripMenuItem.Checked = false;
        }

        private void JoinTypeExcuteablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_joinType = JoinType.Executeables;
            this.JoinTypeAllToolStripMenuItem.Checked = false;
            this.JoinTypePicturesToolStripMenuItem.Checked = false;
            this.JoinTypeVideosToolStripMenuItem.Checked = false;
            this.JoinTypeAudiosToolStripMenuItem.Checked = false;
            this.JoinTypeDocumentsToolStripMenuItem.Checked = false;
            this.JoinTypeCompressesToolStripMenuItem.Checked = false;
            this.JoinTypeExcuteablesToolStripMenuItem.Checked = true;
        }

        private void SimiliarFilesCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {

                new SimiliarAnaliesForm().analiesDir(new DirectoryInfo(m_currentPath));

            
        }

        private void RegexSearchOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RegexSearchOpenToolStripMenuItem.Checked = !this.RegexSearchOpenToolStripMenuItem.Checked;
        }

        private void RegexOnlyFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.regexType = RegexSearchTargetType.FileNameOnly;
            this.RegexOnlyFileNameToolStripMenuItem.Checked = !this.RegexOnlyFileNameToolStripMenuItem.Checked;
            if (this.RegexOnlyFileNameToolStripMenuItem.Checked)
            {
                this.RegexFullPathToolStripMenuItem.Checked = false;
                this.RegexOnlyPathToolStripMenuItem.Checked = false;
                this.RegexFileNameToolStripMenuItem.Checked = false;
                this.RegexOnlyExtensionToolStripMenuItem.Checked = false;
            }
        }

        private void RegexFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.regexType = RegexSearchTargetType.FullPath;
            this.RegexFullPathToolStripMenuItem.Checked = !this.RegexFullPathToolStripMenuItem.Checked;
            if (this.RegexFullPathToolStripMenuItem.Checked)
            {
                this.RegexOnlyFileNameToolStripMenuItem.Checked = false;
                this.RegexOnlyPathToolStripMenuItem.Checked = false;
                this.RegexFileNameToolStripMenuItem.Checked = false;
                this.RegexOnlyExtensionToolStripMenuItem.Checked = false;
            }
        }

        private void RegexFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.regexType = RegexSearchTargetType.FileName;
            this.RegexFileNameToolStripMenuItem.Checked = !this.RegexFileNameToolStripMenuItem.Checked;
            if (this.RegexFileNameToolStripMenuItem.Checked)
            {
                this.RegexOnlyFileNameToolStripMenuItem.Checked = false;
                this.RegexOnlyPathToolStripMenuItem.Checked = false;
                this.RegexFullPathToolStripMenuItem.Checked = false;
                this.RegexOnlyExtensionToolStripMenuItem.Checked = false;
            }
        }

        private void RegexOnlyPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.regexType = RegexSearchTargetType.PathOnly;
            this.RegexOnlyPathToolStripMenuItem.Checked = !this.RegexOnlyPathToolStripMenuItem.Checked;
            if (this.RegexOnlyPathToolStripMenuItem.Checked)
            {
                this.RegexOnlyFileNameToolStripMenuItem.Checked = false;
                this.RegexFileNameToolStripMenuItem.Checked = false;
                this.RegexFullPathToolStripMenuItem.Checked = false;
                this.RegexOnlyExtensionToolStripMenuItem.Checked = false;
            }
        }

        private void RegexOnlyExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.regexType = RegexSearchTargetType.ExtensionOnly;
            this.RegexOnlyExtensionToolStripMenuItem.Checked = !this.RegexOnlyExtensionToolStripMenuItem.Checked;
            if (this.RegexOnlyExtensionToolStripMenuItem.Checked)
            {
                this.RegexOnlyFileNameToolStripMenuItem.Checked = false;
                this.RegexFileNameToolStripMenuItem.Checked = false;
                this.RegexFullPathToolStripMenuItem.Checked = false;
                this.RegexOnlyPathToolStripMenuItem.Checked = false;
            }
        }

        private void RegexIgnoreCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RegexIgnoreCaseToolStripMenuItem.Checked = !this.RegexIgnoreCaseToolStripMenuItem.Checked;
        }

        private void FileSplitPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewFiles.SelectedItems.Count == 0)
            {
                return;
            }
            long baseUnitSize = 1;
            string baseUnitDesc = "byte";
            if (this.SplitUnitByteToolStripMenuItem.Checked)
            {
                baseUnitSize = 1;
                baseUnitDesc = "byte";
            }
            else if (this.SplitUnitKbyteToolStripMenuItem.Checked)
            {
                baseUnitSize = 1024;
                baseUnitDesc = "Kb";
            }
            else if (this.SplitUnitMbyteToolStripMenuItem1.Checked)
            {
                baseUnitSize = 1024 * 1024;
                baseUnitDesc = "Mb";
            }
            else if (this.SplitUnitGbyteToolStripMenuItem.Checked)
            {
                baseUnitSize = 1024 * 1024 * 1024;
                baseUnitDesc = "Gb";
            }
            string str = Interaction.InputBox("请输入大小，单位："+baseUnitDesc, "文件拆分大小限定输入框", "", -1, -1);
            str = str.Trim();
            if (!Regex.IsMatch(str, "\\d+"))
            {
                MessageBox.Show(this, "拆分大小应该是一个正整数", "输入错误");
                return;
            }

            long psize = long.Parse(str);

            long size = psize * baseUnitSize;
            foreach (ListViewItem it in this.listViewFiles.SelectedItems)
            {
                FileInfo fi = new FileInfo(it.Tag.ToString());
                if (fi.Exists)
                {
                    FileSplitJoinUtil.splitFile(fi.FullName, m_currentPath, size);
                }

            }
            refreshCurrentDirectory();
        }

        private void FileJoinPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewFiles.SelectedItems.Count == 0)
            {
                return;
            }

            foreach (ListViewItem it in this.listViewFiles.SelectedItems)
            {
                FileInfo fi = new FileInfo(it.Tag.ToString());
                if (fi.Exists)
                {
                    FileSplitJoinUtil.joinFileRecognize(fi.FullName, m_currentPath);
                }

            }
            refreshCurrentDirectory();
        }

        private void splitUnitMenuItemCheckProxy(ToolStripMenuItem item)
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
            items.Add(this.SplitUnitByteToolStripMenuItem);
            items.Add(this.SplitUnitKbyteToolStripMenuItem);
            items.Add(this.SplitUnitMbyteToolStripMenuItem1);
            items.Add(this.SplitUnitGbyteToolStripMenuItem);
            foreach (ToolStripMenuItem pit in items)
            {
                if (pit == item)
                {
                    item.Checked = true;
                }
                else
                {
                    pit.Checked = false;
                }
            }
        }

        private void SplitUnitByteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitUnitMenuItemCheckProxy(this.SplitUnitByteToolStripMenuItem);
        }

        private void SplitUnitKbyteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitUnitMenuItemCheckProxy(this.SplitUnitKbyteToolStripMenuItem);
        }

        private void SplitUnitMbyteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            splitUnitMenuItemCheckProxy(this.SplitUnitMbyteToolStripMenuItem1);
        }

        private void SplitUnitGbyteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitUnitMenuItemCheckProxy(this.SplitUnitGbyteToolStripMenuItem);
        }

        private void FileZipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewFiles.SelectedItems.Count == 0)
            {
                return;
            }

            string defaultName = new DirectoryInfo(m_currentPath).Name;
            string str = Interaction.InputBox("请输入打包后文件名：", "文件名输入框", defaultName, -1, -1);
            if (str.Length==0)
            {
                MessageBox.Show(this, "请输入有效文件名", "输入错误");
                return;
            }
            List<string> paths = new List<string>(1024);
            foreach (ListViewItem it in this.listViewFiles.SelectedItems)
            {
                string path = it.Tag.ToString();
                paths.Add(path);

            }
            FileZipUnzipUtil.zipFiles(paths, m_currentPath, str);
            refreshCurrentDirectory();
        }

        private void FileUnzipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewFiles.SelectedItems.Count == 0)
            {
                return;
            }

            List<string> paths = new List<string>(1024);
            foreach (ListViewItem it in this.listViewFiles.SelectedItems)
            {
                string path = it.Tag.ToString();
                FileInfo fi = new FileInfo(it.Tag.ToString());
                if (fi.Exists)
                {
                    string savePath = m_currentPath + "\\" + fi.Name.Substring(0,fi.Name.Length-fi.Extension.Length);
                    FileZipUnzipUtil.unzipFile(fi.FullName, savePath);
                }

            }
            refreshCurrentDirectory();
        }

        private void SaveDataFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string str=Clipboard.GetText();
                string name = Interaction.InputBox("请输入文件名：", "文件名输入框", "clipboard.txt", -1, -1);
                if (name.Length == 0)
                {
                    MessageBox.Show(this, "请输入有效文件名", "输入错误");
                    return;
                }
                FileInfo file = new FileInfo(m_currentPath + "\\" + name);
                FileStream stream = new FileStream(file.FullName, FileMode.Create);
                StreamWriter writer = new StreamWriter(stream,Encoding.Default);
                writer.Write(str);
                writer.Close();
                stream.Close();
                refreshCurrentDirectory();
            }
            else if (Clipboard.ContainsImage())
            {
                Image img=Clipboard.GetImage();
                string name = Interaction.InputBox("请输入文件名：", "文件名输入框", "clipboard.png", -1, -1);
                if (name.Length == 0)
                {
                    MessageBox.Show(this, "请输入有效文件名", "输入错误");
                    return;
                }
                FileInfo file = new FileInfo(m_currentPath + "\\" + name);
                FileStream stream = new FileStream(file.FullName, FileMode.Create);
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();
                refreshCurrentDirectory();
            }
            else
            {
                MessageBox.Show(this, "剪切板无数据或不支持的类型", "执行错误");
            }
        }

       private void ControlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe");
        }
        

        private void MspaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint.exe");
        }

        private void NotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void RegeditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("regedit.exe");
        }

        private void ComputerAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe", "system");
        }

        private void SystemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("msinfo32.exe"); 
        }

        private void UACControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("UserAccountControlSettings.exe");
        }

        private void ProgramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("appwiz.cpl");
        }

        private void WindowsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("winver.exe");
        }

        private void ManagementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("compmgmt.msc");
        }

        private void FirewallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe", "firewall.cpl");
        }

        private void NetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe", "ncpa.cpl");
        }

        private void MouseSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe", "main.cpl");
        }

        private void PowerOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe", "powercfg.cpl");
        }

        private void SettingsCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo("cmd", "/c start ms-settings:wheel");
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
        }

        private void ComputerRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo("cmd", "/c start ms-settings:recovery");
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
        }

        private void setRightMenuItem(bool delKey)
        {
            try
            {
                string selfPath = "\"" + Process.GetCurrentProcess().MainModule.FileName + "\"";
                RegistryKey regKey = Registry.ClassesRoot;
                RegistryKey shellKey = regKey.OpenSubKey("Directory\\Background\\shell",//"*\\shell",
                    true);
                //操作注册表属于高级操作，需要配置Properties-app.manifest,如果文件不存在，则双击Properties-安全性-勾上那个复选框即可
                //设置控制权限，有时候会用到
                //System.Security.AccessControl.RegistrySecurity rs= new System.Security.AccessControl.RegistrySecurity();
                //rs.AddAccessRule(new System.Security.AccessControl.RegistryAccessRule("system",
                //    System.Security.AccessControl.RegistryRights.FullControl,
                //    System.Security.AccessControl.AccessControlType.Allow));
                //shellKey.SetAccessControl(rs);

                if (!delKey)
                {
                    RegistryKey targetKey = shellKey.CreateSubKey("FileAnaliesTool");
                    targetKey.SetValue("icon", selfPath + ",0", RegistryValueKind.String);

                    RegistryKey cmdKey = targetKey.CreateSubKey("command");
                    cmdKey.SetValue("", selfPath + " \"%V\"", RegistryValueKind.String);

                    cmdKey.Close();
                    targetKey.Close();
                }
                else
                {
                    shellKey.DeleteSubKeyTree("FileAnaliesTool", false);
                }

                shellKey.Close();
            }
            catch (Exception)
            {

            }

            try
            {
                string selfPath = "\"" + Process.GetCurrentProcess().MainModule.FileName + "\"";
                RegistryKey regKey = Registry.ClassesRoot;
                RegistryKey shellKey = regKey.OpenSubKey("*\\shell",//"*\\shell",
                    true);
                //操作注册表属于高级操作，需要配置Properties-app.manifest,如果文件不存在，则双击Properties-安全性-勾上那个复选框即可
                //设置控制权限，有时候会用到
                //System.Security.AccessControl.RegistrySecurity rs= new System.Security.AccessControl.RegistrySecurity();
                //rs.AddAccessRule(new System.Security.AccessControl.RegistryAccessRule("system",
                //    System.Security.AccessControl.RegistryRights.FullControl,
                //    System.Security.AccessControl.AccessControlType.Allow));
                //shellKey.SetAccessControl(rs);

                if (!delKey)
                {
                    RegistryKey targetKey = shellKey.CreateSubKey("FileAnaliesTool");
                    targetKey.SetValue("icon", selfPath + ",0", RegistryValueKind.String);

                    RegistryKey cmdKey = targetKey.CreateSubKey("command");
                    cmdKey.SetValue("", selfPath + " \"%1\"", RegistryValueKind.String);

                    cmdKey.Close();
                    targetKey.Close();
                }
                else
                {
                    shellKey.DeleteSubKeyTree("FileAnaliesTool", false);
                }
                shellKey.Close();
            }
            catch (Exception)
            {

            }
        }

        private void Attach2RightContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             //文件上右键
             
            [HKEY_CLASSES_ROOT\*\shell\FileAnaliesTool]
            @="文件分析仪"
            "icon"="E:\\文件分析仪.exe"

            [HKEY_CLASSES_ROOT\*\shell\FileAnaliesTool\command]
            @="E:\\文件分析仪.exe %1"

            //文件夹上右键
             [HKEY_CLASSES_ROOT\Directory\background\shell\FileAnaliesTool]
            "icon"="\"E:\\文件分析仪.exe\",0"

            [HKEY_CLASSES_ROOT\Directory\background\shell\FileAnaliesTool\command]
            @="\"E:\\文件分析仪.exe\" \"%V\""
             */

            setRightMenuItem(false);

        }

        private void Dettach2RightContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setRightMenuItem(true);
        }

        private void Add2SysFileRightCOntextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem it in this.listViewFiles.SelectedItems)
                {
                    string selPath = it.Tag.ToString().Trim();
                    addExtendsRightMenu(true, selPath);
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }


        private void addExtendsRightMenu(bool fileContext,string fileName)
        {
            try
            {
                /*
                 [HKEY_CLASSES_ROOT\Directory\background\shell\MyCommand]
                "icon"="cmd.exe,0"
                "SubCommands"="MyCMD;MyPS;"
                @=""
                "MUIVerb"="命令行"

                [HKEY_CLASSES_ROOT\Directory\background\shell\MyCommand\shell]

                [HKEY_CLASSES_ROOT\Directory\background\shell\MyCommand\shell\MyCMD]
                @="CMD"
                "icon"="cmd.exe,0"

                [HKEY_CLASSES_ROOT\Directory\background\shell\MyCommand\shell\MyCMD\command]
                @="cmd.exe /s /k pushd \"%V\""
                 */

                FileInfo file = new FileInfo(fileName);
                string displayName = file.Name;
                displayName = Interaction.InputBox("请输入名称：\n对文件：\n" + fileName, "右键菜单显示名称输入框", displayName, -1, -1);
                displayName = displayName.Trim();
                if (displayName == "")
                {
                    MessageBox.Show("文件名称为空，不添加此右键菜单项");
                    return;
                }


                string subKeyPath = "Directory\\Background\\shell";
                if(fileContext){
                    subKeyPath = "*\\shell";
                }

                string selfPath = "\"" + Process.GetCurrentProcess().MainModule.FileName + "\"";
                RegistryKey regKey = Registry.ClassesRoot;
                RegistryKey shellKey = regKey.OpenSubKey(subKeyPath,//"*\\shell",
                    true);

                RegistryKey targetKey = shellKey.CreateSubKey("FileAnaliesToolExtend");
                targetKey.SetValue("", "", RegistryValueKind.String);
                targetKey.SetValue("icon", selfPath + ",0", RegistryValueKind.String);
                targetKey.SetValue("MUIVerb", "右键拓展", RegistryValueKind.String);

                string subs = targetKey.GetValue("SubCommands", "") as string;

                RegistryKey groupKey = targetKey.CreateSubKey("shell");

                
                string keyName ="SUB"+ md5(fileName).ToUpper();
                RegistryKey addKey=groupKey.CreateSubKey(keyName);
                addKey.SetValue("", displayName);
                addKey.SetValue("icon", "");


                RegistryKey cmdKey = addKey.CreateSubKey("command");

                string cmd = "explorer \"" + fileName + "\"";
                if (file.Exists)
                {
                    if (file.Extension != null)
                    {
                        if (file.Extension.ToLower() == ".exe")
                        {
                            cmd = "\"" + fileName + "\"" + " \"%V\"";
                            if (fileContext)
                            {
                                cmd = "\"" + fileName + "\"" + " \"%1\"";
                            }
                            addKey.SetValue("icon", "\"" + fileName + "\",0");
                        }
                    }
                }

                cmdKey.SetValue("",cmd , RegistryValueKind.String);

                cmdKey.Close();

                addKey.Close();

                groupKey.Close();

                subs = subs + keyName + ";";
                targetKey.SetValue("SubCommands",subs,RegistryValueKind.String);

                targetKey.Close();


                shellKey.Close();
            }
            catch (Exception)
            {

            }
        }

        public static string md5(string str)
        {
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] bytValue, bytHash;
                bytValue = System.Text.Encoding.UTF8.GetBytes(str);
                bytHash = md5.ComputeHash(bytValue);
                md5.Clear();
                string sTemp = "";
                for (int i = 0; i < bytHash.Length; i++)
                {
                    sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
                }
                str = sTemp.ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return str;
        }

        private void Add2SysDirectoryRightContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem it in this.listViewFiles.SelectedItems)
                {
                    string selPath = it.Tag.ToString().Trim();
                    addExtendsRightMenu(false,selPath);
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void ManageSysFileContextMenuToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem parentItem = this.ManageSysFileContextMenuToolStripMenuItem;
            renderManageSysRightContextMenuItems(parentItem, true);
        }

        private void onDeleteDirectoryRightConetxtMenuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            object[] args = item.Tag as object[];
            bool fileContext = (bool)args[0];
            string name = args[1] as string;

            string subKeyPath="Directory\\Background\\shell";
            if(fileContext){
                subKeyPath="*\\shell";
            }

            RegistryKey regKey = Registry.ClassesRoot;
            RegistryKey shellKey = regKey.OpenSubKey(subKeyPath,//"*\\shell",
                true);

            RegistryKey targetKey = shellKey.CreateSubKey("FileAnaliesToolExtend");

            string subs = targetKey.GetValue("SubCommands", "") as string;

            RegistryKey groupKey = targetKey.CreateSubKey("shell");

            groupKey.DeleteSubKeyTree(name, false);

            subs=subs.Replace(name + ";", "");
            targetKey.SetValue("SubCommands", subs);

            if (subs == "")
            {
                groupKey.Close();
                targetKey.Close();
                shellKey.DeleteSubKeyTree("FileAnaliesToolExtend",false);
            }
            else
            {
                groupKey.Close();
                targetKey.Close();
                shellKey.Close();
            }
        }

        private void renderManageSysRightContextMenuItems(ToolStripMenuItem parentItem,bool fileContext)
        {
            
            parentItem.DropDown.Items.Clear();

            string subKeyPath = "Directory\\Background\\shell";
            if (fileContext)
            {
                subKeyPath = "*\\shell";
            }
            RegistryKey regKey = Registry.ClassesRoot;
            RegistryKey shellKey = regKey.OpenSubKey(subKeyPath,//"*\\shell",
                true);

            RegistryKey targetKey = shellKey.CreateSubKey("FileAnaliesToolExtend");

            string subs = targetKey.GetValue("SubCommands", "") as string;

            RegistryKey groupKey = targetKey.CreateSubKey("shell");

            string[] names = groupKey.GetSubKeyNames();

            foreach (string name in names)
            {
                RegistryKey itemKey = groupKey.OpenSubKey(name);
                String text = itemKey.GetValue("", "") as string;
                itemKey.Close();
                ToolStripMenuItem menuItem = new ToolStripMenuItem(text);

                ToolStripMenuItem opeDelItem = new ToolStripMenuItem("删除", null, new EventHandler(onDeleteDirectoryRightConetxtMenuClick));
                opeDelItem.Tag =new object[]{fileContext,name};

                menuItem.DropDown.Items.Add(opeDelItem);

                parentItem.DropDown.Items.Add(menuItem);
            }

            groupKey.Close();
            targetKey.Close();
            shellKey.Close();
        }
        private void ManageSysDirectoryRightContextMenuToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem parentItem = this.ManageSysDirectoryRightContextMenuToolStripMenuItem;
            renderManageSysRightContextMenuItems(parentItem,false);

        }

        private void addExtendsRightMenu(bool fileContext, string icon,string text,string command)
        {
            try
            {
                /*
                 [HKEY_CLASSES_ROOT\Directory\background\shell\MyCommand]
                "icon"="cmd.exe,0"
                "SubCommands"="MyCMD;MyPS;"
                @=""
                "MUIVerb"="命令行"

                [HKEY_CLASSES_ROOT\Directory\background\shell\MyCommand\shell]

                [HKEY_CLASSES_ROOT\Directory\background\shell\MyCommand\shell\MyCMD]
                @="CMD"
                "icon"="cmd.exe,0"

                [HKEY_CLASSES_ROOT\Directory\background\shell\MyCommand\shell\MyCMD\command]
                @="cmd.exe /s /k pushd \"%V\""
                 */

                string displayName = text;
                displayName = displayName.Trim();
                if (displayName == "")
                {
                    MessageBox.Show("文件名称为空，不添加此右键菜单项");
                    return;
                }
                if (command == "")
                {
                    MessageBox.Show("运行命令为空，不添加此右键菜单项");
                    return;
                }


                string subKeyPath = "Directory\\Background\\shell";
                if (fileContext)
                {
                    subKeyPath = "*\\shell";
                }

                string selfPath = "\"" + Process.GetCurrentProcess().MainModule.FileName + "\"";
                RegistryKey regKey = Registry.ClassesRoot;
                RegistryKey shellKey = regKey.OpenSubKey(subKeyPath,//"*\\shell",
                    true);

                RegistryKey targetKey = shellKey.CreateSubKey("FileAnaliesToolExtend");
                targetKey.SetValue("", "", RegistryValueKind.String);
                targetKey.SetValue("icon", selfPath + ",0", RegistryValueKind.String);
                targetKey.SetValue("MUIVerb", "右键拓展", RegistryValueKind.String);

                string subs = targetKey.GetValue("SubCommands", "") as string;

                RegistryKey groupKey = targetKey.CreateSubKey("shell");


                string keyName = "SUB" + md5(text).ToUpper();
                RegistryKey addKey = groupKey.CreateSubKey(keyName);
                addKey.SetValue("", displayName);
                if (icon == "")
                {
                    addKey.SetValue("icon", "");
                }
                else
                {
                    addKey.SetValue("icon", "\"" + icon + "\",0");
                }


                RegistryKey cmdKey = addKey.CreateSubKey("command");


                cmdKey.SetValue("", command, RegistryValueKind.String);

                cmdKey.Close();

                addKey.Close();

                groupKey.Close();

                subs = subs + keyName + ";";
                targetKey.SetValue("SubCommands", subs, RegistryValueKind.String);

                targetKey.Close();


                shellKey.Close();
            }
            catch (Exception)
            {

            }
        }

        private void addCustomRightContextCommandProxy(bool fileContext)
        {
            string icon = Interaction.InputBox("请输入菜单项使用的驱动程序路径：\n这将作为菜单项的图标\n例如：cmd.exe", "驱动程序图标输入框", "cmd.exe", -1, -1);
            string text = Interaction.InputBox("请输入菜单项名称", "菜单名称输入框", "", -1, -1);
            string tips = "%V表示右键时所在的目录全路径";
            if (fileContext)
            {
                tips = "%1表示右键的文件的全路径";
            }
            string command = Interaction.InputBox("请输入此菜单项执行的命令：\n"+tips, "命令输入框", "", -1, -1);

           addExtendsRightMenu(fileContext, icon, text, command);
        }


        private void AddCustomRightContextFileCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCustomRightContextCommandProxy(true);
        }

        private void AddCustomRightContextDirectoryCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCustomRightContextCommandProxy(false);
        }

        private void AnaliesCacheReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_analiesFileInfoCache.Clear();
        }

        private void AnaliesCacheBoostEnableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_isAnaliesCache = !m_isAnaliesCache;
            this.AnaliesCacheBoostEnableToolStripMenuItem.Checked = m_isAnaliesCache;
            refreshCurrentDirectory();
        }

  

        
    }

}
