namespace GetInterval
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_First = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Second = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Result = new System.Windows.Forms.Button();
            this.lab_first = new System.Windows.Forms.Label();
            this.lab_second = new System.Windows.Forms.Label();
            this.lab_result = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_first);
            this.groupBox1.Controls.Add(this.btn_First);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "第一次获取时间";
            // 
            // btn_First
            // 
            this.btn_First.Location = new System.Drawing.Point(99, 20);
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(123, 23);
            this.btn_First.TabIndex = 1;
            this.btn_First.Text = "第一次获取系统时间";
            this.btn_First.UseVisualStyleBackColor = true;
            this.btn_First.Click += new System.EventHandler(this.btn_First_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lab_second);
            this.groupBox2.Controls.Add(this.btn_Second);
            this.groupBox2.Location = new System.Drawing.Point(13, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 75);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "第二次获取时间";
            // 
            // btn_Second
            // 
            this.btn_Second.Location = new System.Drawing.Point(99, 20);
            this.btn_Second.Name = "btn_Second";
            this.btn_Second.Size = new System.Drawing.Size(123, 23);
            this.btn_Second.TabIndex = 1;
            this.btn_Second.Text = "第二次获取系统时间";
            this.btn_Second.UseVisualStyleBackColor = true;
            this.btn_Second.Click += new System.EventHandler(this.btn_Second_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lab_result);
            this.groupBox3.Controls.Add(this.btn_Result);
            this.groupBox3.Location = new System.Drawing.Point(13, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 75);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "计算时间间隔";
            // 
            // btn_Result
            // 
            this.btn_Result.Location = new System.Drawing.Point(99, 20);
            this.btn_Result.Name = "btn_Result";
            this.btn_Result.Size = new System.Drawing.Size(123, 23);
            this.btn_Result.TabIndex = 1;
            this.btn_Result.Text = "计算时间间隔";
            this.btn_Result.UseVisualStyleBackColor = true;
            this.btn_Result.Click += new System.EventHandler(this.btn_Result_Click);
            // 
            // lab_first
            // 
            this.lab_first.AutoSize = true;
            this.lab_first.Location = new System.Drawing.Point(26, 51);
            this.lab_first.Name = "lab_first";
            this.lab_first.Size = new System.Drawing.Size(0, 12);
            this.lab_first.TabIndex = 2;
            // 
            // lab_second
            // 
            this.lab_second.AutoSize = true;
            this.lab_second.Location = new System.Drawing.Point(26, 51);
            this.lab_second.Name = "lab_second";
            this.lab_second.Size = new System.Drawing.Size(0, 12);
            this.lab_second.TabIndex = 3;
            // 
            // lab_result
            // 
            this.lab_result.AutoSize = true;
            this.lab_result.Location = new System.Drawing.Point(71, 51);
            this.lab_result.Name = "lab_result";
            this.lab_result.Size = new System.Drawing.Size(0, 12);
            this.lab_result.TabIndex = 3;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 249);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用TimeSpan对象获取时间间隔";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_First;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Second;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Result;
        private System.Windows.Forms.Label lab_first;
        private System.Windows.Forms.Label lab_second;
        private System.Windows.Forms.Label lab_result;
    }
}

