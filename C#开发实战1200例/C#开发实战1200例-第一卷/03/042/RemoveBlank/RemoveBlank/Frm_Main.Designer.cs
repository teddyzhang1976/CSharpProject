namespace RemoveBlank
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
            this.btn_RemoveBlank = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_str = new System.Windows.Forms.TextBox();
            this.txt_removeblank = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_RemoveBlank
            // 
            this.btn_RemoveBlank.Location = new System.Drawing.Point(17, 64);
            this.btn_RemoveBlank.Name = "btn_RemoveBlank";
            this.btn_RemoveBlank.Size = new System.Drawing.Size(87, 23);
            this.btn_RemoveBlank.TabIndex = 0;
            this.btn_RemoveBlank.Text = "去除空格";
            this.btn_RemoveBlank.UseVisualStyleBackColor = true;
            this.btn_RemoveBlank.Click += new System.EventHandler(this.btn_RemoveBlank_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入字符串：";
            // 
            // txt_str
            // 
            this.txt_str.Location = new System.Drawing.Point(110, 26);
            this.txt_str.Name = "txt_str";
            this.txt_str.Size = new System.Drawing.Size(172, 21);
            this.txt_str.TabIndex = 2;
            // 
            // txt_removeblank
            // 
            this.txt_removeblank.Location = new System.Drawing.Point(110, 66);
            this.txt_removeblank.Name = "txt_removeblank";
            this.txt_removeblank.Size = new System.Drawing.Size(172, 21);
            this.txt_removeblank.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_removeblank);
            this.groupBox1.Controls.Add(this.btn_RemoveBlank);
            this.groupBox1.Controls.Add(this.txt_str);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 110);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "去除空格";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 119);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "去掉字符串中的所有空格";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_RemoveBlank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_str;
        private System.Windows.Forms.TextBox txt_removeblank;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

