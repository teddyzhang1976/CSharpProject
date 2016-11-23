namespace Round
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
            this.btn_Get = new System.Windows.Forms.Button();
            this.cbox_select = new System.Windows.Forms.ComboBox();
            this.txt_add1 = new System.Windows.Forms.TextBox();
            this.txt_add2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_add3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(178, 52);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(54, 23);
            this.btn_Get.TabIndex = 0;
            this.btn_Get.Text = "计算";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // cbox_select
            // 
            this.cbox_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_select.FormattingEnabled = true;
            this.cbox_select.Items.AddRange(new object[] {
            "保留1位小数",
            "保留2位小数",
            "保留3位小数",
            "保留4位小数"});
            this.cbox_select.Location = new System.Drawing.Point(40, 54);
            this.cbox_select.Name = "cbox_select";
            this.cbox_select.Size = new System.Drawing.Size(121, 20);
            this.cbox_select.TabIndex = 1;
            // 
            // txt_add1
            // 
            this.txt_add1.Location = new System.Drawing.Point(40, 15);
            this.txt_add1.Name = "txt_add1";
            this.txt_add1.Size = new System.Drawing.Size(84, 21);
            this.txt_add1.TabIndex = 2;
            // 
            // txt_add2
            // 
            this.txt_add2.Location = new System.Drawing.Point(147, 15);
            this.txt_add2.Name = "txt_add2";
            this.txt_add2.Size = new System.Drawing.Size(84, 21);
            this.txt_add2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "+";
            // 
            // txt_add3
            // 
            this.txt_add3.Location = new System.Drawing.Point(106, 93);
            this.txt_add3.Name = "txt_add3";
            this.txt_add3.Size = new System.Drawing.Size(126, 21);
            this.txt_add3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "计算结果：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 129);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_add3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_add2);
            this.Controls.Add(this.txt_add1);
            this.Controls.Add(this.cbox_select);
            this.Controls.Add(this.btn_Get);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "对计算结果进行四舍五入";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Get;
        private System.Windows.Forms.ComboBox cbox_select;
        private System.Windows.Forms.TextBox txt_add1;
        private System.Windows.Forms.TextBox txt_add2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_add3;
        private System.Windows.Forms.Label label2;
    }
}

