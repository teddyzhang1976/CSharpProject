namespace AddScroll
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
            this.rtbox_Display = new System.Windows.Forms.RichTextBox();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbox_Display
            // 
            this.rtbox_Display.Location = new System.Drawing.Point(-1, 0);
            this.rtbox_Display.Name = "rtbox_Display";
            this.rtbox_Display.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbox_Display.Size = new System.Drawing.Size(253, 91);
            this.rtbox_Display.TabIndex = 0;
            this.rtbox_Display.Text = "";
            // 
            // btn_Down
            // 
            this.btn_Down.Location = new System.Drawing.Point(258, 51);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(75, 35);
            this.btn_Down.TabIndex = 1;
            this.btn_Down.Text = "向下托动";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Location = new System.Drawing.Point(258, 9);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(75, 35);
            this.btn_Up.TabIndex = 3;
            this.btn_Up.Text = "向上托动";
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 97);
            this.Controls.Add(this.btn_Up);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.rtbox_Display);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "为RichTextBox控件添加自定义滚动条";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbox_Display;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Up;
    }
}

