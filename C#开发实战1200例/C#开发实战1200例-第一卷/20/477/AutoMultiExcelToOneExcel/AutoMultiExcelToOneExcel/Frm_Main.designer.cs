namespace AutoMultiExcelToOneExcel
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
            this.btn_SelectExcel = new System.Windows.Forms.Button();
            this.txt_Excel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_SelectMultiExcel = new System.Windows.Forms.Button();
            this.txt_MultiExcel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudown_Hour = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudown_Min = new System.Windows.Forms.NumericUpDown();
            this.btn_Set = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudown_Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudown_Min)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SelectExcel);
            this.groupBox1.Controls.Add(this.txt_Excel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_SelectMultiExcel);
            this.groupBox1.Controls.Add(this.txt_MultiExcel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // btn_SelectExcel
            // 
            this.btn_SelectExcel.Location = new System.Drawing.Point(319, 52);
            this.btn_SelectExcel.Name = "btn_SelectExcel";
            this.btn_SelectExcel.Size = new System.Drawing.Size(50, 23);
            this.btn_SelectExcel.TabIndex = 5;
            this.btn_SelectExcel.Text = "选择";
            this.btn_SelectExcel.UseVisualStyleBackColor = true;
            this.btn_SelectExcel.Click += new System.EventHandler(this.btn_SelectExcel_Click);
            // 
            // txt_Excel
            // 
            this.txt_Excel.Location = new System.Drawing.Point(137, 54);
            this.txt_Excel.Name = "txt_Excel";
            this.txt_Excel.ReadOnly = true;
            this.txt_Excel.Size = new System.Drawing.Size(172, 21);
            this.txt_Excel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "请选择Excel文件：";
            // 
            // btn_SelectMultiExcel
            // 
            this.btn_SelectMultiExcel.Location = new System.Drawing.Point(319, 21);
            this.btn_SelectMultiExcel.Name = "btn_SelectMultiExcel";
            this.btn_SelectMultiExcel.Size = new System.Drawing.Size(50, 23);
            this.btn_SelectMultiExcel.TabIndex = 2;
            this.btn_SelectMultiExcel.Text = "选择";
            this.btn_SelectMultiExcel.UseVisualStyleBackColor = true;
            this.btn_SelectMultiExcel.Click += new System.EventHandler(this.btn_SelectMultiExcel_Click);
            // 
            // txt_MultiExcel
            // 
            this.txt_MultiExcel.Location = new System.Drawing.Point(137, 23);
            this.txt_MultiExcel.Name = "txt_MultiExcel";
            this.txt_MultiExcel.ReadOnly = true;
            this.txt_MultiExcel.Size = new System.Drawing.Size(172, 21);
            this.txt_MultiExcel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择多个Excel文件：";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(323, 17);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(46, 23);
            this.btn_Browse.TabIndex = 1;
            this.btn_Browse.Text = "查看";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Browse);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.nudown_Hour);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.nudown_Min);
            this.groupBox4.Controls.Add(this.btn_Set);
            this.groupBox4.Location = new System.Drawing.Point(10, 106);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(386, 48);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "自动汇总设置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(154, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "时";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "小时：";
            // 
            // nudown_Hour
            // 
            this.nudown_Hour.Location = new System.Drawing.Point(76, 20);
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
            this.label8.Location = new System.Drawing.Point(158, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "分钟：";
            // 
            // nudown_Min
            // 
            this.nudown_Min.Location = new System.Drawing.Point(201, 20);
            this.nudown_Min.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudown_Min.Name = "nudown_Min";
            this.nudown_Min.Size = new System.Drawing.Size(54, 21);
            this.nudown_Min.TabIndex = 12;
            // 
            // btn_Set
            // 
            this.btn_Set.Location = new System.Drawing.Point(271, 17);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(46, 23);
            this.btn_Set.TabIndex = 5;
            this.btn_Set.Text = "设置";
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 162);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "将多个Excel文件进行自动汇总";
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
        private System.Windows.Forms.Button btn_SelectExcel;
        private System.Windows.Forms.TextBox txt_Excel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_SelectMultiExcel;
        private System.Windows.Forms.TextBox txt_MultiExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudown_Hour;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudown_Min;
        private System.Windows.Forms.Button btn_Set;
        private System.Windows.Forms.Timer timer1;
    }
}

