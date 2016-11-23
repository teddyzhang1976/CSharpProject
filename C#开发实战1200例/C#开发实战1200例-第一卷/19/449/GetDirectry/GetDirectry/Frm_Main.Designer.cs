namespace GetDirectry
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
            this.btn_SaveAs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Path = new System.Windows.Forms.Button();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Open = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.Enabled = false;
            this.btn_SaveAs.Location = new System.Drawing.Point(99, 96);
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(188, 23);
            this.btn_SaveAs.TabIndex = 5;
            this.btn_SaveAs.Text = "提取Word目录保存到新文档";
            this.btn_SaveAs.UseVisualStyleBackColor = true;
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Path);
            this.groupBox1.Controls.Add(this.txt_Path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_SaveAs);
            this.groupBox1.Controls.Add(this.btn_Open);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 136);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打开或新建Word文档";
            // 
            // btn_Path
            // 
            this.btn_Path.Enabled = false;
            this.btn_Path.Location = new System.Drawing.Point(292, 61);
            this.btn_Path.Name = "btn_Path";
            this.btn_Path.Size = new System.Drawing.Size(56, 23);
            this.btn_Path.TabIndex = 8;
            this.btn_Path.Text = "浏览";
            this.btn_Path.UseVisualStyleBackColor = true;
            this.btn_Path.Click += new System.EventHandler(this.btn_Path_Click);
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(98, 63);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.ReadOnly = true;
            this.txt_Path.Size = new System.Drawing.Size(188, 21);
            this.txt_Path.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "目录保存位置：";
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(99, 28);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(188, 23);
            this.btn_Open.TabIndex = 1;
            this.btn_Open.Text = "打开Word文档";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 152);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.Text = "提取Word文档中的目录";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_SaveAs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Path;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Label label1;
    }
}

