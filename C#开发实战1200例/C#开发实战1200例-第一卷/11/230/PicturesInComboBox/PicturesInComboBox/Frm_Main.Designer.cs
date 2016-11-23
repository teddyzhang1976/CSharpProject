namespace PicturesInComboBox
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
            this.cbox_DisplayPictures = new System.Windows.Forms.ComboBox();
            this.btn_Begin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbox_DisplayPictures
            // 
            this.cbox_DisplayPictures.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbox_DisplayPictures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_DisplayPictures.FormattingEnabled = true;
            this.cbox_DisplayPictures.IntegralHeight = false;
            this.cbox_DisplayPictures.ItemHeight = 16;
            this.cbox_DisplayPictures.Location = new System.Drawing.Point(75, 33);
            this.cbox_DisplayPictures.Name = "cbox_DisplayPictures";
            this.cbox_DisplayPictures.Size = new System.Drawing.Size(168, 22);
            this.cbox_DisplayPictures.TabIndex = 1;
            this.cbox_DisplayPictures.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbox_DisplayPictures_DrawItem);
            // 
            // btn_Begin
            // 
            this.btn_Begin.Location = new System.Drawing.Point(121, 72);
            this.btn_Begin.Name = "btn_Begin";
            this.btn_Begin.Size = new System.Drawing.Size(75, 23);
            this.btn_Begin.TabIndex = 0;
            this.btn_Begin.Text = "开始演示";
            this.btn_Begin.UseVisualStyleBackColor = true;
            this.btn_Begin.Click += new System.EventHandler(this.btn_Begin_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 104);
            this.Controls.Add(this.btn_Begin);
            this.Controls.Add(this.cbox_DisplayPictures);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在ComboBox下拉列表中显示图片";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_DisplayPictures;
        private System.Windows.Forms.Button btn_Begin;
    }
}

