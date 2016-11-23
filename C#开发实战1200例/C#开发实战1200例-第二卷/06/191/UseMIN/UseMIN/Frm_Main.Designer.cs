namespace UseMIN
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
            this.rbtn_Profit = new System.Windows.Forms.RadioButton();
            this.rbtn_Money = new System.Windows.Forms.RadioButton();
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
            this.dgv_Message.Size = new System.Drawing.Size(399, 178);
            this.dgv_Message.TabIndex = 4;
            // 
            // rbtn_Profit
            // 
            this.rbtn_Profit.AutoSize = true;
            this.rbtn_Profit.Location = new System.Drawing.Point(124, 47);
            this.rbtn_Profit.Name = "rbtn_Profit";
            this.rbtn_Profit.Size = new System.Drawing.Size(155, 16);
            this.rbtn_Profit.TabIndex = 3;
            this.rbtn_Profit.Text = "查询利润最少的商品信息";
            this.rbtn_Profit.UseVisualStyleBackColor = true;
            this.rbtn_Profit.CheckedChanged += new System.EventHandler(this.rbtn_Profit_CheckedChanged);
            // 
            // rbtn_Money
            // 
            this.rbtn_Money.AutoSize = true;
            this.rbtn_Money.Location = new System.Drawing.Point(124, 20);
            this.rbtn_Money.Name = "rbtn_Money";
            this.rbtn_Money.Size = new System.Drawing.Size(167, 16);
            this.rbtn_Money.TabIndex = 2;
            this.rbtn_Money.Text = "查询销售额最少的商品信息";
            this.rbtn_Money.UseVisualStyleBackColor = true;
            this.rbtn_Money.CheckedChanged += new System.EventHandler(this.rbtn_Money_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn_Money);
            this.groupBox1.Controls.Add(this.rbtn_Profit);
            this.groupBox1.Location = new System.Drawing.Point(0, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 73);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 255);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_Message);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "利用聚合函数MIN求销售额、利润最少的商品";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Message;
        private System.Windows.Forms.RadioButton rbtn_Profit;
        private System.Windows.Forms.RadioButton rbtn_Money;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

