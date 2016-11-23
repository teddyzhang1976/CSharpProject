namespace GetCount
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_NoBlank = new System.Windows.Forms.RadioButton();
            this.rbtn_Blank = new System.Windows.Forms.RadioButton();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.txt_select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Get = new System.Windows.Forms.Button();
            this.btn_display = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn_NoBlank);
            this.groupBox1.Controls.Add(this.rbtn_Blank);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.txt_select);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_Get);
            this.groupBox1.Controls.Add(this.btn_display);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 146);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计字符数量";
            // 
            // rbtn_NoBlank
            // 
            this.rbtn_NoBlank.AutoSize = true;
            this.rbtn_NoBlank.Location = new System.Drawing.Point(208, 73);
            this.rbtn_NoBlank.Name = "rbtn_NoBlank";
            this.rbtn_NoBlank.Size = new System.Drawing.Size(71, 16);
            this.rbtn_NoBlank.TabIndex = 7;
            this.rbtn_NoBlank.Text = "不记空格";
            this.rbtn_NoBlank.UseVisualStyleBackColor = true;
            // 
            // rbtn_Blank
            // 
            this.rbtn_Blank.AutoSize = true;
            this.rbtn_Blank.Checked = true;
            this.rbtn_Blank.Location = new System.Drawing.Point(81, 73);
            this.rbtn_Blank.Name = "rbtn_Blank";
            this.rbtn_Blank.Size = new System.Drawing.Size(59, 16);
            this.rbtn_Blank.TabIndex = 6;
            this.rbtn_Blank.TabStop = true;
            this.rbtn_Blank.Text = "记空格";
            this.rbtn_Blank.UseVisualStyleBackColor = true;
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(107, 31);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(160, 21);
            this.txt_path.TabIndex = 2;
            // 
            // txt_select
            // 
            this.txt_select.Location = new System.Drawing.Point(273, 31);
            this.txt_select.Name = "txt_select";
            this.txt_select.Size = new System.Drawing.Size(75, 23);
            this.txt_select.TabIndex = 4;
            this.txt_select.Text = "选择";
            this.txt_select.UseVisualStyleBackColor = true;
            this.txt_select.Click += new System.EventHandler(this.txt_select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "打开文档位置：";
            // 
            // btn_Get
            // 
            this.btn_Get.Enabled = false;
            this.btn_Get.Location = new System.Drawing.Point(49, 105);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(91, 23);
            this.btn_Get.TabIndex = 0;
            this.btn_Get.Text = "统计字符数量";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_display
            // 
            this.btn_display.Enabled = false;
            this.btn_display.Location = new System.Drawing.Point(215, 105);
            this.btn_display.Name = "btn_display";
            this.btn_display.Size = new System.Drawing.Size(91, 23);
            this.btn_display.TabIndex = 1;
            this.btn_display.Text = "显示Word文档";
            this.btn_display.UseVisualStyleBackColor = true;
            this.btn_display.Click += new System.EventHandler(this.btn_display_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 163);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "统计Word文档中的字符数";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button txt_select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Get;
        private System.Windows.Forms.Button btn_display;
        private System.Windows.Forms.RadioButton rbtn_NoBlank;
        private System.Windows.Forms.RadioButton rbtn_Blank;

    }
}

