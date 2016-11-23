namespace Conversion
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
            this.btn_transform = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.cbox_select2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.cbox_select = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_transform
            // 
            this.btn_transform.Location = new System.Drawing.Point(180, 72);
            this.btn_transform.Name = "btn_transform";
            this.btn_transform.Size = new System.Drawing.Size(75, 23);
            this.btn_transform.TabIndex = 0;
            this.btn_transform.Text = "转换";
            this.btn_transform.UseVisualStyleBackColor = true;
            this.btn_transform.Click += new System.EventHandler(this.btn_transform_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入数值：";
            // 
            // txt_value
            // 
            this.txt_value.Location = new System.Drawing.Point(91, 32);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(79, 21);
            this.txt_value.TabIndex = 2;
            // 
            // cbox_select2
            // 
            this.cbox_select2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_select2.FormattingEnabled = true;
            this.cbox_select2.Items.AddRange(new object[] {
            "十进制",
            "二进制",
            "八进制",
            "十六进制"});
            this.cbox_select2.Location = new System.Drawing.Point(91, 73);
            this.cbox_select2.Name = "cbox_select2";
            this.cbox_select2.Size = new System.Drawing.Size(79, 20);
            this.cbox_select2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "转换为：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "转换结果：";
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(91, 112);
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(164, 21);
            this.txt_result.TabIndex = 6;
            // 
            // cbox_select
            // 
            this.cbox_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_select.FormattingEnabled = true;
            this.cbox_select.Items.AddRange(new object[] {
            "十进制",
            "二进制",
            "八进制",
            "十六进制"});
            this.cbox_select.Location = new System.Drawing.Point(176, 32);
            this.cbox_select.Name = "cbox_select";
            this.cbox_select.Size = new System.Drawing.Size(79, 20);
            this.cbox_select.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_select);
            this.groupBox1.Controls.Add(this.btn_transform);
            this.groupBox1.Controls.Add(this.txt_result);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_value);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbox_select2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 154);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "进制转换";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 172);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进制转换器";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_transform;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.ComboBox cbox_select2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.ComboBox cbox_select;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

