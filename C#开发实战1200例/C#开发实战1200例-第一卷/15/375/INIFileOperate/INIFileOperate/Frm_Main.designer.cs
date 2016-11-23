namespace INIFileOperate
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pwd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.server = new System.Windows.Forms.TextBox();
            this.database = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pwd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.uid);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.server);
            this.groupBox1.Controls.Add(this.database);
            this.groupBox1.Location = new System.Drawing.Point(4, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 126);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INI文件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "服务器：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "数据库：";
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(70, 94);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(100, 21);
            this.pwd.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "登录身份：";
            // 
            // uid
            // 
            this.uid.Location = new System.Drawing.Point(70, 66);
            this.uid.Name = "uid";
            this.uid.Size = new System.Drawing.Size(100, 21);
            this.uid.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "登录密码：";
            // 
            // server
            // 
            this.server.Location = new System.Drawing.Point(70, 11);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(100, 21);
            this.server.TabIndex = 13;
            // 
            // database
            // 
            this.database.Location = new System.Drawing.Point(70, 38);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(100, 21);
            this.database.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 144);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用C#操作INI文件";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox uid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox server;
        private System.Windows.Forms.TextBox database;
        private System.Windows.Forms.Button button1;
    }
}

