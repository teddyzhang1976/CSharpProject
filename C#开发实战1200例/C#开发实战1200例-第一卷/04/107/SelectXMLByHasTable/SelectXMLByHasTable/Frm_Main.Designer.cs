namespace SelectXMLByHasTable
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_Name = new System.Windows.Forms.ComboBox();
            this.cbox_NetAddress = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "电台名称：";
            // 
            // cbox_Name
            // 
            this.cbox_Name.FormattingEnabled = true;
            this.cbox_Name.Location = new System.Drawing.Point(89, 13);
            this.cbox_Name.Name = "cbox_Name";
            this.cbox_Name.Size = new System.Drawing.Size(178, 20);
            this.cbox_Name.TabIndex = 1;
            // 
            // cbox_NetAddress
            // 
            this.cbox_NetAddress.FormattingEnabled = true;
            this.cbox_NetAddress.Location = new System.Drawing.Point(89, 45);
            this.cbox_NetAddress.Name = "cbox_NetAddress";
            this.cbox_NetAddress.Size = new System.Drawing.Size(178, 20);
            this.cbox_NetAddress.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "电台网址：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 82);
            this.Controls.Add(this.cbox_NetAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbox_Name);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用哈希表对XML文件进行查询";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_Name;
        private System.Windows.Forms.ComboBox cbox_NetAddress;
        private System.Windows.Forms.Label label2;

    }
}

