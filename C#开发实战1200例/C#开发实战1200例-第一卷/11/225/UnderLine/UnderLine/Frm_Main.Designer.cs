namespace UnderLine
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
            this.btn_DisplayUnderLine = new System.Windows.Forms.Button();
            this.txt_Str = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_DisplayUnderLine
            // 
            this.btn_DisplayUnderLine.Location = new System.Drawing.Point(116, 140);
            this.btn_DisplayUnderLine.Name = "btn_DisplayUnderLine";
            this.btn_DisplayUnderLine.Size = new System.Drawing.Size(75, 23);
            this.btn_DisplayUnderLine.TabIndex = 0;
            this.btn_DisplayUnderLine.Text = "显示下划线";
            this.btn_DisplayUnderLine.UseVisualStyleBackColor = true;
            this.btn_DisplayUnderLine.Click += new System.EventHandler(this.btn_DisplayUnderLine_Click);
            // 
            // txt_Str
            // 
            this.txt_Str.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Str.Location = new System.Drawing.Point(0, 0);
            this.txt_Str.Multiline = true;
            this.txt_Str.Name = "txt_Str";
            this.txt_Str.Size = new System.Drawing.Size(315, 134);
            this.txt_Str.TabIndex = 1;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 165);
            this.Controls.Add(this.txt_Str);
            this.Controls.Add(this.btn_DisplayUnderLine);
            this.Name = "Frm_Main";
            this.Text = "在TextBox控件底端显示下划线";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_DisplayUnderLine;
        private System.Windows.Forms.TextBox txt_Str;
    }
}

