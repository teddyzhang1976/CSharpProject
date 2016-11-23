namespace MouseThroughForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolColor = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolColor_Gainsboro = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolColor_DarkOrchid = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolColor_RoyalBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolColor_Gold = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolColor_LightGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClarity = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClarity_10 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClarity_20 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClarity_30 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClarity_40 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClarity_50 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClarity_60 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClarity_70 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClarity_80 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClarity_90 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolAcquiescence = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClose = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolColor,
            this.ToolClarity,
            this.ToolAcquiescence,
            this.ToolClose});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 92);
            // 
            // ToolColor
            // 
            this.ToolColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolColor_Gainsboro,
            this.ToolColor_DarkOrchid,
            this.ToolColor_RoyalBlue,
            this.ToolColor_Gold,
            this.ToolColor_LightGreen});
            this.ToolColor.Name = "ToolColor";
            this.ToolColor.Size = new System.Drawing.Size(136, 22);
            this.ToolColor.Text = "颜色设置";
            // 
            // ToolColor_Gainsboro
            // 
            this.ToolColor_Gainsboro.Name = "ToolColor_Gainsboro";
            this.ToolColor_Gainsboro.Size = new System.Drawing.Size(100, 22);
            this.ToolColor_Gainsboro.Tag = "1";
            this.ToolColor_Gainsboro.Text = "玻璃";
            this.ToolColor_Gainsboro.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolColor_DarkOrchid
            // 
            this.ToolColor_DarkOrchid.Name = "ToolColor_DarkOrchid";
            this.ToolColor_DarkOrchid.Size = new System.Drawing.Size(100, 22);
            this.ToolColor_DarkOrchid.Tag = "2";
            this.ToolColor_DarkOrchid.Text = "炫紫";
            this.ToolColor_DarkOrchid.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolColor_RoyalBlue
            // 
            this.ToolColor_RoyalBlue.Name = "ToolColor_RoyalBlue";
            this.ToolColor_RoyalBlue.Size = new System.Drawing.Size(100, 22);
            this.ToolColor_RoyalBlue.Tag = "3";
            this.ToolColor_RoyalBlue.Text = "海洋";
            this.ToolColor_RoyalBlue.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolColor_Gold
            // 
            this.ToolColor_Gold.Name = "ToolColor_Gold";
            this.ToolColor_Gold.Size = new System.Drawing.Size(100, 22);
            this.ToolColor_Gold.Tag = "4";
            this.ToolColor_Gold.Text = "金属";
            this.ToolColor_Gold.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolColor_LightGreen
            // 
            this.ToolColor_LightGreen.Name = "ToolColor_LightGreen";
            this.ToolColor_LightGreen.Size = new System.Drawing.Size(100, 22);
            this.ToolColor_LightGreen.Tag = "5";
            this.ToolColor_LightGreen.Text = "翠绿";
            this.ToolColor_LightGreen.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolClarity
            // 
            this.ToolClarity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolClarity_10,
            this.ToolClarity_20,
            this.ToolClarity_30,
            this.ToolClarity_40,
            this.ToolClarity_50,
            this.ToolClarity_60,
            this.ToolClarity_70,
            this.ToolClarity_80,
            this.ToolClarity_90});
            this.ToolClarity.Name = "ToolClarity";
            this.ToolClarity.Size = new System.Drawing.Size(136, 22);
            this.ToolClarity.Text = "透明度设置";
            // 
            // ToolClarity_10
            // 
            this.ToolClarity_10.Name = "ToolClarity_10";
            this.ToolClarity_10.Size = new System.Drawing.Size(101, 22);
            this.ToolClarity_10.Tag = "1";
            this.ToolClarity_10.Text = "10%";
            this.ToolClarity_10.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolClarity_20
            // 
            this.ToolClarity_20.Name = "ToolClarity_20";
            this.ToolClarity_20.Size = new System.Drawing.Size(101, 22);
            this.ToolClarity_20.Tag = "2";
            this.ToolClarity_20.Text = "20%";
            this.ToolClarity_20.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolClarity_30
            // 
            this.ToolClarity_30.Name = "ToolClarity_30";
            this.ToolClarity_30.Size = new System.Drawing.Size(101, 22);
            this.ToolClarity_30.Tag = "3";
            this.ToolClarity_30.Text = "30%";
            this.ToolClarity_30.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolClarity_40
            // 
            this.ToolClarity_40.Name = "ToolClarity_40";
            this.ToolClarity_40.Size = new System.Drawing.Size(101, 22);
            this.ToolClarity_40.Tag = "4";
            this.ToolClarity_40.Text = "40%";
            this.ToolClarity_40.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolClarity_50
            // 
            this.ToolClarity_50.Name = "ToolClarity_50";
            this.ToolClarity_50.Size = new System.Drawing.Size(101, 22);
            this.ToolClarity_50.Tag = "5";
            this.ToolClarity_50.Text = "50%";
            this.ToolClarity_50.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolClarity_60
            // 
            this.ToolClarity_60.Name = "ToolClarity_60";
            this.ToolClarity_60.Size = new System.Drawing.Size(101, 22);
            this.ToolClarity_60.Tag = "6";
            this.ToolClarity_60.Text = "60%";
            this.ToolClarity_60.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolClarity_70
            // 
            this.ToolClarity_70.Name = "ToolClarity_70";
            this.ToolClarity_70.Size = new System.Drawing.Size(101, 22);
            this.ToolClarity_70.Tag = "7";
            this.ToolClarity_70.Text = "70%";
            this.ToolClarity_70.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolClarity_80
            // 
            this.ToolClarity_80.Name = "ToolClarity_80";
            this.ToolClarity_80.Size = new System.Drawing.Size(101, 22);
            this.ToolClarity_80.Tag = "8";
            this.ToolClarity_80.Text = "80%";
            this.ToolClarity_80.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolClarity_90
            // 
            this.ToolClarity_90.Name = "ToolClarity_90";
            this.ToolClarity_90.Size = new System.Drawing.Size(101, 22);
            this.ToolClarity_90.Tag = "9";
            this.ToolClarity_90.Text = "90%";
            this.ToolClarity_90.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolAcquiescence
            // 
            this.ToolAcquiescence.Name = "ToolAcquiescence";
            this.ToolAcquiescence.Size = new System.Drawing.Size(136, 22);
            this.ToolAcquiescence.Text = "默认效果";
            this.ToolAcquiescence.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // ToolClose
            // 
            this.ToolClose.Name = "ToolClose";
            this.ToolClose.Size = new System.Drawing.Size(136, 22);
            this.ToolClose.Text = "退出";
            this.ToolClose.Click += new System.EventHandler(this.ToolColor_Glass_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(383, 266);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Main";
            this.Opacity = 0.6;
            this.Text = "鼠标穿透窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolColor;
        private System.Windows.Forms.ToolStripMenuItem ToolClarity;
        private System.Windows.Forms.ToolStripMenuItem ToolAcquiescence;
        private System.Windows.Forms.ToolStripMenuItem ToolClose;
        private System.Windows.Forms.ToolStripMenuItem ToolColor_Gainsboro;
        private System.Windows.Forms.ToolStripMenuItem ToolColor_DarkOrchid;
        private System.Windows.Forms.ToolStripMenuItem ToolColor_RoyalBlue;
        private System.Windows.Forms.ToolStripMenuItem ToolColor_Gold;
        private System.Windows.Forms.ToolStripMenuItem ToolColor_LightGreen;
        private System.Windows.Forms.ToolStripMenuItem ToolClarity_10;
        private System.Windows.Forms.ToolStripMenuItem ToolClarity_20;
        private System.Windows.Forms.ToolStripMenuItem ToolClarity_30;
        private System.Windows.Forms.ToolStripMenuItem ToolClarity_40;
        private System.Windows.Forms.ToolStripMenuItem ToolClarity_50;
        private System.Windows.Forms.ToolStripMenuItem ToolClarity_60;
        private System.Windows.Forms.ToolStripMenuItem ToolClarity_70;
        private System.Windows.Forms.ToolStripMenuItem ToolClarity_80;
        private System.Windows.Forms.ToolStripMenuItem ToolClarity_90;

    }
}

