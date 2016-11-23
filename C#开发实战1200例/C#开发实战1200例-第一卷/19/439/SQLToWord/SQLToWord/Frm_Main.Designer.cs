namespace SQLToWord
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
            this.txt_Server = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_PassWord = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_DataBase = new System.Windows.Forms.TextBox();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.txt_select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_display = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Server);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_PassWord);
            this.groupBox1.Controls.Add(this.txt_UserName);
            this.groupBox1.Controls.Add(this.txt_DataBase);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.txt_select);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_New);
            this.groupBox1.Controls.Add(this.btn_display);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 172);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作Word文档";
            // 
            // txt_Server
            // 
            this.txt_Server.Location = new System.Drawing.Point(106, 23);
            this.txt_Server.Name = "txt_Server";
            this.txt_Server.Size = new System.Drawing.Size(95, 21);
            this.txt_Server.TabIndex = 11;
            this.txt_Server.Text = "MRWXK\\WANGXIAOKE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "数据库服务器：";
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Location = new System.Drawing.Point(299, 60);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.Size = new System.Drawing.Size(95, 21);
            this.txt_PassWord.TabIndex = 7;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(299, 22);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(95, 21);
            this.txt_UserName.TabIndex = 6;
            this.txt_UserName.Text = "sa";
            // 
            // txt_DataBase
            // 
            this.txt_DataBase.Location = new System.Drawing.Point(106, 60);
            this.txt_DataBase.Name = "txt_DataBase";
            this.txt_DataBase.Size = new System.Drawing.Size(95, 21);
            this.txt_DataBase.TabIndex = 5;
            this.txt_DataBase.Text = "db_TomeOne";
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(106, 98);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(207, 21);
            this.txt_path.TabIndex = 2;
            // 
            // txt_select
            // 
            this.txt_select.Location = new System.Drawing.Point(319, 96);
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
            this.label1.Location = new System.Drawing.Point(21, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "文档保存位置：";
            // 
            // btn_New
            // 
            this.btn_New.Enabled = false;
            this.btn_New.Location = new System.Drawing.Point(23, 133);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(168, 23);
            this.btn_New.TabIndex = 0;
            this.btn_New.Text = "读取SQL数据并写入Word文档";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_display
            // 
            this.btn_display.Enabled = false;
            this.btn_display.Location = new System.Drawing.Point(216, 133);
            this.btn_display.Name = "btn_display";
            this.btn_display.Size = new System.Drawing.Size(168, 23);
            this.btn_display.TabIndex = 1;
            this.btn_display.Text = "显示Word文档";
            this.btn_display.UseVisualStyleBackColor = true;
            this.btn_display.Click += new System.EventHandler(this.btn_display_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "数据库密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "数据库用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "数据库名称：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 190);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.Text = "将SQL Server数据查询结果输出到Word";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button txt_select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btn_display;
        private System.Windows.Forms.TextBox txt_PassWord;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_DataBase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Server;
        private System.Windows.Forms.Label label5;
    }
}

