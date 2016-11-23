namespace SnatchVoiceDeviceName
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
            this.aristotle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.snatch = new System.Windows.Forms.Button();
            this.VoiceDeviceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.aristotle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.snatch);
            this.groupBox1.Controls.Add(this.VoiceDeviceName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作类型";
            // 
            // aristotle
            // 
            this.aristotle.Location = new System.Drawing.Point(93, 56);
            this.aristotle.Name = "aristotle";
            this.aristotle.ReadOnly = true;
            this.aristotle.Size = new System.Drawing.Size(170, 21);
            this.aristotle.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "PNPDeviceID ：";
            // 
            // snatch
            // 
            this.snatch.Location = new System.Drawing.Point(201, 83);
            this.snatch.Name = "snatch";
            this.snatch.Size = new System.Drawing.Size(62, 23);
            this.snatch.TabIndex = 2;
            this.snatch.Text = "获取";
            this.snatch.UseVisualStyleBackColor = true;
            this.snatch.Click += new System.EventHandler(this.snatch_Click);
            // 
            // VoiceDeviceName
            // 
            this.VoiceDeviceName.Location = new System.Drawing.Point(93, 30);
            this.VoiceDeviceName.Name = "VoiceDeviceName";
            this.VoiceDeviceName.ReadOnly = true;
            this.VoiceDeviceName.Size = new System.Drawing.Size(170, 21);
            this.VoiceDeviceName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "声音设备名称：";
            // 
            // SnatchVoiceDeviceNameAndID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 138);
            this.Controls.Add(this.groupBox1);
            this.Name = "SnatchVoiceDeviceNameAndID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "获取声音设备的名称及PNPDeviceID";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button snatch;
        private System.Windows.Forms.TextBox VoiceDeviceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox aristotle;
        private System.Windows.Forms.Label label2;
    }
}

