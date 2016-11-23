namespace Transform
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_transform = new System.Windows.Forms.Button();
            this.txt_lower = new System.Windows.Forms.TextBox();
            this.txt_upper = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "小写金额：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "大写金额：";
            // 
            // btn_transform
            // 
            this.btn_transform.Location = new System.Drawing.Point(34, 67);
            this.btn_transform.Name = "btn_transform";
            this.btn_transform.Size = new System.Drawing.Size(63, 23);
            this.btn_transform.TabIndex = 2;
            this.btn_transform.Text = "转换";
            this.btn_transform.UseVisualStyleBackColor = true;
            this.btn_transform.Click += new System.EventHandler(this.btn_transform_Click);
            // 
            // txt_lower
            // 
            this.txt_lower.Location = new System.Drawing.Point(96, 31);
            this.txt_lower.Name = "txt_lower";
            this.txt_lower.Size = new System.Drawing.Size(275, 21);
            this.txt_lower.TabIndex = 3;
            // 
            // txt_upper
            // 
            this.txt_upper.Location = new System.Drawing.Point(97, 104);
            this.txt_upper.Name = "txt_upper";
            this.txt_upper.Size = new System.Drawing.Size(274, 21);
            this.txt_upper.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_upper);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_lower);
            this.groupBox1.Controls.Add(this.btn_transform);
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 148);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "金额转换";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 163);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品金额的大小写转换";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_transform;
        private System.Windows.Forms.TextBox txt_lower;
        private System.Windows.Forms.TextBox txt_upper;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

