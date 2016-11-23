namespace SelectColor
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
            this.cbox_select = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbox_select
            // 
            this.cbox_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_select.FormattingEnabled = true;
            this.cbox_select.Items.AddRange(new object[] {
            "红",
            "绿",
            "蓝"});
            this.cbox_select.Location = new System.Drawing.Point(144, 33);
            this.cbox_select.Name = "cbox_select";
            this.cbox_select.Size = new System.Drawing.Size(121, 20);
            this.cbox_select.TabIndex = 0;
            this.cbox_select.SelectedIndexChanged += new System.EventHandler(this.cbox_select_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择窗体颜色：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 87);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbox_select);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用switch语句更改窗体颜色";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_select;
        private System.Windows.Forms.Label label1;
    }
}

