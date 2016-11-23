namespace RemoveSameNum
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
            this.lab_Array = new System.Windows.Forms.Label();
            this.lab_NArray = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_Array
            // 
            this.lab_Array.AutoSize = true;
            this.lab_Array.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Array.ForeColor = System.Drawing.Color.Red;
            this.lab_Array.Location = new System.Drawing.Point(12, 13);
            this.lab_Array.Name = "lab_Array";
            this.lab_Array.Size = new System.Drawing.Size(287, 14);
            this.lab_Array.TabIndex = 0;
            this.lab_Array.Text = "一维数组：38,98,368,98,698,2998,368,5998";
            // 
            // lab_NArray
            // 
            this.lab_NArray.AutoSize = true;
            this.lab_NArray.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_NArray.ForeColor = System.Drawing.Color.Red;
            this.lab_NArray.Location = new System.Drawing.Point(13, 38);
            this.lab_NArray.Name = "lab_NArray";
            this.lab_NArray.Size = new System.Drawing.Size(0, 14);
            this.lab_NArray.TabIndex = 1;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 77);
            this.Controls.Add(this.lab_NArray);
            this.Controls.Add(this.lab_Array);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用泛型去掉数组中的重复数字";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_Array;
        private System.Windows.Forms.Label lab_NArray;
    }
}

