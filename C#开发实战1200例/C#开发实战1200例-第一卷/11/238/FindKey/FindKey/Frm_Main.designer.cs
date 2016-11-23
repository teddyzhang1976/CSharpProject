namespace FindKey
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
            if(disposing && (components != null))
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
            this.unfold = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.plotRed = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.keyWord = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // unfold
            // 
            this.unfold.Location = new System.Drawing.Point(81, 50);
            this.unfold.Name = "unfold";
            this.unfold.Size = new System.Drawing.Size(157, 23);
            this.unfold.TabIndex = 3;
            this.unfold.Text = "打开文件";
            this.unfold.UseVisualStyleBackColor = true;
            this.unfold.Click += new System.EventHandler(this.unfold_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1, 1);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(308, 169);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // plotRed
            // 
            this.plotRed.Location = new System.Drawing.Point(244, 17);
            this.plotRed.Name = "plotRed";
            this.plotRed.Size = new System.Drawing.Size(45, 23);
            this.plotRed.TabIndex = 2;
            this.plotRed.Text = "描红";
            this.plotRed.UseVisualStyleBackColor = true;
            this.plotRed.Click += new System.EventHandler(this.plotRed_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "关键字：";
            // 
            // keyWord
            // 
            this.keyWord.Location = new System.Drawing.Point(81, 19);
            this.keyWord.Name = "keyWord";
            this.keyWord.Size = new System.Drawing.Size(157, 21);
            this.keyWord.TabIndex = 0;
            this.keyWord.TextChanged += new System.EventHandler(this.keyWord_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.unfold);
            this.groupBox1.Controls.Add(this.plotRed);
            this.groupBox1.Controls.Add(this.keyWord);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 82);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 259);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Frm_Main";
            this.Text = "在RichTextBox中实现关键字描红";
            this.Load += new System.EventHandler(this.KeyWordsPlotRed_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button plotRed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keyWord;
        private System.Windows.Forms.Button unfold;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

