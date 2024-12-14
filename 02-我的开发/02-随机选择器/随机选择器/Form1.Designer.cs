namespace WindowsFormsApplication1
{
    partial class RandomSelector
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
            this.listBox_SumItem = new System.Windows.Forms.ListBox();
            this.textBox_ItemInput = new System.Windows.Forms.TextBox();
            this.button_ADDItem = new System.Windows.Forms.Button();
            this.button_RandomSelect = new System.Windows.Forms.Button();
            this.label_ReTitle = new System.Windows.Forms.Label();
            this.button_Clear = new System.Windows.Forms.Button();
            this.comboBox_Count = new System.Windows.Forms.ComboBox();
            this.listBox_result = new System.Windows.Forms.ListBox();
            this.comboBox_lowline = new System.Windows.Forms.ComboBox();
            this.comboBox_upline = new System.Windows.Forms.ComboBox();
            this.comboBox_step = new System.Windows.Forms.ComboBox();
            this.button_Range = new System.Windows.Forms.Button();
            this.label_from = new System.Windows.Forms.Label();
            this.label_to = new System.Windows.Forms.Label();
            this.label_step = new System.Windows.Forms.Label();
            this.label_count = new System.Windows.Forms.Label();
            this.button_remove = new System.Windows.Forms.Button();
            this.checkBox_single = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox_SumItem
            // 
            this.listBox_SumItem.AllowDrop = true;
            this.listBox_SumItem.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_SumItem.FormattingEnabled = true;
            this.listBox_SumItem.HorizontalScrollbar = true;
            this.listBox_SumItem.ItemHeight = 20;
            this.listBox_SumItem.Location = new System.Drawing.Point(22, 129);
            this.listBox_SumItem.Name = "listBox_SumItem";
            this.listBox_SumItem.Size = new System.Drawing.Size(491, 244);
            this.listBox_SumItem.TabIndex = 0;
            this.listBox_SumItem.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_SumItem_DragDrop);
            this.listBox_SumItem.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_SumItem_DragEnter);
            // 
            // textBox_ItemInput
            // 
            this.textBox_ItemInput.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_ItemInput.Location = new System.Drawing.Point(22, 17);
            this.textBox_ItemInput.Name = "textBox_ItemInput";
            this.textBox_ItemInput.Size = new System.Drawing.Size(377, 30);
            this.textBox_ItemInput.TabIndex = 1;
            this.textBox_ItemInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_ItemInput_KeyDown);
            // 
            // button_ADDItem
            // 
            this.button_ADDItem.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ADDItem.Location = new System.Drawing.Point(405, 17);
            this.button_ADDItem.Name = "button_ADDItem";
            this.button_ADDItem.Size = new System.Drawing.Size(108, 30);
            this.button_ADDItem.TabIndex = 2;
            this.button_ADDItem.Text = "添加选项";
            this.button_ADDItem.UseVisualStyleBackColor = true;
            this.button_ADDItem.Click += new System.EventHandler(this.button_ADDItem_Click);
            // 
            // button_RandomSelect
            // 
            this.button_RandomSelect.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_RandomSelect.Location = new System.Drawing.Point(405, 88);
            this.button_RandomSelect.Name = "button_RandomSelect";
            this.button_RandomSelect.Size = new System.Drawing.Size(108, 30);
            this.button_RandomSelect.TabIndex = 4;
            this.button_RandomSelect.Text = "随机选择";
            this.button_RandomSelect.UseVisualStyleBackColor = true;
            this.button_RandomSelect.Click += new System.EventHandler(this.button_RandomSelect_Click);
            // 
            // label_ReTitle
            // 
            this.label_ReTitle.AutoSize = true;
            this.label_ReTitle.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ReTitle.Location = new System.Drawing.Point(18, 381);
            this.label_ReTitle.Name = "label_ReTitle";
            this.label_ReTitle.Size = new System.Drawing.Size(69, 20);
            this.label_ReTitle.TabIndex = 5;
            this.label_ReTitle.Text = "结果：";
            // 
            // button_Clear
            // 
            this.button_Clear.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Clear.Location = new System.Drawing.Point(111, 90);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(72, 30);
            this.button_Clear.TabIndex = 6;
            this.button_Clear.Text = "清空";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // comboBox_Count
            // 
            this.comboBox_Count.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_Count.FormattingEnabled = true;
            this.comboBox_Count.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "5",
            "7",
            "10",
            "20",
            "30"});
            this.comboBox_Count.Location = new System.Drawing.Point(278, 90);
            this.comboBox_Count.Name = "comboBox_Count";
            this.comboBox_Count.Size = new System.Drawing.Size(121, 28);
            this.comboBox_Count.TabIndex = 7;
            this.comboBox_Count.Text = "1";
            // 
            // listBox_result
            // 
            this.listBox_result.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_result.FormattingEnabled = true;
            this.listBox_result.HorizontalScrollbar = true;
            this.listBox_result.ItemHeight = 20;
            this.listBox_result.Location = new System.Drawing.Point(22, 412);
            this.listBox_result.Name = "listBox_result";
            this.listBox_result.Size = new System.Drawing.Size(491, 144);
            this.listBox_result.TabIndex = 8;
            // 
            // comboBox_lowline
            // 
            this.comboBox_lowline.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_lowline.FormattingEnabled = true;
            this.comboBox_lowline.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "5",
            "10",
            "50",
            "100"});
            this.comboBox_lowline.Location = new System.Drawing.Point(72, 55);
            this.comboBox_lowline.Name = "comboBox_lowline";
            this.comboBox_lowline.Size = new System.Drawing.Size(74, 28);
            this.comboBox_lowline.TabIndex = 9;
            this.comboBox_lowline.Text = "1";
            // 
            // comboBox_upline
            // 
            this.comboBox_upline.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_upline.FormattingEnabled = true;
            this.comboBox_upline.Items.AddRange(new object[] {
            "100",
            "50",
            "20",
            "10",
            "5",
            "2",
            "1"});
            this.comboBox_upline.Location = new System.Drawing.Point(191, 55);
            this.comboBox_upline.Name = "comboBox_upline";
            this.comboBox_upline.Size = new System.Drawing.Size(74, 28);
            this.comboBox_upline.TabIndex = 10;
            this.comboBox_upline.Text = "100";
            // 
            // comboBox_step
            // 
            this.comboBox_step.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_step.FormattingEnabled = true;
            this.comboBox_step.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "5",
            "7",
            "10"});
            this.comboBox_step.Location = new System.Drawing.Point(325, 55);
            this.comboBox_step.Name = "comboBox_step";
            this.comboBox_step.Size = new System.Drawing.Size(74, 28);
            this.comboBox_step.TabIndex = 11;
            this.comboBox_step.Text = "1";
            // 
            // button_Range
            // 
            this.button_Range.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Range.Location = new System.Drawing.Point(405, 53);
            this.button_Range.Name = "button_Range";
            this.button_Range.Size = new System.Drawing.Size(108, 30);
            this.button_Range.TabIndex = 12;
            this.button_Range.Text = "生成";
            this.button_Range.UseVisualStyleBackColor = true;
            this.button_Range.Click += new System.EventHandler(this.button_Range_Click);
            // 
            // label_from
            // 
            this.label_from.AutoSize = true;
            this.label_from.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_from.Location = new System.Drawing.Point(18, 58);
            this.label_from.Name = "label_from";
            this.label_from.Size = new System.Drawing.Size(49, 20);
            this.label_from.TabIndex = 13;
            this.label_from.Text = "From";
            // 
            // label_to
            // 
            this.label_to.AutoSize = true;
            this.label_to.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_to.Location = new System.Drawing.Point(154, 58);
            this.label_to.Name = "label_to";
            this.label_to.Size = new System.Drawing.Size(29, 20);
            this.label_to.TabIndex = 14;
            this.label_to.Text = "To";
            // 
            // label_step
            // 
            this.label_step.AutoSize = true;
            this.label_step.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_step.Location = new System.Drawing.Point(271, 58);
            this.label_step.Name = "label_step";
            this.label_step.Size = new System.Drawing.Size(49, 20);
            this.label_step.TabIndex = 15;
            this.label_step.Text = "Step";
            // 
            // label_count
            // 
            this.label_count.AutoSize = true;
            this.label_count.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_count.Location = new System.Drawing.Point(207, 98);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(59, 20);
            this.label_count.TabIndex = 16;
            this.label_count.Text = "Count";
            // 
            // button_remove
            // 
            this.button_remove.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_remove.Location = new System.Drawing.Point(405, 379);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(108, 30);
            this.button_remove.TabIndex = 17;
            this.button_remove.Text = "移除";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // checkBox_single
            // 
            this.checkBox_single.AutoSize = true;
            this.checkBox_single.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_single.Location = new System.Drawing.Point(22, 95);
            this.checkBox_single.Name = "checkBox_single";
            this.checkBox_single.Size = new System.Drawing.Size(71, 24);
            this.checkBox_single.TabIndex = 18;
            this.checkBox_single.Text = "唯一";
            this.checkBox_single.UseVisualStyleBackColor = true;
            this.checkBox_single.CheckedChanged += new System.EventHandler(this.checkBox_single_CheckedChanged);
            // 
            // RandomSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 570);
            this.Controls.Add(this.checkBox_single);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.label_step);
            this.Controls.Add(this.label_to);
            this.Controls.Add(this.label_from);
            this.Controls.Add(this.button_Range);
            this.Controls.Add(this.comboBox_step);
            this.Controls.Add(this.comboBox_upline);
            this.Controls.Add(this.comboBox_lowline);
            this.Controls.Add(this.listBox_result);
            this.Controls.Add(this.comboBox_Count);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.label_ReTitle);
            this.Controls.Add(this.button_RandomSelect);
            this.Controls.Add(this.button_ADDItem);
            this.Controls.Add(this.textBox_ItemInput);
            this.Controls.Add(this.listBox_SumItem);
            this.Name = "RandomSelector";
            this.Text = "随机选择器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_SumItem;
        private System.Windows.Forms.TextBox textBox_ItemInput;
        private System.Windows.Forms.Button button_ADDItem;
        private System.Windows.Forms.Button button_RandomSelect;
        private System.Windows.Forms.Label label_ReTitle;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.ComboBox comboBox_Count;
        private System.Windows.Forms.ListBox listBox_result;
        private System.Windows.Forms.ComboBox comboBox_lowline;
        private System.Windows.Forms.ComboBox comboBox_upline;
        private System.Windows.Forms.ComboBox comboBox_step;
        private System.Windows.Forms.Button button_Range;
        private System.Windows.Forms.Label label_from;
        private System.Windows.Forms.Label label_to;
        private System.Windows.Forms.Label label_step;
        private System.Windows.Forms.Label label_count;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.CheckBox checkBox_single;
    }
}

