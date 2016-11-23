namespace SetPage
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
            this.CRViewer_Message = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRViewer_Message
            // 
            this.CRViewer_Message.ActiveViewIndex = -1;
            this.CRViewer_Message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRViewer_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRViewer_Message.Location = new System.Drawing.Point(0, 0);
            this.CRViewer_Message.Name = "CRViewer_Message";
            this.CRViewer_Message.SelectionFormula = "";
            this.CRViewer_Message.Size = new System.Drawing.Size(393, 300);
            this.CRViewer_Message.TabIndex = 0;
            this.CRViewer_Message.ViewTimeSelectionFormula = "";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 300);
            this.Controls.Add(this.CRViewer_Message);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "如何设置水晶报表的页面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRViewer_Message;
    }
}

