namespace ASCII
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
            this.txt_Char2 = new System.Windows.Forms.TextBox();
            this.txt_ASCII2 = new System.Windows.Forms.TextBox();
            this.txt_ASCII = new System.Windows.Forms.TextBox();
            this.btn_ToChar = new System.Windows.Forms.Button();
            this.txt_char = new System.Windows.Forms.TextBox();
            this.btn_ToASCII = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Char2);
            this.groupBox1.Controls.Add(this.txt_ASCII2);
            this.groupBox1.Controls.Add(this.txt_ASCII);
            this.groupBox1.Controls.Add(this.btn_ToChar);
            this.groupBox1.Controls.Add(this.txt_char);
            this.groupBox1.Controls.Add(this.btn_ToASCII);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 107);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字母与ASCII相互转换";
            // 
            // txt_Char2
            // 
            this.txt_Char2.Location = new System.Drawing.Point(220, 66);
            this.txt_Char2.Name = "txt_Char2";
            this.txt_Char2.Size = new System.Drawing.Size(100, 21);
            this.txt_Char2.TabIndex = 11;
            // 
            // txt_ASCII2
            // 
            this.txt_ASCII2.Location = new System.Drawing.Point(7, 66);
            this.txt_ASCII2.Name = "txt_ASCII2";
            this.txt_ASCII2.Size = new System.Drawing.Size(100, 21);
            this.txt_ASCII2.TabIndex = 10;
            // 
            // txt_ASCII
            // 
            this.txt_ASCII.Location = new System.Drawing.Point(220, 27);
            this.txt_ASCII.Name = "txt_ASCII";
            this.txt_ASCII.Size = new System.Drawing.Size(100, 21);
            this.txt_ASCII.TabIndex = 9;
            // 
            // btn_ToChar
            // 
            this.btn_ToChar.Location = new System.Drawing.Point(113, 64);
            this.btn_ToChar.Name = "btn_ToChar";
            this.btn_ToChar.Size = new System.Drawing.Size(99, 23);
            this.btn_ToChar.TabIndex = 8;
            this.btn_ToChar.Text = "转换为字母";
            this.btn_ToChar.UseVisualStyleBackColor = true;
            this.btn_ToChar.Click += new System.EventHandler(this.btn_ToChar_Click);
            // 
            // txt_char
            // 
            this.txt_char.Location = new System.Drawing.Point(6, 27);
            this.txt_char.Name = "txt_char";
            this.txt_char.Size = new System.Drawing.Size(100, 21);
            this.txt_char.TabIndex = 7;
            // 
            // btn_ToASCII
            // 
            this.btn_ToASCII.Location = new System.Drawing.Point(113, 25);
            this.btn_ToASCII.Name = "btn_ToASCII";
            this.btn_ToASCII.Size = new System.Drawing.Size(99, 23);
            this.btn_ToASCII.TabIndex = 6;
            this.btn_ToASCII.Text = "转换为ASCII码";
            this.btn_ToASCII.UseVisualStyleBackColor = true;
            this.btn_ToASCII.Click += new System.EventHandler(this.btn_ToASCII_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 128);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "字母与ASCII码的转换";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Char2;
        private System.Windows.Forms.TextBox txt_ASCII2;
        private System.Windows.Forms.TextBox txt_ASCII;
        private System.Windows.Forms.Button btn_ToChar;
        private System.Windows.Forms.TextBox txt_char;
        private System.Windows.Forms.Button btn_ToASCII;
    }
}

