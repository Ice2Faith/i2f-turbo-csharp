namespace StyleSuit
{
    partial class FormSpecial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpecial));
            this.listViewContent = new System.Windows.Forms.ListView();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewBuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReflashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BigIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DetialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotepadOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RouteCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrowserSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListFiles = new System.Windows.Forms.ImageList(this.components);
            this.GoogleTranslateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHeadBorder.SuspendLayout();
            this.panelClient.SuspendLayout();
            this.contextMenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeadBorder
            // 
            this.panelHeadBorder.Size = new System.Drawing.Size(556, 31);
            // 
            // buttonNameWnd
            // 
            this.buttonNameWnd.FlatAppearance.BorderSize = 0;
            this.buttonNameWnd.Location = new System.Drawing.Point(178, 0);
            // 
            // buttonTitleWnd
            // 
            this.buttonTitleWnd.FlatAppearance.BorderSize = 0;
            this.buttonTitleWnd.Size = new System.Drawing.Size(105, 31);
            this.buttonTitleWnd.Text = "SubWindow";
            this.buttonTitleWnd.Visible = false;
            // 
            // buttonIconWnd
            // 
            this.buttonIconWnd.FlatAppearance.BorderSize = 0;
            this.buttonIconWnd.Text = "<<";
            this.buttonIconWnd.Click += new System.EventHandler(this.buttonIconWnd_Click);
            // 
            // buttonMinWnd
            // 
            this.buttonMinWnd.FlatAppearance.BorderSize = 0;
            this.buttonMinWnd.Location = new System.Drawing.Point(381, 0);
            // 
            // buttonMaxWnd
            // 
            this.buttonMaxWnd.FlatAppearance.BorderSize = 0;
            this.buttonMaxWnd.Location = new System.Drawing.Point(443, 0);
            // 
            // buttonCloseWnd
            // 
            this.buttonCloseWnd.FlatAppearance.BorderSize = 0;
            this.buttonCloseWnd.Location = new System.Drawing.Point(505, 0);
            this.buttonCloseWnd.Click += new System.EventHandler(this.buttonCloseWnd_Click);
            // 
            // panelButtomBorder
            // 
            this.panelButtomBorder.Location = new System.Drawing.Point(0, 596);
            this.panelButtomBorder.Size = new System.Drawing.Size(556, 5);
            // 
            // panelLeftBorder
            // 
            this.panelLeftBorder.Size = new System.Drawing.Size(5, 565);
            // 
            // panelRightBorder
            // 
            this.panelRightBorder.Location = new System.Drawing.Point(551, 31);
            this.panelRightBorder.Size = new System.Drawing.Size(5, 565);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.listViewContent);
            this.panelClient.Size = new System.Drawing.Size(546, 565);
            // 
            // listViewContent
            // 
            this.listViewContent.ContextMenuStrip = this.contextMenuStripMain;
            this.listViewContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewContent.LargeImageList = this.imageListFiles;
            this.listViewContent.Location = new System.Drawing.Point(0, 0);
            this.listViewContent.Name = "listViewContent";
            this.listViewContent.Size = new System.Drawing.Size(546, 565);
            this.listViewContent.SmallImageList = this.imageListFiles;
            this.listViewContent.TabIndex = 0;
            this.listViewContent.UseCompatibleStateImageBehavior = false;
            this.listViewContent.DoubleClick += new System.EventHandler(this.listViewContent_DoubleClick);
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewBuildToolStripMenuItem,
            this.ReflashToolStripMenuItem,
            this.DisplayStyleToolStripMenuItem,
            this.NotepadOpenToolStripMenuItem,
            this.CommandOpenToolStripMenuItem,
            this.RouteCopyToolStripMenuItem,
            this.JumpPathToolStripMenuItem,
            this.BrowserSearchToolStripMenuItem,
            this.GoogleTranslateToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(320, 248);
            // 
            // NewBuildToolStripMenuItem
            // 
            this.NewBuildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FolderToolStripMenuItem,
            this.TextFileToolStripMenuItem});
            this.NewBuildToolStripMenuItem.Name = "NewBuildToolStripMenuItem";
            this.NewBuildToolStripMenuItem.Size = new System.Drawing.Size(319, 24);
            this.NewBuildToolStripMenuItem.Text = "新建(&New)";
            // 
            // FolderToolStripMenuItem
            // 
            this.FolderToolStripMenuItem.Name = "FolderToolStripMenuItem";
            this.FolderToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.FolderToolStripMenuItem.Text = "文件夹(&Floder)";
            this.FolderToolStripMenuItem.Click += new System.EventHandler(this.FolderToolStripMenuItem_Click);
            // 
            // TextFileToolStripMenuItem
            // 
            this.TextFileToolStripMenuItem.Name = "TextFileToolStripMenuItem";
            this.TextFileToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.TextFileToolStripMenuItem.Text = "文本文件(&TextFile)";
            this.TextFileToolStripMenuItem.Click += new System.EventHandler(this.TextFileToolStripMenuItem_Click);
            // 
            // ReflashToolStripMenuItem
            // 
            this.ReflashToolStripMenuItem.Name = "ReflashToolStripMenuItem";
            this.ReflashToolStripMenuItem.Size = new System.Drawing.Size(319, 24);
            this.ReflashToolStripMenuItem.Text = "刷新(re&Flash)";
            this.ReflashToolStripMenuItem.Click += new System.EventHandler(this.ReflashFToolStripMenuItem_Click);
            // 
            // DisplayStyleToolStripMenuItem
            // 
            this.DisplayStyleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BigIconToolStripMenuItem,
            this.DetialToolStripMenuItem});
            this.DisplayStyleToolStripMenuItem.Name = "DisplayStyleToolStripMenuItem";
            this.DisplayStyleToolStripMenuItem.Size = new System.Drawing.Size(319, 24);
            this.DisplayStyleToolStripMenuItem.Text = "显示样式(&View)";
            // 
            // BigIconToolStripMenuItem
            // 
            this.BigIconToolStripMenuItem.Name = "BigIconToolStripMenuItem";
            this.BigIconToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.BigIconToolStripMenuItem.Text = "大图标(&Big)";
            this.BigIconToolStripMenuItem.Click += new System.EventHandler(this.BigIconToolStripMenuItem_Click);
            // 
            // DetialToolStripMenuItem
            // 
            this.DetialToolStripMenuItem.Name = "DetialToolStripMenuItem";
            this.DetialToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.DetialToolStripMenuItem.Text = "详细(&Detial)";
            this.DetialToolStripMenuItem.Click += new System.EventHandler(this.DetialToolStripMenuItem_Click);
            // 
            // NotepadOpenToolStripMenuItem
            // 
            this.NotepadOpenToolStripMenuItem.Name = "NotepadOpenToolStripMenuItem";
            this.NotepadOpenToolStripMenuItem.Size = new System.Drawing.Size(319, 24);
            this.NotepadOpenToolStripMenuItem.Text = "用记事本打开(&Notepad)";
            this.NotepadOpenToolStripMenuItem.Click += new System.EventHandler(this.NotepadOpenToolStripMenuItem_Click);
            // 
            // CommandOpenToolStripMenuItem
            // 
            this.CommandOpenToolStripMenuItem.Name = "CommandOpenToolStripMenuItem";
            this.CommandOpenToolStripMenuItem.Size = new System.Drawing.Size(319, 24);
            this.CommandOpenToolStripMenuItem.Text = "在此处打开CMD命令行(c&Ommand)";
            this.CommandOpenToolStripMenuItem.Click += new System.EventHandler(this.CommandOpenToolStripMenuItem_Click);
            // 
            // RouteCopyToolStripMenuItem
            // 
            this.RouteCopyToolStripMenuItem.Name = "RouteCopyToolStripMenuItem";
            this.RouteCopyToolStripMenuItem.Size = new System.Drawing.Size(319, 24);
            this.RouteCopyToolStripMenuItem.Text = "复制当前路径(&Route)";
            this.RouteCopyToolStripMenuItem.Click += new System.EventHandler(this.RouteCopyToolStripMenuItem_Click);
            // 
            // JumpPathToolStripMenuItem
            // 
            this.JumpPathToolStripMenuItem.Name = "JumpPathToolStripMenuItem";
            this.JumpPathToolStripMenuItem.Size = new System.Drawing.Size(319, 24);
            this.JumpPathToolStripMenuItem.Text = "目录跳转(&Jump)";
            this.JumpPathToolStripMenuItem.Click += new System.EventHandler(this.JumpPathToolStripMenuItem_Click_1);
            // 
            // BrowserSearchToolStripMenuItem
            // 
            this.BrowserSearchToolStripMenuItem.Name = "BrowserSearchToolStripMenuItem";
            this.BrowserSearchToolStripMenuItem.Size = new System.Drawing.Size(319, 24);
            this.BrowserSearchToolStripMenuItem.Text = "用浏览器搜索(&Browser)";
            this.BrowserSearchToolStripMenuItem.Click += new System.EventHandler(this.BrowserSearchToolStripMenuItem_Click);
            // 
            // imageListFiles
            // 
            this.imageListFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFiles.ImageStream")));
            this.imageListFiles.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFiles.Images.SetKeyName(0, "disk");
            this.imageListFiles.Images.SetKeyName(1, "folder");
            this.imageListFiles.Images.SetKeyName(2, "null");
            // 
            // GoogleTranslateToolStripMenuItem
            // 
            this.GoogleTranslateToolStripMenuItem.Name = "GoogleTranslateToolStripMenuItem";
            this.GoogleTranslateToolStripMenuItem.Size = new System.Drawing.Size(319, 24);
            this.GoogleTranslateToolStripMenuItem.Text = "谷歌翻译(&Translate)";
            this.GoogleTranslateToolStripMenuItem.Click += new System.EventHandler(this.GoogleTranslateToolStripMenuItem_Click);
            // 
            // FormSpecial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 601);
            this.Name = "FormSpecial";
            this.Text = "SubWindow";
            this.TitleWnd = "SubWindow";
            this.Controls.SetChildIndex(this.panelHeadBorder, 0);
            this.Controls.SetChildIndex(this.panelButtomBorder, 0);
            this.Controls.SetChildIndex(this.panelLeftBorder, 0);
            this.Controls.SetChildIndex(this.panelRightBorder, 0);
            this.Controls.SetChildIndex(this.panelClient, 0);
            this.panelHeadBorder.ResumeLayout(false);
            this.panelHeadBorder.PerformLayout();
            this.panelClient.ResumeLayout(false);
            this.contextMenuStripMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewContent;
        private System.Windows.Forms.ImageList imageListFiles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem NewBuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReflashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisplayStyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BigIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DetialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NotepadOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CommandOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RouteCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JumpPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrowserSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GoogleTranslateToolStripMenuItem;
    }
}