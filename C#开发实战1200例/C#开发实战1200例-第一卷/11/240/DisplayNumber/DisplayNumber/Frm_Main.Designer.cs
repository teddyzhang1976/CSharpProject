namespace DisplayNumber
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hold = new System.Windows.Forms.Button();
            this.unfold = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.figuresNumeration = new System.Windows.Forms.Button();
            this.programNumeration = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "内容区域";
            // 
            // hold
            // 
            this.hold.Location = new System.Drawing.Point(216, 29);
            this.hold.Name = "hold";
            this.hold.Size = new System.Drawing.Size(98, 23);
            this.hold.TabIndex = 2;
            this.hold.Text = "保存";
            this.hold.UseVisualStyleBackColor = true;
            this.hold.Click += new System.EventHandler(this.hold_Click);
            // 
            // unfold
            // 
            this.unfold.Location = new System.Drawing.Point(73, 29);
            this.unfold.Name = "unfold";
            this.unfold.Size = new System.Drawing.Size(98, 23);
            this.unfold.TabIndex = 1;
            this.unfold.Text = "打开";
            this.unfold.UseVisualStyleBackColor = true;
            this.unfold.Click += new System.EventHandler(this.unfold_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.figuresNumeration);
            this.groupBox2.Controls.Add(this.programNumeration);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 84);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "项目符号和编号";
            // 
            // figuresNumeration
            // 
            this.figuresNumeration.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.figuresNumeration.Image = global::DisplayNumber.Properties.Resources.数字编号;
            this.figuresNumeration.Location = new System.Drawing.Point(285, 27);
            this.figuresNumeration.Name = "figuresNumeration";
            this.figuresNumeration.Size = new System.Drawing.Size(52, 38);
            this.figuresNumeration.TabIndex = 5;
            this.figuresNumeration.UseVisualStyleBackColor = true;
            this.figuresNumeration.Click += new System.EventHandler(this.figuresNumeration_Click);
            // 
            // programNumeration
            // 
            this.programNumeration.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.programNumeration.Image = global::DisplayNumber.Properties.Resources.项目编号;
            this.programNumeration.Location = new System.Drawing.Point(120, 27);
            this.programNumeration.Name = "programNumeration";
            this.programNumeration.Size = new System.Drawing.Size(52, 38);
            this.programNumeration.TabIndex = 4;
            this.programNumeration.UseVisualStyleBackColor = true;
            this.programNumeration.Click += new System.EventHandler(this.programNumeration_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数字编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目符号：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.unfold);
            this.groupBox3.Controls.Add(this.hold);
            this.groupBox3.Location = new System.Drawing.Point(7, 307);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 68);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作文档";
            // 
            // DisplayNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 378);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DisplayNumber";
            this.Text = "在RichTextBox中实现项目符号功能";
            this.Load += new System.EventHandler(this.DisplayNumber_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button hold;
        private System.Windows.Forms.Button unfold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button figuresNumeration;
        private System.Windows.Forms.Button programNumeration;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

