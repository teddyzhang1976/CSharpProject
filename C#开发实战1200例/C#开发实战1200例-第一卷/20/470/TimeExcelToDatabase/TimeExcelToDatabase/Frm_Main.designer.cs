namespace TimeExcelToDatabase
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Access = new System.Windows.Forms.Button();
            this.rbtn_Access = new System.Windows.Forms.RadioButton();
            this.txt_Access = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtn_Sql = new System.Windows.Forms.RadioButton();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudown_Hour = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudown_Min = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudown_Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudown_Min)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.txt_Path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 274);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Access);
            this.groupBox3.Controls.Add(this.rbtn_Access);
            this.groupBox3.Controls.Add(this.txt_Access);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(14, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 50);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // btn_Access
            // 
            this.btn_Access.Location = new System.Drawing.Point(308, 18);
            this.btn_Access.Name = "btn_Access";
            this.btn_Access.Size = new System.Drawing.Size(49, 23);
            this.btn_Access.TabIndex = 7;
            this.btn_Access.Text = "选择";
            this.btn_Access.UseVisualStyleBackColor = true;
            this.btn_Access.Click += new System.EventHandler(this.btn_Access_Click);
            // 
            // rbtn_Access
            // 
            this.rbtn_Access.AutoSize = true;
            this.rbtn_Access.Location = new System.Drawing.Point(10, 0);
            this.rbtn_Access.Name = "rbtn_Access";
            this.rbtn_Access.Size = new System.Drawing.Size(119, 16);
            this.rbtn_Access.TabIndex = 6;
            this.rbtn_Access.TabStop = true;
            this.rbtn_Access.Text = "Access数据库设置";
            this.rbtn_Access.UseVisualStyleBackColor = true;
            this.rbtn_Access.CheckedChanged += new System.EventHandler(this.rbtn_Access_CheckedChanged);
            // 
            // txt_Access
            // 
            this.txt_Access.Location = new System.Drawing.Point(126, 20);
            this.txt_Access.Name = "txt_Access";
            this.txt_Access.ReadOnly = true;
            this.txt_Access.Size = new System.Drawing.Size(176, 21);
            this.txt_Access.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "请选择Access文件：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtn_Sql);
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
            this.groupBox2.Location = new System.Drawing.Point(14, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 161);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // rbtn_Sql
            // 
            this.rbtn_Sql.AutoSize = true;
            this.rbtn_Sql.Location = new System.Drawing.Point(10, 0);
            this.rbtn_Sql.Name = "rbtn_Sql";
            this.rbtn_Sql.Size = new System.Drawing.Size(167, 16);
            this.rbtn_Sql.TabIndex = 7;
            this.rbtn_Sql.TabStop = true;
            this.rbtn_Sql.Text = "Sql Server数据库连接设置";
            this.rbtn_Sql.UseVisualStyleBackColor = true;
            this.rbtn_Sql.CheckedChanged += new System.EventHandler(this.rbtn_Sql_CheckedChanged);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Enabled = false;
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
            this.cbox_Server.Enabled = false;
            this.cbox_Server.FormattingEnabled = true;
            this.cbox_Server.Location = new System.Drawing.Point(101, 129);
            this.cbox_Server.Name = "cbox_Server";
            this.cbox_Server.Size = new System.Drawing.Size(206, 20);
            this.cbox_Server.TabIndex = 13;
            // 
            // ckbox_SQL
            // 
            this.ckbox_SQL.AutoSize = true;
            this.ckbox_SQL.Enabled = false;
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
            this.ckbox_Windows.Enabled = false;
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
            this.txt_Server.Enabled = false;
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
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择Excel文件：";
            // 
            // btn_Set
            // 
            this.btn_Set.Location = new System.Drawing.Point(323, 15);
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
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.nudown_Hour);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.nudown_Min);
            this.groupBox4.Controls.Add(this.btn_Set);
            this.groupBox4.Location = new System.Drawing.Point(7, 288);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(395, 48);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "定时设置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(140, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "时";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "小时：";
            // 
            // nudown_Hour
            // 
            this.nudown_Hour.Location = new System.Drawing.Point(82, 18);
            this.nudown_Hour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudown_Hour.Name = "nudown_Hour";
            this.nudown_Hour.Size = new System.Drawing.Size(54, 21);
            this.nudown_Hour.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "分钟：";
            // 
            // nudown_Min
            // 
            this.nudown_Min.Location = new System.Drawing.Point(219, 18);
            this.nudown_Min.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudown_Min.Name = "nudown_Min";
            this.nudown_Min.Size = new System.Drawing.Size(54, 21);
            this.nudown_Min.TabIndex = 12;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 348);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "每天定时读取Excel文件给指定数据库";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudown_Hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudown_Min)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Access;
        private System.Windows.Forms.TextBox txt_Access;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtn_Access;
        private System.Windows.Forms.RadioButton rbtn_Sql;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudown_Hour;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudown_Min;
    }
}

