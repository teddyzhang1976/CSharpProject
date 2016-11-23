namespace BeautifulCheckBox
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.glorifyCheckBox1 = new BeautifulCheckBox.GlorifyCheckBox();
            this.glorifyCheckBox2 = new BeautifulCheckBox.GlorifyCheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(61, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "复选按钮3";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.glorifyCheckBox1);
            this.groupBox1.Controls.Add(this.glorifyCheckBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 61);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自定义复选按钮";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 52);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "C#自带的复选按钮";
            // 
            // glorifyCheckBox1
            // 
            this.glorifyCheckBox1.AutoSize = true;
            this.glorifyCheckBox1.CentralColor = System.Drawing.Color.CornflowerBlue;
            this.glorifyCheckBox1.Location = new System.Drawing.Point(28, 30);
            this.glorifyCheckBox1.Name = "glorifyCheckBox1";
            this.glorifyCheckBox1.NoCentralColor = System.Drawing.Color.PowderBlue;
            this.glorifyCheckBox1.PeripheryColor = System.Drawing.Color.DarkBlue;
            this.glorifyCheckBox1.Size = new System.Drawing.Size(78, 16);
            this.glorifyCheckBox1.StippleColor = System.Drawing.Color.DarkBlue;
            this.glorifyCheckBox1.TabIndex = 12;
            this.glorifyCheckBox1.Text = "复选按钮1";
            this.glorifyCheckBox1.UseVisualStyleBackColor = true;
            // 
            // glorifyCheckBox2
            // 
            this.glorifyCheckBox2.AutoSize = true;
            this.glorifyCheckBox2.CentralColor = System.Drawing.Color.DarkGoldenrod;
            this.glorifyCheckBox2.Location = new System.Drawing.Point(115, 30);
            this.glorifyCheckBox2.Name = "glorifyCheckBox2";
            this.glorifyCheckBox2.NoCentralColor = System.Drawing.Color.Khaki;
            this.glorifyCheckBox2.PeripheryColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.glorifyCheckBox2.Size = new System.Drawing.Size(78, 16);
            this.glorifyCheckBox2.StippleColor = System.Drawing.Color.Green;
            this.glorifyCheckBox2.TabIndex = 13;
            this.glorifyCheckBox2.Text = "复选按钮2";
            this.glorifyCheckBox2.UseVisualStyleBackColor = true;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 141);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "美化复选框控件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private BeautifulCheckBox.GlorifyCheckBox glorifyCheckBox2;
        private BeautifulCheckBox.GlorifyCheckBox glorifyCheckBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

