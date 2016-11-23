namespace PortFolio.View.AccountManager
{
    partial class AccountEditDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.accountNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.accountPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.accountPasswordConfirmTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.initMoneyPooltextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.accountMemoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.commissionRationTextBox = new System.Windows.Forms.TextBox();
            this.minCommissionTextBox = new System.Windows.Forms.TextBox();
            this.taxRatioTextBox = new System.Windows.Forms.TextBox();
            this.delegateFeeRatioTextBox = new System.Windows.Forms.TextBox();
            this.transferFeeRatioTextBox = new System.Windows.Forms.TextBox();
            this.minTransferFeeTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.traderNameComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "账户名称：";
            // 
            // accountNameTextBox
            // 
            this.accountNameTextBox.Location = new System.Drawing.Point(93, 26);
            this.accountNameTextBox.Name = "accountNameTextBox";
            this.accountNameTextBox.Size = new System.Drawing.Size(96, 21);
            this.accountNameTextBox.TabIndex = 1;
            this.accountNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.accountNameTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "账户密码：";
            // 
            // accountPasswordTextBox
            // 
            this.accountPasswordTextBox.Location = new System.Drawing.Point(93, 71);
            this.accountPasswordTextBox.Name = "accountPasswordTextBox";
            this.accountPasswordTextBox.Size = new System.Drawing.Size(96, 21);
            this.accountPasswordTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "密码确认：";
            // 
            // accountPasswordConfirmTtextBox
            // 
            this.accountPasswordConfirmTextBox.Location = new System.Drawing.Point(93, 110);
            this.accountPasswordConfirmTextBox.Name = "accountPasswordConfirmTtextBox";
            this.accountPasswordConfirmTextBox.Size = new System.Drawing.Size(96, 21);
            this.accountPasswordConfirmTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "初始资金：";
            // 
            // initMoneyPooltextBox
            // 
            this.initMoneyPooltextBox.Location = new System.Drawing.Point(93, 150);
            this.initMoneyPooltextBox.Name = "initMoneyPooltextBox";
            this.initMoneyPooltextBox.Size = new System.Drawing.Size(96, 21);
            this.initMoneyPooltextBox.TabIndex = 1;
            this.initMoneyPooltextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericValidateKeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "账户备注：";
            // 
            // accountMemoRichTextBox
            // 
            this.accountMemoRichTextBox.Location = new System.Drawing.Point(93, 193);
            this.accountMemoRichTextBox.Name = "accountMemoRichTextBox";
            this.accountMemoRichTextBox.Size = new System.Drawing.Size(606, 127);
            this.accountMemoRichTextBox.TabIndex = 2;
            this.accountMemoRichTextBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(560, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "佣金费率：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "最低佣金：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "印花税率：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(532, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "委托费率：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(532, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "过户费率：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(532, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "最低过户费：";
            // 
            // commissionRationTextBox
            // 
            this.commissionRationTextBox.Location = new System.Drawing.Point(349, 26);
            this.commissionRationTextBox.Name = "commissionRationTextBox";
            this.commissionRationTextBox.Size = new System.Drawing.Size(96, 21);
            this.commissionRationTextBox.TabIndex = 1;
            this.commissionRationTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericValidateKeyPress);
            // 
            // minCommissionTextBox
            // 
            this.minCommissionTextBox.Location = new System.Drawing.Point(349, 71);
            this.minCommissionTextBox.Name = "minCommissionTextBox";
            this.minCommissionTextBox.Size = new System.Drawing.Size(96, 21);
            this.minCommissionTextBox.TabIndex = 1;
            this.minCommissionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericValidateKeyPress);
            // 
            // taxRatioTextBox
            // 
            this.taxRatioTextBox.Location = new System.Drawing.Point(349, 113);
            this.taxRatioTextBox.Name = "taxRatioTextBox";
            this.taxRatioTextBox.Size = new System.Drawing.Size(96, 21);
            this.taxRatioTextBox.TabIndex = 1;
            this.taxRatioTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericValidateKeyPress);
            // 
            // delegateFeeRatioTextBox
            // 
            this.delegateFeeRatioTextBox.Location = new System.Drawing.Point(603, 113);
            this.delegateFeeRatioTextBox.Name = "delegateFeeRatioTextBox";
            this.delegateFeeRatioTextBox.Size = new System.Drawing.Size(96, 21);
            this.delegateFeeRatioTextBox.TabIndex = 1;
            this.delegateFeeRatioTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericValidateKeyPress);
            // 
            // transferFeeRatioTextBox
            // 
            this.transferFeeRatioTextBox.Location = new System.Drawing.Point(603, 26);
            this.transferFeeRatioTextBox.Name = "transferFeeRatioTextBox";
            this.transferFeeRatioTextBox.Size = new System.Drawing.Size(96, 21);
            this.transferFeeRatioTextBox.TabIndex = 1;
            this.transferFeeRatioTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericValidateKeyPress);
            // 
            // minTransferFeeTextBox
            // 
            this.minTransferFeeTextBox.Location = new System.Drawing.Point(603, 69);
            this.minTransferFeeTextBox.Name = "minTransferFeeTextBox";
            this.minTransferFeeTextBox.Size = new System.Drawing.Size(96, 21);
            this.minTransferFeeTextBox.TabIndex = 1;
            this.minTransferFeeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericValidateKeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(451, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(705, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 4;
            this.label13.Text = "%";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(451, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "%";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(705, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "%";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(278, 156);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "交易商名字：";
            // 
            // traderNameComboBox
            // 
            this.traderNameComboBox.FormattingEnabled = true;
            this.traderNameComboBox.Items.AddRange(new object[] {
            "华泰证券",
            "长城证券",
            "东方证券",
            "华夏证券",
            "同福证券",
            "平安证券",
            "华富证券"});
            this.traderNameComboBox.Location = new System.Drawing.Point(349, 151);
            this.traderNameComboBox.Name = "traderNameComboBox";
            this.traderNameComboBox.Size = new System.Drawing.Size(102, 20);
            this.traderNameComboBox.TabIndex = 5;
            // 
            // AccountEditDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 380);
            this.Controls.Add(this.traderNameComboBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.accountMemoRichTextBox);
            this.Controls.Add(this.initMoneyPooltextBox);
            this.Controls.Add(this.accountPasswordConfirmTextBox);
            this.Controls.Add(this.accountPasswordTextBox);
            this.Controls.Add(this.minTransferFeeTextBox);
            this.Controls.Add(this.transferFeeRatioTextBox);
            this.Controls.Add(this.delegateFeeRatioTextBox);
            this.Controls.Add(this.taxRatioTextBox);
            this.Controls.Add(this.minCommissionTextBox);
            this.Controls.Add(this.commissionRationTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.accountNameTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AccountEditDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AccountEdit";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox accountNameTextBox;
        public System.Windows.Forms.TextBox accountPasswordTextBox;
        public System.Windows.Forms.TextBox accountPasswordConfirmTextBox;
        public System.Windows.Forms.TextBox initMoneyPooltextBox;
        public System.Windows.Forms.RichTextBox accountMemoRichTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox commissionRationTextBox;
        public System.Windows.Forms.TextBox minCommissionTextBox;
        public System.Windows.Forms.TextBox taxRatioTextBox;
        public System.Windows.Forms.TextBox delegateFeeRatioTextBox;
        public System.Windows.Forms.TextBox transferFeeRatioTextBox;
        public System.Windows.Forms.TextBox minTransferFeeTextBox;
        public System.Windows.Forms.ComboBox traderNameComboBox;
    }
}