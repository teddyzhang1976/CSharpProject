namespace UserName
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
            this.btn_true = new System.Windows.Forms.GroupBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_true.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_true
            // 
            this.btn_true.Controls.Add(this.label1);
            this.btn_true.Controls.Add(this.button1);
            this.btn_true.Controls.Add(this.txt_username);
            this.btn_true.Location = new System.Drawing.Point(12, 9);
            this.btn_true.Name = "btn_true";
            this.btn_true.Size = new System.Drawing.Size(280, 103);
            this.btn_true.TabIndex = 0;
            this.btn_true.TabStop = false;
            this.btn_true.Text = "登陆";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(144, 30);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(100, 21);
            this.txt_username.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "登陆";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请输入用户名：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 120);
            this.Controls.Add(this.btn_true);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "判断用户输入的用户名是否正确";
            this.btn_true.ResumeLayout(false);
            this.btn_true.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox btn_true;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_username;
    }
}

