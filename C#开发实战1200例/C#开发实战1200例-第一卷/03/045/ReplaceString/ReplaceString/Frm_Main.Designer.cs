namespace ReplaceString
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
            this.btn_replace = new System.Windows.Forms.Button();
            this.txt_str = new System.Windows.Forms.TextBox();
            this.txt_find = new System.Windows.Forms.TextBox();
            this.txt_replace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_replace
            // 
            this.btn_replace.Location = new System.Drawing.Point(226, 239);
            this.btn_replace.Name = "btn_replace";
            this.btn_replace.Size = new System.Drawing.Size(75, 23);
            this.btn_replace.TabIndex = 0;
            this.btn_replace.Text = "替换";
            this.btn_replace.UseVisualStyleBackColor = true;
            this.btn_replace.Click += new System.EventHandler(this.btn_replace_Click);
            // 
            // txt_str
            // 
            this.txt_str.Location = new System.Drawing.Point(0, 2);
            this.txt_str.Multiline = true;
            this.txt_str.Name = "txt_str";
            this.txt_str.Size = new System.Drawing.Size(315, 202);
            this.txt_str.TabIndex = 1;
            // 
            // txt_find
            // 
            this.txt_find.Location = new System.Drawing.Point(107, 212);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(100, 21);
            this.txt_find.TabIndex = 2;
            // 
            // txt_replace
            // 
            this.txt_replace.Location = new System.Drawing.Point(107, 239);
            this.txt_replace.Name = "txt_replace";
            this.txt_replace.Size = new System.Drawing.Size(100, 21);
            this.txt_replace.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "查找字符串：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "替换字符串：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 271);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_replace);
            this.Controls.Add(this.txt_find);
            this.Controls.Add(this.txt_str);
            this.Controls.Add(this.btn_replace);
            this.Name = "Frm_Main";
            this.Text = "批量替换某一类字符串";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_replace;
        private System.Windows.Forms.TextBox txt_str;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.TextBox txt_replace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

