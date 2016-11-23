namespace AddElementInArray
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
            this.btn_RArray = new System.Windows.Forms.Button();
            this.txt_RArray = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Element = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbox_NArray = new System.Windows.Forms.RichTextBox();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_RArray
            // 
            this.btn_RArray.Location = new System.Drawing.Point(15, 13);
            this.btn_RArray.Name = "btn_RArray";
            this.btn_RArray.Size = new System.Drawing.Size(97, 23);
            this.btn_RArray.TabIndex = 0;
            this.btn_RArray.Text = "随机生成数组";
            this.btn_RArray.UseVisualStyleBackColor = true;
            this.btn_RArray.Click += new System.EventHandler(this.btn_RArray_Click);
            // 
            // txt_RArray
            // 
            this.txt_RArray.Location = new System.Drawing.Point(119, 14);
            this.txt_RArray.Name = "txt_RArray";
            this.txt_RArray.Size = new System.Drawing.Size(148, 21);
            this.txt_RArray.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请输入要插入的元素：";
            // 
            // txt_Element
            // 
            this.txt_Element.Location = new System.Drawing.Point(135, 44);
            this.txt_Element.Name = "txt_Element";
            this.txt_Element.Size = new System.Drawing.Size(82, 21);
            this.txt_Element.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "新数组：";
            // 
            // rtbox_NArray
            // 
            this.rtbox_NArray.Location = new System.Drawing.Point(32, 91);
            this.rtbox_NArray.Name = "rtbox_NArray";
            this.rtbox_NArray.Size = new System.Drawing.Size(235, 44);
            this.rtbox_NArray.TabIndex = 5;
            this.rtbox_NArray.Text = "";
            // 
            // btn_Sure
            // 
            this.btn_Sure.Location = new System.Drawing.Point(223, 42);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(46, 23);
            this.btn_Sure.TabIndex = 7;
            this.btn_Sure.Text = "确定";
            this.btn_Sure.UseVisualStyleBackColor = true;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 147);
            this.Controls.Add(this.btn_Sure);
            this.Controls.Add(this.rtbox_NArray);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Element);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_RArray);
            this.Controls.Add(this.btn_RArray);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在数组中添加一个元素";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RArray;
        private System.Windows.Forms.TextBox txt_RArray;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Element;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbox_NArray;
        private System.Windows.Forms.Button btn_Sure;
    }
}

