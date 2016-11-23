namespace SortResult
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
            this.btn_Ascending = new System.Windows.Forms.Button();
            this.btn_Descending = new System.Windows.Forms.Button();
            this.dgv_Message = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Ascending
            // 
            this.btn_Ascending.Location = new System.Drawing.Point(101, 31);
            this.btn_Ascending.Name = "btn_Ascending";
            this.btn_Ascending.Size = new System.Drawing.Size(75, 23);
            this.btn_Ascending.TabIndex = 5;
            this.btn_Ascending.Text = "升序排序";
            this.btn_Ascending.UseVisualStyleBackColor = true;
            this.btn_Ascending.Click += new System.EventHandler(this.btn_Ascending_Click);
            // 
            // btn_Descending
            // 
            this.btn_Descending.Location = new System.Drawing.Point(249, 31);
            this.btn_Descending.Name = "btn_Descending";
            this.btn_Descending.Size = new System.Drawing.Size(75, 23);
            this.btn_Descending.TabIndex = 4;
            this.btn_Descending.Text = "降序排序";
            this.btn_Descending.UseVisualStyleBackColor = true;
            this.btn_Descending.Click += new System.EventHandler(this.btn_Descending_Click);
            // 
            // dgv_Message
            // 
            this.dgv_Message.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Message.Location = new System.Drawing.Point(0, 0);
            this.dgv_Message.Name = "dgv_Message";
            this.dgv_Message.RowTemplate.Height = 23;
            this.dgv_Message.Size = new System.Drawing.Size(417, 195);
            this.dgv_Message.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Descending);
            this.groupBox1.Controls.Add(this.btn_Ascending);
            this.groupBox1.Location = new System.Drawing.Point(0, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 75);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 273);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_Message);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "对组合查询后的结果进行排序";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Ascending;
        private System.Windows.Forms.Button btn_Descending;
        private System.Windows.Forms.DataGridView dgv_Message;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

