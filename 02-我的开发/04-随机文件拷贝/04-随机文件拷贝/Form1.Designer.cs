namespace _04_随机文件拷贝
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.folderBrowserDialog_Src = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog_Drt = new System.Windows.Forms.FolderBrowserDialog();
            this.button_Src = new System.Windows.Forms.Button();
            this.button_Drt = new System.Windows.Forms.Button();
            this.textBox_Src = new System.Windows.Forms.TextBox();
            this.textBox_Drt = new System.Windows.Forms.TextBox();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.numericUpDown_count = new System.Windows.Forms.NumericUpDown();
            this.button_rand = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.checkBox_recovery = new System.Windows.Forms.CheckBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.splitContainer_List = new System.Windows.Forms.SplitContainer();
            this.listBox_Src = new System.Windows.Forms.ListBox();
            this.statusStrip_tips = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBox_Drt = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_List)).BeginInit();
            this.splitContainer_List.Panel1.SuspendLayout();
            this.splitContainer_List.Panel2.SuspendLayout();
            this.splitContainer_List.SuspendLayout();
            this.statusStrip_tips.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Src
            // 
            this.button_Src.BackColor = System.Drawing.Color.White;
            this.button_Src.Location = new System.Drawing.Point(376, 3);
            this.button_Src.Name = "button_Src";
            this.button_Src.Size = new System.Drawing.Size(75, 23);
            this.button_Src.TabIndex = 0;
            this.button_Src.Text = "源文件夹";
            this.button_Src.UseVisualStyleBackColor = false;
            this.button_Src.Click += new System.EventHandler(this.button_Src_Click);
            // 
            // button_Drt
            // 
            this.button_Drt.BackColor = System.Drawing.Color.White;
            this.button_Drt.Location = new System.Drawing.Point(376, 34);
            this.button_Drt.Name = "button_Drt";
            this.button_Drt.Size = new System.Drawing.Size(75, 23);
            this.button_Drt.TabIndex = 1;
            this.button_Drt.Text = "新文件夹";
            this.button_Drt.UseVisualStyleBackColor = false;
            this.button_Drt.Click += new System.EventHandler(this.button_Drt_Click);
            // 
            // textBox_Src
            // 
            this.textBox_Src.BackColor = System.Drawing.Color.White;
            this.textBox_Src.Location = new System.Drawing.Point(3, 3);
            this.textBox_Src.Name = "textBox_Src";
            this.textBox_Src.ReadOnly = true;
            this.textBox_Src.Size = new System.Drawing.Size(367, 25);
            this.textBox_Src.TabIndex = 2;
            // 
            // textBox_Drt
            // 
            this.textBox_Drt.BackColor = System.Drawing.Color.White;
            this.textBox_Drt.Location = new System.Drawing.Point(3, 34);
            this.textBox_Drt.Name = "textBox_Drt";
            this.textBox_Drt.ReadOnly = true;
            this.textBox_Drt.Size = new System.Drawing.Size(367, 25);
            this.textBox_Drt.TabIndex = 3;
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            this.splitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.splitContainer_List);
            this.splitContainer_Main.Size = new System.Drawing.Size(776, 542);
            this.splitContainer_Main.SplitterDistance = 88;
            this.splitContainer_Main.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.textBox_Src);
            this.flowLayoutPanel1.Controls.Add(this.button_Src);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDown_count);
            this.flowLayoutPanel1.Controls.Add(this.button_rand);
            this.flowLayoutPanel1.Controls.Add(this.button_remove);
            this.flowLayoutPanel1.Controls.Add(this.textBox_Drt);
            this.flowLayoutPanel1.Controls.Add(this.button_Drt);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_recovery);
            this.flowLayoutPanel1.Controls.Add(this.button_start);
            this.flowLayoutPanel1.Controls.Add(this.button_clear);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 88);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // numericUpDown_count
            // 
            this.numericUpDown_count.BackColor = System.Drawing.Color.White;
            this.numericUpDown_count.Location = new System.Drawing.Point(457, 3);
            this.numericUpDown_count.Name = "numericUpDown_count";
            this.numericUpDown_count.Size = new System.Drawing.Size(104, 25);
            this.numericUpDown_count.TabIndex = 6;
            this.numericUpDown_count.ValueChanged += new System.EventHandler(this.numericUpDown_count_ValueChanged);
            // 
            // button_rand
            // 
            this.button_rand.BackColor = System.Drawing.Color.White;
            this.button_rand.Location = new System.Drawing.Point(567, 3);
            this.button_rand.Name = "button_rand";
            this.button_rand.Size = new System.Drawing.Size(75, 23);
            this.button_rand.TabIndex = 4;
            this.button_rand.Text = "随机";
            this.button_rand.UseVisualStyleBackColor = false;
            this.button_rand.Click += new System.EventHandler(this.button_rand_Click);
            // 
            // button_remove
            // 
            this.button_remove.BackColor = System.Drawing.Color.White;
            this.button_remove.Location = new System.Drawing.Point(648, 3);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(75, 23);
            this.button_remove.TabIndex = 8;
            this.button_remove.Text = "移除";
            this.button_remove.UseVisualStyleBackColor = false;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // checkBox_recovery
            // 
            this.checkBox_recovery.AutoSize = true;
            this.checkBox_recovery.BackColor = System.Drawing.Color.White;
            this.checkBox_recovery.Location = new System.Drawing.Point(457, 34);
            this.checkBox_recovery.Name = "checkBox_recovery";
            this.checkBox_recovery.Size = new System.Drawing.Size(104, 19);
            this.checkBox_recovery.TabIndex = 7;
            this.checkBox_recovery.Text = "覆盖已存在";
            this.checkBox_recovery.UseVisualStyleBackColor = false;
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.White;
            this.button_start.Location = new System.Drawing.Point(567, 34);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 5;
            this.button_start.Text = "复制";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.White;
            this.button_clear.Location = new System.Drawing.Point(648, 34);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 9;
            this.button_clear.Text = "清空";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // splitContainer_List
            // 
            this.splitContainer_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_List.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_List.Name = "splitContainer_List";
            // 
            // splitContainer_List.Panel1
            // 
            this.splitContainer_List.Panel1.Controls.Add(this.listBox_Src);
            // 
            // splitContainer_List.Panel2
            // 
            this.splitContainer_List.Panel2.Controls.Add(this.statusStrip_tips);
            this.splitContainer_List.Panel2.Controls.Add(this.listBox_Drt);
            this.splitContainer_List.Size = new System.Drawing.Size(776, 450);
            this.splitContainer_List.SplitterDistance = 377;
            this.splitContainer_List.TabIndex = 0;
            // 
            // listBox_Src
            // 
            this.listBox_Src.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Src.FormattingEnabled = true;
            this.listBox_Src.ItemHeight = 15;
            this.listBox_Src.Location = new System.Drawing.Point(0, 0);
            this.listBox_Src.Name = "listBox_Src";
            this.listBox_Src.Size = new System.Drawing.Size(377, 450);
            this.listBox_Src.Sorted = true;
            this.listBox_Src.TabIndex = 0;
            // 
            // statusStrip_tips
            // 
            this.statusStrip_tips.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip_tips.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_info});
            this.statusStrip_tips.Location = new System.Drawing.Point(0, 425);
            this.statusStrip_tips.Name = "statusStrip_tips";
            this.statusStrip_tips.Size = new System.Drawing.Size(395, 25);
            this.statusStrip_tips.TabIndex = 1;
            this.statusStrip_tips.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_info
            // 
            this.toolStripStatusLabel_info.Name = "toolStripStatusLabel_info";
            this.toolStripStatusLabel_info.Size = new System.Drawing.Size(39, 20);
            this.toolStripStatusLabel_info.Text = "就绪";
            // 
            // listBox_Drt
            // 
            this.listBox_Drt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Drt.FormattingEnabled = true;
            this.listBox_Drt.ItemHeight = 15;
            this.listBox_Drt.Location = new System.Drawing.Point(0, 0);
            this.listBox_Drt.Name = "listBox_Drt";
            this.listBox_Drt.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Drt.Size = new System.Drawing.Size(395, 450);
            this.listBox_Drt.Sorted = true;
            this.listBox_Drt.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(776, 542);
            this.Controls.Add(this.splitContainer_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "随机文件拷贝";
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).EndInit();
            this.splitContainer_List.Panel1.ResumeLayout(false);
            this.splitContainer_List.Panel2.ResumeLayout(false);
            this.splitContainer_List.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_List)).EndInit();
            this.splitContainer_List.ResumeLayout(false);
            this.statusStrip_tips.ResumeLayout(false);
            this.statusStrip_tips.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Src;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Drt;
        private System.Windows.Forms.Button button_Src;
        private System.Windows.Forms.Button button_Drt;
        private System.Windows.Forms.TextBox textBox_Src;
        private System.Windows.Forms.TextBox textBox_Drt;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.SplitContainer splitContainer_List;
        private System.Windows.Forms.ListBox listBox_Src;
        private System.Windows.Forms.ListBox listBox_Drt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button_rand;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.NumericUpDown numericUpDown_count;
        private System.Windows.Forms.CheckBox checkBox_recovery;
        private System.Windows.Forms.StatusStrip statusStrip_tips;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_info;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_clear;
    }
}

