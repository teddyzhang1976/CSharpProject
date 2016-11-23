namespace UseCOMPUTEBY
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Message = new System.Windows.Forms.DataGridView();
            this.txt_Pay3 = new System.Windows.Forms.TextBox();
            this.txt_Pay2 = new System.Windows.Forms.TextBox();
            this.txt_Pay1 = new System.Windows.Forms.TextBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "文档部门工资统计：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "设计部门工资统计：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "ASP部门工资统计：";
            // 
            // dgv_Message
            // 
            this.dgv_Message.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Message.Location = new System.Drawing.Point(0, 0);
            this.dgv_Message.Name = "dgv_Message";
            this.dgv_Message.RowTemplate.Height = 23;
            this.dgv_Message.Size = new System.Drawing.Size(441, 149);
            this.dgv_Message.TabIndex = 8;
            // 
            // txt_Pay3
            // 
            this.txt_Pay3.Location = new System.Drawing.Point(184, 68);
            this.txt_Pay3.Name = "txt_Pay3";
            this.txt_Pay3.Size = new System.Drawing.Size(100, 21);
            this.txt_Pay3.TabIndex = 5;
            // 
            // txt_Pay2
            // 
            this.txt_Pay2.Location = new System.Drawing.Point(184, 45);
            this.txt_Pay2.Name = "txt_Pay2";
            this.txt_Pay2.Size = new System.Drawing.Size(100, 21);
            this.txt_Pay2.TabIndex = 6;
            // 
            // txt_Pay1
            // 
            this.txt_Pay1.Location = new System.Drawing.Point(184, 22);
            this.txt_Pay1.Name = "txt_Pay1";
            this.txt_Pay1.Size = new System.Drawing.Size(100, 21);
            this.txt_Pay1.TabIndex = 7;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(307, 62);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 4;
            this.btn_Select.Text = "查询";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Pay1);
            this.groupBox1.Controls.Add(this.txt_Pay2);
            this.groupBox1.Controls.Add(this.txt_Pay3);
            this.groupBox1.Location = new System.Drawing.Point(0, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计各部门总工资";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 251);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_Message);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用COMPUTE BY";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Message;
        private System.Windows.Forms.TextBox txt_Pay3;
        private System.Windows.Forms.TextBox txt_Pay2;
        private System.Windows.Forms.TextBox txt_Pay1;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

