namespace WinHexViewer
{
    partial class HexViewer
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
            DeleteTempFile();
            base.Dispose(disposing);
            
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxEditLine = new System.Windows.Forms.TextBox();
            this.panelControlBar = new System.Windows.Forms.Panel();
            this.panelHelpBox = new System.Windows.Forms.Panel();
            this.textBoxHexCode = new System.Windows.Forms.TextBox();
            this.textBoxNumCode = new System.Windows.Forms.TextBox();
            this.textBoxCharCode = new System.Windows.Forms.TextBox();
            this.buttonSelectLine = new System.Windows.Forms.Button();
            this.buttonPageIndex = new System.Windows.Forms.Button();
            this.buttonSaveModify = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.panelBox = new System.Windows.Forms.Panel();
            this.listBoxContent = new System.Windows.Forms.ListBox();
            this.saveFileDialogSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.panelControlBar.SuspendLayout();
            this.panelHelpBox.SuspendLayout();
            this.panelBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxEditLine
            // 
            this.textBoxEditLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxEditLine.Location = new System.Drawing.Point(0, 0);
            this.textBoxEditLine.Name = "textBoxEditLine";
            this.textBoxEditLine.Size = new System.Drawing.Size(632, 25);
            this.textBoxEditLine.TabIndex = 1;
            this.textBoxEditLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEditLine_KeyDown);
            // 
            // panelControlBar
            // 
            this.panelControlBar.Controls.Add(this.panelHelpBox);
            this.panelControlBar.Controls.Add(this.buttonSelectLine);
            this.panelControlBar.Controls.Add(this.buttonPageIndex);
            this.panelControlBar.Controls.Add(this.buttonSaveModify);
            this.panelControlBar.Controls.Add(this.buttonNextPage);
            this.panelControlBar.Controls.Add(this.buttonApply);
            this.panelControlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlBar.Location = new System.Drawing.Point(0, 25);
            this.panelControlBar.Name = "panelControlBar";
            this.panelControlBar.Size = new System.Drawing.Size(632, 41);
            this.panelControlBar.TabIndex = 2;
            // 
            // panelHelpBox
            // 
            this.panelHelpBox.Controls.Add(this.textBoxHexCode);
            this.panelHelpBox.Controls.Add(this.textBoxNumCode);
            this.panelHelpBox.Controls.Add(this.textBoxCharCode);
            this.panelHelpBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelHelpBox.Location = new System.Drawing.Point(347, 0);
            this.panelHelpBox.Name = "panelHelpBox";
            this.panelHelpBox.Size = new System.Drawing.Size(210, 41);
            this.panelHelpBox.TabIndex = 5;
            // 
            // textBoxHexCode
            // 
            this.textBoxHexCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBoxHexCode.Location = new System.Drawing.Point(2, 0);
            this.textBoxHexCode.MaxLength = 2;
            this.textBoxHexCode.Multiline = true;
            this.textBoxHexCode.Name = "textBoxHexCode";
            this.textBoxHexCode.Size = new System.Drawing.Size(69, 41);
            this.textBoxHexCode.TabIndex = 2;
            this.textBoxHexCode.Leave += new System.EventHandler(this.textBoxHexCode_Leave);
            // 
            // textBoxNumCode
            // 
            this.textBoxNumCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBoxNumCode.Location = new System.Drawing.Point(71, 0);
            this.textBoxNumCode.MaxLength = 3;
            this.textBoxNumCode.Multiline = true;
            this.textBoxNumCode.Name = "textBoxNumCode";
            this.textBoxNumCode.Size = new System.Drawing.Size(73, 41);
            this.textBoxNumCode.TabIndex = 1;
            this.textBoxNumCode.Leave += new System.EventHandler(this.textBoxNumCode_Leave);
            // 
            // textBoxCharCode
            // 
            this.textBoxCharCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBoxCharCode.Location = new System.Drawing.Point(144, 0);
            this.textBoxCharCode.MaxLength = 1;
            this.textBoxCharCode.Multiline = true;
            this.textBoxCharCode.Name = "textBoxCharCode";
            this.textBoxCharCode.Size = new System.Drawing.Size(66, 41);
            this.textBoxCharCode.TabIndex = 0;
            this.textBoxCharCode.Leave += new System.EventHandler(this.textBoxCharCode_Leave);
            // 
            // buttonSelectLine
            // 
            this.buttonSelectLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSelectLine.FlatAppearance.BorderSize = 0;
            this.buttonSelectLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectLine.Location = new System.Drawing.Point(225, 0);
            this.buttonSelectLine.Name = "buttonSelectLine";
            this.buttonSelectLine.Size = new System.Drawing.Size(75, 41);
            this.buttonSelectLine.TabIndex = 4;
            this.buttonSelectLine.Text = "选中行";
            this.buttonSelectLine.UseVisualStyleBackColor = true;
            // 
            // buttonPageIndex
            // 
            this.buttonPageIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPageIndex.FlatAppearance.BorderSize = 0;
            this.buttonPageIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPageIndex.Location = new System.Drawing.Point(150, 0);
            this.buttonPageIndex.Name = "buttonPageIndex";
            this.buttonPageIndex.Size = new System.Drawing.Size(75, 41);
            this.buttonPageIndex.TabIndex = 3;
            this.buttonPageIndex.Text = "页码";
            this.buttonPageIndex.UseVisualStyleBackColor = true;
            // 
            // buttonSaveModify
            // 
            this.buttonSaveModify.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSaveModify.Location = new System.Drawing.Point(557, 0);
            this.buttonSaveModify.Name = "buttonSaveModify";
            this.buttonSaveModify.Size = new System.Drawing.Size(75, 41);
            this.buttonSaveModify.TabIndex = 2;
            this.buttonSaveModify.Text = "保存修改";
            this.buttonSaveModify.UseVisualStyleBackColor = true;
            this.buttonSaveModify.Click += new System.EventHandler(this.buttonSaveModify_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonNextPage.Location = new System.Drawing.Point(75, 0);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(75, 41);
            this.buttonNextPage.TabIndex = 1;
            this.buttonNextPage.Text = "下一页";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonApply.Location = new System.Drawing.Point(0, 0);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 41);
            this.buttonApply.TabIndex = 0;
            this.buttonApply.Text = "修改";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // panelBox
            // 
            this.panelBox.Controls.Add(this.listBoxContent);
            this.panelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBox.Location = new System.Drawing.Point(0, 66);
            this.panelBox.Name = "panelBox";
            this.panelBox.Size = new System.Drawing.Size(632, 437);
            this.panelBox.TabIndex = 3;
            // 
            // listBoxContent
            // 
            this.listBoxContent.AllowDrop = true;
            this.listBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxContent.FormattingEnabled = true;
            this.listBoxContent.ItemHeight = 15;
            this.listBoxContent.Location = new System.Drawing.Point(0, 0);
            this.listBoxContent.Name = "listBoxContent";
            this.listBoxContent.Size = new System.Drawing.Size(632, 437);
            this.listBoxContent.TabIndex = 0;
            this.listBoxContent.Click += new System.EventHandler(this.listBoxContent_Click);
            this.listBoxContent.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxContent_DragDrop);
            this.listBoxContent.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxContent_DragEnter);
            this.listBoxContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxContent_KeyDown);
            // 
            // HexViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBox);
            this.Controls.Add(this.panelControlBar);
            this.Controls.Add(this.textBoxEditLine);
            this.Name = "HexViewer";
            this.Size = new System.Drawing.Size(632, 503);
            this.panelControlBar.ResumeLayout(false);
            this.panelHelpBox.ResumeLayout(false);
            this.panelHelpBox.PerformLayout();
            this.panelBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxEditLine;
        public System.Windows.Forms.Panel panelControlBar;
        public System.Windows.Forms.Button buttonSelectLine;
        public System.Windows.Forms.Button buttonPageIndex;
        public System.Windows.Forms.Button buttonSaveModify;
        public System.Windows.Forms.Button buttonNextPage;
        public System.Windows.Forms.Button buttonApply;
        public System.Windows.Forms.Panel panelBox;
        public System.Windows.Forms.ListBox listBoxContent;
        public System.Windows.Forms.SaveFileDialog saveFileDialogSaveFile;
        public System.Windows.Forms.Panel panelHelpBox;
        public System.Windows.Forms.TextBox textBoxHexCode;
        public System.Windows.Forms.TextBox textBoxNumCode;
        public System.Windows.Forms.TextBox textBoxCharCode;
    }
}
