namespace TimeCloseComputer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNowTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.rbShowMessage = new System.Windows.Forms.RadioButton();
            this.rbLogout = new System.Windows.Forms.RadioButton();
            this.rbBegin = new System.Windows.Forms.RadioButton();
            this.rbShutDown = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbbWeek = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbcycleWeek = new System.Windows.Forms.RadioButton();
            this.rbcycleDay = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.chbAutoRun = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNowTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统当前时间";
            // 
            // lblNowTime
            // 
            this.lblNowTime.AutoSize = true;
            this.lblNowTime.Location = new System.Drawing.Point(80, 22);
            this.lblNowTime.Name = "lblNowTime";
            this.lblNowTime.Size = new System.Drawing.Size(0, 12);
            this.lblNowTime.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "当前时间：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设定关机时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "设置关机时间：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(102, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(118, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMessage);
            this.groupBox3.Controls.Add(this.rbShowMessage);
            this.groupBox3.Controls.Add(this.rbLogout);
            this.groupBox3.Controls.Add(this.rbBegin);
            this.groupBox3.Controls.Add(this.rbShutDown);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择关机类型";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(102, 41);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(173, 21);
            this.txtMessage.TabIndex = 9;
            // 
            // rbShowMessage
            // 
            this.rbShowMessage.AutoSize = true;
            this.rbShowMessage.Location = new System.Drawing.Point(8, 44);
            this.rbShowMessage.Name = "rbShowMessage";
            this.rbShowMessage.Size = new System.Drawing.Size(95, 16);
            this.rbShowMessage.TabIndex = 8;
            this.rbShowMessage.Text = "显示提示信息";
            this.rbShowMessage.UseVisualStyleBackColor = true;
            // 
            // rbLogout
            // 
            this.rbLogout.AutoSize = true;
            this.rbLogout.Location = new System.Drawing.Point(154, 20);
            this.rbLogout.Name = "rbLogout";
            this.rbLogout.Size = new System.Drawing.Size(47, 16);
            this.rbLogout.TabIndex = 7;
            this.rbLogout.Text = "注销";
            this.rbLogout.UseVisualStyleBackColor = true;
            // 
            // rbBegin
            // 
            this.rbBegin.AutoSize = true;
            this.rbBegin.Location = new System.Drawing.Point(82, 20);
            this.rbBegin.Name = "rbBegin";
            this.rbBegin.Size = new System.Drawing.Size(47, 16);
            this.rbBegin.TabIndex = 6;
            this.rbBegin.Text = "重启";
            this.rbBegin.UseVisualStyleBackColor = true;
            // 
            // rbShutDown
            // 
            this.rbShutDown.AutoSize = true;
            this.rbShutDown.Checked = true;
            this.rbShutDown.Location = new System.Drawing.Point(8, 20);
            this.rbShutDown.Name = "rbShutDown";
            this.rbShutDown.Size = new System.Drawing.Size(47, 16);
            this.rbShutDown.TabIndex = 5;
            this.rbShutDown.TabStop = true;
            this.rbShutDown.Text = "关机";
            this.rbShutDown.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Controls.Add(this.cbbWeek);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.rbcycleWeek);
            this.groupBox4.Controls.Add(this.rbcycleDay);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.chbAutoRun);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(12, 193);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(284, 116);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "自动选设置";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TimeCloseComputer.Properties.Resources._false;
            this.pictureBox2.Location = new System.Drawing.Point(150, 86);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(92, 24);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // cbbWeek
            // 
            this.cbbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWeek.FormattingEnabled = true;
            this.cbbWeek.Items.AddRange(new object[] {
            "一",
            "二",
            "三",
            "四",
            "五",
            "六",
            "日"});
            this.cbbWeek.Location = new System.Drawing.Point(182, 44);
            this.cbbWeek.Name = "cbbWeek";
            this.cbbWeek.Size = new System.Drawing.Size(53, 20);
            this.cbbWeek.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TimeCloseComputer.Properties.Resources._true;
            this.pictureBox1.Location = new System.Drawing.Point(33, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 24);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // rbcycleWeek
            // 
            this.rbcycleWeek.AutoSize = true;
            this.rbcycleWeek.Location = new System.Drawing.Point(129, 46);
            this.rbcycleWeek.Name = "rbcycleWeek";
            this.rbcycleWeek.Size = new System.Drawing.Size(47, 16);
            this.rbcycleWeek.TabIndex = 5;
            this.rbcycleWeek.Text = "每周";
            this.rbcycleWeek.UseVisualStyleBackColor = true;
            // 
            // rbcycleDay
            // 
            this.rbcycleDay.AutoSize = true;
            this.rbcycleDay.Checked = true;
            this.rbcycleDay.Location = new System.Drawing.Point(78, 46);
            this.rbcycleDay.Name = "rbcycleDay";
            this.rbcycleDay.Size = new System.Drawing.Size(47, 16);
            this.rbcycleDay.TabIndex = 4;
            this.rbcycleDay.TabStop = true;
            this.rbcycleDay.Text = "每天";
            this.rbcycleDay.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "执行周期：";
            // 
            // chbAutoRun
            // 
            this.chbAutoRun.AutoSize = true;
            this.chbAutoRun.Location = new System.Drawing.Point(8, 20);
            this.chbAutoRun.Name = "chbAutoRun";
            this.chbAutoRun.Size = new System.Drawing.Size(204, 16);
            this.chbAutoRun.TabIndex = 0;
            this.chbAutoRun.Text = "开机自动运行，并按预设时间关机";
            this.chbAutoRun.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "定时关闭计算机";
            this.notifyIcon1.BalloonTipTitle = "定时关闭计算机";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "定时关闭计算机";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Image = global::TimeCloseComputer.Properties.Resources.图标__18_;
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = global::TimeCloseComputer.Properties.Resources.图标__93_;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(307, 314);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时关闭计算机";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton rbLogout;
        private System.Windows.Forms.RadioButton rbBegin;
        private System.Windows.Forms.RadioButton rbShutDown;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.RadioButton rbShowMessage;
        private System.Windows.Forms.ComboBox cbbWeek;
        private System.Windows.Forms.RadioButton rbcycleWeek;
        private System.Windows.Forms.RadioButton rbcycleDay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chbAutoRun;
        private System.Windows.Forms.Label lblNowTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

