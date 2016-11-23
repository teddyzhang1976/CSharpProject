namespace Transform
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbtn_object = new System.Windows.Forms.RadioButton();
            this.rbtn_stream = new System.Windows.Forms.RadioButton();
            this.rbtn_string = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(137, 117);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(75, 23);
            this.btn_Get.TabIndex = 0;
            this.btn_Get.Text = "类型转换";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "将FileStream对象转换为：";
            // 
            // rbtn_object
            // 
            this.rbtn_object.AutoSize = true;
            this.rbtn_object.Checked = true;
            this.rbtn_object.Location = new System.Drawing.Point(179, 24);
            this.rbtn_object.Name = "rbtn_object";
            this.rbtn_object.Size = new System.Drawing.Size(119, 16);
            this.rbtn_object.TabIndex = 2;
            this.rbtn_object.TabStop = true;
            this.rbtn_object.Text = "转换为object类型";
            this.rbtn_object.UseVisualStyleBackColor = true;
            // 
            // rbtn_stream
            // 
            this.rbtn_stream.AutoSize = true;
            this.rbtn_stream.Location = new System.Drawing.Point(179, 46);
            this.rbtn_stream.Name = "rbtn_stream";
            this.rbtn_stream.Size = new System.Drawing.Size(119, 16);
            this.rbtn_stream.TabIndex = 3;
            this.rbtn_stream.TabStop = true;
            this.rbtn_stream.Text = "转换为Stream类型";
            this.rbtn_stream.UseVisualStyleBackColor = true;
            // 
            // rbtn_string
            // 
            this.rbtn_string.AutoSize = true;
            this.rbtn_string.Location = new System.Drawing.Point(179, 68);
            this.rbtn_string.Name = "rbtn_string";
            this.rbtn_string.Size = new System.Drawing.Size(119, 16);
            this.rbtn_string.TabIndex = 4;
            this.rbtn_string.TabStop = true;
            this.rbtn_string.Text = "转换为String类型";
            this.rbtn_string.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbtn_string);
            this.groupBox1.Controls.Add(this.rbtn_stream);
            this.groupBox1.Controls.Add(this.rbtn_object);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 99);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类型转换";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 145);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Get);
            this.Name = "Frm_Main";
            this.Text = "使用as关键字将对象转换为指定类型";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Get;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtn_object;
        private System.Windows.Forms.RadioButton rbtn_stream;
        private System.Windows.Forms.RadioButton rbtn_string;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

