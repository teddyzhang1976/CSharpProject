namespace WYStockRealView
{
    partial class RealTimeForm
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
            this.DisplayPicPanel = new System.Windows.Forms.Panel();
            this.PriceVolPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.DisplayPicPanel.SuspendLayout();
            this.PriceVolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisplayPicPanel
            // 
            this.DisplayPicPanel.BackColor = System.Drawing.Color.Black;
            this.DisplayPicPanel.Controls.Add(this.label1);
            this.DisplayPicPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayPicPanel.Location = new System.Drawing.Point(0, 0);
            this.DisplayPicPanel.Name = "DisplayPicPanel";
            this.DisplayPicPanel.Size = new System.Drawing.Size(861, 612);
            this.DisplayPicPanel.TabIndex = 1;
            // 
            // PriceVolPanel
            // 
            this.PriceVolPanel.BackColor = System.Drawing.Color.Black;
            this.PriceVolPanel.Controls.Add(this.label2);
            this.PriceVolPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.PriceVolPanel.Location = new System.Drawing.Point(642, 0);
            this.PriceVolPanel.Name = "PriceVolPanel";
            this.PriceVolPanel.Size = new System.Drawing.Size(219, 612);
            this.PriceVolPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(319, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图形区域";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(77, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "价格区域";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(639, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 612);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // RealTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 612);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.PriceVolPanel);
            this.Controls.Add(this.DisplayPicPanel);
            this.Name = "RealTimeForm";
            this.Text = "RealTimeForm";
            this.DisplayPicPanel.ResumeLayout(false);
            this.DisplayPicPanel.PerformLayout();
            this.PriceVolPanel.ResumeLayout(false);
            this.PriceVolPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DisplayPicPanel;
        private System.Windows.Forms.Panel PriceVolPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter1;
    }
}