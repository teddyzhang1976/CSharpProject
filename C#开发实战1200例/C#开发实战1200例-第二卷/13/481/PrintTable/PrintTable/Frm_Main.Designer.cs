namespace PrintTable
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReflush = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtSMoney = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtGMoney = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtxtInDate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxGUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGNum = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtGSpec = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtGName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtGID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInProvider = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInPeople = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReflush);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(570, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(95, 168);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // btnReflush
            // 
            this.btnReflush.Location = new System.Drawing.Point(10, 129);
            this.btnReflush.Name = "btnReflush";
            this.btnReflush.Size = new System.Drawing.Size(75, 31);
            this.btnReflush.TabIndex = 15;
            this.btnReflush.Text = "刷新";
            this.btnReflush.UseVisualStyleBackColor = true;
            this.btnReflush.Click += new System.EventHandler(this.btnReflush_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(10, 92);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 31);
            this.btnDel.TabIndex = 14;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(10, 55);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 31);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 31);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(40, 155);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(520, 78);
            this.txtRemark.TabIndex = 11;
            this.txtRemark.Text = "";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(14, 140);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 48;
            this.label25.Text = "备注：";
            // 
            // txtSMoney
            // 
            this.txtSMoney.Location = new System.Drawing.Point(292, 109);
            this.txtSMoney.Name = "txtSMoney";
            this.txtSMoney.ReadOnly = true;
            this.txtSMoney.Size = new System.Drawing.Size(92, 21);
            this.txtSMoney.TabIndex = 19;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(239, 112);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 41;
            this.label22.Text = "总金额：";
            // 
            // txtGMoney
            // 
            this.txtGMoney.Location = new System.Drawing.Point(54, 109);
            this.txtGMoney.Name = "txtGMoney";
            this.txtGMoney.Size = new System.Drawing.Size(60, 21);
            this.txtGMoney.TabIndex = 8;
            this.txtGMoney.TextChanged += new System.EventHandler(this.txtGMoney_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 34;
            this.label18.Text = "单价：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtxtInDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboxGUnit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.txtSMoney);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtGNum);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtGMoney);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtGSpec);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtGName);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtGID);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtPlace);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtInProvider);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtInPeople);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 243);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品入库信息";
            // 
            // mtxtInDate
            // 
            this.mtxtInDate.Location = new System.Drawing.Point(460, 108);
            this.mtxtInDate.Mask = "0000-00-00";
            this.mtxtInDate.Name = "mtxtInDate";
            this.mtxtInDate.Size = new System.Drawing.Size(100, 21);
            this.mtxtInDate.TabIndex = 10;
            this.mtxtInDate.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 60;
            this.label5.Text = "进货日期：";
            // 
            // cboxGUnit
            // 
            this.cboxGUnit.FormattingEnabled = true;
            this.cboxGUnit.Items.AddRange(new object[] {
            "个",
            "本",
            "台",
            "套",
            "件"});
            this.cboxGUnit.Location = new System.Drawing.Point(511, 80);
            this.cboxGUnit.Name = "cboxGUnit";
            this.cboxGUnit.Size = new System.Drawing.Size(49, 20);
            this.cboxGUnit.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 58;
            this.label3.Text = "计量单位：";
            // 
            // txtGNum
            // 
            this.txtGNum.Location = new System.Drawing.Point(167, 109);
            this.txtGNum.Name = "txtGNum";
            this.txtGNum.Size = new System.Drawing.Size(62, 21);
            this.txtGNum.TabIndex = 9;
            this.txtGNum.TextChanged += new System.EventHandler(this.txtGNum_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(124, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 36;
            this.label20.Text = "数量：";
            // 
            // txtGSpec
            // 
            this.txtGSpec.Location = new System.Drawing.Point(279, 80);
            this.txtGSpec.Name = "txtGSpec";
            this.txtGSpec.Size = new System.Drawing.Size(162, 21);
            this.txtGSpec.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(239, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "规格：";
            // 
            // txtGName
            // 
            this.txtGName.Location = new System.Drawing.Point(76, 80);
            this.txtGName.Name = "txtGName";
            this.txtGName.Size = new System.Drawing.Size(153, 21);
            this.txtGName.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 26;
            this.label14.Text = "商品名称：";
            // 
            // txtGID
            // 
            this.txtGID.Location = new System.Drawing.Point(426, 50);
            this.txtGID.Name = "txtGID";
            this.txtGID.Size = new System.Drawing.Size(134, 21);
            this.txtGID.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(363, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "商品编号：";
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(54, 50);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(300, 21);
            this.txtPlace.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "产地：";
            // 
            // txtInProvider
            // 
            this.txtInProvider.Location = new System.Drawing.Point(407, 20);
            this.txtInProvider.Name = "txtInProvider";
            this.txtInProvider.Size = new System.Drawing.Size(153, 21);
            this.txtInProvider.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "供货单位：";
            // 
            // txtInPeople
            // 
            this.txtInPeople.Location = new System.Drawing.Point(243, 20);
            this.txtInPeople.Name = "txtInPeople";
            this.txtInPeople.Size = new System.Drawing.Size(88, 21);
            this.txtInPeople.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "入库人：";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(54, 20);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(125, 21);
            this.txtID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号：";
            // 
            // dgvInfo
            // 
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Location = new System.Drawing.Point(6, 255);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.Size = new System.Drawing.Size(673, 209);
            this.dgvInfo.TabIndex = 16;
            this.dgvInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfo_CellClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(604, 468);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 31);
            this.btnPrint.TabIndex = 31;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 502);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvInfo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品入库信息";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReflush;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox txtRemark;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtSMoney;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtGMoney;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGNum;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtGSpec;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtGName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtGID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInPeople;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cboxGUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtxtInDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}

