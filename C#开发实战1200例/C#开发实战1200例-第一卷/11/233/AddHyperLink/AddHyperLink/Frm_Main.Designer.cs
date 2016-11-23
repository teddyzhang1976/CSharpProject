namespace AddHyperLink
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
            this.rtbox_HyperLink = new System.Windows.Forms.RichTextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbox_HyperLink
            // 
            this.rtbox_HyperLink.Location = new System.Drawing.Point(10, 12);
            this.rtbox_HyperLink.Name = "rtbox_HyperLink";
            this.rtbox_HyperLink.Size = new System.Drawing.Size(337, 231);
            this.rtbox_HyperLink.TabIndex = 0;
            this.rtbox_HyperLink.Text = "";
            this.rtbox_HyperLink.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbox_HyperLink_LinkClicked);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(129, 252);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(100, 23);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "添加文本内容";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 287);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.rtbox_HyperLink);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在RichTextBox控件中添加超链接文字";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbox_HyperLink;
        private System.Windows.Forms.Button btn_Add;
    }
}

