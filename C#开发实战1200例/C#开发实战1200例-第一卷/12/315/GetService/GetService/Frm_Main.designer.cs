namespace GetService
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
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Status = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.White;
            this.btn_Start.Enabled = false;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.ForeColor = System.Drawing.Color.Red;
            this.btn_Start.Location = new System.Drawing.Point(102, 133);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(104, 23);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "启动IIS服务(&W)";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackColor = System.Drawing.Color.White;
            this.btn_Stop.Enabled = false;
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Stop.ForeColor = System.Drawing.Color.Red;
            this.btn_Stop.Location = new System.Drawing.Point(193, 213);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(104, 23);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "停止IIS服务(&Q)";
            this.btn_Stop.UseVisualStyleBackColor = false;
            this.btn_Stop.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Status
            // 
            this.btn_Status.BackColor = System.Drawing.Color.White;
            this.btn_Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Status.ForeColor = System.Drawing.Color.Red;
            this.btn_Status.Location = new System.Drawing.Point(193, 56);
            this.btn_Status.Name = "btn_Status";
            this.btn_Status.Size = new System.Drawing.Size(104, 23);
            this.btn_Status.TabIndex = 2;
            this.btn_Status.Text = "IIS服务状态(&D)";
            this.btn_Status.UseVisualStyleBackColor = false;
            this.btn_Status.Click += new System.EventHandler(this.button3_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GetService.Properties.Resources._20080811_b7e5eb1623139377650eJ32s2hJgG4uy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(432, 280);
            this.Controls.Add(this.btn_Status);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用ServiceController组件计算机的服务";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Status;
    }
}

