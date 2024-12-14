namespace FileExplorer
{
    partial class SeniorSetting
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.dateTimePicker_createTime = new System.Windows.Forms.DateTimePicker();
            this.label_createTime = new System.Windows.Forms.Label();
            this.label_lastaccess = new System.Windows.Forms.Label();
            this.dateTimePicker_lastaccess = new System.Windows.Forms.DateTimePicker();
            this.label_lastmodify = new System.Windows.Forms.Label();
            this.dateTimePicker_lastmodify = new System.Windows.Forms.DateTimePicker();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBox_filename = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.listBox_hexcontext = new System.Windows.Forms.ListBox();
            this.listBox_txtcontext = new System.Windows.Forms.ListBox();
            this.button_nextpage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button_nextpage);
            this.splitContainer1.Panel2.Controls.Add(this.label_lastmodify);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePicker_lastmodify);
            this.splitContainer1.Panel2.Controls.Add(this.label_lastaccess);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePicker_lastaccess);
            this.splitContainer1.Panel2.Controls.Add(this.label_createTime);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePicker_createTime);
            this.splitContainer1.Panel2.Controls.Add(this.button_cancel);
            this.splitContainer1.Panel2.Controls.Add(this.button_apply);
            this.splitContainer1.Size = new System.Drawing.Size(892, 638);
            this.splitContainer1.SplitterDistance = 602;
            this.splitContainer1.TabIndex = 0;
            // 
            // button_apply
            // 
            this.button_apply.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_apply.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_apply.Location = new System.Drawing.Point(0, 597);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(286, 41);
            this.button_apply.TabIndex = 0;
            this.button_apply.Text = "应用";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancel.Location = new System.Drawing.Point(0, 550);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(286, 47);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // dateTimePicker_createTime
            // 
            this.dateTimePicker_createTime.CustomFormat = "yyyy年MM月dd日 hh:mm:ss";
            this.dateTimePicker_createTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_createTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_createTime.Location = new System.Drawing.Point(1, 33);
            this.dateTimePicker_createTime.Name = "dateTimePicker_createTime";
            this.dateTimePicker_createTime.ShowUpDown = true;
            this.dateTimePicker_createTime.Size = new System.Drawing.Size(273, 30);
            this.dateTimePicker_createTime.TabIndex = 2;
            // 
            // label_createTime
            // 
            this.label_createTime.AutoSize = true;
            this.label_createTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_createTime.Location = new System.Drawing.Point(3, 9);
            this.label_createTime.Name = "label_createTime";
            this.label_createTime.Size = new System.Drawing.Size(89, 20);
            this.label_createTime.TabIndex = 3;
            this.label_createTime.Text = "创建时间";
            // 
            // label_lastaccess
            // 
            this.label_lastaccess.AutoSize = true;
            this.label_lastaccess.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_lastaccess.Location = new System.Drawing.Point(3, 67);
            this.label_lastaccess.Name = "label_lastaccess";
            this.label_lastaccess.Size = new System.Drawing.Size(129, 20);
            this.label_lastaccess.TabIndex = 5;
            this.label_lastaccess.Text = "最后访问时间";
            // 
            // dateTimePicker_lastaccess
            // 
            this.dateTimePicker_lastaccess.CustomFormat = "yyyy年MM月dd日 hh:mm:ss";
            this.dateTimePicker_lastaccess.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_lastaccess.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_lastaccess.Location = new System.Drawing.Point(1, 91);
            this.dateTimePicker_lastaccess.Name = "dateTimePicker_lastaccess";
            this.dateTimePicker_lastaccess.ShowUpDown = true;
            this.dateTimePicker_lastaccess.Size = new System.Drawing.Size(273, 30);
            this.dateTimePicker_lastaccess.TabIndex = 4;
            // 
            // label_lastmodify
            // 
            this.label_lastmodify.AutoSize = true;
            this.label_lastmodify.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_lastmodify.Location = new System.Drawing.Point(3, 125);
            this.label_lastmodify.Name = "label_lastmodify";
            this.label_lastmodify.Size = new System.Drawing.Size(129, 20);
            this.label_lastmodify.TabIndex = 7;
            this.label_lastmodify.Text = "最后修改时间";
            // 
            // dateTimePicker_lastmodify
            // 
            this.dateTimePicker_lastmodify.CustomFormat = "yyyy年MM月dd日 hh:mm:ss";
            this.dateTimePicker_lastmodify.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_lastmodify.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_lastmodify.Location = new System.Drawing.Point(1, 149);
            this.dateTimePicker_lastmodify.Name = "dateTimePicker_lastmodify";
            this.dateTimePicker_lastmodify.ShowUpDown = true;
            this.dateTimePicker_lastmodify.Size = new System.Drawing.Size(273, 30);
            this.dateTimePicker_lastmodify.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBox_filename);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(602, 638);
            this.splitContainer2.SplitterDistance = 28;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBox_filename
            // 
            this.textBox_filename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_filename.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_filename.Location = new System.Drawing.Point(0, 0);
            this.textBox_filename.Multiline = true;
            this.textBox_filename.Name = "textBox_filename";
            this.textBox_filename.ReadOnly = true;
            this.textBox_filename.Size = new System.Drawing.Size(602, 28);
            this.textBox_filename.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listBox_hexcontext);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listBox_txtcontext);
            this.splitContainer3.Size = new System.Drawing.Size(602, 606);
            this.splitContainer3.SplitterDistance = 307;
            this.splitContainer3.TabIndex = 0;
            // 
            // listBox_hexcontext
            // 
            this.listBox_hexcontext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_hexcontext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_hexcontext.FormattingEnabled = true;
            this.listBox_hexcontext.ItemHeight = 20;
            this.listBox_hexcontext.Location = new System.Drawing.Point(0, 0);
            this.listBox_hexcontext.Name = "listBox_hexcontext";
            this.listBox_hexcontext.Size = new System.Drawing.Size(307, 606);
            this.listBox_hexcontext.TabIndex = 0;
            // 
            // listBox_txtcontext
            // 
            this.listBox_txtcontext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_txtcontext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_txtcontext.FormattingEnabled = true;
            this.listBox_txtcontext.ItemHeight = 20;
            this.listBox_txtcontext.Location = new System.Drawing.Point(0, 0);
            this.listBox_txtcontext.Name = "listBox_txtcontext";
            this.listBox_txtcontext.Size = new System.Drawing.Size(291, 606);
            this.listBox_txtcontext.TabIndex = 0;
            // 
            // button_nextpage
            // 
            this.button_nextpage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_nextpage.Location = new System.Drawing.Point(1, 275);
            this.button_nextpage.Name = "button_nextpage";
            this.button_nextpage.Size = new System.Drawing.Size(285, 42);
            this.button_nextpage.TabIndex = 8;
            this.button_nextpage.Text = "下一页";
            this.button_nextpage.UseVisualStyleBackColor = true;
            this.button_nextpage.Click += new System.EventHandler(this.button_nextpage_Click);
            // 
            // SeniorSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 638);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "SeniorSetting";
            this.Text = "SeniorSetting";
            this.Load += new System.EventHandler(this.SeniorSetting_Load);
            this.SizeChanged += new System.EventHandler(this.SeniorSetting_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.DateTimePicker dateTimePicker_createTime;
        private System.Windows.Forms.Label label_lastaccess;
        private System.Windows.Forms.DateTimePicker dateTimePicker_lastaccess;
        private System.Windows.Forms.Label label_createTime;
        private System.Windows.Forms.Label label_lastmodify;
        private System.Windows.Forms.DateTimePicker dateTimePicker_lastmodify;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBox_filename;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListBox listBox_hexcontext;
        private System.Windows.Forms.ListBox listBox_txtcontext;
        private System.Windows.Forms.Button button_nextpage;
    }
}