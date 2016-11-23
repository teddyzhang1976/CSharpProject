namespace Getdirectory
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TreeViewFile = new System.Windows.Forms.TreeView();
            this.ListViewFile = new System.Windows.Forms.ListView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TreeViewFile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ListViewFile);
            this.splitContainer1.Size = new System.Drawing.Size(632, 401);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 0;
            // 
            // TreeViewFile
            // 
            this.TreeViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewFile.Location = new System.Drawing.Point(0, 0);
            this.TreeViewFile.Name = "TreeViewFile";
            this.TreeViewFile.Size = new System.Drawing.Size(248, 401);
            this.TreeViewFile.TabIndex = 0;
            this.TreeViewFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewFile_AfterSelect);
            // 
            // ListViewFile
            // 
            this.ListViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewFile.Location = new System.Drawing.Point(0, 0);
            this.ListViewFile.MultiSelect = false;
            this.ListViewFile.Name = "ListViewFile";
            this.ListViewFile.Size = new System.Drawing.Size(380, 401);
            this.ListViewFile.TabIndex = 0;
            this.ListViewFile.UseCompatibleStateImageBehavior = false;
            this.ListViewFile.View = System.Windows.Forms.View.List;
            this.ListViewFile.DoubleClick += new System.EventHandler(this.ListViewFile_DoubleClick);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 401);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用TreeView控件遍历磁盘目录";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView TreeViewFile;
        private System.Windows.Forms.ListView ListViewFile;
    }
}

