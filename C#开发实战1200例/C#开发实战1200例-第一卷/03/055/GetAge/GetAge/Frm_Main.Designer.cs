namespace GetAge
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
            this.btn_GetAge = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpicker_BirthDay = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_GetAge
            // 
            this.btn_GetAge.Location = new System.Drawing.Point(135, 91);
            this.btn_GetAge.Name = "btn_GetAge";
            this.btn_GetAge.Size = new System.Drawing.Size(75, 23);
            this.btn_GetAge.TabIndex = 0;
            this.btn_GetAge.Text = "计算年龄";
            this.btn_GetAge.UseVisualStyleBackColor = true;
            this.btn_GetAge.Click += new System.EventHandler(this.btn_GetAge_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpicker_BirthDay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 83);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生日：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "请选择出生年月日：";
            // 
            // dtpicker_BirthDay
            // 
            this.dtpicker_BirthDay.Location = new System.Drawing.Point(116, 35);
            this.dtpicker_BirthDay.Name = "dtpicker_BirthDay";
            this.dtpicker_BirthDay.Size = new System.Drawing.Size(200, 21);
            this.dtpicker_BirthDay.TabIndex = 5;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 118);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_GetAge);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "根据生日自动计算员工年龄";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GetAge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpicker_BirthDay;
        private System.Windows.Forms.Label label1;
    }
}

