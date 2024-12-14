namespace FileExplorer
{
    partial class InputBox
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
            this.lable_tips = new System.Windows.Forms.Label();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.button_enter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lable_tips
            // 
            this.lable_tips.AutoSize = true;
            this.lable_tips.Location = new System.Drawing.Point(13, 13);
            this.lable_tips.Name = "lable_tips";
            this.lable_tips.Size = new System.Drawing.Size(39, 15);
            this.lable_tips.TabIndex = 0;
            this.lable_tips.Text = "tips";
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(13, 65);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(344, 25);
            this.textBox_input.TabIndex = 1;
            this.textBox_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_input_KeyPress);
            // 
            // button_enter
            // 
            this.button_enter.Location = new System.Drawing.Point(363, 66);
            this.button_enter.Name = "button_enter";
            this.button_enter.Size = new System.Drawing.Size(62, 23);
            this.button_enter.TabIndex = 2;
            this.button_enter.Text = "确认";
            this.button_enter.UseVisualStyleBackColor = true;
            this.button_enter.Click += new System.EventHandler(this.button_enter_Click);
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 98);
            this.Controls.Add(this.button_enter);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.lable_tips);
            this.Name = "InputBox";
            this.Text = "InputBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable_tips;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.Button button_enter;
    }
}