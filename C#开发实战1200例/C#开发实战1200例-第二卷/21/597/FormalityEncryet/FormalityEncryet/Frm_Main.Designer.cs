namespace FormalityEncryet
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
            System.Windows.Forms.CheckBox checkBox_BIOS;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Pass = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_EXE = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button_File = new System.Windows.Forms.Button();
            this.textBox_File = new System.Windows.Forms.TextBox();
            this.groupB_Encryption = new System.Windows.Forms.GroupBox();
            this.comboBox_Disk = new System.Windows.Forms.ComboBox();
            this.checkBox_Disk = new System.Windows.Forms.CheckBox();
            this.checkBox_MAC = new System.Windows.Forms.CheckBox();
            this.checkBox_CPU = new System.Windows.Forms.CheckBox();
            this.tabPage_Pigh = new System.Windows.Forms.TabPage();
            this.groupBox_Other = new System.Windows.Forms.GroupBox();
            this.radio_Count = new System.Windows.Forms.RadioButton();
            this.radio_Day = new System.Windows.Forms.RadioButton();
            this.radio_Month = new System.Windows.Forms.RadioButton();
            this.numer_Count = new System.Windows.Forms.NumericUpDown();
            this.numer_Day = new System.Windows.Forms.NumericUpDown();
            this.nume_Month = new System.Windows.Forms.NumericUpDown();
            this.groupBox_Data = new System.Windows.Forms.GroupBox();
            this.radio_Data = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            checkBox_BIOS = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_Pass.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupB_Encryption.SuspendLayout();
            this.tabPage_Pigh.SuspendLayout();
            this.groupBox_Other.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numer_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numer_Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nume_Month)).BeginInit();
            this.groupBox_Data.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_BIOS
            // 
            checkBox_BIOS.AutoSize = true;
            checkBox_BIOS.Location = new System.Drawing.Point(21, 34);
            checkBox_BIOS.Name = "checkBox_BIOS";
            checkBox_BIOS.Size = new System.Drawing.Size(72, 16);
            checkBox_BIOS.TabIndex = 0;
            checkBox_BIOS.Tag = "0";
            checkBox_BIOS.Text = "主机名称";
            checkBox_BIOS.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Pass);
            this.tabControl1.Controls.Add(this.tabPage_Pigh);
            this.tabControl1.Location = new System.Drawing.Point(4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(319, 246);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage_Pass
            // 
            this.tabPage_Pass.Controls.Add(this.groupBox1);
            this.tabPage_Pass.Controls.Add(this.groupB_Encryption);
            this.tabPage_Pass.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Pass.Name = "tabPage_Pass";
            this.tabPage_Pass.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Pass.Size = new System.Drawing.Size(311, 220);
            this.tabPage_Pass.TabIndex = 0;
            this.tabPage_Pass.Text = "文件加密设置";
            this.tabPage_Pass.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_EXE);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button_File);
            this.groupBox1.Controls.Add(this.textBox_File);
            this.groupBox1.Location = new System.Drawing.Point(6, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EXE文件加密";
            // 
            // button_EXE
            // 
            this.button_EXE.Location = new System.Drawing.Point(184, 71);
            this.button_EXE.Name = "button_EXE";
            this.button_EXE.Size = new System.Drawing.Size(93, 23);
            this.button_EXE.TabIndex = 3;
            this.button_EXE.Text = "EXE文件加密";
            this.button_EXE.UseVisualStyleBackColor = true;
            this.button_EXE.Click += new System.EventHandler(this.button_EXE_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "获取加密文件的路径：";
            // 
            // button_File
            // 
            this.button_File.Location = new System.Drawing.Point(244, 38);
            this.button_File.Name = "button_File";
            this.button_File.Size = new System.Drawing.Size(33, 23);
            this.button_File.TabIndex = 1;
            this.button_File.Text = "...";
            this.button_File.UseVisualStyleBackColor = true;
            this.button_File.Click += new System.EventHandler(this.button_File_Click);
            // 
            // textBox_File
            // 
            this.textBox_File.Location = new System.Drawing.Point(10, 38);
            this.textBox_File.Name = "textBox_File";
            this.textBox_File.Size = new System.Drawing.Size(228, 21);
            this.textBox_File.TabIndex = 0;
            // 
            // groupB_Encryption
            // 
            this.groupB_Encryption.Controls.Add(this.comboBox_Disk);
            this.groupB_Encryption.Controls.Add(this.checkBox_Disk);
            this.groupB_Encryption.Controls.Add(this.checkBox_MAC);
            this.groupB_Encryption.Controls.Add(this.checkBox_CPU);
            this.groupB_Encryption.Controls.Add(checkBox_BIOS);
            this.groupB_Encryption.Location = new System.Drawing.Point(6, 6);
            this.groupB_Encryption.Name = "groupB_Encryption";
            this.groupB_Encryption.Size = new System.Drawing.Size(297, 109);
            this.groupB_Encryption.TabIndex = 0;
            this.groupB_Encryption.TabStop = false;
            this.groupB_Encryption.Text = "设置加密码";
            // 
            // comboBox_Disk
            // 
            this.comboBox_Disk.FormattingEnabled = true;
            this.comboBox_Disk.Location = new System.Drawing.Point(146, 56);
            this.comboBox_Disk.Name = "comboBox_Disk";
            this.comboBox_Disk.Size = new System.Drawing.Size(84, 20);
            this.comboBox_Disk.TabIndex = 15;
            // 
            // checkBox_Disk
            // 
            this.checkBox_Disk.AutoSize = true;
            this.checkBox_Disk.Location = new System.Drawing.Point(146, 34);
            this.checkBox_Disk.Name = "checkBox_Disk";
            this.checkBox_Disk.Size = new System.Drawing.Size(84, 16);
            this.checkBox_Disk.TabIndex = 3;
            this.checkBox_Disk.Tag = "3";
            this.checkBox_Disk.Text = "硬盘序列号";
            this.checkBox_Disk.UseVisualStyleBackColor = true;
            // 
            // checkBox_MAC
            // 
            this.checkBox_MAC.AutoSize = true;
            this.checkBox_MAC.Location = new System.Drawing.Point(21, 78);
            this.checkBox_MAC.Name = "checkBox_MAC";
            this.checkBox_MAC.Size = new System.Drawing.Size(96, 16);
            this.checkBox_MAC.TabIndex = 2;
            this.checkBox_MAC.Tag = "2";
            this.checkBox_MAC.Text = "网卡硬件地址";
            this.checkBox_MAC.UseVisualStyleBackColor = true;
            // 
            // checkBox_CPU
            // 
            this.checkBox_CPU.AutoSize = true;
            this.checkBox_CPU.Location = new System.Drawing.Point(21, 56);
            this.checkBox_CPU.Name = "checkBox_CPU";
            this.checkBox_CPU.Size = new System.Drawing.Size(78, 16);
            this.checkBox_CPU.TabIndex = 1;
            this.checkBox_CPU.Tag = "1";
            this.checkBox_CPU.Text = "CPU序列号";
            this.checkBox_CPU.UseVisualStyleBackColor = true;
            // 
            // tabPage_Pigh
            // 
            this.tabPage_Pigh.Controls.Add(this.groupBox_Other);
            this.tabPage_Pigh.Controls.Add(this.groupBox_Data);
            this.tabPage_Pigh.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Pigh.Name = "tabPage_Pigh";
            this.tabPage_Pigh.Size = new System.Drawing.Size(311, 220);
            this.tabPage_Pigh.TabIndex = 1;
            this.tabPage_Pigh.Text = "高级设置";
            this.tabPage_Pigh.UseVisualStyleBackColor = true;
            // 
            // groupBox_Other
            // 
            this.groupBox_Other.Controls.Add(this.radio_Count);
            this.groupBox_Other.Controls.Add(this.radio_Day);
            this.groupBox_Other.Controls.Add(this.radio_Month);
            this.groupBox_Other.Controls.Add(this.numer_Count);
            this.groupBox_Other.Controls.Add(this.numer_Day);
            this.groupBox_Other.Controls.Add(this.nume_Month);
            this.groupBox_Other.Location = new System.Drawing.Point(17, 84);
            this.groupBox_Other.Name = "groupBox_Other";
            this.groupBox_Other.Size = new System.Drawing.Size(281, 119);
            this.groupBox_Other.TabIndex = 1;
            this.groupBox_Other.TabStop = false;
            this.groupBox_Other.Text = "其他设置";
            // 
            // radio_Count
            // 
            this.radio_Count.AutoSize = true;
            this.radio_Count.Location = new System.Drawing.Point(33, 89);
            this.radio_Count.Name = "radio_Count";
            this.radio_Count.Size = new System.Drawing.Size(71, 16);
            this.radio_Count.TabIndex = 8;
            this.radio_Count.TabStop = true;
            this.radio_Count.Text = "运行次数";
            this.radio_Count.UseVisualStyleBackColor = true;
            this.radio_Count.MouseUp += new System.Windows.Forms.MouseEventHandler(this.radio_Data_MouseUp);
            // 
            // radio_Day
            // 
            this.radio_Day.AutoSize = true;
            this.radio_Day.Location = new System.Drawing.Point(33, 58);
            this.radio_Day.Name = "radio_Day";
            this.radio_Day.Size = new System.Drawing.Size(71, 16);
            this.radio_Day.TabIndex = 7;
            this.radio_Day.TabStop = true;
            this.radio_Day.Text = "天　　数";
            this.radio_Day.UseVisualStyleBackColor = true;
            this.radio_Day.MouseUp += new System.Windows.Forms.MouseEventHandler(this.radio_Data_MouseUp);
            // 
            // radio_Month
            // 
            this.radio_Month.AutoSize = true;
            this.radio_Month.Location = new System.Drawing.Point(33, 27);
            this.radio_Month.Name = "radio_Month";
            this.radio_Month.Size = new System.Drawing.Size(71, 16);
            this.radio_Month.TabIndex = 6;
            this.radio_Month.TabStop = true;
            this.radio_Month.Text = "月份个数";
            this.radio_Month.UseVisualStyleBackColor = true;
            this.radio_Month.MouseUp += new System.Windows.Forms.MouseEventHandler(this.radio_Data_MouseUp);
            // 
            // numer_Count
            // 
            this.numer_Count.Location = new System.Drawing.Point(114, 86);
            this.numer_Count.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numer_Count.Name = "numer_Count";
            this.numer_Count.Size = new System.Drawing.Size(131, 21);
            this.numer_Count.TabIndex = 5;
            // 
            // numer_Day
            // 
            this.numer_Day.Location = new System.Drawing.Point(114, 55);
            this.numer_Day.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numer_Day.Name = "numer_Day";
            this.numer_Day.Size = new System.Drawing.Size(131, 21);
            this.numer_Day.TabIndex = 4;
            // 
            // nume_Month
            // 
            this.nume_Month.Location = new System.Drawing.Point(114, 24);
            this.nume_Month.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nume_Month.Name = "nume_Month";
            this.nume_Month.Size = new System.Drawing.Size(131, 21);
            this.nume_Month.TabIndex = 3;
            // 
            // groupBox_Data
            // 
            this.groupBox_Data.Controls.Add(this.radio_Data);
            this.groupBox_Data.Controls.Add(this.dateTimePicker1);
            this.groupBox_Data.Controls.Add(this.label1);
            this.groupBox_Data.Location = new System.Drawing.Point(17, 13);
            this.groupBox_Data.Name = "groupBox_Data";
            this.groupBox_Data.Size = new System.Drawing.Size(281, 55);
            this.groupBox_Data.TabIndex = 0;
            this.groupBox_Data.TabStop = false;
            this.groupBox_Data.Text = "日期设置";
            // 
            // radio_Data
            // 
            this.radio_Data.AutoSize = true;
            this.radio_Data.Location = new System.Drawing.Point(33, 24);
            this.radio_Data.Name = "radio_Data";
            this.radio_Data.Size = new System.Drawing.Size(71, 16);
            this.radio_Data.TabIndex = 2;
            this.radio_Data.TabStop = true;
            this.radio_Data.Text = "截止日期";
            this.radio_Data.UseVisualStyleBackColor = true;
            this.radio_Data.MouseUp += new System.Windows.Forms.MouseEventHandler(this.radio_Data_MouseUp);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(114, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "截止日期：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 254);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXE文件加密器";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Pass.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupB_Encryption.ResumeLayout(false);
            this.groupB_Encryption.PerformLayout();
            this.tabPage_Pigh.ResumeLayout(false);
            this.groupBox_Other.ResumeLayout(false);
            this.groupBox_Other.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numer_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numer_Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nume_Month)).EndInit();
            this.groupBox_Data.ResumeLayout(false);
            this.groupBox_Data.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Pass;
        private System.Windows.Forms.GroupBox groupB_Encryption;
        private System.Windows.Forms.CheckBox checkBox_Disk;
        private System.Windows.Forms.CheckBox checkBox_MAC;
        private System.Windows.Forms.CheckBox checkBox_CPU;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_File;
        private System.Windows.Forms.TextBox textBox_File;
        private System.Windows.Forms.ComboBox comboBox_Disk;
        private System.Windows.Forms.Button button_EXE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage_Pigh;
        private System.Windows.Forms.GroupBox groupBox_Other;
        private System.Windows.Forms.GroupBox groupBox_Data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nume_Month;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radio_Month;
        private System.Windows.Forms.NumericUpDown numer_Count;
        private System.Windows.Forms.NumericUpDown numer_Day;
        private System.Windows.Forms.RadioButton radio_Data;
        private System.Windows.Forms.RadioButton radio_Count;
        private System.Windows.Forms.RadioButton radio_Day;
    }
}

