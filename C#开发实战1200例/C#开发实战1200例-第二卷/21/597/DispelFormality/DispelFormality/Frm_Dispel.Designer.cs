namespace DispelFormality
{
    partial class Frm_Dispel
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.checkBox_Show = new System.Windows.Forms.CheckBox();
            this.textBox_Dispel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "解码：";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(55, 78);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "确定";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(173, 78);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // checkBox_Show
            // 
            this.checkBox_Show.AutoSize = true;
            this.checkBox_Show.Location = new System.Drawing.Point(34, 53);
            this.checkBox_Show.Name = "checkBox_Show";
            this.checkBox_Show.Size = new System.Drawing.Size(120, 16);
            this.checkBox_Show.TabIndex = 4;
            this.checkBox_Show.Text = "下次登录是否显示";
            this.checkBox_Show.UseVisualStyleBackColor = true;
            // 
            // textBox_Dispel
            // 
            this.textBox_Dispel.Location = new System.Drawing.Point(78, 22);
            this.textBox_Dispel.Name = "textBox_Dispel";
            this.textBox_Dispel.Size = new System.Drawing.Size(170, 21);
            this.textBox_Dispel.TabIndex = 5;
            // 
            // Frm_Dispel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 119);
            this.Controls.Add(this.textBox_Dispel);
            this.Controls.Add(this.checkBox_Show);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Dispel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "对EXE文件进行解密";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.CheckBox checkBox_Show;
        private System.Windows.Forms.TextBox textBox_Dispel;
    }
}