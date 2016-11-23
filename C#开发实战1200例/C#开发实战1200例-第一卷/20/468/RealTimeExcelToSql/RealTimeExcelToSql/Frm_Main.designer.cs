namespace RealTimeExcelToSql
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbox_Server = new System.Windows.Forms.ComboBox();
            this.ckbox_SQL = new System.Windows.Forms.CheckBox();
            this.ckbox_Windows = new System.Windows.Forms.CheckBox();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Server = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Select = new System.Windows.Forms.Button();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Set = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ckbox_Auto = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.txt_Path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 218);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Refresh);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbox_Server);
            this.groupBox2.Controls.Add(this.ckbox_SQL);
            this.groupBox2.Controls.Add(this.ckbox_Windows);
            this.groupBox2.Controls.Add(this.txt_Pwd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_Name);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_Server);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(14, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 161);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sql Server数据库连接设置";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(313, 127);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(45, 23);
            this.btn_Refresh.TabIndex = 15;
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "选择数据库：";
            // 
            // cbox_Server
            // 
            this.cbox_Server.FormattingEnabled = true;
            this.cbox_Server.Location = new System.Drawing.Point(101, 129);
            this.cbox_Server.Name = "cbox_Server";
            this.cbox_Server.Size = new System.Drawing.Size(206, 20);
            this.cbox_Server.TabIndex = 13;
            // 
            // ckbox_SQL
            // 
            this.ckbox_SQL.AutoSize = true;
            this.ckbox_SQL.Location = new System.Drawing.Point(26, 73);
            this.ckbox_SQL.Name = "ckbox_SQL";
            this.ckbox_SQL.Size = new System.Drawing.Size(132, 16);
            this.ckbox_SQL.TabIndex = 12;
            this.ckbox_SQL.Text = "SQL Server身份验证";
            this.ckbox_SQL.UseVisualStyleBackColor = true;
            this.ckbox_SQL.CheckedChanged += new System.EventHandler(this.ckbox_SQL_CheckedChanged);
            // 
            // ckbox_Windows
            // 
            this.ckbox_Windows.AutoSize = true;
            this.ckbox_Windows.Location = new System.Drawing.Point(26, 52);
            this.ckbox_Windows.Name = "ckbox_Windows";
            this.ckbox_Windows.Size = new System.Drawing.Size(114, 16);
            this.ckbox_Windows.TabIndex = 11;
            this.ckbox_Windows.Text = "Windows身份验证";
            this.ckbox_Windows.UseVisualStyleBackColor = true;
            this.ckbox_Windows.CheckedChanged += new System.EventHandler(this.ckbox_Winfows_CheckedChanged);
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.Enabled = false;
            this.txt_Pwd.Location = new System.Drawing.Point(248, 98);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.PasswordChar = '*';
            this.txt_Pwd.Size = new System.Drawing.Size(109, 21);
            this.txt_Pwd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码：";
            // 
            // txt_Name
            // 
            this.txt_Name.Enabled = false;
            this.txt_Name.Location = new System.Drawing.Point(81, 98);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(111, 21);
            this.txt_Name.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "用户名：";
            // 
            // txt_Server
            // 
            this.txt_Server.Location = new System.Drawing.Point(78, 23);
            this.txt_Server.Name = "txt_Server";
            this.txt_Server.Size = new System.Drawing.Size(279, 21);
            this.txt_Server.TabIndex = 2;
            this.txt_Server.Text = "(local)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "服务器：";
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(322, 17);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(49, 23);
            this.btn_Select.TabIndex = 2;
            this.btn_Select.Text = "选择";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(140, 19);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.ReadOnly = true;
            this.txt_Path.Size = new System.Drawing.Size(176, 21);
            this.txt_Path.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择Excel文件：";
            // 
            // btn_Set
            // 
            this.btn_Set.Location = new System.Drawing.Point(340, 232);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(62, 23);
            this.btn_Set.TabIndex = 5;
            this.btn_Set.Text = "设置";
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ckbox_Auto
            // 
            this.ckbox_Auto.AutoSize = true;
            this.ckbox_Auto.Location = new System.Drawing.Point(21, 236);
            this.ckbox_Auto.Name = "ckbox_Auto";
            this.ckbox_Auto.Size = new System.Drawing.Size(96, 16);
            this.ckbox_Auto.TabIndex = 6;
            this.ckbox_Auto.Text = "是否自动执行";
            this.ckbox_Auto.UseVisualStyleBackColor = true;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 260);
            this.Controls.Add(this.ckbox_Auto);
            this.Controls.Add(this.btn_Set);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实时读取Excel数据到Sql Server数据库";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_Set;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbox_Server;
        private System.Windows.Forms.CheckBox ckbox_SQL;
        private System.Windows.Forms.CheckBox ckbox_Windows;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Server;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox ckbox_Auto;
    }
}

