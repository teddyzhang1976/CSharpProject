namespace BeautifulListBox
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
            this.drawListBox1 = new BeautifulListBox.DrawListBox();
            this.SuspendLayout();
            // 
            // drawListBox1
            // 
            this.drawListBox1.Color1 = System.Drawing.Color.CornflowerBlue;
            this.drawListBox1.Color1Gradual = System.Drawing.Color.Thistle;
            this.drawListBox1.Color2 = System.Drawing.Color.PaleGreen;
            this.drawListBox1.Color2Gradual = System.Drawing.Color.DarkKhaki;
            this.drawListBox1.ColorSelect = System.Drawing.Color.Gainsboro;
            this.drawListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.drawListBox1.FormattingEnabled = true;
            this.drawListBox1.GradualC = true;
            this.drawListBox1.Items.AddRange(new object[] {
            "明日科技",
            "C#编程词典（体验版）",
            "C#编程词典（学习版）",
            "C#编程词典（全能版）",
            "C#编程词典（标准版）",
            "C#编程词典（珍藏版）",
            "C#编程词典（企业版）",
            "C#编程词典（钻石版）"});
            this.drawListBox1.Location = new System.Drawing.Point(12, 9);
            this.drawListBox1.Name = "drawListBox1";
            this.drawListBox1.Size = new System.Drawing.Size(305, 108);
            this.drawListBox1.TabIndex = 0;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 125);
            this.Controls.Add(this.drawListBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重绘ListBox控件";
            this.ResumeLayout(false);

        }

        #endregion

        private DrawListBox drawListBox1;




    }
}

