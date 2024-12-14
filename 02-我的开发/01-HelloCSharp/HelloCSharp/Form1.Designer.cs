namespace HelloCSharp
{
    partial class Login
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
            this.button_LOGIN = new System.Windows.Forms.Button();
            this.checkBox_MAN = new System.Windows.Forms.CheckBox();
            this.label_TIPS = new System.Windows.Forms.Label();
            this.textBox_NAME = new System.Windows.Forms.TextBox();
            this.textBox_PWD = new System.Windows.Forms.TextBox();
            this.checkBox_WOMAN = new System.Windows.Forms.CheckBox();
            this.label_NAME = new System.Windows.Forms.Label();
            this.label_PWD = new System.Windows.Forms.Label();
            this.label_SEX = new System.Windows.Forms.Label();
            this.label_TEL = new System.Windows.Forms.Label();
            this.textBox_TEL = new System.Windows.Forms.TextBox();
            this.monthCalendar_DATE = new System.Windows.Forms.MonthCalendar();
            this.label_DATE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_LOGIN
            // 
            this.button_LOGIN.Location = new System.Drawing.Point(113, 454);
            this.button_LOGIN.Name = "button_LOGIN";
            this.button_LOGIN.Size = new System.Drawing.Size(325, 25);
            this.button_LOGIN.TabIndex = 0;
            this.button_LOGIN.Text = "Login";
            this.button_LOGIN.UseVisualStyleBackColor = true;
            this.button_LOGIN.Click += new System.EventHandler(this.button_LOGIN_Click);
            // 
            // checkBox_MAN
            // 
            this.checkBox_MAN.AutoSize = true;
            this.checkBox_MAN.Location = new System.Drawing.Point(176, 184);
            this.checkBox_MAN.Name = "checkBox_MAN";
            this.checkBox_MAN.Size = new System.Drawing.Size(44, 19);
            this.checkBox_MAN.TabIndex = 1;
            this.checkBox_MAN.Text = "男";
            this.checkBox_MAN.UseVisualStyleBackColor = true;
            this.checkBox_MAN.CheckedChanged += new System.EventHandler(this.checkBox_MAN_CheckedChanged);
            // 
            // label_TIPS
            // 
            this.label_TIPS.AutoSize = true;
            this.label_TIPS.Location = new System.Drawing.Point(232, 494);
            this.label_TIPS.Name = "label_TIPS";
            this.label_TIPS.Size = new System.Drawing.Size(79, 15);
            this.label_TIPS.TabIndex = 2;
            this.label_TIPS.Text = "LoginDemo";
            this.label_TIPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_NAME
            // 
            this.textBox_NAME.Location = new System.Drawing.Point(178, 46);
            this.textBox_NAME.Name = "textBox_NAME";
            this.textBox_NAME.Size = new System.Drawing.Size(262, 25);
            this.textBox_NAME.TabIndex = 3;
            // 
            // textBox_PWD
            // 
            this.textBox_PWD.Location = new System.Drawing.Point(178, 95);
            this.textBox_PWD.Name = "textBox_PWD";
            this.textBox_PWD.Size = new System.Drawing.Size(262, 25);
            this.textBox_PWD.TabIndex = 4;
            this.textBox_PWD.UseSystemPasswordChar = true;
            // 
            // checkBox_WOMAN
            // 
            this.checkBox_WOMAN.AutoSize = true;
            this.checkBox_WOMAN.Location = new System.Drawing.Point(334, 184);
            this.checkBox_WOMAN.Name = "checkBox_WOMAN";
            this.checkBox_WOMAN.Size = new System.Drawing.Size(44, 19);
            this.checkBox_WOMAN.TabIndex = 5;
            this.checkBox_WOMAN.Text = "女";
            this.checkBox_WOMAN.UseVisualStyleBackColor = true;
            this.checkBox_WOMAN.CheckedChanged += new System.EventHandler(this.checkBox_WOMAN_CheckedChanged);
            // 
            // label_NAME
            // 
            this.label_NAME.AutoSize = true;
            this.label_NAME.Location = new System.Drawing.Point(110, 56);
            this.label_NAME.Name = "label_NAME";
            this.label_NAME.Size = new System.Drawing.Size(37, 15);
            this.label_NAME.TabIndex = 6;
            this.label_NAME.Text = "姓名";
            // 
            // label_PWD
            // 
            this.label_PWD.AutoSize = true;
            this.label_PWD.Location = new System.Drawing.Point(110, 105);
            this.label_PWD.Name = "label_PWD";
            this.label_PWD.Size = new System.Drawing.Size(37, 15);
            this.label_PWD.TabIndex = 7;
            this.label_PWD.Text = "密码";
            // 
            // label_SEX
            // 
            this.label_SEX.AutoSize = true;
            this.label_SEX.Location = new System.Drawing.Point(110, 188);
            this.label_SEX.Name = "label_SEX";
            this.label_SEX.Size = new System.Drawing.Size(37, 15);
            this.label_SEX.TabIndex = 8;
            this.label_SEX.Text = "性别";
            // 
            // label_TEL
            // 
            this.label_TEL.AutoSize = true;
            this.label_TEL.Location = new System.Drawing.Point(110, 147);
            this.label_TEL.Name = "label_TEL";
            this.label_TEL.Size = new System.Drawing.Size(37, 15);
            this.label_TEL.TabIndex = 10;
            this.label_TEL.Text = "电话";
            // 
            // textBox_TEL
            // 
            this.textBox_TEL.Location = new System.Drawing.Point(178, 137);
            this.textBox_TEL.Name = "textBox_TEL";
            this.textBox_TEL.Size = new System.Drawing.Size(262, 25);
            this.textBox_TEL.TabIndex = 9;
            // 
            // monthCalendar_DATE
            // 
            this.monthCalendar_DATE.Location = new System.Drawing.Point(176, 215);
            this.monthCalendar_DATE.Name = "monthCalendar_DATE";
            this.monthCalendar_DATE.TabIndex = 11;
            // 
            // label_DATE
            // 
            this.label_DATE.AutoSize = true;
            this.label_DATE.Location = new System.Drawing.Point(110, 231);
            this.label_DATE.Name = "label_DATE";
            this.label_DATE.Size = new System.Drawing.Size(37, 15);
            this.label_DATE.TabIndex = 12;
            this.label_DATE.Text = "生日";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 528);
            this.Controls.Add(this.label_DATE);
            this.Controls.Add(this.monthCalendar_DATE);
            this.Controls.Add(this.label_TEL);
            this.Controls.Add(this.textBox_TEL);
            this.Controls.Add(this.label_SEX);
            this.Controls.Add(this.label_PWD);
            this.Controls.Add(this.label_NAME);
            this.Controls.Add(this.checkBox_WOMAN);
            this.Controls.Add(this.textBox_PWD);
            this.Controls.Add(this.textBox_NAME);
            this.Controls.Add(this.label_TIPS);
            this.Controls.Add(this.checkBox_MAN);
            this.Controls.Add(this.button_LOGIN);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LOGIN;
        private System.Windows.Forms.CheckBox checkBox_MAN;
        private System.Windows.Forms.Label label_TIPS;
        private System.Windows.Forms.TextBox textBox_NAME;
        private System.Windows.Forms.TextBox textBox_PWD;
        private System.Windows.Forms.CheckBox checkBox_WOMAN;
        private System.Windows.Forms.Label label_NAME;
        private System.Windows.Forms.Label label_PWD;
        private System.Windows.Forms.Label label_SEX;
        private System.Windows.Forms.Label label_TEL;
        private System.Windows.Forms.TextBox textBox_TEL;
        private System.Windows.Forms.MonthCalendar monthCalendar_DATE;
        private System.Windows.Forms.Label label_DATE;
    }
}

