namespace FormatDataInExcel
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_KeyWord = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbox_Condition = new System.Windows.Forms.ComboBox();
            this.btn_Query = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.dgv_Info = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Excel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Info)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_KeyWord);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cbox_Condition);
            this.groupBox2.Controls.Add(this.btn_Query);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(7, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 45);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息查询设置";
            // 
            // txt_KeyWord
            // 
            this.txt_KeyWord.Location = new System.Drawing.Point(283, 18);
            this.txt_KeyWord.Name = "txt_KeyWord";
            this.txt_KeyWord.Size = new System.Drawing.Size(157, 21);
            this.txt_KeyWord.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(206, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "查询关键字：";
            // 
            // cbox_Condition
            // 
            this.cbox_Condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Condition.FormattingEnabled = true;
            this.cbox_Condition.Items.AddRange(new object[] {
            "职工编号",
            "职工姓名",
            "性别"});
            this.cbox_Condition.Location = new System.Drawing.Point(72, 18);
            this.cbox_Condition.Name = "cbox_Condition";
            this.cbox_Condition.Size = new System.Drawing.Size(127, 20);
            this.cbox_Condition.TabIndex = 3;
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(448, 16);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(63, 23);
            this.btn_Query.TabIndex = 2;
            this.btn_Query.Text = "查询";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "查询条件：";
            // 
            // dgv_Info
            // 
            this.dgv_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Info.Location = new System.Drawing.Point(7, 60);
            this.dgv_Info.Name = "dgv_Info";
            this.dgv_Info.RowTemplate.Height = 23;
            this.dgv_Info.Size = new System.Drawing.Size(522, 184);
            this.dgv_Info.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Excel);
            this.groupBox1.Location = new System.Drawing.Point(7, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 40);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // btn_Excel
            // 
            this.btn_Excel.Location = new System.Drawing.Point(416, 12);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(95, 23);
            this.btn_Excel.TabIndex = 0;
            this.btn_Excel.Text = "Excel格式转换";
            this.btn_Excel.UseVisualStyleBackColor = true;
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 296);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_Info);
            this.Controls.Add(this.groupBox2);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "利用Excel对数据进行格式转换";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Info)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_KeyWord;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbox_Condition;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgv_Info;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Excel;

    }
}

