namespace BeautifulRadioButton
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.glorifyRadioButton1 = new BeautifulRadioButton.GlorifyRadioButton();
            this.glorifyRadioButton2 = new BeautifulRadioButton.GlorifyRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(58, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 16);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "单选按钮3";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.glorifyRadioButton1);
            this.groupBox1.Controls.Add(this.glorifyRadioButton2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 58);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自定义单选按钮";
            // 
            // glorifyRadioButton1
            // 
            this.glorifyRadioButton1.AutoSize = true;
            this.glorifyRadioButton1.CentralColor = System.Drawing.Color.CornflowerBlue;
            this.glorifyRadioButton1.Location = new System.Drawing.Point(24, 27);
            this.glorifyRadioButton1.Name = "glorifyRadioButton1";
            this.glorifyRadioButton1.NoCentralColor = System.Drawing.Color.PowderBlue;
            this.glorifyRadioButton1.NoStippleColor = System.Drawing.Color.Azure;
            this.glorifyRadioButton1.PeripheryColor = System.Drawing.Color.DarkBlue;
            this.glorifyRadioButton1.Size = new System.Drawing.Size(77, 16);
            this.glorifyRadioButton1.StippleColor = System.Drawing.Color.DarkBlue;
            this.glorifyRadioButton1.TabIndex = 10;
            this.glorifyRadioButton1.TabStop = true;
            this.glorifyRadioButton1.Text = "单选按钮1";
            this.glorifyRadioButton1.UseVisualStyleBackColor = true;
            // 
            // glorifyRadioButton2
            // 
            this.glorifyRadioButton2.AutoSize = true;
            this.glorifyRadioButton2.CentralColor = System.Drawing.Color.Orchid;
            this.glorifyRadioButton2.Location = new System.Drawing.Point(120, 27);
            this.glorifyRadioButton2.Name = "glorifyRadioButton2";
            this.glorifyRadioButton2.NoCentralColor = System.Drawing.Color.Thistle;
            this.glorifyRadioButton2.NoStippleColor = System.Drawing.Color.Azure;
            this.glorifyRadioButton2.PeripheryColor = System.Drawing.Color.Indigo;
            this.glorifyRadioButton2.Size = new System.Drawing.Size(77, 16);
            this.glorifyRadioButton2.StippleColor = System.Drawing.Color.Indigo;
            this.glorifyRadioButton2.TabIndex = 11;
            this.glorifyRadioButton2.TabStop = true;
            this.glorifyRadioButton2.Text = "单选按钮2";
            this.glorifyRadioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 59);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "C#自带的单选按钮";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 139);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "美化单选按钮控件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private BeautifulRadioButton.GlorifyRadioButton glorifyRadioButton2;
        private BeautifulRadioButton.GlorifyRadioButton glorifyRadioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

