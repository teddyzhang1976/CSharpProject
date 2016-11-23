namespace TreeForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("企业类型设置");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("企业性质设置");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("企业级别设置");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("企业资信设置");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("基础信息维护", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("客户信息");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("联系人信息");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("业务往来");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("客户信息维护", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("客户投诉");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("客户反馈");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("客户服务", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("联系人信息查询");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("客户信息查询");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("客户信息查询", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("客户信息报表");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("业务往来报表");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("联系人信息报表");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("打印报表", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("调用Word");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("调用Excel");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("辅助工具", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.基础信息维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户信息维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基础信息维护ToolStripMenuItem,
            this.客户信息维护ToolStripMenuItem,
            this.客户服务ToolStripMenuItem,
            this.客户信息查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 基础信息维护ToolStripMenuItem
            // 
            this.基础信息维护ToolStripMenuItem.Name = "基础信息维护ToolStripMenuItem";
            this.基础信息维护ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.基础信息维护ToolStripMenuItem.Text = "基础信息维护";
            // 
            // 客户信息维护ToolStripMenuItem
            // 
            this.客户信息维护ToolStripMenuItem.Name = "客户信息维护ToolStripMenuItem";
            this.客户信息维护ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.客户信息维护ToolStripMenuItem.Text = "客户信息维护";
            // 
            // 客户服务ToolStripMenuItem
            // 
            this.客户服务ToolStripMenuItem.Name = "客户服务ToolStripMenuItem";
            this.客户服务ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.客户服务ToolStripMenuItem.Text = "客户服务";
            // 
            // 客户信息查询ToolStripMenuItem
            // 
            this.客户信息查询ToolStripMenuItem.Name = "客户信息查询ToolStripMenuItem";
            this.客户信息查询ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.客户信息查询ToolStripMenuItem.Text = "客户信息查询";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 77);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Text = "企业类型设置";
            treeNode2.Name = "节点2";
            treeNode2.Text = "企业性质设置";
            treeNode3.Name = "节点3";
            treeNode3.Text = "企业级别设置";
            treeNode4.Name = "节点4";
            treeNode4.Text = "企业资信设置";
            treeNode5.Name = "节点0";
            treeNode5.Text = "基础信息维护";
            treeNode6.Name = "节点6";
            treeNode6.Text = "客户信息";
            treeNode7.Name = "节点7";
            treeNode7.Text = "联系人信息";
            treeNode8.Name = "节点9";
            treeNode8.Text = "业务往来";
            treeNode9.Name = "节点5";
            treeNode9.Text = "客户信息维护";
            treeNode10.Name = "节点11";
            treeNode10.Text = "客户投诉";
            treeNode11.Name = "节点12";
            treeNode11.Text = "客户反馈";
            treeNode12.Name = "节点10";
            treeNode12.Text = "客户服务";
            treeNode13.Name = "节点14";
            treeNode13.Text = "联系人信息查询";
            treeNode14.Name = "节点15";
            treeNode14.Text = "客户信息查询";
            treeNode15.Name = "节点13";
            treeNode15.Text = "客户信息查询";
            treeNode16.Name = "节点17";
            treeNode16.Text = "客户信息报表";
            treeNode17.Name = "节点18";
            treeNode17.Text = "业务往来报表";
            treeNode18.Name = "节点20";
            treeNode18.Text = "联系人信息报表";
            treeNode19.Name = "节点16";
            treeNode19.Text = "打印报表";
            treeNode20.Name = "节点21";
            treeNode20.Text = "调用Word";
            treeNode21.Name = "节点22";
            treeNode21.Text = "调用Excel";
            treeNode22.Name = "节点19";
            treeNode22.Text = "辅助工具";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode9,
            treeNode12,
            treeNode15,
            treeNode19,
            treeNode22});
            this.treeView1.Size = new System.Drawing.Size(139, 393);
            this.treeView1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TreeForm.Properties.Resources.右;
            this.pictureBox2.Location = new System.Drawing.Point(136, 77);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(581, 416);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TreeForm.Properties.Resources.上;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(765, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 473);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "以树形显示的程序界面";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 基础信息维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户信息维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户信息查询ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

