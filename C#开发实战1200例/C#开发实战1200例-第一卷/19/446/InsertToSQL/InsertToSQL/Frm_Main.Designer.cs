namespace InsertToSQL
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
            this.btn_SetTask = new System.Windows.Forms.Button();
            this.btn_DisplayData = new System.Windows.Forms.Button();
            this.txt_Server = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_PassWord = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_DataBase = new System.Windows.Forms.TextBox();
            this.btn_Begin = new System.Windows.Forms.Button();
            this.btn_display = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_Message = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_Seconds = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Complete = new System.Windows.Forms.Button();
            this.txt_Minutes = new System.Windows.Forms.TextBox();
            this.txt_Hours = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_RemoveTask = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbox_Task = new System.Windows.Forms.ListBox();
            this.btn_AddTask = new System.Windows.Forms.Button();
            this.btn_Hide = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SetTask);
            this.groupBox1.Controls.Add(this.btn_DisplayData);
            this.groupBox1.Controls.Add(this.txt_Server);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_PassWord);
            this.groupBox1.Controls.Add(this.txt_UserName);
            this.groupBox1.Controls.Add(this.txt_DataBase);
            this.groupBox1.Controls.Add(this.btn_Begin);
            this.groupBox1.Controls.Add(this.btn_display);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 211);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作Word文档";
            // 
            // btn_SetTask
            // 
            this.btn_SetTask.Location = new System.Drawing.Point(225, 126);
            this.btn_SetTask.Name = "btn_SetTask";
            this.btn_SetTask.Size = new System.Drawing.Size(170, 23);
            this.btn_SetTask.TabIndex = 14;
            this.btn_SetTask.Text = "设置定时信息";
            this.btn_SetTask.UseVisualStyleBackColor = true;
            this.btn_SetTask.Click += new System.EventHandler(this.btn_SetTask_Click);
            // 
            // btn_DisplayData
            // 
            this.btn_DisplayData.Location = new System.Drawing.Point(227, 167);
            this.btn_DisplayData.Name = "btn_DisplayData";
            this.btn_DisplayData.Size = new System.Drawing.Size(170, 23);
            this.btn_DisplayData.TabIndex = 13;
            this.btn_DisplayData.Text = "显示SQL中的数据";
            this.btn_DisplayData.UseVisualStyleBackColor = true;
            this.btn_DisplayData.Click += new System.EventHandler(this.btn_DisplayData_Click);
            // 
            // txt_Server
            // 
            this.txt_Server.Location = new System.Drawing.Point(105, 37);
            this.txt_Server.Name = "txt_Server";
            this.txt_Server.Size = new System.Drawing.Size(95, 21);
            this.txt_Server.TabIndex = 11;
            this.txt_Server.Text = "MRWXK\\WANGXIAOKE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "数据库服务器：";
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Location = new System.Drawing.Point(298, 76);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.Size = new System.Drawing.Size(95, 21);
            this.txt_PassWord.TabIndex = 7;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(298, 36);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(95, 21);
            this.txt_UserName.TabIndex = 6;
            this.txt_UserName.Text = "sa";
            // 
            // txt_DataBase
            // 
            this.txt_DataBase.Location = new System.Drawing.Point(105, 76);
            this.txt_DataBase.Name = "txt_DataBase";
            this.txt_DataBase.Size = new System.Drawing.Size(95, 21);
            this.txt_DataBase.TabIndex = 5;
            this.txt_DataBase.Text = "db_TomeOne";
            // 
            // btn_Begin
            // 
            this.btn_Begin.Location = new System.Drawing.Point(22, 167);
            this.btn_Begin.Name = "btn_Begin";
            this.btn_Begin.Size = new System.Drawing.Size(170, 23);
            this.btn_Begin.TabIndex = 0;
            this.btn_Begin.Text = "开始监控并执行定时任务";
            this.btn_Begin.UseVisualStyleBackColor = true;
            this.btn_Begin.Click += new System.EventHandler(this.btn_Begin_Click);
            // 
            // btn_display
            // 
            this.btn_display.Location = new System.Drawing.Point(22, 126);
            this.btn_display.Name = "btn_display";
            this.btn_display.Size = new System.Drawing.Size(170, 23);
            this.btn_display.TabIndex = 1;
            this.btn_display.Text = "显示Word文档并手动添加数据";
            this.btn_display.UseVisualStyleBackColor = true;
            this.btn_display.Click += new System.EventHandler(this.btn_display_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "数据库密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "数据库用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "数据库名称：";
            // 
            // dgv_Message
            // 
            this.dgv_Message.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Message.Location = new System.Drawing.Point(12, 229);
            this.dgv_Message.Name = "dgv_Message";
            this.dgv_Message.RowTemplate.Height = 23;
            this.dgv_Message.Size = new System.Drawing.Size(416, 228);
            this.dgv_Message.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_Seconds);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btn_Complete);
            this.groupBox2.Controls.Add(this.txt_Minutes);
            this.groupBox2.Controls.Add(this.txt_Hours);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btn_RemoveTask);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbox_Task);
            this.groupBox2.Controls.Add(this.btn_AddTask);
            this.groupBox2.Location = new System.Drawing.Point(439, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 211);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置提交数据时间";
            // 
            // txt_Seconds
            // 
            this.txt_Seconds.Location = new System.Drawing.Point(172, 152);
            this.txt_Seconds.Name = "txt_Seconds";
            this.txt_Seconds.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Seconds.Size = new System.Drawing.Size(26, 21);
            this.txt_Seconds.TabIndex = 21;
            this.txt_Seconds.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(203, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "秒";
            // 
            // btn_Complete
            // 
            this.btn_Complete.Location = new System.Drawing.Point(146, 180);
            this.btn_Complete.Name = "btn_Complete";
            this.btn_Complete.Size = new System.Drawing.Size(75, 23);
            this.btn_Complete.TabIndex = 19;
            this.btn_Complete.Text = "完成";
            this.btn_Complete.UseVisualStyleBackColor = true;
            this.btn_Complete.Click += new System.EventHandler(this.btn_Complete_Click);
            // 
            // txt_Minutes
            // 
            this.txt_Minutes.Location = new System.Drawing.Point(114, 153);
            this.txt_Minutes.Name = "txt_Minutes";
            this.txt_Minutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Minutes.Size = new System.Drawing.Size(26, 21);
            this.txt_Minutes.TabIndex = 18;
            this.txt_Minutes.Text = "0";
            // 
            // txt_Hours
            // 
            this.txt_Hours.Location = new System.Drawing.Point(60, 153);
            this.txt_Hours.Name = "txt_Hours";
            this.txt_Hours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Hours.Size = new System.Drawing.Size(25, 21);
            this.txt_Hours.TabIndex = 14;
            this.txt_Hours.Text = "13";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "每天的:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "分";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "时";
            // 
            // btn_RemoveTask
            // 
            this.btn_RemoveTask.Location = new System.Drawing.Point(88, 121);
            this.btn_RemoveTask.Name = "btn_RemoveTask";
            this.btn_RemoveTask.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveTask.TabIndex = 14;
            this.btn_RemoveTask.Text = "删除";
            this.btn_RemoveTask.UseVisualStyleBackColor = true;
            this.btn_RemoveTask.Click += new System.EventHandler(this.btn_RemoveTask_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "任务列表：";
            // 
            // lbox_Task
            // 
            this.lbox_Task.FormattingEnabled = true;
            this.lbox_Task.ItemHeight = 12;
            this.lbox_Task.Location = new System.Drawing.Point(6, 41);
            this.lbox_Task.Name = "lbox_Task";
            this.lbox_Task.Size = new System.Drawing.Size(229, 76);
            this.lbox_Task.TabIndex = 12;
            // 
            // btn_AddTask
            // 
            this.btn_AddTask.Location = new System.Drawing.Point(41, 180);
            this.btn_AddTask.Name = "btn_AddTask";
            this.btn_AddTask.Size = new System.Drawing.Size(75, 23);
            this.btn_AddTask.TabIndex = 11;
            this.btn_AddTask.Text = "添加";
            this.btn_AddTask.UseVisualStyleBackColor = true;
            this.btn_AddTask.Click += new System.EventHandler(this.btn_AddTask_Click);
            // 
            // btn_Hide
            // 
            this.btn_Hide.Location = new System.Drawing.Point(178, 463);
            this.btn_Hide.Name = "btn_Hide";
            this.btn_Hide.Size = new System.Drawing.Size(75, 23);
            this.btn_Hide.TabIndex = 11;
            this.btn_Hide.Text = "隐藏";
            this.btn_Hide.UseVisualStyleBackColor = true;
            this.btn_Hide.Click += new System.EventHandler(this.btn_Hide_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 226);
            this.Controls.Add(this.btn_Hide);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv_Message);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "每天定时读取Word文档中表格数据给指定数据库";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_DisplayData;
        private System.Windows.Forms.TextBox txt_Server;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_PassWord;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_DataBase;
        private System.Windows.Forms.Button btn_Begin;
        private System.Windows.Forms.Button btn_display;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_Message;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_AddTask;
        private System.Windows.Forms.TextBox txt_Minutes;
        private System.Windows.Forms.TextBox txt_Hours;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_RemoveTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbox_Task;
        private System.Windows.Forms.Button btn_Complete;
        private System.Windows.Forms.Button btn_SetTask;
        private System.Windows.Forms.Button btn_Hide;
        private System.Windows.Forms.TextBox txt_Seconds;
        private System.Windows.Forms.Label label9;
    }
}

