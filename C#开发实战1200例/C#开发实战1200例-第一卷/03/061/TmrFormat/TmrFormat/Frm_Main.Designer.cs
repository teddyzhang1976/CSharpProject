namespace TmrFormat
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
            this.btn_GetTime = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_time = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_GetTime
            // 
            this.btn_GetTime.Location = new System.Drawing.Point(109, 16);
            this.btn_GetTime.Name = "btn_GetTime";
            this.btn_GetTime.Size = new System.Drawing.Size(86, 23);
            this.btn_GetTime.TabIndex = 0;
            this.btn_GetTime.Text = "获取系统时间";
            this.btn_GetTime.UseVisualStyleBackColor = true;
            this.btn_GetTime.Click += new System.EventHandler(this.btn_GetTime_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_time);
            this.groupBox1.Controls.Add(this.btn_GetTime);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 161);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "显示系统时间";
            // 
            // lab_time
            // 
            this.lab_time.AutoSize = true;
            this.lab_time.Location = new System.Drawing.Point(27, 41);
            this.lab_time.Name = "lab_time";
            this.lab_time.Size = new System.Drawing.Size(0, 12);
            this.lab_time.TabIndex = 1;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 181);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.Text = "将日期格式化为指定格式";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GetTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lab_time;
    }
}

