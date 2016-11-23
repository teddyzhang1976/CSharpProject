namespace ChineseToABC
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
            this.txt_Chinese = new System.Windows.Forms.TextBox();
            this.txt_PinYIn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Chinese
            // 
            this.txt_Chinese.Location = new System.Drawing.Point(12, 18);
            this.txt_Chinese.Name = "txt_Chinese";
            this.txt_Chinese.Size = new System.Drawing.Size(310, 21);
            this.txt_Chinese.TabIndex = 0;
            this.txt_Chinese.TextChanged += new System.EventHandler(this.txt_Chinese_TextChanged);
            // 
            // txt_PinYIn
            // 
            this.txt_PinYIn.Location = new System.Drawing.Point(12, 55);
            this.txt_PinYIn.Name = "txt_PinYIn";
            this.txt_PinYIn.ReadOnly = true;
            this.txt_PinYIn.Size = new System.Drawing.Size(310, 21);
            this.txt_PinYIn.TabIndex = 1;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 91);
            this.Controls.Add(this.txt_PinYIn);
            this.Controls.Add(this.txt_Chinese);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "将汉字转换为拼音";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Chinese;
        private System.Windows.Forms.TextBox txt_PinYIn;
    }
}

