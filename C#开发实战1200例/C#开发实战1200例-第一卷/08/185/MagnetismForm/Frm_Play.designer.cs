namespace MagnetismForm
{
    partial class Frm_Play
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
            this.panel_Title = new System.Windows.Forms.Panel();
            this.panel_Close = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Title
            // 
            this.panel_Title.BackColor = System.Drawing.Color.MediumBlue;
            this.panel_Title.BackgroundImage = global::MagnetismForm.Properties.Resources._1;
            this.panel_Title.Controls.Add(this.panel_Close);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(290, 31);
            this.panel_Title.TabIndex = 0;
            this.panel_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Title_MouseMove);
            this.panel_Title.Click += new System.EventHandler(this.panel_Title_Click);
            this.panel_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Title_MouseDown);
            this.panel_Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Title_MouseUp);
            // 
            // panel_Close
            // 
            this.panel_Close.BackColor = System.Drawing.Color.Red;
            this.panel_Close.BackgroundImage = global::MagnetismForm.Properties.Resources.Close;
            this.panel_Close.Location = new System.Drawing.Point(270, 5);
            this.panel_Close.Name = "panel_Close";
            this.panel_Close.Size = new System.Drawing.Size(18, 18);
            this.panel_Close.TabIndex = 0;
            this.panel_Close.Click += new System.EventHandler(this.panel_Close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MagnetismForm.Properties.Resources._4;
            this.pictureBox1.Location = new System.Drawing.Point(0, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 120);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Play";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.Frm_Play_Load);
            this.Shown += new System.EventHandler(this.Frm_Play_Shown);
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.Panel panel_Close;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

