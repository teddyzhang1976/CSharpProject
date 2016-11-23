namespace FileComminuteUnite
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCPath = new System.Windows.Forms.TextBox();
            this.txtCFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCPath = new System.Windows.Forms.Button();
            this.btnCombin = new System.Windows.Forms.Button();
            this.btnCFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(354, 201);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtCPath);
            this.tabPage2.Controls.Add(this.txtCFile);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnCPath);
            this.tabPage2.Controls.Add(this.btnCombin);
            this.tabPage2.Controls.Add(this.btnCFile);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(346, 175);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "文件合成";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCPath
            // 
            this.txtCPath.Location = new System.Drawing.Point(37, 88);
            this.txtCPath.Name = "txtCPath";
            this.txtCPath.Size = new System.Drawing.Size(256, 21);
            this.txtCPath.TabIndex = 6;
            // 
            // txtCFile
            // 
            this.txtCFile.Location = new System.Drawing.Point(37, 44);
            this.txtCFile.Name = "txtCFile";
            this.txtCFile.Size = new System.Drawing.Size(174, 21);
            this.txtCFile.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "选择合并后文件存放路径及名称";
            // 
            // btnCPath
            // 
            this.btnCPath.Location = new System.Drawing.Point(299, 87);
            this.btnCPath.Name = "btnCPath";
            this.btnCPath.Size = new System.Drawing.Size(38, 23);
            this.btnCPath.TabIndex = 3;
            this.btnCPath.Text = "<<";
            this.btnCPath.UseVisualStyleBackColor = true;
            this.btnCPath.Click += new System.EventHandler(this.btnCPath_Click);
            // 
            // btnCombin
            // 
            this.btnCombin.Location = new System.Drawing.Point(262, 44);
            this.btnCombin.Name = "btnCombin";
            this.btnCombin.Size = new System.Drawing.Size(75, 23);
            this.btnCombin.TabIndex = 2;
            this.btnCombin.Text = "合并";
            this.btnCombin.UseVisualStyleBackColor = true;
            this.btnCombin.Click += new System.EventHandler(this.btnCombin_Click);
            // 
            // btnCFile
            // 
            this.btnCFile.Location = new System.Drawing.Point(217, 44);
            this.btnCFile.Name = "btnCFile";
            this.btnCFile.Size = new System.Drawing.Size(39, 23);
            this.btnCFile.TabIndex = 1;
            this.btnCFile.Text = "<<";
            this.btnCFile.UseVisualStyleBackColor = true;
            this.btnCFile.Click += new System.EventHandler(this.btnCFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "选择要合成的文件";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 181);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(354, 20);
            this.progressBar.TabIndex = 1;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 201);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "将多个小文件合并为一个文件";
            this.Load += new System.EventHandler(this.frmSplit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtCPath;
        private System.Windows.Forms.TextBox txtCFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCPath;
        private System.Windows.Forms.Button btnCombin;
        private System.Windows.Forms.Button btnCFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}