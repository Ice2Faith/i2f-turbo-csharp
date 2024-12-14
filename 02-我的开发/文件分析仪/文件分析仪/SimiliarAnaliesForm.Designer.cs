namespace 文件分析仪
{
    partial class SimiliarAnaliesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartAnaliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CalcCheckSumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliesFileNameAndSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliseSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliseFileNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliseModifyTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliesCreateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliesOnlyFileNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliesOnlyFileNameAndSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxTreePathRouter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBoxCurrentDir = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItemEntryDir = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewShowList = new System.Windows.Forms.ListView();
            this.columnHeaderGroupId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCheckSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastAccessTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListFiles = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripFileList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenStrategySelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxTipsInfo = new System.Windows.Forms.ToolStripTextBox();
            this.正则过滤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxRegexFileNameFilter = new System.Windows.Forms.ToolStripTextBox();
            this.RegexIgnoreCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegexIncludeExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegexClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMain.SuspendLayout();
            this.contextMenuStripFileList.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.分析ToolStripMenuItem,
            this.toolStripComboBoxTreePathRouter,
            this.toolStripTextBoxCurrentDir,
            this.toolStripMenuItemEntryDir,
            this.toolStripTextBoxTipsInfo,
            this.正则过滤ToolStripMenuItem,
            this.toolStripTextBoxRegexFileNameFilter});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1518, 32);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFilesToolStripMenuItem,
            this.StartAnaliesToolStripMenuItem,
            this.CalcCheckSumToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(51, 28);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // LoadFilesToolStripMenuItem
            // 
            this.LoadFilesToolStripMenuItem.Name = "LoadFilesToolStripMenuItem";
            this.LoadFilesToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.LoadFilesToolStripMenuItem.Text = "加载文件";
            this.LoadFilesToolStripMenuItem.Click += new System.EventHandler(this.LoadFilesToolStripMenuItem_Click);
            // 
            // StartAnaliesToolStripMenuItem
            // 
            this.StartAnaliesToolStripMenuItem.Name = "StartAnaliesToolStripMenuItem";
            this.StartAnaliesToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.StartAnaliesToolStripMenuItem.Text = "开始分析";
            this.StartAnaliesToolStripMenuItem.Click += new System.EventHandler(this.StartAnaliesToolStripMenuItem_Click);
            // 
            // CalcCheckSumToolStripMenuItem
            // 
            this.CalcCheckSumToolStripMenuItem.Name = "CalcCheckSumToolStripMenuItem";
            this.CalcCheckSumToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.CalcCheckSumToolStripMenuItem.Text = "计算校验码";
            this.CalcCheckSumToolStripMenuItem.Click += new System.EventHandler(this.CalcCheckSumToolStripMenuItem_Click);
            // 
            // 分析ToolStripMenuItem
            // 
            this.分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnaliesFileNameAndSizeToolStripMenuItem,
            this.AnaliseSizeToolStripMenuItem,
            this.AnaliseFileNameToolStripMenuItem,
            this.AnaliseModifyTimeToolStripMenuItem,
            this.AnaliesCreateTimeToolStripMenuItem,
            this.AnaliesOnlyFileNameToolStripMenuItem,
            this.AnaliesOnlyFileNameAndSizeToolStripMenuItem});
            this.分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            this.分析ToolStripMenuItem.Size = new System.Drawing.Size(51, 28);
            this.分析ToolStripMenuItem.Text = "分析";
            // 
            // AnaliesFileNameAndSizeToolStripMenuItem
            // 
            this.AnaliesFileNameAndSizeToolStripMenuItem.Name = "AnaliesFileNameAndSizeToolStripMenuItem";
            this.AnaliesFileNameAndSizeToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.AnaliesFileNameAndSizeToolStripMenuItem.Text = "文件名+大小";
            this.AnaliesFileNameAndSizeToolStripMenuItem.Click += new System.EventHandler(this.AnaliesFileNameAndSizeToolStripMenuItem_Click);
            // 
            // AnaliseSizeToolStripMenuItem
            // 
            this.AnaliseSizeToolStripMenuItem.Name = "AnaliseSizeToolStripMenuItem";
            this.AnaliseSizeToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.AnaliseSizeToolStripMenuItem.Text = "按大小";
            this.AnaliseSizeToolStripMenuItem.Click += new System.EventHandler(this.AnaliseSizeToolStripMenuItem_Click);
            // 
            // AnaliseFileNameToolStripMenuItem
            // 
            this.AnaliseFileNameToolStripMenuItem.Name = "AnaliseFileNameToolStripMenuItem";
            this.AnaliseFileNameToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.AnaliseFileNameToolStripMenuItem.Text = "按文件名";
            this.AnaliseFileNameToolStripMenuItem.Click += new System.EventHandler(this.AnaliseFileNameToolStripMenuItem_Click);
            // 
            // AnaliseModifyTimeToolStripMenuItem
            // 
            this.AnaliseModifyTimeToolStripMenuItem.Name = "AnaliseModifyTimeToolStripMenuItem";
            this.AnaliseModifyTimeToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.AnaliseModifyTimeToolStripMenuItem.Text = "按修改时间";
            this.AnaliseModifyTimeToolStripMenuItem.Click += new System.EventHandler(this.AnaliseModifyTimeToolStripMenuItem_Click);
            // 
            // AnaliesCreateTimeToolStripMenuItem
            // 
            this.AnaliesCreateTimeToolStripMenuItem.Name = "AnaliesCreateTimeToolStripMenuItem";
            this.AnaliesCreateTimeToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.AnaliesCreateTimeToolStripMenuItem.Text = "按创建时间";
            this.AnaliesCreateTimeToolStripMenuItem.Click += new System.EventHandler(this.AnaliesCreateTimeToolStripMenuItem_Click);
            // 
            // AnaliesOnlyFileNameToolStripMenuItem
            // 
            this.AnaliesOnlyFileNameToolStripMenuItem.Name = "AnaliesOnlyFileNameToolStripMenuItem";
            this.AnaliesOnlyFileNameToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.AnaliesOnlyFileNameToolStripMenuItem.Text = "仅文件名";
            this.AnaliesOnlyFileNameToolStripMenuItem.Click += new System.EventHandler(this.AnaliesOnlyFileNameToolStripMenuItem_Click);
            // 
            // AnaliesOnlyFileNameAndSizeToolStripMenuItem
            // 
            this.AnaliesOnlyFileNameAndSizeToolStripMenuItem.Name = "AnaliesOnlyFileNameAndSizeToolStripMenuItem";
            this.AnaliesOnlyFileNameAndSizeToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.AnaliesOnlyFileNameAndSizeToolStripMenuItem.Text = "仅文件名+大小";
            this.AnaliesOnlyFileNameAndSizeToolStripMenuItem.Click += new System.EventHandler(this.AnaliesOnlyFileNameAndSizeToolStripMenuItem_Click);
            // 
            // toolStripComboBoxTreePathRouter
            // 
            this.toolStripComboBoxTreePathRouter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxTreePathRouter.DropDownWidth = 480;
            this.toolStripComboBoxTreePathRouter.Name = "toolStripComboBoxTreePathRouter";
            this.toolStripComboBoxTreePathRouter.Size = new System.Drawing.Size(420, 28);
            this.toolStripComboBoxTreePathRouter.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxTreePathRouter_SelectedIndexChanged);
            // 
            // toolStripTextBoxCurrentDir
            // 
            this.toolStripTextBoxCurrentDir.Name = "toolStripTextBoxCurrentDir";
            this.toolStripTextBoxCurrentDir.Size = new System.Drawing.Size(360, 28);
            // 
            // toolStripMenuItemEntryDir
            // 
            this.toolStripMenuItemEntryDir.Name = "toolStripMenuItemEntryDir";
            this.toolStripMenuItemEntryDir.Size = new System.Drawing.Size(51, 28);
            this.toolStripMenuItemEntryDir.Text = "进入";
            this.toolStripMenuItemEntryDir.Click += new System.EventHandler(this.toolStripMenuItemEntryDir_Click);
            // 
            // listViewShowList
            // 
            this.listViewShowList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderGroupId,
            this.columnHeaderFileName,
            this.columnHeaderFileSize,
            this.columnHeaderCheckSum,
            this.columnHeaderLastAccessTime,
            this.columnHeaderCreateTime,
            this.columnHeaderPath});
            this.listViewShowList.ContextMenuStrip = this.contextMenuStripFileList;
            this.listViewShowList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewShowList.FullRowSelect = true;
            this.listViewShowList.GridLines = true;
            this.listViewShowList.LargeImageList = this.imageListFiles;
            this.listViewShowList.Location = new System.Drawing.Point(0, 32);
            this.listViewShowList.Name = "listViewShowList";
            this.listViewShowList.Size = new System.Drawing.Size(1518, 615);
            this.listViewShowList.SmallImageList = this.imageListFiles;
            this.listViewShowList.TabIndex = 1;
            this.listViewShowList.UseCompatibleStateImageBehavior = false;
            this.listViewShowList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderGroupId
            // 
            this.columnHeaderGroupId.Text = "组别";
            this.columnHeaderGroupId.Width = 100;
            // 
            // columnHeaderFileName
            // 
            this.columnHeaderFileName.Text = "文件名";
            this.columnHeaderFileName.Width = 260;
            // 
            // columnHeaderFileSize
            // 
            this.columnHeaderFileSize.Text = "大小";
            this.columnHeaderFileSize.Width = 120;
            // 
            // columnHeaderCheckSum
            // 
            this.columnHeaderCheckSum.Text = "校验码";
            this.columnHeaderCheckSum.Width = 120;
            // 
            // columnHeaderLastAccessTime
            // 
            this.columnHeaderLastAccessTime.Text = "最后修改";
            this.columnHeaderLastAccessTime.Width = 120;
            // 
            // columnHeaderCreateTime
            // 
            this.columnHeaderCreateTime.Text = "创建时间";
            this.columnHeaderCreateTime.Width = 120;
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "路径";
            this.columnHeaderPath.Width = 360;
            // 
            // imageListFiles
            // 
            this.imageListFiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageListFiles.ImageSize = new System.Drawing.Size(24, 24);
            this.imageListFiles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStripFileList
            // 
            this.contextMenuStripFileList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripFileList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileToolStripMenuItem,
            this.OpenStrategySelectToolStripMenuItem,
            this.OpenFilePathToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.CopyPathToolStripMenuItem,
            this.SelectGroupToolStripMenuItem});
            this.contextMenuStripFileList.Name = "contextMenuStripFileList";
            this.contextMenuStripFileList.Size = new System.Drawing.Size(169, 148);
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.OpenFileToolStripMenuItem.Text = "打开";
            this.OpenFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // OpenFilePathToolStripMenuItem
            // 
            this.OpenFilePathToolStripMenuItem.Name = "OpenFilePathToolStripMenuItem";
            this.OpenFilePathToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.OpenFilePathToolStripMenuItem.Text = "打开所在路径";
            this.OpenFilePathToolStripMenuItem.Click += new System.EventHandler(this.OpenFilePathToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.DeleteToolStripMenuItem.Text = "删除";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // CopyPathToolStripMenuItem
            // 
            this.CopyPathToolStripMenuItem.Name = "CopyPathToolStripMenuItem";
            this.CopyPathToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.CopyPathToolStripMenuItem.Text = "复制完整路径";
            this.CopyPathToolStripMenuItem.Click += new System.EventHandler(this.CopyPathToolStripMenuItem_Click);
            // 
            // SelectGroupToolStripMenuItem
            // 
            this.SelectGroupToolStripMenuItem.Name = "SelectGroupToolStripMenuItem";
            this.SelectGroupToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.SelectGroupToolStripMenuItem.Text = "选中组";
            this.SelectGroupToolStripMenuItem.Click += new System.EventHandler(this.SelectGroupToolStripMenuItem_Click);
            // 
            // OpenStrategySelectToolStripMenuItem
            // 
            this.OpenStrategySelectToolStripMenuItem.Name = "OpenStrategySelectToolStripMenuItem";
            this.OpenStrategySelectToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.OpenStrategySelectToolStripMenuItem.Text = "打开方式";
            this.OpenStrategySelectToolStripMenuItem.Click += new System.EventHandler(this.OpenStrategySelectToolStripMenuItem_Click);
            // 
            // toolStripTextBoxTipsInfo
            // 
            this.toolStripTextBoxTipsInfo.Name = "toolStripTextBoxTipsInfo";
            this.toolStripTextBoxTipsInfo.ReadOnly = true;
            this.toolStripTextBoxTipsInfo.Size = new System.Drawing.Size(240, 28);
            // 
            // 正则过滤ToolStripMenuItem
            // 
            this.正则过滤ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegexIgnoreCaseToolStripMenuItem,
            this.RegexIncludeExtensionToolStripMenuItem,
            this.toolStripSeparator1,
            this.RegexClearToolStripMenuItem});
            this.正则过滤ToolStripMenuItem.Name = "正则过滤ToolStripMenuItem";
            this.正则过滤ToolStripMenuItem.Size = new System.Drawing.Size(81, 28);
            this.正则过滤ToolStripMenuItem.Text = "正则过滤";
            // 
            // toolStripTextBoxRegexFileNameFilter
            // 
            this.toolStripTextBoxRegexFileNameFilter.Name = "toolStripTextBoxRegexFileNameFilter";
            this.toolStripTextBoxRegexFileNameFilter.Size = new System.Drawing.Size(180, 28);
            // 
            // RegexIgnoreCaseToolStripMenuItem
            // 
            this.RegexIgnoreCaseToolStripMenuItem.Name = "RegexIgnoreCaseToolStripMenuItem";
            this.RegexIgnoreCaseToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.RegexIgnoreCaseToolStripMenuItem.Text = "忽略大小写";
            this.RegexIgnoreCaseToolStripMenuItem.Click += new System.EventHandler(this.RegexIgnoreCaseToolStripMenuItem_Click);
            // 
            // RegexIncludeExtensionToolStripMenuItem
            // 
            this.RegexIncludeExtensionToolStripMenuItem.Name = "RegexIncludeExtensionToolStripMenuItem";
            this.RegexIncludeExtensionToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.RegexIncludeExtensionToolStripMenuItem.Text = "包含后缀匹配";
            this.RegexIncludeExtensionToolStripMenuItem.Click += new System.EventHandler(this.RegexIncludeExtensionToolStripMenuItem_Click);
            // 
            // RegexClearToolStripMenuItem
            // 
            this.RegexClearToolStripMenuItem.Name = "RegexClearToolStripMenuItem";
            this.RegexClearToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.RegexClearToolStripMenuItem.Text = "清空";
            this.RegexClearToolStripMenuItem.Click += new System.EventHandler(this.RegexClearToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // SimiliarAnaliesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 647);
            this.Controls.Add(this.listViewShowList);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "SimiliarAnaliesForm";
            this.Text = "疑似文件分析";
            this.Load += new System.EventHandler(this.SimiliarAnaliesForm_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.contextMenuStripFileList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem 分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnaliesFileNameAndSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnaliseSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnaliseFileNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnaliseModifyTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnaliesCreateTimeToolStripMenuItem;
        private System.Windows.Forms.ListView listViewShowList;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxTreePathRouter;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCurrentDir;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEntryDir;
        private System.Windows.Forms.ColumnHeader columnHeaderGroupId;
        private System.Windows.Forms.ColumnHeader columnHeaderFileName;
        private System.Windows.Forms.ColumnHeader columnHeaderFileSize;
        private System.Windows.Forms.ColumnHeader columnHeaderLastAccessTime;
        private System.Windows.Forms.ColumnHeader columnHeaderCreateTime;
        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.ToolStripMenuItem AnaliesOnlyFileNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnaliesOnlyFileNameAndSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartAnaliesToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderCheckSum;
        private System.Windows.Forms.ToolStripMenuItem CalcCheckSumToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListFiles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFileList;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenStrategySelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxTipsInfo;
        private System.Windows.Forms.ToolStripMenuItem 正则过滤ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxRegexFileNameFilter;
        private System.Windows.Forms.ToolStripMenuItem RegexIgnoreCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RegexIncludeExtensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem RegexClearToolStripMenuItem;
    }
}