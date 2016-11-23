namespace SnatchDisplayDeviceRefresh
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
            if(disposing && (components != null))
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nowRefresh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.snatch = new System.Windows.Forms.Button();
            this.minRefresh = new System.Windows.Forms.TextBox();
            this.maxRefresh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nowRefresh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.snatch);
            this.groupBox1.Controls.Add(this.minRefresh);
            this.groupBox1.Controls.Add(this.maxRefresh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作类型";
            // 
            // nowRefresh
            // 
            this.nowRefresh.Location = new System.Drawing.Point(112, 80);
            this.nowRefresh.Name = "nowRefresh";
            this.nowRefresh.ReadOnly = true;
            this.nowRefresh.Size = new System.Drawing.Size(161, 21);
            this.nowRefresh.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "设备当前刷新率 ：";
            // 
            // snatch
            // 
            this.snatch.Location = new System.Drawing.Point(221, 107);
            this.snatch.Name = "snatch";
            this.snatch.Size = new System.Drawing.Size(52, 23);
            this.snatch.TabIndex = 2;
            this.snatch.Text = "获取";
            this.snatch.UseVisualStyleBackColor = true;
            this.snatch.Click += new System.EventHandler(this.snatch_Click);
            // 
            // minRefresh
            // 
            this.minRefresh.Location = new System.Drawing.Point(112, 52);
            this.minRefresh.Name = "minRefresh";
            this.minRefresh.ReadOnly = true;
            this.minRefresh.Size = new System.Drawing.Size(161, 21);
            this.minRefresh.TabIndex = 1;
            // 
            // maxRefresh
            // 
            this.maxRefresh.Location = new System.Drawing.Point(112, 23);
            this.maxRefresh.Name = "maxRefresh";
            this.maxRefresh.ReadOnly = true;
            this.maxRefresh.Size = new System.Drawing.Size(161, 21);
            this.maxRefresh.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "最 小 刷 新 率 ：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "最 大 刷 新 率 ：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 154);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "获取显示设备的最大、最小及当前刷新率";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox minRefresh;
        private System.Windows.Forms.TextBox maxRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button snatch;
        private System.Windows.Forms.TextBox nowRefresh;
        private System.Windows.Forms.Label label3;
    }
}

