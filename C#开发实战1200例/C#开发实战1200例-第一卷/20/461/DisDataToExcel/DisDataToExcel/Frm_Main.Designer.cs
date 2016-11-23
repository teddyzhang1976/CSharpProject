namespace DisDataToExcel
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
            this.btn_SelectTxt = new System.Windows.Forms.Button();
            this.txt_Txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_SelectWord = new System.Windows.Forms.Button();
            this.txt_Word = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_SelectAccess = new System.Windows.Forms.Button();
            this.txt_Access = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_SelectExcel = new System.Windows.Forms.Button();
            this.txt_Excel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SelectTxt);
            this.groupBox1.Controls.Add(this.txt_Txt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文本文件数据";
            // 
            // btn_SelectTxt
            // 
            this.btn_SelectTxt.Location = new System.Drawing.Point(292, 19);
            this.btn_SelectTxt.Name = "btn_SelectTxt";
            this.btn_SelectTxt.Size = new System.Drawing.Size(50, 23);
            this.btn_SelectTxt.TabIndex = 5;
            this.btn_SelectTxt.Text = "选择";
            this.btn_SelectTxt.UseVisualStyleBackColor = true;
            this.btn_SelectTxt.Click += new System.EventHandler(this.btn_SelectTxt_Click);
            // 
            // txt_Txt
            // 
            this.txt_Txt.Location = new System.Drawing.Point(113, 20);
            this.txt_Txt.Name = "txt_Txt";
            this.txt_Txt.ReadOnly = true;
            this.txt_Txt.Size = new System.Drawing.Size(172, 21);
            this.txt_Txt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "请选择文本文件：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_SelectWord);
            this.groupBox2.Controls.Add(this.txt_Word);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Word文档数据";
            // 
            // btn_SelectWord
            // 
            this.btn_SelectWord.Location = new System.Drawing.Point(292, 20);
            this.btn_SelectWord.Name = "btn_SelectWord";
            this.btn_SelectWord.Size = new System.Drawing.Size(50, 23);
            this.btn_SelectWord.TabIndex = 5;
            this.btn_SelectWord.Text = "选择";
            this.btn_SelectWord.UseVisualStyleBackColor = true;
            this.btn_SelectWord.Click += new System.EventHandler(this.btn_SelectWord_Click);
            // 
            // txt_Word
            // 
            this.txt_Word.Location = new System.Drawing.Point(113, 22);
            this.txt_Word.Name = "txt_Word";
            this.txt_Word.ReadOnly = true;
            this.txt_Word.Size = new System.Drawing.Size(172, 21);
            this.txt_Word.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "请选择Word文件：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_SelectAccess);
            this.groupBox3.Controls.Add(this.txt_Access);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 55);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Access数据库文件数据";
            // 
            // btn_SelectAccess
            // 
            this.btn_SelectAccess.Location = new System.Drawing.Point(292, 18);
            this.btn_SelectAccess.Name = "btn_SelectAccess";
            this.btn_SelectAccess.Size = new System.Drawing.Size(50, 23);
            this.btn_SelectAccess.TabIndex = 5;
            this.btn_SelectAccess.Text = "选择";
            this.btn_SelectAccess.UseVisualStyleBackColor = true;
            this.btn_SelectAccess.Click += new System.EventHandler(this.btn_SelectAccess_Click);
            // 
            // txt_Access
            // 
            this.txt_Access.Location = new System.Drawing.Point(113, 20);
            this.txt_Access.Name = "txt_Access";
            this.txt_Access.ReadOnly = true;
            this.txt_Access.Size = new System.Drawing.Size(172, 21);
            this.txt_Access.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "请选择Access文件：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Stop);
            this.groupBox4.Controls.Add(this.btn_Browse);
            this.groupBox4.Controls.Add(this.btn_Start);
            this.groupBox4.Controls.Add(this.btn_SelectExcel);
            this.groupBox4.Controls.Add(this.txt_Excel);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 201);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(353, 89);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Excel文件设置";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(211, 56);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(63, 23);
            this.btn_Stop.TabIndex = 11;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(279, 56);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(63, 23);
            this.btn_Browse.TabIndex = 10;
            this.btn_Browse.Text = "查看";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(143, 56);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(63, 23);
            this.btn_Start.TabIndex = 9;
            this.btn_Start.Text = "开始";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_SelectExcel
            // 
            this.btn_SelectExcel.Location = new System.Drawing.Point(292, 23);
            this.btn_SelectExcel.Name = "btn_SelectExcel";
            this.btn_SelectExcel.Size = new System.Drawing.Size(50, 23);
            this.btn_SelectExcel.TabIndex = 8;
            this.btn_SelectExcel.Text = "选择";
            this.btn_SelectExcel.UseVisualStyleBackColor = true;
            this.btn_SelectExcel.Click += new System.EventHandler(this.btn_SelectExcel_Click);
            // 
            // txt_Excel
            // 
            this.txt_Excel.Location = new System.Drawing.Point(113, 25);
            this.txt_Excel.Name = "txt_Excel";
            this.txt_Excel.ReadOnly = true;
            this.txt_Excel.Size = new System.Drawing.Size(172, 21);
            this.txt_Excel.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "请选择Excel文件：";
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
            this.ClientSize = new System.Drawing.Size(376, 301);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实时读取不同数据到Excel进行汇总处理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_SelectTxt;
        private System.Windows.Forms.TextBox txt_Txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_SelectWord;
        private System.Windows.Forms.TextBox txt_Word;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_SelectAccess;
        private System.Windows.Forms.TextBox txt_Access;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_SelectExcel;
        private System.Windows.Forms.TextBox txt_Excel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_Stop;
    }
}

