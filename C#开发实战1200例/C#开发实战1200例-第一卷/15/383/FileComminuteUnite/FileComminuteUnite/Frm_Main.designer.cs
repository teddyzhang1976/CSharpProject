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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnSPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxUnit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnSFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPath);
            this.tabPage1.Controls.Add(this.txtLength);
            this.tabPage1.Controls.Add(this.txtFile);
            this.tabPage1.Controls.Add(this.btnSPath);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cboxUnit);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnSplit);
            this.tabPage1.Controls.Add(this.btnSFile);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(346, 175);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件分割";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(37, 117);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(256, 21);
            this.txtPath.TabIndex = 10;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(37, 72);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(146, 21);
            this.txtLength.TabIndex = 9;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(37, 27);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(179, 21);
            this.txtFile.TabIndex = 1;
            // 
            // btnSPath
            // 
            this.btnSPath.Location = new System.Drawing.Point(299, 115);
            this.btnSPath.Name = "btnSPath";
            this.btnSPath.Size = new System.Drawing.Size(37, 23);
            this.btnSPath.TabIndex = 8;
            this.btnSPath.Text = "<<";
            this.btnSPath.UseVisualStyleBackColor = true;
            this.btnSPath.Click += new System.EventHandler(this.btnSPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "选择分割后文件存放路径";
            // 
            // cboxUnit
            // 
            this.cboxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUnit.FormattingEnabled = true;
            this.cboxUnit.Items.AddRange(new object[] {
            "Byte",
            "KB",
            "MB",
            "GB"});
            this.cboxUnit.Location = new System.Drawing.Point(189, 73);
            this.cboxUnit.Name = "cboxUnit";
            this.cboxUnit.Size = new System.Drawing.Size(63, 20);
            this.cboxUnit.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "设置分割文件大小";
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(261, 26);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 3;
            this.btnSplit.Text = "分割";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnSFile
            // 
            this.btnSFile.Location = new System.Drawing.Point(220, 26);
            this.btnSFile.Name = "btnSFile";
            this.btnSFile.Size = new System.Drawing.Size(40, 23);
            this.btnSFile.TabIndex = 2;
            this.btnSFile.Text = "<<";
            this.btnSFile.UseVisualStyleBackColor = true;
            this.btnSFile.Click += new System.EventHandler(this.btnSFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择要分割的文件";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(354, 201);
            this.tabControl1.TabIndex = 0;
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
            this.Text = "将一个文件分割为多个小文件";
            this.Load += new System.EventHandler(this.frmSplit_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnSPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnSFile;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TabControl tabControl1;
    }
}