namespace BarCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axBarCodeCtrl1 = new AxBARCODELib.AxBarCodeCtrl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbbdirection = new System.Windows.Forms.ComboBox();
            this.cbbWidth = new System.Windows.Forms.ComboBox();
            this.cbbTrue = new System.Windows.Forms.ComboBox();
            this.cbbZstyle = new System.Windows.Forms.ComboBox();
            this.cbbstyle = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axBarCodeCtrl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "条形码：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(73, 174);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(199, 21);
            this.txtBarCode.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "打印";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.axBarCodeCtrl1);
            this.panel1.Location = new System.Drawing.Point(298, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 254);
            this.panel1.TabIndex = 5;
            // 
            // axBarCodeCtrl1
            // 
            this.axBarCodeCtrl1.Enabled = true;
            this.axBarCodeCtrl1.Location = new System.Drawing.Point(59, 55);
            this.axBarCodeCtrl1.Name = "axBarCodeCtrl1";
            this.axBarCodeCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBarCodeCtrl1.OcxState")));
            this.axBarCodeCtrl1.Size = new System.Drawing.Size(206, 138);
            this.axBarCodeCtrl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(288, 279);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.cbbdirection);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.txtBarCode);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.cbbWidth);
            this.tabPage1.Controls.Add(this.cbbTrue);
            this.tabPage1.Controls.Add(this.cbbZstyle);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbbstyle);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(280, 254);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(200, 17);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "显示数据";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbbdirection
            // 
            this.cbbdirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbdirection.FormattingEnabled = true;
            this.cbbdirection.Items.AddRange(new object[] {
            "0 - 0度",
            "1 - 90度",
            "2 - 180度",
            "3 - 270度"});
            this.cbbdirection.Location = new System.Drawing.Point(73, 141);
            this.cbbdirection.Name = "cbbdirection";
            this.cbbdirection.Size = new System.Drawing.Size(121, 20);
            this.cbbdirection.TabIndex = 15;
            this.cbbdirection.SelectedIndexChanged += new System.EventHandler(this.cbbdirection_SelectedIndexChanged);
            // 
            // cbbWidth
            // 
            this.cbbWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWidth.FormattingEnabled = true;
            this.cbbWidth.Items.AddRange(new object[] {
            "0 - 细",
            "1 - 特别淡",
            "2 - 淡",
            "3 - 普通",
            "4 - 中等",
            "5 - 粗",
            "6 - 浓",
            "7 - 特别浓"});
            this.cbbWidth.Location = new System.Drawing.Point(73, 110);
            this.cbbWidth.Name = "cbbWidth";
            this.cbbWidth.Size = new System.Drawing.Size(121, 20);
            this.cbbWidth.TabIndex = 14;
            this.cbbWidth.SelectedIndexChanged += new System.EventHandler(this.cbbWidth_SelectedIndexChanged);
            // 
            // cbbTrue
            // 
            this.cbbTrue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTrue.FormattingEnabled = true;
            this.cbbTrue.Items.AddRange(new object[] {
            "0 - 无",
            "1 - 无效时修复",
            "2 - 无效时空白"});
            this.cbbTrue.Location = new System.Drawing.Point(73, 78);
            this.cbbTrue.Name = "cbbTrue";
            this.cbbTrue.Size = new System.Drawing.Size(121, 20);
            this.cbbTrue.TabIndex = 13;
            this.cbbTrue.SelectedIndexChanged += new System.EventHandler(this.cbbTrue_SelectedIndexChanged);
            // 
            // cbbZstyle
            // 
            this.cbbZstyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbZstyle.FormattingEnabled = true;
            this.cbbZstyle.Items.AddRange(new object[] {
            "0 - Standard",
            "1 - 2-Digit Supplement",
            "2 - 5-Digit Supplement",
            "3 - POS Case Code"});
            this.cbbZstyle.Location = new System.Drawing.Point(73, 45);
            this.cbbZstyle.Name = "cbbZstyle";
            this.cbbZstyle.Size = new System.Drawing.Size(121, 20);
            this.cbbZstyle.TabIndex = 12;
            this.cbbZstyle.SelectedIndexChanged += new System.EventHandler(this.cbbZstyle_SelectedIndexChanged);
            // 
            // cbbstyle
            // 
            this.cbbstyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbstyle.FormattingEnabled = true;
            this.cbbstyle.Items.AddRange(new object[] {
            "0 - UPC-A",
            "1 - UPC-E",
            "2 - EAN-13",
            "3 - EAN-8",
            "4 - Case Code",
            "5 - Codabar(NW-7)",
            "6 - Code-39",
            "7 - Code-128",
            "8 - U.S. Postnet",
            "9 - U.S. Postal FIM",
            "10 - JP Post"});
            this.cbbstyle.Location = new System.Drawing.Point(73, 15);
            this.cbbstyle.Name = "cbbstyle";
            this.cbbstyle.Size = new System.Drawing.Size(121, 20);
            this.cbbstyle.TabIndex = 11;
            this.cbbstyle.SelectedIndexChanged += new System.EventHandler(this.cbbstyle_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "方向：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "样式：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "子样式：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "校验位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "线条宽度：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(617, 288);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通过控件生成条形码";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.axBarCodeCtrl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel panel1;
        private AxBARCODELib.AxBarCodeCtrl axBarCodeCtrl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cbbdirection;
        private System.Windows.Forms.ComboBox cbbWidth;
        private System.Windows.Forms.ComboBox cbbTrue;
        private System.Windows.Forms.ComboBox cbbZstyle;
        private System.Windows.Forms.ComboBox cbbstyle;


    }
}

