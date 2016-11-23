namespace FilePathString
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
            this.btn_Openfile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_filepath = new System.Windows.Forms.Label();
            this.lb_filename = new System.Windows.Forms.Label();
            this.lb_fileexc = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Openfile
            // 
            this.btn_Openfile.Location = new System.Drawing.Point(144, 12);
            this.btn_Openfile.Name = "btn_Openfile";
            this.btn_Openfile.Size = new System.Drawing.Size(75, 23);
            this.btn_Openfile.TabIndex = 0;
            this.btn_Openfile.Text = "选择文件";
            this.btn_Openfile.UseVisualStyleBackColor = true;
            this.btn_Openfile.Click += new System.EventHandler(this.btn_Openfile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_fileexc);
            this.groupBox1.Controls.Add(this.lb_filename);
            this.groupBox1.Controls.Add(this.lb_filepath);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 118);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件信息";
            // 
            // lb_filepath
            // 
            this.lb_filepath.AutoSize = true;
            this.lb_filepath.Location = new System.Drawing.Point(20, 29);
            this.lb_filepath.Name = "lb_filepath";
            this.lb_filepath.Size = new System.Drawing.Size(65, 12);
            this.lb_filepath.TabIndex = 0;
            this.lb_filepath.Text = "文件路径：";
            // 
            // lb_filename
            // 
            this.lb_filename.AutoSize = true;
            this.lb_filename.Location = new System.Drawing.Point(20, 57);
            this.lb_filename.Name = "lb_filename";
            this.lb_filename.Size = new System.Drawing.Size(53, 12);
            this.lb_filename.TabIndex = 1;
            this.lb_filename.Text = "文件名：";
            // 
            // lb_fileexc
            // 
            this.lb_fileexc.AutoSize = true;
            this.lb_fileexc.Location = new System.Drawing.Point(20, 87);
            this.lb_fileexc.Name = "lb_fileexc";
            this.lb_fileexc.Size = new System.Drawing.Size(77, 12);
            this.lb_fileexc.TabIndex = 2;
            this.lb_fileexc.Text = "文件扩展名：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 173);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Openfile);
            this.Name = "Frm_Main";
            this.Text = "从字符串中分离文件路径、文件名及扩展名";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Openfile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_fileexc;
        private System.Windows.Forms.Label lb_filename;
        private System.Windows.Forms.Label lb_filepath;
    }
}

