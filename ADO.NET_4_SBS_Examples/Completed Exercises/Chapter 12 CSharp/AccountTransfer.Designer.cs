namespace Chapter_12_CSharp
{
    partial class AccountTransfer
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
            this.UseDistributed = new System.Windows.Forms.CheckBox();
            this.OptFromSavings = new System.Windows.Forms.RadioButton();
            this.OptFromChecking = new System.Windows.Forms.RadioButton();
            this.LabelTransferAmount = new System.Windows.Forms.Label();
            this.LabelTransferType = new System.Windows.Forms.Label();
            this.SavingsBalance = new System.Windows.Forms.Label();
            this.CheckingBalance = new System.Windows.Forms.Label();
            this.LabelSavingsBalance = new System.Windows.Forms.Label();
            this.LabelCheckingBalance = new System.Windows.Forms.Label();
            this.TransferAmount = new System.Windows.Forms.TextBox();
            this.ActTransfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UseDistributed
            // 
            this.UseDistributed.AutoSize = true;
            this.UseDistributed.Location = new System.Drawing.Point(112, 136);
            this.UseDistributed.Name = "UseDistributed";
            this.UseDistributed.Size = new System.Drawing.Size(160, 17);
            this.UseDistributed.TabIndex = 9;
            this.UseDistributed.Text = "Use a &distributed transaction";
            this.UseDistributed.UseVisualStyleBackColor = true;
            // 
            // OptFromSavings
            // 
            this.OptFromSavings.AutoSize = true;
            this.OptFromSavings.Location = new System.Drawing.Point(112, 80);
            this.OptFromSavings.Name = "OptFromSavings";
            this.OptFromSavings.Size = new System.Drawing.Size(153, 17);
            this.OptFromSavings.TabIndex = 6;
            this.OptFromSavings.Text = "From &Savings To Checking";
            this.OptFromSavings.UseVisualStyleBackColor = true;
            // 
            // OptFromChecking
            // 
            this.OptFromChecking.AutoSize = true;
            this.OptFromChecking.Checked = true;
            this.OptFromChecking.Location = new System.Drawing.Point(112, 56);
            this.OptFromChecking.Name = "OptFromChecking";
            this.OptFromChecking.Size = new System.Drawing.Size(153, 17);
            this.OptFromChecking.TabIndex = 5;
            this.OptFromChecking.TabStop = true;
            this.OptFromChecking.Text = "From &Checking To Savings";
            this.OptFromChecking.UseVisualStyleBackColor = true;
            // 
            // LabelTransferAmount
            // 
            this.LabelTransferAmount.AutoSize = true;
            this.LabelTransferAmount.Location = new System.Drawing.Point(8, 106);
            this.LabelTransferAmount.Name = "LabelTransferAmount";
            this.LabelTransferAmount.Size = new System.Drawing.Size(88, 13);
            this.LabelTransferAmount.TabIndex = 7;
            this.LabelTransferAmount.Text = "Transfer &Amount:";
            // 
            // LabelTransferType
            // 
            this.LabelTransferType.AutoSize = true;
            this.LabelTransferType.Location = new System.Drawing.Point(8, 58);
            this.LabelTransferType.Name = "LabelTransferType";
            this.LabelTransferType.Size = new System.Drawing.Size(76, 13);
            this.LabelTransferType.TabIndex = 4;
            this.LabelTransferType.Text = "Transfer Type:";
            // 
            // SavingsBalance
            // 
            this.SavingsBalance.AutoSize = true;
            this.SavingsBalance.Location = new System.Drawing.Point(168, 32);
            this.SavingsBalance.Name = "SavingsBalance";
            this.SavingsBalance.Size = new System.Drawing.Size(34, 13);
            this.SavingsBalance.TabIndex = 3;
            this.SavingsBalance.Text = "$0.00";
            this.SavingsBalance.UseMnemonic = false;
            // 
            // CheckingBalance
            // 
            this.CheckingBalance.AutoSize = true;
            this.CheckingBalance.Location = new System.Drawing.Point(168, 8);
            this.CheckingBalance.Name = "CheckingBalance";
            this.CheckingBalance.Size = new System.Drawing.Size(34, 13);
            this.CheckingBalance.TabIndex = 1;
            this.CheckingBalance.Text = "$0.00";
            this.CheckingBalance.UseMnemonic = false;
            // 
            // LabelSavingsBalance
            // 
            this.LabelSavingsBalance.AutoSize = true;
            this.LabelSavingsBalance.Location = new System.Drawing.Point(8, 32);
            this.LabelSavingsBalance.Name = "LabelSavingsBalance";
            this.LabelSavingsBalance.Size = new System.Drawing.Size(148, 13);
            this.LabelSavingsBalance.TabIndex = 2;
            this.LabelSavingsBalance.Text = "Savings Account 987654321:";
            // 
            // LabelCheckingBalance
            // 
            this.LabelCheckingBalance.AutoSize = true;
            this.LabelCheckingBalance.Location = new System.Drawing.Point(8, 8);
            this.LabelCheckingBalance.Name = "LabelCheckingBalance";
            this.LabelCheckingBalance.Size = new System.Drawing.Size(158, 13);
            this.LabelCheckingBalance.TabIndex = 0;
            this.LabelCheckingBalance.Text = "Checking Account 123456789: ";
            // 
            // TransferAmount
            // 
            this.TransferAmount.Location = new System.Drawing.Point(112, 104);
            this.TransferAmount.MaxLength = 20;
            this.TransferAmount.Name = "TransferAmount";
            this.TransferAmount.Size = new System.Drawing.Size(208, 20);
            this.TransferAmount.TabIndex = 8;
            this.TransferAmount.Enter += new System.EventHandler(this.TransferAmount_Enter);
            // 
            // ActTransfer
            // 
            this.ActTransfer.Location = new System.Drawing.Point(245, 160);
            this.ActTransfer.Name = "ActTransfer";
            this.ActTransfer.Size = new System.Drawing.Size(75, 23);
            this.ActTransfer.TabIndex = 10;
            this.ActTransfer.Text = "Transfer";
            this.ActTransfer.UseVisualStyleBackColor = true;
            this.ActTransfer.Click += new System.EventHandler(this.ActTransfer_Click);
            // 
            // AccountTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 194);
            this.Controls.Add(this.UseDistributed);
            this.Controls.Add(this.OptFromSavings);
            this.Controls.Add(this.OptFromChecking);
            this.Controls.Add(this.LabelTransferAmount);
            this.Controls.Add(this.LabelTransferType);
            this.Controls.Add(this.SavingsBalance);
            this.Controls.Add(this.CheckingBalance);
            this.Controls.Add(this.LabelSavingsBalance);
            this.Controls.Add(this.LabelCheckingBalance);
            this.Controls.Add(this.TransferAmount);
            this.Controls.Add(this.ActTransfer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AccountTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 12 - Account Transfer";
            this.Load += new System.EventHandler(this.AccountTransfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox UseDistributed;
        internal System.Windows.Forms.RadioButton OptFromSavings;
        internal System.Windows.Forms.RadioButton OptFromChecking;
        internal System.Windows.Forms.Label LabelTransferAmount;
        internal System.Windows.Forms.Label LabelTransferType;
        internal System.Windows.Forms.Label SavingsBalance;
        internal System.Windows.Forms.Label CheckingBalance;
        internal System.Windows.Forms.Label LabelSavingsBalance;
        internal System.Windows.Forms.Label LabelCheckingBalance;
        internal System.Windows.Forms.TextBox TransferAmount;
        internal System.Windows.Forms.Button ActTransfer;
    }
}

