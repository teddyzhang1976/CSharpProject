namespace InnerUnion
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
            this.btn_Select = new System.Windows.Forms.Button();
            this.dgv_InnerUnion = new System.Windows.Forms.DataGridView();
            this.dgv_Grade = new System.Windows.Forms.DataGridView();
            this.dgv_Student = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InnerUnion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Grade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(299, 20);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 11;
            this.btn_Select.Text = "查询";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // dgv_InnerUnion
            // 
            this.dgv_InnerUnion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_InnerUnion.Location = new System.Drawing.Point(6, 20);
            this.dgv_InnerUnion.Name = "dgv_InnerUnion";
            this.dgv_InnerUnion.RowTemplate.Height = 23;
            this.dgv_InnerUnion.Size = new System.Drawing.Size(659, 150);
            this.dgv_InnerUnion.TabIndex = 7;
            // 
            // dgv_Grade
            // 
            this.dgv_Grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Grade.Location = new System.Drawing.Point(5, 25);
            this.dgv_Grade.Name = "dgv_Grade";
            this.dgv_Grade.RowTemplate.Height = 23;
            this.dgv_Grade.Size = new System.Drawing.Size(272, 150);
            this.dgv_Grade.TabIndex = 6;
            // 
            // dgv_Student
            // 
            this.dgv_Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Student.Location = new System.Drawing.Point(6, 25);
            this.dgv_Student.Name = "dgv_Student";
            this.dgv_Student.RowTemplate.Height = 23;
            this.dgv_Student.Size = new System.Drawing.Size(375, 150);
            this.dgv_Student.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Student);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 181);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "学生信息表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_Grade);
            this.groupBox2.Location = new System.Drawing.Point(388, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 181);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "学生成绩表";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_InnerUnion);
            this.groupBox3.Location = new System.Drawing.Point(0, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(671, 175);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "内联接查询结果";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Select);
            this.groupBox4.Location = new System.Drawing.Point(0, 368);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(671, 55);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "内连接查询";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 424);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简单内连接查询";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InnerUnion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Grade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.DataGridView dgv_InnerUnion;
        private System.Windows.Forms.DataGridView dgv_Grade;
        private System.Windows.Forms.DataGridView dgv_Student;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

