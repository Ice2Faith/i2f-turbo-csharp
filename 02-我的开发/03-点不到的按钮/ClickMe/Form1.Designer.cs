namespace ClickMe
{
    partial class Form1
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
            this.button_no = new System.Windows.Forms.Button();
            this.button_yes = new System.Windows.Forms.Button();
            this.label_question = new System.Windows.Forms.Label();
            this.label_tips = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_no
            // 
            this.button_no.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_no.Location = new System.Drawing.Point(222, 155);
            this.button_no.Name = "button_no";
            this.button_no.Size = new System.Drawing.Size(99, 64);
            this.button_no.TabIndex = 0;
            this.button_no.Text = "No";
            this.button_no.UseVisualStyleBackColor = true;
            this.button_no.Click += new System.EventHandler(this.button_no_Click);
            this.button_no.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_clickme_MouseMove);
            // 
            // button_yes
            // 
            this.button_yes.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_yes.Location = new System.Drawing.Point(222, 239);
            this.button_yes.Name = "button_yes";
            this.button_yes.Size = new System.Drawing.Size(99, 64);
            this.button_yes.TabIndex = 1;
            this.button_yes.Text = "Yes";
            this.button_yes.UseVisualStyleBackColor = true;
            this.button_yes.Click += new System.EventHandler(this.button_yes_Click);
            // 
            // label_question
            // 
            this.label_question.AutoSize = true;
            this.label_question.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_question.Location = new System.Drawing.Point(152, 91);
            this.label_question.Name = "label_question";
            this.label_question.Size = new System.Drawing.Size(238, 24);
            this.label_question.TabIndex = 2;
            this.label_question.Text = "Your are blockhead?";
            // 
            // label_tips
            // 
            this.label_tips.AutoSize = true;
            this.label_tips.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_tips.Location = new System.Drawing.Point(242, 176);
            this.label_tips.Name = "label_tips";
            this.label_tips.Size = new System.Drawing.Size(0, 24);
            this.label_tips.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 394);
            this.Controls.Add(this.label_tips);
            this.Controls.Add(this.label_question);
            this.Controls.Add(this.button_yes);
            this.Controls.Add(this.button_no);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Haha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_no;
        private System.Windows.Forms.Button button_yes;
        private System.Windows.Forms.Label label_question;
        private System.Windows.Forms.Label label_tips;
    }
}

