namespace XmlPainter
{
    partial class XmlPainterForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlPainterForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenInFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveInFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SavePictureInFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CursorInOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineInOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoreLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArrowLineInOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FillArrowLineInOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextInOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EraseInOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CircleInShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RectangleInShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EllipseInShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiamondInShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TriangleInShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RoundRectangleInShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutInHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpInHelpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.saveFileDialogMain = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogMain = new System.Windows.Forms.OpenFileDialog();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.OperationToolStripMenuItem,
            this.ShapeToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(909, 28);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenInFileToolStripMenuItem,
            this.SaveInFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.SavePictureInFileToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // OpenInFileToolStripMenuItem
            // 
            this.OpenInFileToolStripMenuItem.Name = "OpenInFileToolStripMenuItem";
            this.OpenInFileToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.OpenInFileToolStripMenuItem.Text = "打开(&O)";
            this.OpenInFileToolStripMenuItem.Click += new System.EventHandler(this.OpenInFileToolStripMenuItem_Click);
            // 
            // SaveInFileToolStripMenuItem
            // 
            this.SaveInFileToolStripMenuItem.Name = "SaveInFileToolStripMenuItem";
            this.SaveInFileToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.SaveInFileToolStripMenuItem.Text = "保存(&S)";
            this.SaveInFileToolStripMenuItem.Click += new System.EventHandler(this.SaveInFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // SavePictureInFileToolStripMenuItem
            // 
            this.SavePictureInFileToolStripMenuItem.Name = "SavePictureInFileToolStripMenuItem";
            this.SavePictureInFileToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.SavePictureInFileToolStripMenuItem.Text = "保存图片(&P)";
            this.SavePictureInFileToolStripMenuItem.Click += new System.EventHandler(this.SavePictureInFileToolStripMenuItem_Click);
            // 
            // OperationToolStripMenuItem
            // 
            this.OperationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CursorInOperationToolStripMenuItem,
            this.LineInOperationToolStripMenuItem,
            this.MoreLinesToolStripMenuItem,
            this.TextInOperationToolStripMenuItem,
            this.EraseInOperationToolStripMenuItem});
            this.OperationToolStripMenuItem.Name = "OperationToolStripMenuItem";
            this.OperationToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.OperationToolStripMenuItem.Text = "操作(&O)";
            // 
            // CursorInOperationToolStripMenuItem
            // 
            this.CursorInOperationToolStripMenuItem.Name = "CursorInOperationToolStripMenuItem";
            this.CursorInOperationToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.CursorInOperationToolStripMenuItem.Text = "指针(&C)";
            this.CursorInOperationToolStripMenuItem.Click += new System.EventHandler(this.CursorInOperationToolStripMenuItem_Click);
            // 
            // LineInOperationToolStripMenuItem
            // 
            this.LineInOperationToolStripMenuItem.Name = "LineInOperationToolStripMenuItem";
            this.LineInOperationToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.LineInOperationToolStripMenuItem.Text = "连线(&L)";
            this.LineInOperationToolStripMenuItem.Click += new System.EventHandler(this.LineInOperationToolStripMenuItem_Click);
            // 
            // MoreLinesToolStripMenuItem
            // 
            this.MoreLinesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ArrowLineInOperationToolStripMenuItem,
            this.FillArrowLineInOperationToolStripMenuItem});
            this.MoreLinesToolStripMenuItem.Name = "MoreLinesToolStripMenuItem";
            this.MoreLinesToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.MoreLinesToolStripMenuItem.Text = "更多连线(&M)";
            // 
            // ArrowLineInOperationToolStripMenuItem
            // 
            this.ArrowLineInOperationToolStripMenuItem.Name = "ArrowLineInOperationToolStripMenuItem";
            this.ArrowLineInOperationToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.ArrowLineInOperationToolStripMenuItem.Text = "箭头(&A)";
            this.ArrowLineInOperationToolStripMenuItem.Click += new System.EventHandler(this.ArrowLineInOperationToolStripMenuItem_Click);
            // 
            // FillArrowLineInOperationToolStripMenuItem
            // 
            this.FillArrowLineInOperationToolStripMenuItem.Name = "FillArrowLineInOperationToolStripMenuItem";
            this.FillArrowLineInOperationToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.FillArrowLineInOperationToolStripMenuItem.Text = "实心箭头(&M)";
            this.FillArrowLineInOperationToolStripMenuItem.Click += new System.EventHandler(this.FillArrowLineInOperationToolStripMenuItem_Click);
            // 
            // TextInOperationToolStripMenuItem
            // 
            this.TextInOperationToolStripMenuItem.Name = "TextInOperationToolStripMenuItem";
            this.TextInOperationToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.TextInOperationToolStripMenuItem.Text = "文字(&T)";
            this.TextInOperationToolStripMenuItem.Click += new System.EventHandler(this.TextInOperationToolStripMenuItem_Click);
            // 
            // EraseInOperationToolStripMenuItem
            // 
            this.EraseInOperationToolStripMenuItem.Name = "EraseInOperationToolStripMenuItem";
            this.EraseInOperationToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.EraseInOperationToolStripMenuItem.Text = "清空(&E)";
            this.EraseInOperationToolStripMenuItem.Click += new System.EventHandler(this.EraseInOperationToolStripMenuItem_Click);
            // 
            // ShapeToolStripMenuItem
            // 
            this.ShapeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CircleInShapeToolStripMenuItem,
            this.RectangleInShapeToolStripMenuItem,
            this.EllipseInShapeToolStripMenuItem,
            this.DiamondInShapeToolStripMenuItem,
            this.TriangleInShapeToolStripMenuItem,
            this.RoundRectangleInShapeToolStripMenuItem});
            this.ShapeToolStripMenuItem.Name = "ShapeToolStripMenuItem";
            this.ShapeToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.ShapeToolStripMenuItem.Text = "图形(&S)";
            // 
            // CircleInShapeToolStripMenuItem
            // 
            this.CircleInShapeToolStripMenuItem.Name = "CircleInShapeToolStripMenuItem";
            this.CircleInShapeToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.CircleInShapeToolStripMenuItem.Text = "圆(&C)";
            this.CircleInShapeToolStripMenuItem.Click += new System.EventHandler(this.CircleInShapeToolStripMenuItem_Click);
            // 
            // RectangleInShapeToolStripMenuItem
            // 
            this.RectangleInShapeToolStripMenuItem.Name = "RectangleInShapeToolStripMenuItem";
            this.RectangleInShapeToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.RectangleInShapeToolStripMenuItem.Text = "矩形(&R)";
            this.RectangleInShapeToolStripMenuItem.Click += new System.EventHandler(this.RectangleInShapeToolStripMenuItem_Click);
            // 
            // EllipseInShapeToolStripMenuItem
            // 
            this.EllipseInShapeToolStripMenuItem.Name = "EllipseInShapeToolStripMenuItem";
            this.EllipseInShapeToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.EllipseInShapeToolStripMenuItem.Text = "椭圆(&E)";
            this.EllipseInShapeToolStripMenuItem.Click += new System.EventHandler(this.EllipseInShapeToolStripMenuItem_Click);
            // 
            // DiamondInShapeToolStripMenuItem
            // 
            this.DiamondInShapeToolStripMenuItem.Name = "DiamondInShapeToolStripMenuItem";
            this.DiamondInShapeToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.DiamondInShapeToolStripMenuItem.Text = "菱形(&D)";
            this.DiamondInShapeToolStripMenuItem.Click += new System.EventHandler(this.DiamondInShapeToolStripMenuItem_Click);
            // 
            // TriangleInShapeToolStripMenuItem
            // 
            this.TriangleInShapeToolStripMenuItem.Name = "TriangleInShapeToolStripMenuItem";
            this.TriangleInShapeToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.TriangleInShapeToolStripMenuItem.Text = "等腰三角形(&T)";
            this.TriangleInShapeToolStripMenuItem.Click += new System.EventHandler(this.TriangleInShapeToolStripMenuItem_Click);
            // 
            // RoundRectangleInShapeToolStripMenuItem
            // 
            this.RoundRectangleInShapeToolStripMenuItem.Name = "RoundRectangleInShapeToolStripMenuItem";
            this.RoundRectangleInShapeToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.RoundRectangleInShapeToolStripMenuItem.Text = "圆角矩形(&O)";
            this.RoundRectangleInShapeToolStripMenuItem.Click += new System.EventHandler(this.RoundRectangleInShapeToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutInHelpToolStripMenuItem,
            this.HelpInHelpToolStripMenuItem1});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.HelpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // AboutInHelpToolStripMenuItem
            // 
            this.AboutInHelpToolStripMenuItem.Name = "AboutInHelpToolStripMenuItem";
            this.AboutInHelpToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.AboutInHelpToolStripMenuItem.Text = "关于(&A)";
            this.AboutInHelpToolStripMenuItem.Click += new System.EventHandler(this.AboutInHelpToolStripMenuItem_Click);
            // 
            // HelpInHelpToolStripMenuItem1
            // 
            this.HelpInHelpToolStripMenuItem1.Name = "HelpInHelpToolStripMenuItem1";
            this.HelpInHelpToolStripMenuItem1.Size = new System.Drawing.Size(136, 26);
            this.HelpInHelpToolStripMenuItem1.Text = "帮助(&H)";
            this.HelpInHelpToolStripMenuItem1.Click += new System.EventHandler(this.HelpInHelpToolStripMenuItem1_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMain.Location = new System.Drawing.Point(0, 28);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(909, 401);
            this.pictureBoxMain.TabIndex = 1;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseClick);
            this.pictureBoxMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDoubleClick);
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // openFileDialogMain
            // 
            this.openFileDialogMain.FileName = "openFileDialog1";
            // 
            // XmlPainterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 429);
            this.Controls.Add(this.pictureBoxMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "XmlPainterForm";
            this.Text = "Xml Painter";
            this.Load += new System.EventHandler(this.XmlPainterForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XmlPainterForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.XmlPainterForm_KeyUp);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenInFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveInFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogMain;
        private System.Windows.Forms.OpenFileDialog openFileDialogMain;
        private System.Windows.Forms.ToolStripMenuItem OperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CursorInOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LineInOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextInOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CircleInShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RectangleInShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EllipseInShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EraseInOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SavePictureInFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DiamondInShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TriangleInShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RoundRectangleInShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoreLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ArrowLineInOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FillArrowLineInOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutInHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpInHelpToolStripMenuItem1;
    }
}

