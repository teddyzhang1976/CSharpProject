namespace TypeOf
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
            this.rtbox_text = new System.Windows.Forms.RichTextBox();
            this.btn_Get = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbox_text
            // 
            this.rtbox_text.Location = new System.Drawing.Point(0, 2);
            this.rtbox_text.Name = "rtbox_text";
            this.rtbox_text.Size = new System.Drawing.Size(321, 262);
            this.rtbox_text.TabIndex = 3;
            this.rtbox_text.Text = "";
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(119, 266);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(75, 23);
            this.btn_Get.TabIndex = 2;
            this.btn_Get.Text = "获取";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 292);
            this.Controls.Add(this.rtbox_text);
            this.Controls.Add(this.btn_Get);
            this.Name = "Form1";
            this.Text = "使用typeof运算符获取类的内部结构";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbox_text;
        private System.Windows.Forms.Button btn_Get;
    }
}

