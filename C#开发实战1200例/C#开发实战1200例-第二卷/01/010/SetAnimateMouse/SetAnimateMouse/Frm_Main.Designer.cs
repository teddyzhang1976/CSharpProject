namespace SetAnimateMouse
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.鼠标样式设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_From = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_FromRevert = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_System = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_SystemRevert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.鼠标样式设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 鼠标样式设置ToolStripMenuItem
            // 
            this.鼠标样式设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_From,
            this.ToolS_FromRevert,
            this.ToolS_System,
            this.ToolS_SystemRevert});
            this.鼠标样式设置ToolStripMenuItem.Name = "鼠标样式设置ToolStripMenuItem";
            this.鼠标样式设置ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.鼠标样式设置ToolStripMenuItem.Text = "鼠标样式设置";
            // 
            // ToolS_From
            // 
            this.ToolS_From.Name = "ToolS_From";
            this.ToolS_From.Size = new System.Drawing.Size(196, 22);
            this.ToolS_From.Text = "在窗体中改变鼠标样式";
            this.ToolS_From.Click += new System.EventHandler(this.ToolS_From_Click);
            // 
            // ToolS_FromRevert
            // 
            this.ToolS_FromRevert.Name = "ToolS_FromRevert";
            this.ToolS_FromRevert.Size = new System.Drawing.Size(196, 22);
            this.ToolS_FromRevert.Text = "在窗体中还原鼠标样式";
            this.ToolS_FromRevert.Click += new System.EventHandler(this.ToolS_FromRevert_Click);
            // 
            // ToolS_System
            // 
            this.ToolS_System.Name = "ToolS_System";
            this.ToolS_System.Size = new System.Drawing.Size(196, 22);
            this.ToolS_System.Text = "改变系统的鼠标样式";
            this.ToolS_System.Click += new System.EventHandler(this.ToolS_System_Click);
            // 
            // ToolS_SystemRevert
            // 
            this.ToolS_SystemRevert.Name = "ToolS_SystemRevert";
            this.ToolS_SystemRevert.Size = new System.Drawing.Size(196, 22);
            this.ToolS_SystemRevert.Text = "还原系统的鼠标样式";
            this.ToolS_SystemRevert.Click += new System.EventHandler(this.ToolS_SystemRevert_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 172);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义动画鼠标";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 鼠标样式设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolS_From;
        private System.Windows.Forms.ToolStripMenuItem ToolS_FromRevert;
        private System.Windows.Forms.ToolStripMenuItem ToolS_System;
        private System.Windows.Forms.ToolStripMenuItem ToolS_SystemRevert;
    }
}

