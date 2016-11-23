namespace BeautifulComboBox
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
            if(disposing && (components != null))
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
            this.beautyComboBox = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // beautyComboBox
            // 
            this.beautyComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.beautyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.beautyComboBox.FormattingEnabled = true;
            this.beautyComboBox.Location = new System.Drawing.Point(39, 31);
            this.beautyComboBox.Name = "beautyComboBox";
            this.beautyComboBox.Size = new System.Drawing.Size(198, 22);
            this.beautyComboBox.TabIndex = 1;
            this.beautyComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.beautyComboBox_DrawItem);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "200812120301473636752.gif");
            this.imageList1.Images.SetKeyName(1, "200812120304155365081.jpg");
            this.imageList1.Images.SetKeyName(2, "200812120310127302145.gif");
            this.imageList1.Images.SetKeyName(3, "Image3.gif");
            this.imageList1.Images.SetKeyName(4, "Image6.gif");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.beautyComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "美化控件";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 97);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "美化ComboBox控件下拉框";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox beautyComboBox;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

