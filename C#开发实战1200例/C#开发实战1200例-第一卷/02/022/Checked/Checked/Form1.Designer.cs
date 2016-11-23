namespace Checked
{
    partial class Form1
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
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.txt_Add_Two = new System.Windows.Forms.TextBox();
            this.txt_Add_One = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Get = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Result
            // 
            this.txt_Result.Location = new System.Drawing.Point(222, 24);
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.Size = new System.Drawing.Size(52, 21);
            this.txt_Result.TabIndex = 11;
            // 
            // txt_Add_Two
            // 
            this.txt_Add_Two.Location = new System.Drawing.Point(149, 24);
            this.txt_Add_Two.Name = "txt_Add_Two";
            this.txt_Add_Two.Size = new System.Drawing.Size(52, 21);
            this.txt_Add_Two.TabIndex = 10;
            this.txt_Add_Two.Text = "200";
            // 
            // txt_Add_One
            // 
            this.txt_Add_One.Location = new System.Drawing.Point(74, 24);
            this.txt_Add_One.Name = "txt_Add_One";
            this.txt_Add_One.Size = new System.Drawing.Size(52, 21);
            this.txt_Add_One.TabIndex = 9;
            this.txt_Add_One.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "+";
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(136, 66);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(75, 23);
            this.btn_Get.TabIndex = 6;
            this.btn_Get.Text = "计算";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 97);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.txt_Add_Two);
            this.Controls.Add(this.txt_Add_One);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Get);
            this.Name = "Form1";
            this.Text = "使用checked运算符处理“溢出”错误";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Result;
        private System.Windows.Forms.TextBox txt_Add_Two;
        private System.Windows.Forms.TextBox txt_Add_One;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Get;
    }
}

