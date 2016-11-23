namespace Lines
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
            this.txt_string = new System.Windows.Forms.TextBox();
            this.btn_true = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Lines = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_string
            // 
            this.txt_string.Location = new System.Drawing.Point(14, 80);
            this.txt_string.Multiline = true;
            this.txt_string.Name = "txt_string";
            this.txt_string.Size = new System.Drawing.Size(309, 60);
            this.txt_string.TabIndex = 0;
            // 
            // btn_true
            // 
            this.btn_true.Location = new System.Drawing.Point(132, 146);
            this.btn_true.Name = "btn_true";
            this.btn_true.Size = new System.Drawing.Size(75, 23);
            this.btn_true.TabIndex = 2;
            this.btn_true.Text = "分行显示";
            this.btn_true.UseVisualStyleBackColor = true;
            this.btn_true.Click += new System.EventHandler(this.btn_true_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "点击分行显示按钮，根据（,）号对字符串进行分行。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "在下面文本框中输入字符串，并使用（,）号分隔，";
            // 
            // txt_Lines
            // 
            this.txt_Lines.Location = new System.Drawing.Point(14, 175);
            this.txt_Lines.Multiline = true;
            this.txt_Lines.Name = "txt_Lines";
            this.txt_Lines.Size = new System.Drawing.Size(309, 120);
            this.txt_Lines.TabIndex = 4;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 298);
            this.Controls.Add(this.txt_Lines);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_true);
            this.Controls.Add(this.txt_string);
            this.Name = "Frm_Main";
            this.Text = "根据标点符号对字符串进行分行";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_string;
        private System.Windows.Forms.Button btn_true;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Lines;
    }
}

