namespace WYStockRealView
{
    partial class FormDirect
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
            this.Klinebutton = new System.Windows.Forms.Button();
            this.RealTimebutton = new System.Windows.Forms.Button();
            this.PICDEMO = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Klinebutton
            // 
            this.Klinebutton.Location = new System.Drawing.Point(12, 3);
            this.Klinebutton.Name = "Klinebutton";
            this.Klinebutton.Size = new System.Drawing.Size(75, 23);
            this.Klinebutton.TabIndex = 0;
            this.Klinebutton.Text = "K线图";
            this.Klinebutton.UseVisualStyleBackColor = true;
            this.Klinebutton.Click += new System.EventHandler(this.Klinebutton_Click);
            // 
            // RealTimebutton
            // 
            this.RealTimebutton.Location = new System.Drawing.Point(12, 60);
            this.RealTimebutton.Name = "RealTimebutton";
            this.RealTimebutton.Size = new System.Drawing.Size(75, 23);
            this.RealTimebutton.TabIndex = 1;
            this.RealTimebutton.Text = "分时走势";
            this.RealTimebutton.UseVisualStyleBackColor = true;
            this.RealTimebutton.Click += new System.EventHandler(this.RealTimebutton_Click);
            // 
            // PICDEMO
            // 
            this.PICDEMO.Location = new System.Drawing.Point(12, 89);
            this.PICDEMO.Name = "PICDEMO";
            this.PICDEMO.Size = new System.Drawing.Size(75, 23);
            this.PICDEMO.TabIndex = 2;
            this.PICDEMO.Text = "图形化演示";
            this.PICDEMO.UseVisualStyleBackColor = true;
            this.PICDEMO.Click += new System.EventHandler(this.PICDEMO_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "多K线图";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "显示图";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormDirect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 498);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PICDEMO);
            this.Controls.Add(this.RealTimebutton);
            this.Controls.Add(this.Klinebutton);
            this.Name = "FormDirect";
            this.Text = "FormDirect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Klinebutton;
        private System.Windows.Forms.Button RealTimebutton;
        private System.Windows.Forms.Button PICDEMO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

