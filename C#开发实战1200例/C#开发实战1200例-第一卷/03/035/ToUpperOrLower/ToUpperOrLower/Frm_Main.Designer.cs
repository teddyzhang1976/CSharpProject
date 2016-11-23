namespace ToUpperOrLower
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
            this.btn_change = new System.Windows.Forms.Button();
            this.txt_string = new System.Windows.Forms.TextBox();
            this.txt_changed = new System.Windows.Forms.TextBox();
            this.rbtn_upper = new System.Windows.Forms.RadioButton();
            this.rbtn_lower = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(45, 57);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(75, 23);
            this.btn_change.TabIndex = 0;
            this.btn_change.Text = "转换";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // txt_string
            // 
            this.txt_string.Location = new System.Drawing.Point(45, 28);
            this.txt_string.Name = "txt_string";
            this.txt_string.Size = new System.Drawing.Size(189, 21);
            this.txt_string.TabIndex = 2;
            this.txt_string.Text = "          请输入字符串";
            this.txt_string.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_string_MouseClick);
            // 
            // txt_changed
            // 
            this.txt_changed.Location = new System.Drawing.Point(45, 89);
            this.txt_changed.Name = "txt_changed";
            this.txt_changed.Size = new System.Drawing.Size(189, 21);
            this.txt_changed.TabIndex = 3;
            // 
            // rbtn_upper
            // 
            this.rbtn_upper.AutoSize = true;
            this.rbtn_upper.Checked = true;
            this.rbtn_upper.Location = new System.Drawing.Point(130, 60);
            this.rbtn_upper.Name = "rbtn_upper";
            this.rbtn_upper.Size = new System.Drawing.Size(47, 16);
            this.rbtn_upper.TabIndex = 4;
            this.rbtn_upper.TabStop = true;
            this.rbtn_upper.Text = "大写";
            this.rbtn_upper.UseVisualStyleBackColor = true;
            // 
            // rbtn_lower
            // 
            this.rbtn_lower.AutoSize = true;
            this.rbtn_lower.Location = new System.Drawing.Point(184, 60);
            this.rbtn_lower.Name = "rbtn_lower";
            this.rbtn_lower.Size = new System.Drawing.Size(47, 16);
            this.rbtn_lower.TabIndex = 5;
            this.rbtn_lower.TabStop = true;
            this.rbtn_lower.Text = "小写";
            this.rbtn_lower.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_string);
            this.groupBox1.Controls.Add(this.rbtn_lower);
            this.groupBox1.Controls.Add(this.btn_change);
            this.groupBox1.Controls.Add(this.rbtn_upper);
            this.groupBox1.Controls.Add(this.txt_changed);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 124);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "大小写转换";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 135);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "将字母全部转换为大写或小写";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.TextBox txt_string;
        private System.Windows.Forms.TextBox txt_changed;
        private System.Windows.Forms.RadioButton rbtn_upper;
        private System.Windows.Forms.RadioButton rbtn_lower;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

