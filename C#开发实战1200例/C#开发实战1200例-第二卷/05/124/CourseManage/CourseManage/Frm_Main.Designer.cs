namespace CourseManage
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置优先级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实时ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高于标准ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标准ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.低于标准ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.低ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.结束进程ToolStripMenuItem,
            this.设置优先级ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.ShowItemToolTips = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 70);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 结束进程ToolStripMenuItem
            // 
            this.结束进程ToolStripMenuItem.Name = "结束进程ToolStripMenuItem";
            this.结束进程ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.结束进程ToolStripMenuItem.Text = "结束进程";
            this.结束进程ToolStripMenuItem.Click += new System.EventHandler(this.结束进程ToolStripMenuItem_Click);
            // 
            // 设置优先级ToolStripMenuItem
            // 
            this.设置优先级ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.实时ToolStripMenuItem,
            this.高ToolStripMenuItem,
            this.高于标准ToolStripMenuItem,
            this.标准ToolStripMenuItem,
            this.低于标准ToolStripMenuItem,
            this.低ToolStripMenuItem});
            this.设置优先级ToolStripMenuItem.Name = "设置优先级ToolStripMenuItem";
            this.设置优先级ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.设置优先级ToolStripMenuItem.Text = "设置优先级";
            // 
            // 实时ToolStripMenuItem
            // 
            this.实时ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.实时ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.实时ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.实时ToolStripMenuItem.Name = "实时ToolStripMenuItem";
            this.实时ToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.实时ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.实时ToolStripMenuItem.Text = "实时";
            this.实时ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.实时ToolStripMenuItem.Click += new System.EventHandler(this.实时ToolStripMenuItem_Click);
            // 
            // 高ToolStripMenuItem
            // 
            this.高ToolStripMenuItem.Name = "高ToolStripMenuItem";
            this.高ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.高ToolStripMenuItem.Text = "高";
            this.高ToolStripMenuItem.Click += new System.EventHandler(this.高ToolStripMenuItem_Click);
            // 
            // 高于标准ToolStripMenuItem
            // 
            this.高于标准ToolStripMenuItem.Name = "高于标准ToolStripMenuItem";
            this.高于标准ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.高于标准ToolStripMenuItem.Text = "高于标准";
            this.高于标准ToolStripMenuItem.Click += new System.EventHandler(this.高于标准ToolStripMenuItem_Click);
            // 
            // 标准ToolStripMenuItem
            // 
            this.标准ToolStripMenuItem.Name = "标准ToolStripMenuItem";
            this.标准ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.标准ToolStripMenuItem.Text = "标准";
            this.标准ToolStripMenuItem.Click += new System.EventHandler(this.标准ToolStripMenuItem_Click);
            // 
            // 低于标准ToolStripMenuItem
            // 
            this.低于标准ToolStripMenuItem.Name = "低于标准ToolStripMenuItem";
            this.低于标准ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.低于标准ToolStripMenuItem.Text = "低于标准";
            this.低于标准ToolStripMenuItem.Click += new System.EventHandler(this.低于标准ToolStripMenuItem_Click);
            // 
            // 低ToolStripMenuItem
            // 
            this.低ToolStripMenuItem.Name = "低ToolStripMenuItem";
            this.低ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.低ToolStripMenuItem.Text = "低";
            this.低ToolStripMenuItem.Click += new System.EventHandler(this.低ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(469, 314);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(461, 289);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "进程";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(455, 283);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "映像名称";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "进程ID";
            this.columnHeader12.Width = 70;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "线程数";
            this.columnHeader13.Width = 70;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "优先级";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "物理内存";
            this.columnHeader15.Width = 65;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "虚拟内存";
            this.columnHeader16.Width = 85;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 314);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(469, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslInfo
            // 
            this.tsslInfo.Name = "tsslInfo";
            this.tsslInfo.Size = new System.Drawing.Size(131, 17);
            this.tsslInfo.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 336);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进程管理器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束进程ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ToolStripMenuItem 设置优先级ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslInfo;
        private System.Windows.Forms.ToolStripMenuItem 实时ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高于标准ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标准ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 低于标准ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 低ToolStripMenuItem;
    }
}

