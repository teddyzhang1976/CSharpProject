namespace TimeReportResultToExcel
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
            this.btn_SelectFlod = new System.Windows.Forms.Button();
            this.txt_Floder = new System.Windows.Forms.TextBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudown_Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudown_Min)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SelectFlod);
            this.groupBox1.Controls.Add(this.txt_Floder);
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // btn_SelectFlod
            // 
            this.btn_SelectFlod.Location = new System.Drawing.Point(321, 20);
            this.btn_SelectFlod.Name = "btn_SelectFlod";
            this.btn_SelectFlod.Size = new System.Drawing.Size(49, 23);
            this.btn_SelectFlod.TabIndex = 7;
            this.btn_SelectFlod.Text = "选择";
            this.btn_SelectFlod.UseVisualStyleBackColor = true;
            this.btn_SelectFlod.Click += new System.EventHandler(this.btn_SelectFlod_Click);
            // 
            // txt_Floder
            // 
            this.txt_Floder.Location = new System.Drawing.Point(139, 22);
            this.txt_Floder.Name = "txt_Floder";
            this.txt_Floder.ReadOnly = true;
            this.txt_Floder.Size = new System.Drawing.Size(176, 21);
            this.txt_Floder.TabIndex = 6;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(321, 49);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(49, 23);
            this.btn_Select.TabIndex = 2;
            this.btn_Select.Text = "选择";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "请选择上报结果文件夹：";
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(139, 51);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.ReadOnly = true;
            this.txt_Path.Size = new System.Drawing.Size(176, 21);
            this.txt_Path.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择Excel文件：";
            // 
            // btn_Set
            // 
            this.btn_Set.Location = new System.Drawing.Point(308, 15);
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
            this.groupBox4.Location = new System.Drawing.Point(7, 98);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(378, 48);
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
            this.ClientSize = new System.Drawing.Size(396, 154);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "每天定时将各地上报结果处理到Excel";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btn_SelectFlod;
        private System.Windows.Forms.TextBox txt_Floder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudown_Hour;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudown_Min;
    }
}

