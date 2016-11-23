namespace ExchangeItem
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
            this.lb_Source = new System.Windows.Forms.ListBox();
            this.lb_Choose = new System.Windows.Forms.ListBox();
            this.btn_Get = new System.Windows.Forms.Button();
            this.btn_Gets = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Cancels = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Source
            // 
            this.lb_Source.FormattingEnabled = true;
            this.lb_Source.ItemHeight = 12;
            this.lb_Source.Location = new System.Drawing.Point(12, 24);
            this.lb_Source.Name = "lb_Source";
            this.lb_Source.Size = new System.Drawing.Size(84, 148);
            this.lb_Source.TabIndex = 0;
            // 
            // lb_Choose
            // 
            this.lb_Choose.FormattingEnabled = true;
            this.lb_Choose.ItemHeight = 12;
            this.lb_Choose.Location = new System.Drawing.Point(183, 24);
            this.lb_Choose.Name = "lb_Choose";
            this.lb_Choose.Size = new System.Drawing.Size(94, 148);
            this.lb_Choose.TabIndex = 2;
            // 
            // btn_Get
            // 
            this.btn_Get.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Get.Location = new System.Drawing.Point(102, 36);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(75, 23);
            this.btn_Get.TabIndex = 3;
            this.btn_Get.Text = ">>";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Gets
            // 
            this.btn_Gets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Gets.Location = new System.Drawing.Point(102, 108);
            this.btn_Gets.Name = "btn_Gets";
            this.btn_Gets.Size = new System.Drawing.Size(75, 23);
            this.btn_Gets.TabIndex = 4;
            this.btn_Gets.Text = "<<";
            this.btn_Gets.UseVisualStyleBackColor = true;
            this.btn_Gets.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "图书";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Location = new System.Drawing.Point(102, 66);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = ">";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Cancels
            // 
            this.btn_Cancels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancels.Location = new System.Drawing.Point(102, 137);
            this.btn_Cancels.Name = "btn_Cancels";
            this.btn_Cancels.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancels.TabIndex = 8;
            this.btn_Cancels.Text = "<";
            this.btn_Cancels.UseVisualStyleBackColor = true;
            this.btn_Cancels.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "购物车";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 179);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Cancels);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Gets);
            this.Controls.Add(this.btn_Get);
            this.Controls.Add(this.lb_Choose);
            this.Controls.Add(this.lb_Source);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在ListBox控件间交换数据";
            this.Load += new System.EventHandler(this.frmListBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Source;
        private System.Windows.Forms.ListBox lb_Choose;
        private System.Windows.Forms.Button btn_Get;
        private System.Windows.Forms.Button btn_Gets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Cancels;
        private System.Windows.Forms.Label label3;
    }
}