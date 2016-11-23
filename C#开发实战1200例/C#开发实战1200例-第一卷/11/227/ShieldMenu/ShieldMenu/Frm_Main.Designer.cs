namespace ShieldMenu
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
            this.btn_Shield = new System.Windows.Forms.Button();
            this.txt_Str = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Shield
            // 
            this.btn_Shield.Location = new System.Drawing.Point(124, 102);
            this.btn_Shield.Name = "btn_Shield";
            this.btn_Shield.Size = new System.Drawing.Size(100, 23);
            this.btn_Shield.TabIndex = 0;
            this.btn_Shield.Text = "屏蔽右键菜单";
            this.btn_Shield.UseVisualStyleBackColor = true;
            this.btn_Shield.Click += new System.EventHandler(this.btn_Shield_Click);
            // 
            // txt_Str
            // 
            this.txt_Str.Location = new System.Drawing.Point(0, 0);
            this.txt_Str.Multiline = true;
            this.txt_Str.Name = "txt_Str";
            this.txt_Str.Size = new System.Drawing.Size(349, 98);
            this.txt_Str.TabIndex = 1;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 129);
            this.Controls.Add(this.txt_Str);
            this.Controls.Add(this.btn_Shield);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏蔽TextBox控件上默认的右键菜单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Shield;
        private System.Windows.Forms.TextBox txt_Str;
    }
}

