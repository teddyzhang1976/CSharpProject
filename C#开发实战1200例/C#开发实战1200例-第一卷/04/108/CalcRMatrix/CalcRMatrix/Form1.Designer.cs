namespace CalcRMatrix
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
            this.lab_First = new System.Windows.Forms.Label();
            this.lab_Second = new System.Windows.Forms.Label();
            this.lab_Result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_First
            // 
            this.lab_First.AutoSize = true;
            this.lab_First.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_First.ForeColor = System.Drawing.Color.Red;
            this.lab_First.Location = new System.Drawing.Point(14, 13);
            this.lab_First.Name = "lab_First";
            this.lab_First.Size = new System.Drawing.Size(0, 14);
            this.lab_First.TabIndex = 0;
            // 
            // lab_Second
            // 
            this.lab_Second.AutoSize = true;
            this.lab_Second.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Second.ForeColor = System.Drawing.Color.Red;
            this.lab_Second.Location = new System.Drawing.Point(213, 13);
            this.lab_Second.Name = "lab_Second";
            this.lab_Second.Size = new System.Drawing.Size(0, 14);
            this.lab_Second.TabIndex = 1;
            // 
            // lab_Result
            // 
            this.lab_Result.AutoSize = true;
            this.lab_Result.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Result.ForeColor = System.Drawing.Color.Red;
            this.lab_Result.Location = new System.Drawing.Point(111, 82);
            this.lab_Result.Name = "lab_Result";
            this.lab_Result.Size = new System.Drawing.Size(0, 14);
            this.lab_Result.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(186, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 154);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab_Result);
            this.Controls.Add(this.lab_Second);
            this.Controls.Add(this.lab_First);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算两个矩形矩阵的乘积";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_First;
        private System.Windows.Forms.Label lab_Second;
        private System.Windows.Forms.Label lab_Result;
        private System.Windows.Forms.Label label1;
    }
}

