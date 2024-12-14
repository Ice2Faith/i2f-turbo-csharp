namespace 聊天室客户端
{
    partial class FormClient
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
            this.panelIPPort = new System.Windows.Forms.Panel();
            this.buttonLink = new System.Windows.Forms.Button();
            this.textBoxInputPort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxInputIP = new System.Windows.Forms.TextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.panelSendMsg = new System.Windows.Forms.Panel();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxInputMsg = new System.Windows.Forms.TextBox();
            this.listBoxMsgs = new System.Windows.Forms.ListBox();
            this.statusStripMain.SuspendLayout();
            this.panelIPPort.SuspendLayout();
            this.panelSendMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLog});
            this.statusStripMain.Location = new System.Drawing.Point(0, 471);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(807, 25);
            this.statusStripMain.TabIndex = 0;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLog
            // 
            this.toolStripStatusLabelLog.Name = "toolStripStatusLabelLog";
            this.toolStripStatusLabelLog.Size = new System.Drawing.Size(39, 20);
            this.toolStripStatusLabelLog.Text = "就绪";
            // 
            // panelIPPort
            // 
            this.panelIPPort.Controls.Add(this.buttonLink);
            this.panelIPPort.Controls.Add(this.textBoxInputPort);
            this.panelIPPort.Controls.Add(this.labelPort);
            this.panelIPPort.Controls.Add(this.textBoxInputIP);
            this.panelIPPort.Controls.Add(this.labelIP);
            this.panelIPPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelIPPort.Location = new System.Drawing.Point(0, 0);
            this.panelIPPort.Name = "panelIPPort";
            this.panelIPPort.Size = new System.Drawing.Size(807, 79);
            this.panelIPPort.TabIndex = 1;
            // 
            // buttonLink
            // 
            this.buttonLink.Location = new System.Drawing.Point(691, 26);
            this.buttonLink.Name = "buttonLink";
            this.buttonLink.Size = new System.Drawing.Size(75, 23);
            this.buttonLink.TabIndex = 4;
            this.buttonLink.Text = "链接";
            this.buttonLink.UseVisualStyleBackColor = true;
            this.buttonLink.Click += new System.EventHandler(this.buttonLink_Click);
            // 
            // textBoxInputPort
            // 
            this.textBoxInputPort.Location = new System.Drawing.Point(585, 24);
            this.textBoxInputPort.Name = "textBoxInputPort";
            this.textBoxInputPort.Size = new System.Drawing.Size(100, 25);
            this.textBoxInputPort.TabIndex = 3;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(523, 34);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(39, 15);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "Port";
            // 
            // textBoxInputIP
            // 
            this.textBoxInputIP.Location = new System.Drawing.Point(75, 24);
            this.textBoxInputIP.Name = "textBoxInputIP";
            this.textBoxInputIP.Size = new System.Drawing.Size(427, 25);
            this.textBoxInputIP.TabIndex = 1;
            this.textBoxInputIP.Text = "59.56.51.164";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(13, 34);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(23, 15);
            this.labelIP.TabIndex = 0;
            this.labelIP.Text = "IP";
            // 
            // panelSendMsg
            // 
            this.panelSendMsg.Controls.Add(this.buttonSend);
            this.panelSendMsg.Controls.Add(this.textBoxInputMsg);
            this.panelSendMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSendMsg.Location = new System.Drawing.Point(0, 412);
            this.panelSendMsg.Name = "panelSendMsg";
            this.panelSendMsg.Size = new System.Drawing.Size(807, 59);
            this.panelSendMsg.TabIndex = 2;
            // 
            // buttonSend
            // 
            this.buttonSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSend.Location = new System.Drawing.Point(732, 0);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 59);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxInputMsg
            // 
            this.textBoxInputMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInputMsg.Location = new System.Drawing.Point(0, 0);
            this.textBoxInputMsg.Multiline = true;
            this.textBoxInputMsg.Name = "textBoxInputMsg";
            this.textBoxInputMsg.Size = new System.Drawing.Size(807, 59);
            this.textBoxInputMsg.TabIndex = 0;
            this.textBoxInputMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputMsg_KeyPress);
            // 
            // listBoxMsgs
            // 
            this.listBoxMsgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMsgs.FormattingEnabled = true;
            this.listBoxMsgs.ItemHeight = 15;
            this.listBoxMsgs.Location = new System.Drawing.Point(0, 79);
            this.listBoxMsgs.Name = "listBoxMsgs";
            this.listBoxMsgs.Size = new System.Drawing.Size(807, 333);
            this.listBoxMsgs.TabIndex = 3;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 496);
            this.Controls.Add(this.listBoxMsgs);
            this.Controls.Add(this.panelSendMsg);
            this.Controls.Add(this.panelIPPort);
            this.Controls.Add(this.statusStripMain);
            this.Name = "FormClient";
            this.Text = "聊天室-客户端";
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.panelIPPort.ResumeLayout(false);
            this.panelIPPort.PerformLayout();
            this.panelSendMsg.ResumeLayout(false);
            this.panelSendMsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.Panel panelIPPort;
        private System.Windows.Forms.Button buttonLink;
        private System.Windows.Forms.TextBox textBoxInputPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxInputIP;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLog;
        private System.Windows.Forms.Panel panelSendMsg;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxInputMsg;
        private System.Windows.Forms.ListBox listBoxMsgs;
    }
}

