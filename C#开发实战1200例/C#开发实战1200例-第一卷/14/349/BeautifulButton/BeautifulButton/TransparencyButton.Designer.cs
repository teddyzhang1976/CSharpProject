namespace BeautifulButton
{
    partial class TransparencyButton
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// Devildom-bat
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TransparencyButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "TransparencyButton";
            this.Size = new System.Drawing.Size(53, 25);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TransparencyButton_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TransparencyButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TransparencyButton_MouseUp);
            this.SizeChanged += new System.EventHandler(this.TransparencyButton_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
