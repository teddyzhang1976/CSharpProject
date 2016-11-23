namespace AddDataBase
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
            this.btn_GetFile = new System.Windows.Forms.Button();
            this.btn_GetLog = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_LogName = new System.Windows.Forms.TextBox();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btn_GetFile
            // 
            this.btn_GetFile.Location = new System.Drawing.Point(365, 9);
            this.btn_GetFile.Name = "btn_GetFile";
            this.btn_GetFile.Size = new System.Drawing.Size(75, 23);
            this.btn_GetFile.TabIndex = 0;
            this.btn_GetFile.Text = "浏览";
            this.btn_GetFile.UseVisualStyleBackColor = true;
            this.btn_GetFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_GetLog
            // 
            this.btn_GetLog.Location = new System.Drawing.Point(365, 36);
            this.btn_GetLog.Name = "btn_GetLog";
            this.btn_GetLog.Size = new System.Drawing.Size(75, 23);
            this.btn_GetLog.TabIndex = 1;
            this.btn_GetLog.Text = "浏览";
            this.btn_GetLog.UseVisualStyleBackColor = true;
            this.btn_GetLog.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Enabled = false;
            this.btn_Add.Location = new System.Drawing.Point(365, 64);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "附加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "要附加数据库的MDF文件：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "要附加数据库的LDF文件：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "数据库名：";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(160, 64);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(198, 21);
            this.txt_Name.TabIndex = 6;
            // 
            // txt_LogName
            // 
            this.txt_LogName.Location = new System.Drawing.Point(161, 37);
            this.txt_LogName.Name = "txt_LogName";
            this.txt_LogName.Size = new System.Drawing.Size(197, 21);
            this.txt_LogName.TabIndex = 7;
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(161, 12);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(198, 21);
            this.txt_FileName.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "MDF文件";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "LDF文件";
            // 
            // Frm_Main
            // 
            this.ClientSize = new System.Drawing.Size(447, 103);
            this.Controls.Add(this.txt_FileName);
            this.Controls.Add(this.txt_LogName);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_GetLog);
            this.Controls.Add(this.btn_GetFile);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "附加数据库";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GetFile;
        private System.Windows.Forms.Button btn_GetLog;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_LogName;
        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

