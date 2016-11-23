namespace BindToComboBox
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
            this.btn_Add = new System.Windows.Forms.Button();
            this.cbox_Display = new System.Windows.Forms.ComboBox();
            this.lb_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(131, 83);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(115, 23);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "添加数据表字段";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // cbox_Display
            // 
            this.cbox_Display.FormattingEnabled = true;
            this.cbox_Display.Location = new System.Drawing.Point(66, 49);
            this.cbox_Display.Name = "cbox_Display";
            this.cbox_Display.Size = new System.Drawing.Size(196, 20);
            this.cbox_Display.TabIndex = 1;
            this.cbox_Display.SelectedIndexChanged += new System.EventHandler(this.cbox_Display_SelectedIndexChanged);
            // 
            // lb_text
            // 
            this.lb_text.AutoSize = true;
            this.lb_text.Location = new System.Drawing.Point(270, 53);
            this.lb_text.Name = "lb_text";
            this.lb_text.Size = new System.Drawing.Size(0, 12);
            this.lb_text.TabIndex = 2;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 118);
            this.Controls.Add(this.lb_text);
            this.Controls.Add(this.cbox_Display);
            this.Controls.Add(this.btn_Add);
            this.Name = "Frm_Main";
            this.Text = "将数据表中的字段添加到ComboBox控件中";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ComboBox cbox_Display;
        private System.Windows.Forms.Label lb_text;
    }
}

