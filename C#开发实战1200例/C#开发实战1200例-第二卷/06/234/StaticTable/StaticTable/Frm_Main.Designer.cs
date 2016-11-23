namespace StaticTable
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
            this.btn_Department = new System.Windows.Forms.Button();
            this.btn_Name = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Message
            // 
            this.dgv_Message.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Message.Location = new System.Drawing.Point(0, 36);
            this.dgv_Message.Name = "dgv_Message";
            this.dgv_Message.RowTemplate.Height = 23;
            this.dgv_Message.Size = new System.Drawing.Size(391, 145);
            this.dgv_Message.TabIndex = 6;
            // 
            // btn_Department
            // 
            this.btn_Department.Location = new System.Drawing.Point(277, 187);
            this.btn_Department.Name = "btn_Department";
            this.btn_Department.Size = new System.Drawing.Size(105, 23);
            this.btn_Department.TabIndex = 5;
            this.btn_Department.Text = "按部门分析";
            this.btn_Department.UseVisualStyleBackColor = true;
            this.btn_Department.Click += new System.EventHandler(this.btn_Department_Click);
            // 
            // btn_Name
            // 
            this.btn_Name.Location = new System.Drawing.Point(164, 187);
            this.btn_Name.Name = "btn_Name";
            this.btn_Name.Size = new System.Drawing.Size(107, 23);
            this.btn_Name.TabIndex = 4;
            this.btn_Name.Text = "按员工姓名分析";
            this.btn_Name.UseVisualStyleBackColor = true;
            this.btn_Name.Click += new System.EventHandler(this.btn_Name_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(128, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "销售业绩分析";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 215);
            this.Controls.Add(this.dgv_Message);
            this.Controls.Add(this.btn_Department);
            this.Controls.Add(this.btn_Name);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "静态交叉表（SQLServer2005）";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Message;
        private System.Windows.Forms.Button btn_Department;
        private System.Windows.Forms.Button btn_Name;
        private System.Windows.Forms.Label label1;
    }
}

