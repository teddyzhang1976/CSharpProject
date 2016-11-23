namespace ChangeFormSize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.panel_BR = new System.Windows.Forms.Panel();
            this.panel_All = new System.Windows.Forms.Panel();
            this.panel_TitR = new System.Windows.Forms.Panel();
            this.panel_BL = new System.Windows.Forms.Panel();
            this.panel_TitZ = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_TitL = new System.Windows.Forms.Panel();
            this.panel_Right = new System.Windows.Forms.Panel();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.panel_Title = new System.Windows.Forms.Panel();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.panel_Bn = new System.Windows.Forms.Panel();
            this.panel_TitZ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_Title.SuspendLayout();
            this.panel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_BR
            // 
            this.panel_BR.BackColor = System.Drawing.Color.Transparent;
            this.panel_BR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_BR.BackgroundImage")));
            this.panel_BR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_BR.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.panel_BR.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_BR.Location = new System.Drawing.Point(284, 0);
            this.panel_BR.Name = "panel_BR";
            this.panel_BR.Size = new System.Drawing.Size(8, 10);
            this.panel_BR.TabIndex = 1;
            this.panel_BR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Right_MouseMove);
            this.panel_BR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Right_MouseDown);
            // 
            // panel_All
            // 
            this.panel_All.BackColor = System.Drawing.Color.Honeydew;
            this.panel_All.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_All.Location = new System.Drawing.Point(6, 19);
            this.panel_All.Name = "panel_All";
            this.panel_All.Size = new System.Drawing.Size(280, 96);
            this.panel_All.TabIndex = 13;
            // 
            // panel_TitR
            // 
            this.panel_TitR.BackColor = System.Drawing.Color.Transparent;
            this.panel_TitR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_TitR.BackgroundImage")));
            this.panel_TitR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_TitR.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_TitR.Location = new System.Drawing.Point(284, 0);
            this.panel_TitR.Name = "panel_TitR";
            this.panel_TitR.Size = new System.Drawing.Size(8, 19);
            this.panel_TitR.TabIndex = 1;
            this.panel_TitR.Tag = "3";
            this.panel_TitR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_TitL_MouseMove);
            this.panel_TitR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_TitL_MouseDown);
            // 
            // panel_BL
            // 
            this.panel_BL.BackColor = System.Drawing.Color.Transparent;
            this.panel_BL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_BL.BackgroundImage")));
            this.panel_BL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_BL.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.panel_BL.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_BL.Location = new System.Drawing.Point(0, 0);
            this.panel_BL.Name = "panel_BL";
            this.panel_BL.Size = new System.Drawing.Size(8, 10);
            this.panel_BL.TabIndex = 0;
            // 
            // panel_TitZ
            // 
            this.panel_TitZ.BackColor = System.Drawing.Color.Transparent;
            this.panel_TitZ.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_TitZ.BackgroundImage")));
            this.panel_TitZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_TitZ.Controls.Add(this.pictureBox1);
            this.panel_TitZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TitZ.Location = new System.Drawing.Point(12, 0);
            this.panel_TitZ.Name = "panel_TitZ";
            this.panel_TitZ.Size = new System.Drawing.Size(272, 19);
            this.panel_TitZ.TabIndex = 2;
            this.panel_TitZ.Tag = "2";
            this.panel_TitZ.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_TitL_MouseMove);
            this.panel_TitZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_TitL_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(260, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(11, 11);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "11";
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel_TitL
            // 
            this.panel_TitL.BackColor = System.Drawing.Color.Transparent;
            this.panel_TitL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_TitL.BackgroundImage")));
            this.panel_TitL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_TitL.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_TitL.Location = new System.Drawing.Point(0, 0);
            this.panel_TitL.Name = "panel_TitL";
            this.panel_TitL.Size = new System.Drawing.Size(12, 19);
            this.panel_TitL.TabIndex = 0;
            this.panel_TitL.Tag = "1";
            this.panel_TitL.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_TitL_MouseMove);
            this.panel_TitL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_TitL_MouseDown);
            // 
            // panel_Right
            // 
            this.panel_Right.BackColor = System.Drawing.Color.Transparent;
            this.panel_Right.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Right.BackgroundImage")));
            this.panel_Right.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.panel_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Right.Location = new System.Drawing.Point(286, 19);
            this.panel_Right.Name = "panel_Right";
            this.panel_Right.Size = new System.Drawing.Size(6, 96);
            this.panel_Right.TabIndex = 10;
            this.panel_Right.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Right_MouseMove);
            this.panel_Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Right_MouseDown);
            // 
            // panel_Left
            // 
            this.panel_Left.BackColor = System.Drawing.Color.Transparent;
            this.panel_Left.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Left.BackgroundImage")));
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 19);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(6, 96);
            this.panel_Left.TabIndex = 9;
            this.panel_Left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Right_MouseMove);
            this.panel_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Right_MouseDown);
            // 
            // panel_Title
            // 
            this.panel_Title.BackColor = System.Drawing.Color.Transparent;
            this.panel_Title.Controls.Add(this.panel_TitZ);
            this.panel_Title.Controls.Add(this.panel_TitR);
            this.panel_Title.Controls.Add(this.panel_TitL);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(292, 19);
            this.panel_Title.TabIndex = 7;
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.BackColor = System.Drawing.Color.Transparent;
            this.panel_Bottom.Controls.Add(this.panel_Bn);
            this.panel_Bottom.Controls.Add(this.panel_BR);
            this.panel_Bottom.Controls.Add(this.panel_BL);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 115);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(292, 10);
            this.panel_Bottom.TabIndex = 8;
            // 
            // panel_Bn
            // 
            this.panel_Bn.BackColor = System.Drawing.Color.Transparent;
            this.panel_Bn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Bn.BackgroundImage")));
            this.panel_Bn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Bn.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.panel_Bn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Bn.Location = new System.Drawing.Point(8, 0);
            this.panel_Bn.Name = "panel_Bn";
            this.panel_Bn.Size = new System.Drawing.Size(276, 10);
            this.panel_Bn.TabIndex = 2;
            this.panel_Bn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Right_MouseMove);
            this.panel_Bn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Right_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 125);
            this.Controls.Add(this.panel_All);
            this.Controls.Add(this.panel_Right);
            this.Controls.Add(this.panel_Left);
            this.Controls.Add(this.panel_Title);
            this.Controls.Add(this.panel_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_TitZ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_Title.ResumeLayout(false);
            this.panel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_BR;
        private System.Windows.Forms.Panel panel_All;
        private System.Windows.Forms.Panel panel_TitR;
        private System.Windows.Forms.Panel panel_BL;
        private System.Windows.Forms.Panel panel_TitZ;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_TitL;
        private System.Windows.Forms.Panel panel_Right;
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.Panel panel_Bn;
    }
}

