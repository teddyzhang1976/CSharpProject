namespace InsertImage
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
            this.rtbox_Display = new System.Windows.Forms.RichTextBox();
            this.btn_InsertImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbox_Display
            // 
            this.rtbox_Display.Location = new System.Drawing.Point(0, 0);
            this.rtbox_Display.Name = "rtbox_Display";
            this.rtbox_Display.Size = new System.Drawing.Size(498, 349);
            this.rtbox_Display.TabIndex = 0;
            this.rtbox_Display.Text = "";
            // 
            // btn_InsertImage
            // 
            this.btn_InsertImage.Location = new System.Drawing.Point(208, 357);
            this.btn_InsertImage.Name = "btn_InsertImage";
            this.btn_InsertImage.Size = new System.Drawing.Size(75, 23);
            this.btn_InsertImage.TabIndex = 1;
            this.btn_InsertImage.Text = "插入图片";
            this.btn_InsertImage.UseVisualStyleBackColor = true;
            this.btn_InsertImage.Click += new System.EventHandler(this.btn_InsertImage_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 385);
            this.Controls.Add(this.btn_InsertImage);
            this.Controls.Add(this.rtbox_Display);
            this.Name = "Frm_Main";
            this.Text = "在RichTextBox控件插入图片";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbox_Display;
        private System.Windows.Forms.Button btn_InsertImage;
    }
}

