namespace TxtAlignment
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hold = new System.Windows.Forms.Button();
            this.unfold = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.justifyRight = new System.Windows.Forms.Button();
            this.justifyCenter = new System.Windows.Forms.Button();
            this.justifyLeft = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "居中对齐：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 206);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "内容区域";
            // 
            // hold
            // 
            this.hold.Location = new System.Drawing.Point(223, 24);
            this.hold.Name = "hold";
            this.hold.Size = new System.Drawing.Size(102, 23);
            this.hold.TabIndex = 2;
            this.hold.Text = "保存";
            this.hold.UseVisualStyleBackColor = true;
            this.hold.Click += new System.EventHandler(this.hold_Click);
            // 
            // unfold
            // 
            this.unfold.Location = new System.Drawing.Point(68, 24);
            this.unfold.Name = "unfold";
            this.unfold.Size = new System.Drawing.Size(102, 23);
            this.unfold.TabIndex = 1;
            this.unfold.Text = "打开";
            this.unfold.UseVisualStyleBackColor = true;
            this.unfold.Click += new System.EventHandler(this.unfold_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(5, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(371, 186);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.justifyRight);
            this.groupBox2.Controls.Add(this.justifyCenter);
            this.groupBox2.Controls.Add(this.justifyLeft);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 69);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "对齐方式";
            // 
            // justifyRight
            // 
            this.justifyRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.justifyRight.Image = global::TxtAlignment.Properties.Resources.右对齐;
            this.justifyRight.Location = new System.Drawing.Point(301, 24);
            this.justifyRight.Name = "justifyRight";
            this.justifyRight.Size = new System.Drawing.Size(37, 25);
            this.justifyRight.TabIndex = 6;
            this.justifyRight.UseVisualStyleBackColor = true;
            this.justifyRight.Click += new System.EventHandler(this.justifyRight_Click);
            // 
            // justifyCenter
            // 
            this.justifyCenter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.justifyCenter.Image = global::TxtAlignment.Properties.Resources.居中对齐;
            this.justifyCenter.Location = new System.Drawing.Point(184, 24);
            this.justifyCenter.Name = "justifyCenter";
            this.justifyCenter.Size = new System.Drawing.Size(37, 25);
            this.justifyCenter.TabIndex = 5;
            this.justifyCenter.UseVisualStyleBackColor = true;
            this.justifyCenter.Click += new System.EventHandler(this.justifyCenter_Click);
            // 
            // justifyLeft
            // 
            this.justifyLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.justifyLeft.Image = global::TxtAlignment.Properties.Resources.左对齐;
            this.justifyLeft.Location = new System.Drawing.Point(68, 24);
            this.justifyLeft.Name = "justifyLeft";
            this.justifyLeft.Size = new System.Drawing.Size(37, 25);
            this.justifyLeft.TabIndex = 4;
            this.justifyLeft.UseVisualStyleBackColor = true;
            this.justifyLeft.Click += new System.EventHandler(this.justifyLeft_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "右对齐：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "左对齐：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.unfold);
            this.groupBox3.Controls.Add(this.hold);
            this.groupBox3.Location = new System.Drawing.Point(7, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 63);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文件操作";
            // 
            // TxtAlignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 359);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "TxtAlignment";
            this.Text = "设置RichTextBox的文本对齐方式";
            this.Load += new System.EventHandler(this.TxtAlignment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button hold;
        private System.Windows.Forms.Button unfold;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button justifyLeft;
        private System.Windows.Forms.Button justifyRight;
        private System.Windows.Forms.Button justifyCenter;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

