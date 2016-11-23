namespace SearchTextInRange
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_Open = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstxt_Excel = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tscbox_Sheet = new System.Windows.Forms.ToolStripComboBox();
            this.WBrowser_Excel = new System.Windows.Forms.WebBrowser();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tstxt_Start = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tstxt_End = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.tstxt_Text = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_Query = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_Open,
            this.toolStripSeparator1,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.tstxt_Excel,
            this.toolStripSeparator2,
            this.toolStripSeparator7,
            this.toolStripLabel3,
            this.tscbox_Sheet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(595, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_Open
            // 
            this.tsbtn_Open.Image = global::SearchTextInRange.Properties.Resources.open;
            this.tsbtn_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Open.Name = "tsbtn_Open";
            this.tsbtn_Open.Size = new System.Drawing.Size(105, 22);
            this.tsbtn_Open.Text = "打开Excel文件";
            this.tsbtn_Open.Click += new System.EventHandler(this.tsbtn_Open_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(73, 22);
            this.toolStripLabel1.Text = "Excel路径：";
            // 
            // tstxt_Excel
            // 
            this.tstxt_Excel.Name = "tstxt_Excel";
            this.tstxt_Excel.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel3.Text = "请选择工作表：";
            // 
            // tscbox_Sheet
            // 
            this.tscbox_Sheet.Name = "tscbox_Sheet";
            this.tscbox_Sheet.Size = new System.Drawing.Size(120, 25);
            this.tscbox_Sheet.SelectedIndexChanged += new System.EventHandler(this.tscbox_Sheet_SelectedIndexChanged);
            // 
            // WBrowser_Excel
            // 
            this.WBrowser_Excel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WBrowser_Excel.Location = new System.Drawing.Point(0, 25);
            this.WBrowser_Excel.MinimumSize = new System.Drawing.Size(20, 20);
            this.WBrowser_Excel.Name = "WBrowser_Excel";
            this.WBrowser_Excel.Size = new System.Drawing.Size(595, 356);
            this.WBrowser_Excel.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.tstxt_Start,
            this.toolStripLabel5,
            this.tstxt_End,
            this.toolStripSeparator5,
            this.toolStripSeparator3,
            this.toolStripLabel6,
            this.tstxt_Text,
            this.toolStripSeparator6,
            this.toolStripSeparator8,
            this.tsbtn_Query});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(595, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(104, 22);
            this.toolStripLabel4.Text = "请输入查找范围：";
            // 
            // tstxt_Start
            // 
            this.tstxt_Start.Name = "tstxt_Start";
            this.tstxt_Start.Size = new System.Drawing.Size(50, 25);
            this.tstxt_Start.Text = "A1";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel5.Text = "到";
            // 
            // tstxt_End
            // 
            this.tstxt_End.Name = "tstxt_End";
            this.tstxt_End.Size = new System.Drawing.Size(50, 25);
            this.tstxt_End.Text = "C1";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(104, 22);
            this.toolStripLabel6.Text = "请输入查找文本：";
            // 
            // tstxt_Text
            // 
            this.tstxt_Text.Name = "tstxt_Text";
            this.tstxt_Text.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtn_Query
            // 
            this.tsbtn_Query.Image = global::SearchTextInRange.Properties.Resources.Query;
            this.tsbtn_Query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Query.Name = "tsbtn_Query";
            this.tsbtn_Query.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_Query.Text = "搜索";
            this.tsbtn_Query.Click += new System.EventHandler(this.tsbtn_Query_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 381);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.WBrowser_Excel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在Excel的指定范围内搜索文本";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_Open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstxt_Excel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.WebBrowser WBrowser_Excel;
        private System.Windows.Forms.ToolStripComboBox tscbox_Sheet;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox tstxt_Start;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox tstxt_End;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripTextBox tstxt_Text;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbtn_Query;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;

    }
}

