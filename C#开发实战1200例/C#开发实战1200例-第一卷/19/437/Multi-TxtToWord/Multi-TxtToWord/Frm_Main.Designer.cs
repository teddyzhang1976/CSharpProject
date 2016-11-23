namespace Multi_TxtToWord
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
            this.lb_FileName = new System.Windows.Forms.ListBox();
            this.txt_TxtPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_txt = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_Display = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_FileName);
            this.groupBox1.Controls.Add(this.txt_TxtPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_txt);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.btn_Display);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_New);
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 264);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作Word文档";
            // 
            // lb_FileName
            // 
            this.lb_FileName.FormattingEnabled = true;
            this.lb_FileName.ItemHeight = 12;
            this.lb_FileName.Location = new System.Drawing.Point(27, 27);
            this.lb_FileName.Name = "lb_FileName";
            this.lb_FileName.Size = new System.Drawing.Size(312, 112);
            this.lb_FileName.TabIndex = 9;
            // 
            // txt_TxtPath
            // 
            this.txt_TxtPath.Location = new System.Drawing.Point(117, 151);
            this.txt_TxtPath.Name = "txt_TxtPath";
            this.txt_TxtPath.ReadOnly = true;
            this.txt_TxtPath.Size = new System.Drawing.Size(156, 21);
            this.txt_TxtPath.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "文本文件位置：";
            // 
            // btn_txt
            // 
            this.btn_txt.Location = new System.Drawing.Point(282, 151);
            this.btn_txt.Name = "btn_txt";
            this.btn_txt.Size = new System.Drawing.Size(57, 23);
            this.btn_txt.TabIndex = 6;
            this.btn_txt.Text = "浏览";
            this.btn_txt.UseVisualStyleBackColor = true;
            this.btn_txt.Click += new System.EventHandler(this.btn_txt_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(117, 189);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(156, 21);
            this.txt_path.TabIndex = 5;
            // 
            // btn_Display
            // 
            this.btn_Display.Enabled = false;
            this.btn_Display.Location = new System.Drawing.Point(209, 227);
            this.btn_Display.Name = "btn_Display";
            this.btn_Display.Size = new System.Drawing.Size(95, 23);
            this.btn_Display.TabIndex = 3;
            this.btn_Display.Text = "显示Word文档";
            this.btn_Display.UseVisualStyleBackColor = true;
            this.btn_Display.Click += new System.EventHandler(this.btn_Display_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "文档保存位置：";
            // 
            // btn_New
            // 
            this.btn_New.Enabled = false;
            this.btn_New.Location = new System.Drawing.Point(62, 227);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(95, 23);
            this.btn_New.TabIndex = 2;
            this.btn_New.Text = "创建Word文档";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Enabled = false;
            this.btn_Select.Location = new System.Drawing.Point(282, 189);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(57, 23);
            this.btn_Select.TabIndex = 0;
            this.btn_Select.Text = "浏览";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 281);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.Text = "读取多个文本文件到同一Word文档中";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lb_FileName;
        private System.Windows.Forms.TextBox txt_TxtPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_txt;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_Display;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btn_Select;
    }
}

