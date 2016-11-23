namespace Chapter_3_CSharp
{
    partial class AccountDetail
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
            this.StartDate = new System.Windows.Forms.TextBox();
            this.AnnualFee = new System.Windows.Forms.TextBox();
            this.AccountID = new System.Windows.Forms.Label();
            this.LabelDate = new System.Windows.Forms.Label();
            this.LabelFee = new System.Windows.Forms.Label();
            this.LabelName = new System.Windows.Forms.Label();
            this.ActCancel = new System.Windows.Forms.Button();
            this.AccountName = new System.Windows.Forms.TextBox();
            this.LabelAccountID = new System.Windows.Forms.Label();
            this.ActiveAccount = new System.Windows.Forms.CheckBox();
            this.ActOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartDate
            // 
            this.StartDate.Location = new System.Drawing.Point(72, 81);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(208, 20);
            this.StartDate.TabIndex = 8;
            this.StartDate.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // AnnualFee
            // 
            this.AnnualFee.Location = new System.Drawing.Point(72, 57);
            this.AnnualFee.Name = "AnnualFee";
            this.AnnualFee.Size = new System.Drawing.Size(208, 20);
            this.AnnualFee.TabIndex = 6;
            this.AnnualFee.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // AccountID
            // 
            this.AccountID.AutoSize = true;
            this.AccountID.Location = new System.Drawing.Point(72, 11);
            this.AccountID.Name = "AccountID";
            this.AccountID.Size = new System.Drawing.Size(29, 13);
            this.AccountID.TabIndex = 1;
            this.AccountID.Text = "New";
            this.AccountID.UseMnemonic = false;
            // 
            // LabelDate
            // 
            this.LabelDate.AutoSize = true;
            this.LabelDate.Location = new System.Drawing.Point(8, 83);
            this.LabelDate.Name = "LabelDate";
            this.LabelDate.Size = new System.Drawing.Size(58, 13);
            this.LabelDate.TabIndex = 7;
            this.LabelDate.Text = "&Start Date:";
            // 
            // LabelFee
            // 
            this.LabelFee.AutoSize = true;
            this.LabelFee.Location = new System.Drawing.Point(8, 59);
            this.LabelFee.Name = "LabelFee";
            this.LabelFee.Size = new System.Drawing.Size(64, 13);
            this.LabelFee.TabIndex = 5;
            this.LabelFee.Text = "&Annual Fee:";
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(8, 35);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(38, 13);
            this.LabelName.TabIndex = 3;
            this.LabelName.Text = "&Name:";
            // 
            // ActCancel
            // 
            this.ActCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActCancel.Location = new System.Drawing.Point(208, 113);
            this.ActCancel.Name = "ActCancel";
            this.ActCancel.Size = new System.Drawing.Size(75, 23);
            this.ActCancel.TabIndex = 10;
            this.ActCancel.Text = "Cancel";
            this.ActCancel.UseVisualStyleBackColor = true;
            // 
            // AccountName
            // 
            this.AccountName.Location = new System.Drawing.Point(72, 33);
            this.AccountName.Name = "AccountName";
            this.AccountName.Size = new System.Drawing.Size(208, 20);
            this.AccountName.TabIndex = 4;
            this.AccountName.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelAccountID
            // 
            this.LabelAccountID.AutoSize = true;
            this.LabelAccountID.Location = new System.Drawing.Point(8, 11);
            this.LabelAccountID.Name = "LabelAccountID";
            this.LabelAccountID.Size = new System.Drawing.Size(21, 13);
            this.LabelAccountID.TabIndex = 0;
            this.LabelAccountID.Text = "ID:";
            // 
            // ActiveAccount
            // 
            this.ActiveAccount.AutoSize = true;
            this.ActiveAccount.Checked = true;
            this.ActiveAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ActiveAccount.Location = new System.Drawing.Point(224, 9);
            this.ActiveAccount.Name = "ActiveAccount";
            this.ActiveAccount.Size = new System.Drawing.Size(56, 17);
            this.ActiveAccount.TabIndex = 2;
            this.ActiveAccount.Text = "&Active";
            this.ActiveAccount.UseVisualStyleBackColor = true;
            // 
            // ActOK
            // 
            this.ActOK.Location = new System.Drawing.Point(128, 113);
            this.ActOK.Name = "ActOK";
            this.ActOK.Size = new System.Drawing.Size(75, 23);
            this.ActOK.TabIndex = 9;
            this.ActOK.Text = "OK";
            this.ActOK.UseVisualStyleBackColor = true;
            this.ActOK.Click += new System.EventHandler(this.ActOK_Click);
            // 
            // AccountDetail
            // 
            this.AcceptButton = this.ActOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActCancel;
            this.ClientSize = new System.Drawing.Size(290, 144);
            this.ControlBox = false;
            this.Controls.Add(this.StartDate);
            this.Controls.Add(this.AnnualFee);
            this.Controls.Add(this.AccountID);
            this.Controls.Add(this.LabelDate);
            this.Controls.Add(this.LabelFee);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.ActCancel);
            this.Controls.Add(this.AccountName);
            this.Controls.Add(this.LabelAccountID);
            this.Controls.Add(this.ActiveAccount);
            this.Controls.Add(this.ActOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AccountDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 3 - Edit Account";
            this.Load += new System.EventHandler(this.AccountDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox StartDate;
        internal System.Windows.Forms.TextBox AnnualFee;
        internal System.Windows.Forms.Label AccountID;
        internal System.Windows.Forms.Label LabelDate;
        internal System.Windows.Forms.Label LabelFee;
        internal System.Windows.Forms.Label LabelName;
        internal System.Windows.Forms.Button ActCancel;
        internal System.Windows.Forms.TextBox AccountName;
        internal System.Windows.Forms.Label LabelAccountID;
        internal System.Windows.Forms.CheckBox ActiveAccount;
        internal System.Windows.Forms.Button ActOK;
    }
}