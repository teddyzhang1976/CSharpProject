namespace PlayAVIMIDAndWAVCluster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选取文件 = new System.Windows.Forms.ToolStripMenuItem();
            this.播放文件 = new System.Windows.Forms.ToolStripMenuItem();
            this.停止 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出 = new System.Windows.Forms.ToolStripMenuItem();
            this.optFile = new System.Windows.Forms.OpenFileDialog();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选取文件,
            this.播放文件,
            this.停止,
            this.退出});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 选取文件
            // 
            this.选取文件.Name = "选取文件";
            this.选取文件.Size = new System.Drawing.Size(140, 22);
            this.选取文件.Text = "选取文件(&C)";
            this.选取文件.Click += new System.EventHandler(this.选取文件_Click);
            // 
            // 播放文件
            // 
            this.播放文件.Name = "播放文件";
            this.播放文件.Size = new System.Drawing.Size(140, 22);
            this.播放文件.Text = "播放文件(&P)";
            this.播放文件.Click += new System.EventHandler(this.播放文件_Click);
            // 
            // 停止
            // 
            this.停止.Name = "停止";
            this.停止.Size = new System.Drawing.Size(140, 22);
            this.停止.Text = "停止(&S)";
            this.停止.Click += new System.EventHandler(this.停止_Click);
            // 
            // 退出
            // 
            this.退出.Name = "退出";
            this.退出.Size = new System.Drawing.Size(140, 22);
            this.退出.Text = "退出(&E)";
            this.退出.Click += new System.EventHandler(this.退出_Click);
            // 
            // optFile
            // 
            this.optFile.FileName = "openFileDialog1";
            this.optFile.Filter = "视频文件(*.avi)|*.avi|音频文件 (*.mid)|*.mid|音频文件 (*.wav)|*.wav";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 25);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(434, 270);
            this.axWindowsMediaPlayer1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 295);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放指定的avi-mid-wav文件";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选取文件;
        private System.Windows.Forms.ToolStripMenuItem 播放文件;
        private System.Windows.Forms.ToolStripMenuItem 停止;
        private System.Windows.Forms.ToolStripMenuItem 退出;
        private System.Windows.Forms.OpenFileDialog optFile;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;

    }
}

