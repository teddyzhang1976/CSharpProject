namespace BeautifulRichTextBox
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
            this.guageRichTextBox1 = new BeautifulRichTextBox.GuageRichTextBox();
            this.SuspendLayout();
            // 
            // guageRichTextBox1
            // 
            this.guageRichTextBox1.BackColor = System.Drawing.Color.Silver;
            this.guageRichTextBox1.CodeShow = true;
            this.guageRichTextBox1.Location = new System.Drawing.Point(12, 9);
            this.guageRichTextBox1.Name = "guageRichTextBox1";
            this.guageRichTextBox1.RulerStyle = BeautifulRichTextBox.GuageRichTextBox.Ruler.Graduation;
            this.guageRichTextBox1.Size = new System.Drawing.Size(336, 268);
            this.guageRichTextBox1.TabIndex = 0;
            this.guageRichTextBox1.UnitStyle = BeautifulRichTextBox.GuageRichTextBox.Unit.Cm;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 289);
            this.Controls.Add(this.guageRichTextBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设计带行数和标尺的RichTextBox控件";
            this.ResumeLayout(false);

        }

        #endregion

        private GuageRichTextBox guageRichTextBox1;


    }
}

