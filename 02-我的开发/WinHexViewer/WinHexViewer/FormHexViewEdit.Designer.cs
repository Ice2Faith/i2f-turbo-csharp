namespace WinHexViewer
{
    partial class FormHexViewEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHexViewEdit));
            this.hexViewer1 = new WinHexViewer.HexViewer();
            this.SuspendLayout();
            // 
            // hexViewer1
            // 
            this.hexViewer1.DisplayLineCount = 16;
            this.hexViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexViewer1.FileName = null;
            this.hexViewer1.LineByteCount = 16;
            this.hexViewer1.Location = new System.Drawing.Point(0, 0);
            this.hexViewer1.Name = "hexViewer1";
            this.hexViewer1.Size = new System.Drawing.Size(619, 552);
            this.hexViewer1.TabIndex = 0;
            // 
            // FormHexViewEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 552);
            this.Controls.Add(this.hexViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHexViewEdit";
            this.Text = "Hex编辑器-Ugex";
            this.ResumeLayout(false);

        }

        #endregion

        private HexViewer hexViewer1;
    }
}

