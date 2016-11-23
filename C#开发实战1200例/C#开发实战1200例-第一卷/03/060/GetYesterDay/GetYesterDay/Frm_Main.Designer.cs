namespace GetYesterDay
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
            this.btn_GetYesterday = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_GetYesterday
            // 
            this.btn_GetYesterday.Location = new System.Drawing.Point(93, 58);
            this.btn_GetYesterday.Name = "btn_GetYesterday";
            this.btn_GetYesterday.Size = new System.Drawing.Size(124, 23);
            this.btn_GetYesterday.TabIndex = 0;
            this.btn_GetYesterday.Text = "获取前一天时间";
            this.btn_GetYesterday.UseVisualStyleBackColor = true;
            this.btn_GetYesterday.Click += new System.EventHandler(this.btn_GetYesterday_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 133);
            this.Controls.Add(this.btn_GetYesterday);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取得当前日期的前一天";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GetYesterday;
    }
}

