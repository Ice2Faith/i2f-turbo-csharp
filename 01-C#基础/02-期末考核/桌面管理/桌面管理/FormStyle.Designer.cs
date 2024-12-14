namespace StyleSuit
{
    partial class FormStyle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStyle));
            this.panelHeadBorder = new System.Windows.Forms.Panel();
            this.buttonLock = new System.Windows.Forms.Button();
            this.buttonShrink = new System.Windows.Forms.Button();
            this.buttonNameWnd = new System.Windows.Forms.Button();
            this.buttonTitleWnd = new System.Windows.Forms.Button();
            this.buttonIconWnd = new System.Windows.Forms.Button();
            this.buttonMinWnd = new System.Windows.Forms.Button();
            this.buttonMaxWnd = new System.Windows.Forms.Button();
            this.buttonCloseWnd = new System.Windows.Forms.Button();
            this.panelButtomBorder = new System.Windows.Forms.Panel();
            this.panelLeftBorder = new System.Windows.Forms.Panel();
            this.panelRightBorder = new System.Windows.Forms.Panel();
            this.panelClient = new System.Windows.Forms.Panel();
            this.panelHeadBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeadBorder
            // 
            this.panelHeadBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelHeadBorder.Controls.Add(this.buttonLock);
            this.panelHeadBorder.Controls.Add(this.buttonShrink);
            this.panelHeadBorder.Controls.Add(this.buttonNameWnd);
            this.panelHeadBorder.Controls.Add(this.buttonTitleWnd);
            this.panelHeadBorder.Controls.Add(this.buttonIconWnd);
            this.panelHeadBorder.Controls.Add(this.buttonMinWnd);
            this.panelHeadBorder.Controls.Add(this.buttonMaxWnd);
            this.panelHeadBorder.Controls.Add(this.buttonCloseWnd);
            this.panelHeadBorder.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.panelHeadBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeadBorder.Location = new System.Drawing.Point(0, 0);
            this.panelHeadBorder.Name = "panelHeadBorder";
            this.panelHeadBorder.Size = new System.Drawing.Size(702, 31);
            this.panelHeadBorder.TabIndex = 0;
            this.panelHeadBorder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseDoubleClick);
            this.panelHeadBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panelHeadBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseMove);
            // 
            // buttonLock
            // 
            this.buttonLock.AutoSize = true;
            this.buttonLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLock.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonLock.FlatAppearance.BorderSize = 0;
            this.buttonLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLock.Location = new System.Drawing.Point(179, 0);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(51, 31);
            this.buttonLock.TabIndex = 3;
            this.buttonLock.Text = "锁定";
            this.buttonLock.UseVisualStyleBackColor = false;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // buttonShrink
            // 
            this.buttonShrink.AutoSize = true;
            this.buttonShrink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonShrink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShrink.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonShrink.FlatAppearance.BorderSize = 0;
            this.buttonShrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShrink.Location = new System.Drawing.Point(128, 0);
            this.buttonShrink.Name = "buttonShrink";
            this.buttonShrink.Size = new System.Drawing.Size(51, 31);
            this.buttonShrink.TabIndex = 3;
            this.buttonShrink.Text = "折叠";
            this.buttonShrink.UseVisualStyleBackColor = false;
            this.buttonShrink.Click += new System.EventHandler(this.buttonShrink_Click);
            // 
            // buttonNameWnd
            // 
            this.buttonNameWnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonNameWnd.AutoSize = true;
            this.buttonNameWnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonNameWnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNameWnd.FlatAppearance.BorderSize = 0;
            this.buttonNameWnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNameWnd.Location = new System.Drawing.Point(288, 0);
            this.buttonNameWnd.Name = "buttonNameWnd";
            this.buttonNameWnd.Size = new System.Drawing.Size(75, 31);
            this.buttonNameWnd.TabIndex = 5;
            this.buttonNameWnd.Text = "窗口名";
            this.buttonNameWnd.UseVisualStyleBackColor = false;
            // 
            // buttonTitleWnd
            // 
            this.buttonTitleWnd.AutoSize = true;
            this.buttonTitleWnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonTitleWnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTitleWnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonTitleWnd.FlatAppearance.BorderSize = 0;
            this.buttonTitleWnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTitleWnd.Location = new System.Drawing.Point(51, 0);
            this.buttonTitleWnd.Name = "buttonTitleWnd";
            this.buttonTitleWnd.Size = new System.Drawing.Size(77, 31);
            this.buttonTitleWnd.TabIndex = 4;
            this.buttonTitleWnd.Text = "窗口标题";
            this.buttonTitleWnd.UseVisualStyleBackColor = false;
            // 
            // buttonIconWnd
            // 
            this.buttonIconWnd.AutoSize = true;
            this.buttonIconWnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonIconWnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonIconWnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonIconWnd.FlatAppearance.BorderSize = 0;
            this.buttonIconWnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIconWnd.Location = new System.Drawing.Point(0, 0);
            this.buttonIconWnd.Name = "buttonIconWnd";
            this.buttonIconWnd.Size = new System.Drawing.Size(51, 31);
            this.buttonIconWnd.TabIndex = 3;
            this.buttonIconWnd.Text = "Icon";
            this.buttonIconWnd.UseVisualStyleBackColor = false;
            // 
            // buttonMinWnd
            // 
            this.buttonMinWnd.AutoSize = true;
            this.buttonMinWnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonMinWnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinWnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMinWnd.FlatAppearance.BorderSize = 0;
            this.buttonMinWnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinWnd.Location = new System.Drawing.Point(527, 0);
            this.buttonMinWnd.Name = "buttonMinWnd";
            this.buttonMinWnd.Size = new System.Drawing.Size(62, 31);
            this.buttonMinWnd.TabIndex = 2;
            this.buttonMinWnd.Text = "最小化";
            this.buttonMinWnd.UseVisualStyleBackColor = false;
            this.buttonMinWnd.Click += new System.EventHandler(this.buttonMinWnd_Click);
            // 
            // buttonMaxWnd
            // 
            this.buttonMaxWnd.AutoSize = true;
            this.buttonMaxWnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonMaxWnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMaxWnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMaxWnd.FlatAppearance.BorderSize = 0;
            this.buttonMaxWnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxWnd.Location = new System.Drawing.Point(589, 0);
            this.buttonMaxWnd.Name = "buttonMaxWnd";
            this.buttonMaxWnd.Size = new System.Drawing.Size(62, 31);
            this.buttonMaxWnd.TabIndex = 1;
            this.buttonMaxWnd.Text = "最大化";
            this.buttonMaxWnd.UseVisualStyleBackColor = false;
            this.buttonMaxWnd.Click += new System.EventHandler(this.buttonMaxWnd_Click);
            // 
            // buttonCloseWnd
            // 
            this.buttonCloseWnd.AutoSize = true;
            this.buttonCloseWnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonCloseWnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCloseWnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCloseWnd.FlatAppearance.BorderSize = 0;
            this.buttonCloseWnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseWnd.Location = new System.Drawing.Point(651, 0);
            this.buttonCloseWnd.Name = "buttonCloseWnd";
            this.buttonCloseWnd.Size = new System.Drawing.Size(51, 31);
            this.buttonCloseWnd.TabIndex = 0;
            this.buttonCloseWnd.Text = "关闭";
            this.buttonCloseWnd.UseVisualStyleBackColor = false;
            this.buttonCloseWnd.Click += new System.EventHandler(this.buttonCloseWnd_Click);
            // 
            // panelButtomBorder
            // 
            this.panelButtomBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelButtomBorder.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelButtomBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtomBorder.Location = new System.Drawing.Point(0, 650);
            this.panelButtomBorder.Name = "panelButtomBorder";
            this.panelButtomBorder.Size = new System.Drawing.Size(702, 5);
            this.panelButtomBorder.TabIndex = 1;
            this.panelButtomBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panelButtomBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorderResize_MouseMove);
            // 
            // panelLeftBorder
            // 
            this.panelLeftBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelLeftBorder.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelLeftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftBorder.Location = new System.Drawing.Point(0, 31);
            this.panelLeftBorder.Name = "panelLeftBorder";
            this.panelLeftBorder.Size = new System.Drawing.Size(5, 619);
            this.panelLeftBorder.TabIndex = 2;
            this.panelLeftBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panelLeftBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorderResize_MouseMove);
            // 
            // panelRightBorder
            // 
            this.panelRightBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelRightBorder.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelRightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightBorder.Location = new System.Drawing.Point(697, 31);
            this.panelRightBorder.Name = "panelRightBorder";
            this.panelRightBorder.Size = new System.Drawing.Size(5, 619);
            this.panelRightBorder.TabIndex = 3;
            this.panelRightBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panelRightBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorderResize_MouseMove);
            // 
            // panelClient
            // 
            this.panelClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClient.Location = new System.Drawing.Point(5, 31);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(692, 619);
            this.panelClient.TabIndex = 4;
            // 
            // FormStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(702, 655);
            this.Controls.Add(this.panelClient);
            this.Controls.Add(this.panelRightBorder);
            this.Controls.Add(this.panelLeftBorder);
            this.Controls.Add(this.panelButtomBorder);
            this.Controls.Add(this.panelHeadBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStyle";
            this.Text = "FormStyle";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Resize += new System.EventHandler(this.FormStyle_Resize);
            this.panelHeadBorder.ResumeLayout(false);
            this.panelHeadBorder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelHeadBorder;
        public System.Windows.Forms.Button buttonNameWnd;
        public System.Windows.Forms.Button buttonTitleWnd;
        public System.Windows.Forms.Button buttonIconWnd;
        public System.Windows.Forms.Button buttonMinWnd;
        public System.Windows.Forms.Button buttonMaxWnd;
        public System.Windows.Forms.Button buttonCloseWnd;
        public System.Windows.Forms.Panel panelButtomBorder;
        public System.Windows.Forms.Panel panelLeftBorder;
        public System.Windows.Forms.Panel panelRightBorder;
        public System.Windows.Forms.Panel panelClient;
        public System.Windows.Forms.Button buttonLock;
        public System.Windows.Forms.Button buttonShrink;

    }
}

