namespace NestingFind
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
            this.dgv_Message = new System.Windows.Forms.DataGridView();
            this.txt_Name2 = new System.Windows.Forms.TextBox();
            this.txt_Name1 = new System.Windows.Forms.TextBox();
            this.cbox_Select = new System.Windows.Forms.ComboBox();
            this.cbox_Operator = new System.Windows.Forms.ComboBox();
            this.cbox_Subject = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Select = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Message
            // 
            this.dgv_Message.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Message.Location = new System.Drawing.Point(0, 0);
            this.dgv_Message.Name = "dgv_Message";
            this.dgv_Message.RowTemplate.Height = 23;
            this.dgv_Message.Size = new System.Drawing.Size(485, 163);
            this.dgv_Message.TabIndex = 17;
            // 
            // txt_Name2
            // 
            this.txt_Name2.Location = new System.Drawing.Point(300, 74);
            this.txt_Name2.Name = "txt_Name2";
            this.txt_Name2.Size = new System.Drawing.Size(83, 21);
            this.txt_Name2.TabIndex = 15;
            // 
            // txt_Name1
            // 
            this.txt_Name1.Location = new System.Drawing.Point(162, 72);
            this.txt_Name1.Name = "txt_Name1";
            this.txt_Name1.Size = new System.Drawing.Size(83, 21);
            this.txt_Name1.TabIndex = 16;
            // 
            // cbox_Select
            // 
            this.cbox_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Select.FormattingEnabled = true;
            this.cbox_Select.Items.AddRange(new object[] {
            "ANY",
            "SOME",
            "ALL"});
            this.cbox_Select.Location = new System.Drawing.Point(162, 47);
            this.cbox_Select.Name = "cbox_Select";
            this.cbox_Select.Size = new System.Drawing.Size(83, 20);
            this.cbox_Select.TabIndex = 12;
            // 
            // cbox_Operator
            // 
            this.cbox_Operator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Operator.FormattingEnabled = true;
            this.cbox_Operator.Items.AddRange(new object[] {
            "<",
            ">"});
            this.cbox_Operator.Location = new System.Drawing.Point(300, 23);
            this.cbox_Operator.Name = "cbox_Operator";
            this.cbox_Operator.Size = new System.Drawing.Size(83, 20);
            this.cbox_Operator.TabIndex = 13;
            // 
            // cbox_Subject
            // 
            this.cbox_Subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Subject.FormattingEnabled = true;
            this.cbox_Subject.Items.AddRange(new object[] {
            "高数",
            "外语",
            "文化基础",
            "马经",
            "数据库管理",
            "数据结构",
            "软件工程"});
            this.cbox_Subject.Location = new System.Drawing.Point(162, 21);
            this.cbox_Subject.Name = "cbox_Subject";
            this.cbox_Subject.Size = new System.Drawing.Size(83, 20);
            this.cbox_Subject.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "条件选择：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "和";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "运算符：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "选择科目：";
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(390, 72);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(83, 23);
            this.btn_Select.TabIndex = 5;
            this.btn_Select.Text = "查询";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.txt_Name2);
            this.groupBox1.Controls.Add(this.txt_Name1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbox_Select);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbox_Operator);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbox_Subject);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 102);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询符合条件的学生信息";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 272);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_Message);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "嵌套查询在查询统计中的应用";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Message;
        private System.Windows.Forms.TextBox txt_Name2;
        private System.Windows.Forms.TextBox txt_Name1;
        private System.Windows.Forms.ComboBox cbox_Select;
        private System.Windows.Forms.ComboBox cbox_Operator;
        private System.Windows.Forms.ComboBox cbox_Subject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

