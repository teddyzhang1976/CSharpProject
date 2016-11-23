namespace GetWeek
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
            this.btn_GetWeek = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_GetWeek
            // 
            this.btn_GetWeek.Location = new System.Drawing.Point(106, 44);
            this.btn_GetWeek.Name = "btn_GetWeek";
            this.btn_GetWeek.Size = new System.Drawing.Size(125, 23);
            this.btn_GetWeek.TabIndex = 0;
            this.btn_GetWeek.Text = "显示星期信息";
            this.btn_GetWeek.UseVisualStyleBackColor = true;
            this.btn_GetWeek.Click += new System.EventHandler(this.btn_GetWeek_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 105);
            this.Controls.Add(this.btn_GetWeek);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "获取当前日期是星期几";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GetWeek;
    }
}

