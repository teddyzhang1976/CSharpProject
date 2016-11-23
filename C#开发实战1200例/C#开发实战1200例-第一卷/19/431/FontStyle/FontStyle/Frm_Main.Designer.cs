namespace FontStyle
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
            this.btn_Show = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Text = new System.Windows.Forms.TextBox();
            this.cbox_Select = new System.Windows.Forms.ComboBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.rbtn_Font2 = new System.Windows.Forms.RadioButton();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.rbtn_Font1 = new System.Windows.Forms.RadioButton();
            this.btn_Display = new System.Windows.Forms.Button();
            this.rbtn_Font3 = new System.Windows.Forms.RadioButton();
            this.btn_New = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Show);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_Text);
            this.groupBox1.Controls.Add(this.cbox_Select);
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.rbtn_Font2);
            this.groupBox1.Controls.Add(this.txt_Path);
            this.groupBox1.Controls.Add(this.rbtn_Font1);
            this.groupBox1.Controls.Add(this.btn_Display);
            this.groupBox1.Controls.Add(this.rbtn_Font3);
            this.groupBox1.Controls.Add(this.btn_New);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置字体样式";
            // 
            // btn_Show
            // 
            this.btn_Show.Location = new System.Drawing.Point(20, 237);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(91, 23);
            this.btn_Show.TabIndex = 2;
            this.btn_Show.Text = "预览";
            this.btn_Show.UseVisualStyleBackColor = true;
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "磅";
            // 
            // txt_Text
            // 
            this.txt_Text.Location = new System.Drawing.Point(20, 61);
            this.txt_Text.Multiline = true;
            this.txt_Text.Name = "txt_Text";
            this.txt_Text.Size = new System.Drawing.Size(323, 134);
            this.txt_Text.TabIndex = 1;
            // 
            // cbox_Select
            // 
            this.cbox_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Select.FormattingEnabled = true;
            this.cbox_Select.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "25",
            "30"});
            this.cbox_Select.Location = new System.Drawing.Point(247, 201);
            this.cbox_Select.Name = "cbox_Select";
            this.cbox_Select.Size = new System.Drawing.Size(68, 20);
            this.cbox_Select.TabIndex = 1;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(268, 34);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 9;
            this.btn_Select.Text = "选择";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // rbtn_Font2
            // 
            this.rbtn_Font2.AutoSize = true;
            this.rbtn_Font2.Location = new System.Drawing.Point(99, 201);
            this.rbtn_Font2.Name = "rbtn_Font2";
            this.rbtn_Font2.Size = new System.Drawing.Size(47, 16);
            this.rbtn_Font2.TabIndex = 3;
            this.rbtn_Font2.Text = "楷体";
            this.rbtn_Font2.UseVisualStyleBackColor = true;
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(102, 34);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.ReadOnly = true;
            this.txt_Path.Size = new System.Drawing.Size(160, 21);
            this.txt_Path.TabIndex = 7;
            // 
            // rbtn_Font1
            // 
            this.rbtn_Font1.AutoSize = true;
            this.rbtn_Font1.Checked = true;
            this.rbtn_Font1.Location = new System.Drawing.Point(46, 201);
            this.rbtn_Font1.Name = "rbtn_Font1";
            this.rbtn_Font1.Size = new System.Drawing.Size(47, 16);
            this.rbtn_Font1.TabIndex = 2;
            this.rbtn_Font1.TabStop = true;
            this.rbtn_Font1.Text = "宋体";
            this.rbtn_Font1.UseVisualStyleBackColor = true;
            // 
            // btn_Display
            // 
            this.btn_Display.Enabled = false;
            this.btn_Display.Location = new System.Drawing.Point(252, 237);
            this.btn_Display.Name = "btn_Display";
            this.btn_Display.Size = new System.Drawing.Size(91, 23);
            this.btn_Display.TabIndex = 6;
            this.btn_Display.Text = "显示Word文档";
            this.btn_Display.UseVisualStyleBackColor = true;
            this.btn_Display.Click += new System.EventHandler(this.btn_Display_Click);
            // 
            // rbtn_Font3
            // 
            this.rbtn_Font3.AutoSize = true;
            this.rbtn_Font3.Location = new System.Drawing.Point(152, 201);
            this.rbtn_Font3.Name = "rbtn_Font3";
            this.rbtn_Font3.Size = new System.Drawing.Size(47, 16);
            this.rbtn_Font3.TabIndex = 1;
            this.rbtn_Font3.Text = "隶书";
            this.rbtn_Font3.UseVisualStyleBackColor = true;
            // 
            // btn_New
            // 
            this.btn_New.Enabled = false;
            this.btn_New.Location = new System.Drawing.Point(138, 237);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(91, 23);
            this.btn_New.TabIndex = 5;
            this.btn_New.Text = "创建Word文档";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "文档保存位置：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "字体：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "大小：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(386, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 273);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(346, 247);
            this.textBox1.TabIndex = 3;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 290);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.Text = "设置Word文档中的字体样式";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbox_Select;
        private System.Windows.Forms.RadioButton rbtn_Font2;
        private System.Windows.Forms.RadioButton rbtn_Font1;
        private System.Windows.Forms.RadioButton rbtn_Font3;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Button btn_Display;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Show;
    }
}

