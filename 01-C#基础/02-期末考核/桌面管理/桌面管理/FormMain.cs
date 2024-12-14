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


namespace StyleSuit
{
    public partial class FormMain : FormStyle
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MainLoad();
        }
        private void listViewDesktop_DoubleClick(object sender, EventArgs e)
        {
            OpenRunProcessFile();
        }

        private void buttonTitleWnd_Click(object sender, EventArgs e)
        {
            GotoParentDirectory();
        }

        private void buttonIconWnd_Click(object sender, EventArgs e)
        {
            BackToHistoryDirectory();
        }
        
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedFiles();
        }


        private void ReflashFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateListView(preListDir);
        }

        
        private void FolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFolder();
        }
        
        private void TextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTextFile();
        }

        private void CPPFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCppFile();
        }

        private void CFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCFile();
        }

        private void CPPHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCorCppHeadFile();
        }

        private void JavaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewJavaFile();
        }

        private void HtmlFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewHtmlFile();
        }

        private void PythonFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPythonFile();
        }

        private void BatFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewBatFile();
        }

        private void BashFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewBashFile();
        }

        private void NotepadOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSelectByNotepad();
        }

        private void CommandOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCmdOnPresentDirectory();
        }

        private void PowershellOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPowershellOnPresentDirectory();
        }
        
        private void AllFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewAllTypeFile();
        }

        private void RouteCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyPrensentDirectoryFullNameToClipBord();
        }

        private void CutBufferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CutSelectedPaths();
        }

        private void CopyBufferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelectedPaths();
        }
       
        private void PauseBufferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteSelectedPaths();
        }

        private void BigIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewDesktop.View = View.LargeIcon;
        }

        private void SmallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewDesktop.View = View.SmallIcon;
        }

        private void ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewDesktop.View = View.List;
        }

        private void DetialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewDesktop.View = View.Details;
        }

        private void TileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewDesktop.View = View.Tile;
        }

        private void ExplorerOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPresentDirectoryInSysExplorer();
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameSelectPaths();
        }

        private void listViewDesktop_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeyDownInListView(e);
        }

        private void ShowAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAllChildWnd();
        }

        private void SpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, FileSizeToString(GetSelectedPathsSize()), "占用空间");
        }
        
        private void FullFooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FullScreenFoo();
        }
        
        private void LockFooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockFooJoinAllChildWnd();
        }

        private void FreeFooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isFreeFooMode = true;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (!isFreeFooMode)
            {
                JoinAllChildWnd();
            }
        }

        private void FormMain_Move(object sender, EventArgs e)
        {
            if (!isFreeFooMode)
            {
                JoinAllChildWnd();
            }
        }

        private void JumpPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JumpToInputPath();
        }

        private void BrowserSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowserSearch();
        }
        
        private void GoogleTranslateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoogleTeanslate();
        }

        private void CopySelectToClipBordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelectPathsFullNameToClipbord();
        }
        
        private void HalfTransparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HalfTransparentAllWnd();
        }

        private void FileAnaliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            needAnaly = !needAnaly;
            UpdateListView(preListDir);
        }

        private void ViewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preViewType = ViewTypeEnum.SHOW_ALL;
            UpdateListView(preListDir);
        }

        private void ViewOnlyFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preViewType = ViewTypeEnum.SHOW_ONLY_FILE;
            UpdateListView(preListDir);
        }

        private void ViewOnlyFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preViewType = ViewTypeEnum.SHOW_ONLY_FOLDER;
            UpdateListView(preListDir);
        }

        private void ViewOnlyExecLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preViewType = ViewTypeEnum.SHOW_ONLY_EXECORLINK;
            UpdateListView(preListDir);
        }

        private void SortDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preSortType = SortTypeEnum.SORT_DEFAULT;
            UpdateListView(preListDir);
        }

        private void SortNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preSortType = SortTypeEnum.SORT_NAME;
            UpdateListView(preListDir);
        }

        private void SortSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preSortType = SortTypeEnum.SORT_SIZE;
            UpdateListView(preListDir);
        }

        private void SortTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preSortType = SortTypeEnum.SORT_TIME;
            UpdateListView(preListDir);
        }

        private void SortDirectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortDirection = !SortDirection;
            UpdateListView(preListDir);
        }

        private void listViewDesktop_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
           RenameByListViewLable(e);
        }
       
        private void CloseAllChildWndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllChildWnd();
        }

        private void listViewDesktop_DragDrop(object sender, DragEventArgs e)
        {
            DropFilesIn(((Array)e.Data.GetData(DataFormats.FileDrop)));
        }

        private void listViewDesktop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

    }
}
