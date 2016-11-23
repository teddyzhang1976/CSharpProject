namespace FindStr
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
            this.txt_find = new System.Windows.Forms.TextBox();
            this.txt_display = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_Message = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_find
            // 
            this.txt_find.Location = new System.Drawing.Point(117, 72);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(126, 21);
            this.txt_find.TabIndex = 1;
            this.txt_find.TextChanged += new System.EventHandler(this.txt_find_TextChanged);
            // 
            // txt_display
            // 
            this.txt_display.Location = new System.Drawing.Point(12, 111);
            this.txt_display.Multiline = true;
            this.txt_display.Name = "txt_display";
            this.txt_display.Size = new System.Drawing.Size(290, 69);
            this.txt_display.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_find);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lab_Message);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检索元素";
            // 
            // lab_Message
            // 
            this.lab_Message.AutoSize = true;
            this.lab_Message.Location = new System.Drawing.Point(130, 15);
            this.lab_Message.Name = "lab_Message";
            this.lab_Message.Size = new System.Drawing.Size(0, 12);
            this.lab_Message.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "输入查询信息：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 187);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_display);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "按指定条件在数组中检索元素";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.TextBox txt_display;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lab_Message;
        private System.Windows.Forms.Label label1;
    }
}

