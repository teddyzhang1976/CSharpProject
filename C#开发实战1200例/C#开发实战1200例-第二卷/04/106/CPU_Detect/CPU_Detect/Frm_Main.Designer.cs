namespace CPU_Detect
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCPU = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMuse = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.pbMemoryUse = new System.Windows.Forms.ProgressBar();
            this.pbMemorySum = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssluse = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblVuse = new System.Windows.Forms.Label();
            this.lblVinfo = new System.Windows.Forms.Label();
            this.pbVmemoryuse = new System.Windows.Forms.ProgressBar();
            this.pbVmemorysum = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPU 使用";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblCPU);
            this.panel1.Location = new System.Drawing.Point(7, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(74, 185);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Green;
            this.panel3.Location = new System.Drawing.Point(26, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(22, 154);
            this.panel3.TabIndex = 4;
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCPU.ForeColor = System.Drawing.Color.Lime;
            this.lblCPU.Location = new System.Drawing.Point(24, 172);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(0, 12);
            this.lblCPU.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMuse);
            this.groupBox2.Controls.Add(this.lblSum);
            this.groupBox2.Controls.Add(this.pbMemoryUse);
            this.groupBox2.Controls.Add(this.pbMemorySum);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(103, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "物理内存(K)";
            // 
            // lblMuse
            // 
            this.lblMuse.AutoSize = true;
            this.lblMuse.Location = new System.Drawing.Point(257, 61);
            this.lblMuse.Name = "lblMuse";
            this.lblMuse.Size = new System.Drawing.Size(41, 12);
            this.lblMuse.TabIndex = 7;
            this.lblMuse.Text = "label8";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(257, 39);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(41, 12);
            this.lblSum.TabIndex = 6;
            this.lblSum.Text = "label7";
            // 
            // pbMemoryUse
            // 
            this.pbMemoryUse.Location = new System.Drawing.Point(69, 61);
            this.pbMemoryUse.Name = "pbMemoryUse";
            this.pbMemoryUse.Size = new System.Drawing.Size(183, 13);
            this.pbMemoryUse.TabIndex = 4;
            // 
            // pbMemorySum
            // 
            this.pbMemorySum.Location = new System.Drawing.Point(69, 39);
            this.pbMemorySum.Name = "pbMemorySum";
            this.pbMemorySum.Size = new System.Drawing.Size(183, 13);
            this.pbMemorySum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "可用数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "总数：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslNum,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.tssluse});
            this.statusStrip1.Location = new System.Drawing.Point(0, 220);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(432, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "进程数：";
            // 
            // tsslNum
            // 
            this.tsslNum.AutoSize = false;
            this.tsslNum.Name = "tsslNum";
            this.tsslNum.Size = new System.Drawing.Size(50, 17);
            this.tsslNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("宋体", 10F);
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Gray;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel4.Text = "CPU 使用：";
            // 
            // tssluse
            // 
            this.tssluse.Name = "tssluse";
            this.tssluse.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblVuse);
            this.groupBox3.Controls.Add(this.lblVinfo);
            this.groupBox3.Controls.Add(this.pbVmemoryuse);
            this.groupBox3.Controls.Add(this.pbVmemorysum);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(103, 113);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(321, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "虚拟内存(K)";
            // 
            // lblVuse
            // 
            this.lblVuse.AutoSize = true;
            this.lblVuse.Location = new System.Drawing.Point(257, 61);
            this.lblVuse.Name = "lblVuse";
            this.lblVuse.Size = new System.Drawing.Size(41, 12);
            this.lblVuse.TabIndex = 9;
            this.lblVuse.Text = "label8";
            // 
            // lblVinfo
            // 
            this.lblVinfo.AutoSize = true;
            this.lblVinfo.Location = new System.Drawing.Point(257, 38);
            this.lblVinfo.Name = "lblVinfo";
            this.lblVinfo.Size = new System.Drawing.Size(41, 12);
            this.lblVinfo.TabIndex = 8;
            this.lblVinfo.Text = "label8";
            // 
            // pbVmemoryuse
            // 
            this.pbVmemoryuse.Location = new System.Drawing.Point(69, 60);
            this.pbVmemoryuse.Name = "pbVmemoryuse";
            this.pbVmemoryuse.Size = new System.Drawing.Size(183, 13);
            this.pbVmemoryuse.TabIndex = 4;
            // 
            // pbVmemorysum
            // 
            this.pbVmemorysum.Location = new System.Drawing.Point(69, 38);
            this.pbVmemorysum.Name = "pbVmemorysum";
            this.pbVmemorysum.Size = new System.Drawing.Size(183, 13);
            this.pbVmemorysum.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "可用数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "总数：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 242);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPU使用率";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslNum;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tssluse;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbMemoryUse;
        private System.Windows.Forms.ProgressBar pbMemorySum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar pbVmemoryuse;
        private System.Windows.Forms.ProgressBar pbVmemorysum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMuse;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label lblVuse;
        private System.Windows.Forms.Label lblVinfo;

    }
}

