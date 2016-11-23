namespace SQLDelete
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
            this.txt_Execute = new System.Windows.Forms.Button();
            this.txt_SQL = new System.Windows.Forms.TextBox();
            this.dgv_Message = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Execute
            // 
            this.txt_Execute.Location = new System.Drawing.Point(103, 99);
            this.txt_Execute.Name = "txt_Execute";
            this.txt_Execute.Size = new System.Drawing.Size(95, 23);
            this.txt_Execute.TabIndex = 13;
            this.txt_Execute.Text = "执行";
            this.txt_Execute.UseVisualStyleBackColor = true;
            this.txt_Execute.Click += new System.EventHandler(this.txt_Execute_Click);
            // 
            // txt_SQL
            // 
            this.txt_SQL.Location = new System.Drawing.Point(6, 20);
            this.txt_SQL.Multiline = true;
            this.txt_SQL.Name = "txt_SQL";
            this.txt_SQL.Size = new System.Drawing.Size(283, 73);
            this.txt_SQL.TabIndex = 12;
            this.txt_SQL.Text = "DELETE FROM 员工表 WHERE 员工编号 = \'1008\'";
            // 
            // dgv_Message
            // 
            this.dgv_Message.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Message.Location = new System.Drawing.Point(0, 0);
            this.dgv_Message.Name = "dgv_Message";
            this.dgv_Message.RowTemplate.Height = 23;
            this.dgv_Message.Size = new System.Drawing.Size(295, 123);
            this.dgv_Message.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_SQL);
            this.groupBox1.Controls.Add(this.txt_Execute);
            this.groupBox1.Location = new System.Drawing.Point(0, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 127);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "在文本框中输入有效的SQL语句修改数据";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 258);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_Message);
            this.Name = "Frm_Main";
            this.Text = "删除表格中指定的记录";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button txt_Execute;
        private System.Windows.Forms.TextBox txt_SQL;
        private System.Windows.Forms.DataGridView dgv_Message;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

