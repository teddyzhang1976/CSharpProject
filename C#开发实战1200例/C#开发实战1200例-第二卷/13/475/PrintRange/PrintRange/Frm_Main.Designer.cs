namespace PrintRange
{
    partial class Frm_Main
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_PageSize = new System.Windows.Forms.ComboBox();
            this.button_Preview = new System.Windows.Forms.Button();
            this.checkBox_Aspect = new System.Windows.Forms.CheckBox();
            this.panel_Line = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(323, 287);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBox_PageSize);
            this.groupBox1.Controls.Add(this.button_Preview);
            this.groupBox1.Controls.Add(this.checkBox_Aspect);
            this.groupBox1.Controls.Add(this.panel_Line);
            this.groupBox1.Location = new System.Drawing.Point(332, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 287);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印设置";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "纸张大小：";
            // 
            // comboBox_PageSize
            // 
            this.comboBox_PageSize.FormattingEnabled = true;
            this.comboBox_PageSize.Items.AddRange(new object[] {
            "A4",
            "A5",
            "A6",
            "B5(ISO)",
            "B5(JIS)",
            "Double Post Card",
            "Envelope #10",
            "Envelope B5",
            "Envelope C5",
            "Envelope DL",
            "Envelope Monarch",
            "ExeCutive",
            "Legal",
            "Letter",
            "Post Card",
            "16K",
            "8.5x13"});
            this.comboBox_PageSize.Location = new System.Drawing.Point(67, 229);
            this.comboBox_PageSize.Name = "comboBox_PageSize";
            this.comboBox_PageSize.Size = new System.Drawing.Size(71, 20);
            this.comboBox_PageSize.TabIndex = 18;
            // 
            // button_Preview
            // 
            this.button_Preview.Location = new System.Drawing.Point(34, 254);
            this.button_Preview.Name = "button_Preview";
            this.button_Preview.Size = new System.Drawing.Size(70, 23);
            this.button_Preview.TabIndex = 17;
            this.button_Preview.Text = "打印预览";
            this.button_Preview.UseVisualStyleBackColor = true;
            this.button_Preview.Click += new System.EventHandler(this.button_Preview_Click);
            // 
            // checkBox_Aspect
            // 
            this.checkBox_Aspect.AutoSize = true;
            this.checkBox_Aspect.Location = new System.Drawing.Point(34, 211);
            this.checkBox_Aspect.Name = "checkBox_Aspect";
            this.checkBox_Aspect.Size = new System.Drawing.Size(72, 16);
            this.checkBox_Aspect.TabIndex = 15;
            this.checkBox_Aspect.Text = "横向打印";
            this.checkBox_Aspect.UseVisualStyleBackColor = true;
            this.checkBox_Aspect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkBox_Aspect_MouseDown);
            // 
            // panel_Line
            // 
            this.panel_Line.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_Line.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Line.Location = new System.Drawing.Point(23, 74);
            this.panel_Line.Name = "panel_Line";
            this.panel_Line.Size = new System.Drawing.Size(100, 116);
            this.panel_Line.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 296);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义横向或纵向打印";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Activated += new System.EventHandler(this.Form1_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_PageSize;
        private System.Windows.Forms.Button button_Preview;
        private System.Windows.Forms.CheckBox checkBox_Aspect;
        private System.Windows.Forms.Panel panel_Line;

    }
}

