namespace ChuffedFarm
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
            this.pbxInseminate = new System.Windows.Forms.PictureBox();
            this.pbxVegetate = new System.Windows.Forms.PictureBox();
            this.pbxBlossomOut = new System.Windows.Forms.PictureBox();
            this.pbxMakeFruitage = new System.Windows.Forms.PictureBox();
            this.pbxHarvest = new System.Windows.Forms.PictureBox();
            this.lbAmount = new System.Windows.Forms.Label();
            this.tipSeed = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxInseminate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVegetate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBlossomOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMakeFruitage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHarvest)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxInseminate
            // 
            this.pbxInseminate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxInseminate.BackColor = System.Drawing.Color.Transparent;
            this.pbxInseminate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxInseminate.Image = global::ChuffedFarm.Properties.Resources.播种;
            this.pbxInseminate.Location = new System.Drawing.Point(28, 186);
            this.pbxInseminate.Name = "pbxInseminate";
            this.pbxInseminate.Size = new System.Drawing.Size(57, 57);
            this.pbxInseminate.TabIndex = 0;
            this.pbxInseminate.TabStop = false;
            this.pbxInseminate.MouseLeave += new System.EventHandler(this.pbxSeed_MouseLeave);
            this.pbxInseminate.Click += new System.EventHandler(this.pbxInseminate_Click);
            this.pbxInseminate.MouseEnter += new System.EventHandler(this.pbxSeed_MouseEnter);
            // 
            // pbxVegetate
            // 
            this.pbxVegetate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxVegetate.BackColor = System.Drawing.Color.Transparent;
            this.pbxVegetate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxVegetate.Image = global::ChuffedFarm.Properties.Resources.生长;
            this.pbxVegetate.Location = new System.Drawing.Point(112, 186);
            this.pbxVegetate.Name = "pbxVegetate";
            this.pbxVegetate.Size = new System.Drawing.Size(57, 57);
            this.pbxVegetate.TabIndex = 1;
            this.pbxVegetate.TabStop = false;
            this.pbxVegetate.MouseLeave += new System.EventHandler(this.pbxVegetate_MouseLeave);
            this.pbxVegetate.Click += new System.EventHandler(this.pbxVegetate_Click);
            this.pbxVegetate.MouseEnter += new System.EventHandler(this.pbxVegetate_MouseEnter);
            // 
            // pbxBlossomOut
            // 
            this.pbxBlossomOut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxBlossomOut.BackColor = System.Drawing.Color.Transparent;
            this.pbxBlossomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxBlossomOut.Image = global::ChuffedFarm.Properties.Resources.开花;
            this.pbxBlossomOut.Location = new System.Drawing.Point(196, 186);
            this.pbxBlossomOut.Name = "pbxBlossomOut";
            this.pbxBlossomOut.Size = new System.Drawing.Size(57, 57);
            this.pbxBlossomOut.TabIndex = 2;
            this.pbxBlossomOut.TabStop = false;
            this.pbxBlossomOut.MouseLeave += new System.EventHandler(this.pbxBlossomOut_MouseLeave);
            this.pbxBlossomOut.Click += new System.EventHandler(this.pbxBlossomOut_Click);
            this.pbxBlossomOut.MouseEnter += new System.EventHandler(this.pbxBlossomOut_MouseEnter);
            // 
            // pbxMakeFruitage
            // 
            this.pbxMakeFruitage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxMakeFruitage.BackColor = System.Drawing.Color.Transparent;
            this.pbxMakeFruitage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxMakeFruitage.Image = global::ChuffedFarm.Properties.Resources.结果;
            this.pbxMakeFruitage.Location = new System.Drawing.Point(280, 186);
            this.pbxMakeFruitage.Name = "pbxMakeFruitage";
            this.pbxMakeFruitage.Size = new System.Drawing.Size(57, 57);
            this.pbxMakeFruitage.TabIndex = 3;
            this.pbxMakeFruitage.TabStop = false;
            this.pbxMakeFruitage.MouseLeave += new System.EventHandler(this.pbxMakeFruitage_MouseLeave);
            this.pbxMakeFruitage.Click += new System.EventHandler(this.pbxMakeFruitage_Click);
            this.pbxMakeFruitage.MouseEnter += new System.EventHandler(this.pbxMakeFruitage_MouseEnter);
            // 
            // pbxHarvest
            // 
            this.pbxHarvest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxHarvest.BackColor = System.Drawing.Color.Transparent;
            this.pbxHarvest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxHarvest.Image = global::ChuffedFarm.Properties.Resources.收获;
            this.pbxHarvest.Location = new System.Drawing.Point(364, 186);
            this.pbxHarvest.Name = "pbxHarvest";
            this.pbxHarvest.Size = new System.Drawing.Size(57, 57);
            this.pbxHarvest.TabIndex = 4;
            this.pbxHarvest.TabStop = false;
            this.pbxHarvest.MouseLeave += new System.EventHandler(this.pbxHarvest_MouseLeave);
            this.pbxHarvest.Click += new System.EventHandler(this.pbxHarvest_Click);
            this.pbxHarvest.MouseEnter += new System.EventHandler(this.pbxHarvest_MouseEnter);
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbAmount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAmount.Location = new System.Drawing.Point(96, 24);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(239, 12);
            this.lbAmount.TabIndex = 5;
            this.lbAmount.Text = "你的仓库没有任何果实了，快快播种吧！";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChuffedFarm.Properties.Resources.plowland;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(458, 242);
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.pbxHarvest);
            this.Controls.Add(this.pbxMakeFruitage);
            this.Controls.Add(this.pbxBlossomOut);
            this.Controls.Add(this.pbxVegetate);
            this.Controls.Add(this.pbxInseminate);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打造自己的开心农场";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbxInseminate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVegetate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBlossomOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMakeFruitage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHarvest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxInseminate;
        private System.Windows.Forms.PictureBox pbxVegetate;
        private System.Windows.Forms.PictureBox pbxBlossomOut;
        private System.Windows.Forms.PictureBox pbxMakeFruitage;
        private System.Windows.Forms.PictureBox pbxHarvest;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.ToolTip tipSeed;
    }
}

