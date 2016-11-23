namespace StringEncrypt
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
            this.btn_Encrypt = new System.Windows.Forms.Button();
            this.txt_str = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_EncryptStr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_str2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_password2 = new System.Windows.Forms.TextBox();
            this.txt_EncryptStr2 = new System.Windows.Forms.TextBox();
            this.btn_UnEncrypt = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Encrypt
            // 
            this.btn_Encrypt.Location = new System.Drawing.Point(354, 92);
            this.btn_Encrypt.Name = "btn_Encrypt";
            this.btn_Encrypt.Size = new System.Drawing.Size(75, 23);
            this.btn_Encrypt.TabIndex = 0;
            this.btn_Encrypt.Text = "加密";
            this.btn_Encrypt.UseVisualStyleBackColor = true;
            this.btn_Encrypt.Click += new System.EventHandler(this.btn_Encrypt_Click);
            // 
            // txt_str
            // 
            this.txt_str.Location = new System.Drawing.Point(6, 45);
            this.txt_str.Multiline = true;
            this.txt_str.Name = "txt_str";
            this.txt_str.Size = new System.Drawing.Size(436, 41);
            this.txt_str.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_EncryptStr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_password);
            this.groupBox1.Controls.Add(this.txt_str);
            this.groupBox1.Controls.Add(this.btn_Encrypt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 192);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字符串加密";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "加密后字符串：";
            // 
            // txt_EncryptStr
            // 
            this.txt_EncryptStr.Location = new System.Drawing.Point(10, 139);
            this.txt_EncryptStr.Multiline = true;
            this.txt_EncryptStr.Name = "txt_EncryptStr";
            this.txt_EncryptStr.Size = new System.Drawing.Size(436, 41);
            this.txt_EncryptStr.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "加密前字符串：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "输入加密密钥（4位）：";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(150, 92);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(184, 21);
            this.txt_password.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_str2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_password2);
            this.groupBox2.Controls.Add(this.txt_EncryptStr2);
            this.groupBox2.Controls.Add(this.btn_UnEncrypt);
            this.groupBox2.Location = new System.Drawing.Point(12, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 192);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "字符串解密";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "解密后字符串：";
            // 
            // txt_str2
            // 
            this.txt_str2.Location = new System.Drawing.Point(10, 139);
            this.txt_str2.Multiline = true;
            this.txt_str2.Name = "txt_str2";
            this.txt_str2.Size = new System.Drawing.Size(436, 41);
            this.txt_str2.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "解密前字符串：";
            // 
            // txt_password2
            // 
            this.txt_password2.Location = new System.Drawing.Point(150, 92);
            this.txt_password2.Name = "txt_password2";
            this.txt_password2.Size = new System.Drawing.Size(184, 21);
            this.txt_password2.TabIndex = 3;
            // 
            // txt_EncryptStr2
            // 
            this.txt_EncryptStr2.Location = new System.Drawing.Point(6, 45);
            this.txt_EncryptStr2.Multiline = true;
            this.txt_EncryptStr2.Name = "txt_EncryptStr2";
            this.txt_EncryptStr2.Size = new System.Drawing.Size(436, 41);
            this.txt_EncryptStr2.TabIndex = 1;
            // 
            // btn_UnEncrypt
            // 
            this.btn_UnEncrypt.Location = new System.Drawing.Point(354, 92);
            this.btn_UnEncrypt.Name = "btn_UnEncrypt";
            this.btn_UnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btn_UnEncrypt.TabIndex = 0;
            this.btn_UnEncrypt.Text = "解密";
            this.btn_UnEncrypt.UseVisualStyleBackColor = true;
            this.btn_UnEncrypt.Click += new System.EventHandler(this.btn_UnEncrypt_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "输入加密密钥（4位）：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 406);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.Text = "对字符串进行加密与解密";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Encrypt;
        private System.Windows.Forms.TextBox txt_str;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_EncryptStr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_str2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_password2;
        private System.Windows.Forms.TextBox txt_EncryptStr2;
        private System.Windows.Forms.Button btn_UnEncrypt;
        private System.Windows.Forms.Label label7;
    }
}

