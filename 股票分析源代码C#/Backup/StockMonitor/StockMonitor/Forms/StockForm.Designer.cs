namespace StockMonitor.Forms
{
    partial class StockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockForm));
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.chartGraph1 = new ImageOfStock.ChartGraph();
            this.SuspendLayout();
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            // 
            // chartGraph1
            // 
            this.chartGraph1.AxisSpace = 0;
            this.chartGraph1.CanDragSeries = false;
            this.chartGraph1.CrossOverIndex = 0;
            this.chartGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartGraph1.FirstVisibleRecord = 0;
            this.chartGraph1.LastVisibleRecord = 0;
            this.chartGraph1.LeftPixSpace = 0;
            this.chartGraph1.Location = new System.Drawing.Point(2, 22);
            this.chartGraph1.Name = "chartGraph1";
            this.chartGraph1.ProcessBarValue = 0;
            this.chartGraph1.RightPixSpace = 0;
            this.chartGraph1.ScrollLeftStep = 1;
            this.chartGraph1.ScrollRightStep = 1;
            this.chartGraph1.ShowCrossHair = false;
            this.chartGraph1.ShowLeftScale = false;
            this.chartGraph1.ShowRightScale = false;
            this.chartGraph1.Size = new System.Drawing.Size(1020, 546);
            this.chartGraph1.TabIndex = 6;
            this.chartGraph1.Text = "chartGraph2";
            this.chartGraph1.TimekeyField = null;
            this.chartGraph1.UseScrollAddSpeed = false;
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 570);
            this.Controls.Add(this.chartGraph1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockForm";
            this.Text = "Œ“”Æ≤∆∏ª÷’∂À";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.chartGraph1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdFile;
        private ImageOfStock.ChartGraph chartGraph1;
    }
}