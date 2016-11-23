namespace CombineSelect
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
            this.dgv_Combine = new System.Windows.Forms.DataGridView();
            this.dgv_Grade = new System.Windows.Forms.DataGridView();
            this.dgv_Student = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Combine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Grade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(283, 31);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 7;
            this.btn_Select.Text = "查　询";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // dgv_Combine
            // 
            this.dgv_Combine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Combine.Location = new System.Drawing.Point(0, 307);
            this.dgv_Combine.Name = "dgv_Combine";
            this.dgv_Combine.RowTemplate.Height = 23;
            this.dgv_Combine.Size = new System.Drawing.Size(637, 150);
            this.dgv_Combine.TabIndex = 6;
            // 
            // dgv_Grade
            // 
            this.dgv_Grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Grade.Location = new System.Drawing.Point(0, 153);
            this.dgv_Grade.Name = "dgv_Grade";
            this.dgv_Grade.RowTemplate.Height = 23;
            this.dgv_Grade.Size = new System.Drawing.Size(637, 150);
            this.dgv_Grade.TabIndex = 5;
            // 
            // dgv_Student
            // 
            this.dgv_Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Student.Location = new System.Drawing.Point(0, 0);
            this.dgv_Student.Name = "dgv_Student";
            this.dgv_Student.RowTemplate.Height = 23;
            this.dgv_Student.Size = new System.Drawing.Size(637, 150);
            this.dgv_Student.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Location = new System.Drawing.Point(0, 461);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 69);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    通过union语句，查询成绩表中总成绩大于600的学生与学生表中所在学院为理学院的学生的信息";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 531);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_Combine);
            this.Controls.Add(this.dgv_Grade);
            this.Controls.Add(this.dgv_Student);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用组合查询";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Combine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Grade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.DataGridView dgv_Combine;
        private System.Windows.Forms.DataGridView dgv_Grade;
        private System.Windows.Forms.DataGridView dgv_Student;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

