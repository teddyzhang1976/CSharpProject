namespace IfThenElse
{
    partial class Form1
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
            this.rbtn_false = new System.Windows.Forms.RadioButton();
            this.rbtn_true = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtn_false
            // 
            this.rbtn_false.AutoSize = true;
            this.rbtn_false.Checked = true;
            this.rbtn_false.Location = new System.Drawing.Point(175, 28);
            this.rbtn_false.Name = "rbtn_false";
            this.rbtn_false.Size = new System.Drawing.Size(35, 16);
            this.rbtn_false.TabIndex = 7;
            this.rbtn_false.TabStop = true;
            this.rbtn_false.Text = "否";
            this.rbtn_false.UseVisualStyleBackColor = true;
            // 
            // rbtn_true
            // 
            this.rbtn_true.AutoSize = true;
            this.rbtn_true.Location = new System.Drawing.Point(135, 27);
            this.rbtn_true.Name = "rbtn_true";
            this.rbtn_true.Size = new System.Drawing.Size(35, 16);
            this.rbtn_true.TabIndex = 6;
            this.rbtn_true.Text = "是";
            this.rbtn_true.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "是否是业务花销：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(77, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "报销";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 90);
            this.Controls.Add(this.rbtn_false);
            this.Controls.Add(this.rbtn_true);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "报销业务花销";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn_false;
        private System.Windows.Forms.RadioButton rbtn_true;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

