namespace WhichWay
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
            this.btn_go = new System.Windows.Forms.Button();
            this.rbtn_school = new System.Windows.Forms.RadioButton();
            this.rbtn_hospital = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(117, 50);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(75, 23);
            this.btn_go.TabIndex = 0;
            this.btn_go.Text = "出发";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // rbtn_school
            // 
            this.rbtn_school.AutoSize = true;
            this.rbtn_school.Checked = true;
            this.rbtn_school.Location = new System.Drawing.Point(56, 26);
            this.rbtn_school.Name = "rbtn_school";
            this.rbtn_school.Size = new System.Drawing.Size(59, 16);
            this.rbtn_school.TabIndex = 1;
            this.rbtn_school.TabStop = true;
            this.rbtn_school.Text = "去学校";
            this.rbtn_school.UseVisualStyleBackColor = true;
            // 
            // rbtn_hospital
            // 
            this.rbtn_hospital.AutoSize = true;
            this.rbtn_hospital.Location = new System.Drawing.Point(195, 26);
            this.rbtn_hospital.Name = "rbtn_hospital";
            this.rbtn_hospital.Size = new System.Drawing.Size(59, 16);
            this.rbtn_hospital.TabIndex = 2;
            this.rbtn_hospital.TabStop = true;
            this.rbtn_hospital.Text = "去医院";
            this.rbtn_hospital.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 83);
            this.Controls.Add(this.rbtn_hospital);
            this.Controls.Add(this.rbtn_school);
            this.Controls.Add(this.btn_go);
            this.Name = "Form1";
            this.Text = "小明去学校和医院分别要走哪条路";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.RadioButton rbtn_school;
        private System.Windows.Forms.RadioButton rbtn_hospital;
    }
}

