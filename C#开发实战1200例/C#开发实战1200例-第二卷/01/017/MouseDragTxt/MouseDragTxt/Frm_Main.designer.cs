namespace MouseDragTxt
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
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.lab1 = new System.Windows.Forms.Label();
            this.lab2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(88, 18);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(180, 21);
            this.txt1.TabIndex = 0;
            this.txt1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txt1_MouseMove);
            // 
            // txt2
            // 
            this.txt2.AllowDrop = true;
            this.txt2.Location = new System.Drawing.Point(88, 53);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(180, 21);
            this.txt2.TabIndex = 1;
            this.txt2.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt2_DragDrop);
            this.txt2.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt2_DragEnter);
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Location = new System.Drawing.Point(24, 21);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(59, 12);
            this.lab1.TabIndex = 2;
            this.lab1.Text = " 数据源：";
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.Location = new System.Drawing.Point(30, 56);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(53, 12);
            this.lab2.TabIndex = 3;
            this.lab2.Text = "拖放到：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 90);
            this.Controls.Add(this.lab2);
            this.Controls.Add(this.lab1);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用鼠标拖放复制文本";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.Label lab2;
    }
}

