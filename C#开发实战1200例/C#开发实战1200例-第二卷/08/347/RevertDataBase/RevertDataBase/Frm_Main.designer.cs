namespace RevertDataBase
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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.cbox_DataBase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Revert = new System.Windows.Forms.Button();
            this.btn_path = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "路径：";
            // 
            // txt_Path
            // 
            this.txt_Path.Enabled = false;
            this.txt_Path.Location = new System.Drawing.Point(97, 40);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(172, 21);
            this.txt_Path.TabIndex = 9;
            // 
            // cbox_DataBase
            // 
            this.cbox_DataBase.FormattingEnabled = true;
            this.cbox_DataBase.Location = new System.Drawing.Point(98, 15);
            this.cbox_DataBase.Name = "cbox_DataBase";
            this.cbox_DataBase.Size = new System.Drawing.Size(171, 20);
            this.cbox_DataBase.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "操作数据库：";
            // 
            // btn_Revert
            // 
            this.btn_Revert.Location = new System.Drawing.Point(194, 66);
            this.btn_Revert.Name = "btn_Revert";
            this.btn_Revert.Size = new System.Drawing.Size(75, 23);
            this.btn_Revert.TabIndex = 6;
            this.btn_Revert.Text = "恢复";
            this.btn_Revert.UseVisualStyleBackColor = true;
            this.btn_Revert.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(113, 66);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(75, 23);
            this.btn_path.TabIndex = 11;
            this.btn_path.Text = "浏览";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openF";
            this.openFileDialog1.Filter = "备份文件 (*.bak)|*.bak|所有文件 (*.*)|*.*";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 104);
            this.Controls.Add(this.btn_path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Path);
            this.Controls.Add(this.cbox_DataBase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Revert);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "还原SQL Server数据库";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.ComboBox cbox_DataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Revert;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

