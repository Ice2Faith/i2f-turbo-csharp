namespace 聊天室服务器
{
    partial class FormServer
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
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxInputPort = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.panelEndPoint = new System.Windows.Forms.Panel();
            this.comboBoxIP = new System.Windows.Forms.ComboBox();
            this.listBoxMsgs = new System.Windows.Forms.ListBox();
            this.textBoxInputBroad = new System.Windows.Forms.TextBox();
            this.buttonBroad = new System.Windows.Forms.Button();
            this.statusStripMain.SuspendLayout();
            this.panelEndPoint.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLog});
            this.statusStripMain.Location = new System.Drawing.Point(0, 471);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(781, 25);
            this.statusStripMain.TabIndex = 0;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLog
            // 
            this.toolStripStatusLabelLog.Name = "toolStripStatusLabelLog";
            this.toolStripStatusLabelLog.Size = new System.Drawing.Size(39, 20);
            this.toolStripStatusLabelLog.Text = "就绪";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(12, 27);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(23, 15);
            this.labelIP.TabIndex = 1;
            this.labelIP.Text = "IP";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(470, 27);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(37, 15);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "端口";
            // 
            // textBoxInputPort
            // 
            this.textBoxInputPort.Location = new System.Drawing.Point(513, 17);
            this.textBoxInputPort.Name = "textBoxInputPort";
            this.textBoxInputPort.Size = new System.Drawing.Size(81, 25);
            this.textBoxInputPort.TabIndex = 4;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(625, 19);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(144, 23);
            this.buttonRun.TabIndex = 5;
            this.buttonRun.Text = "开启";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // panelEndPoint
            // 
            this.panelEndPoint.Controls.Add(this.buttonBroad);
            this.panelEndPoint.Controls.Add(this.textBoxInputBroad);
            this.panelEndPoint.Controls.Add(this.comboBoxIP);
            this.panelEndPoint.Controls.Add(this.buttonRun);
            this.panelEndPoint.Controls.Add(this.textBoxInputPort);
            this.panelEndPoint.Controls.Add(this.labelIP);
            this.panelEndPoint.Controls.Add(this.labelPort);
            this.panelEndPoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEndPoint.Location = new System.Drawing.Point(0, 0);
            this.panelEndPoint.Name = "panelEndPoint";
            this.panelEndPoint.Size = new System.Drawing.Size(781, 85);
            this.panelEndPoint.TabIndex = 6;
            // 
            // comboBoxIP
            // 
            this.comboBoxIP.FormattingEnabled = true;
            this.comboBoxIP.Location = new System.Drawing.Point(41, 19);
            this.comboBoxIP.Name = "comboBoxIP";
            this.comboBoxIP.Size = new System.Drawing.Size(409, 23);
            this.comboBoxIP.TabIndex = 6;
            // 
            // listBoxMsgs
            // 
            this.listBoxMsgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMsgs.FormattingEnabled = true;
            this.listBoxMsgs.ItemHeight = 15;
            this.listBoxMsgs.Location = new System.Drawing.Point(0, 85);
            this.listBoxMsgs.Name = "listBoxMsgs";
            this.listBoxMsgs.Size = new System.Drawing.Size(781, 386);
            this.listBoxMsgs.TabIndex = 7;
            // 
            // textBoxInputBroad
            // 
            this.textBoxInputBroad.Location = new System.Drawing.Point(41, 48);
            this.textBoxInputBroad.Name = "textBoxInputBroad";
            this.textBoxInputBroad.Size = new System.Drawing.Size(553, 25);
            this.textBoxInputBroad.TabIndex = 7;
            this.textBoxInputBroad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputBroad_KeyPress);
            // 
            // buttonBroad
            // 
            this.buttonBroad.Location = new System.Drawing.Point(625, 49);
            this.buttonBroad.Name = "buttonBroad";
            this.buttonBroad.Size = new System.Drawing.Size(144, 23);
            this.buttonBroad.TabIndex = 8;
            this.buttonBroad.Text = "发送广播";
            this.buttonBroad.UseVisualStyleBackColor = true;
            this.buttonBroad.Click += new System.EventHandler(this.buttonBroad_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 496);
            this.Controls.Add(this.listBoxMsgs);
            this.Controls.Add(this.panelEndPoint);
            this.Controls.Add(this.statusStripMain);
            this.Name = "FormServer";
            this.Text = "聊天室-服务器";
            this.Load += new System.EventHandler(this.FormServer_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.panelEndPoint.ResumeLayout(false);
            this.panelEndPoint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLog;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxInputPort;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Panel panelEndPoint;
        private System.Windows.Forms.ListBox listBoxMsgs;
        private System.Windows.Forms.ComboBox comboBoxIP;
        private System.Windows.Forms.Button buttonBroad;
        private System.Windows.Forms.TextBox textBoxInputBroad;
    }
}

