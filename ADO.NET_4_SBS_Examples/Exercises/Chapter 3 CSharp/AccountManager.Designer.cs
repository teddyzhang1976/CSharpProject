namespace Chapter_3_CSharp
{
    partial class AccountManager
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
            this.ActClose = new System.Windows.Forms.Button();
            this.ActDelete = new System.Windows.Forms.Button();
            this.ActEdit = new System.Windows.Forms.Button();
            this.ColStartDate = new System.Windows.Forms.Label();
            this.ColAnnualFee = new System.Windows.Forms.Label();
            this.ColFullName = new System.Windows.Forms.Label();
            this.AllAccounts = new System.Windows.Forms.ListBox();
            this.ColActive = new System.Windows.Forms.Label();
            this.ActAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ActClose
            // 
            this.ActClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActClose.Location = new System.Drawing.Point(423, 232);
            this.ActClose.Name = "ActClose";
            this.ActClose.Size = new System.Drawing.Size(75, 23);
            this.ActClose.TabIndex = 8;
            this.ActClose.Text = "Close";
            this.ActClose.UseVisualStyleBackColor = true;
            this.ActClose.Click += new System.EventHandler(this.ActClose_Click);
            // 
            // ActDelete
            // 
            this.ActDelete.Enabled = false;
            this.ActDelete.Location = new System.Drawing.Point(167, 232);
            this.ActDelete.Name = "ActDelete";
            this.ActDelete.Size = new System.Drawing.Size(75, 23);
            this.ActDelete.TabIndex = 7;
            this.ActDelete.Text = "&Delete";
            this.ActDelete.UseVisualStyleBackColor = true;
            this.ActDelete.Click += new System.EventHandler(this.ActDelete_Click);
            // 
            // ActEdit
            // 
            this.ActEdit.Enabled = false;
            this.ActEdit.Location = new System.Drawing.Point(87, 232);
            this.ActEdit.Name = "ActEdit";
            this.ActEdit.Size = new System.Drawing.Size(75, 23);
            this.ActEdit.TabIndex = 6;
            this.ActEdit.Text = "&Edit...";
            this.ActEdit.UseVisualStyleBackColor = true;
            this.ActEdit.Click += new System.EventHandler(this.ActEdit_Click);
            // 
            // ColStartDate
            // 
            this.ColStartDate.AutoSize = true;
            this.ColStartDate.Location = new System.Drawing.Point(391, 8);
            this.ColStartDate.Name = "ColStartDate";
            this.ColStartDate.Size = new System.Drawing.Size(55, 13);
            this.ColStartDate.TabIndex = 3;
            this.ColStartDate.Text = "Start Date";
            // 
            // ColAnnualFee
            // 
            this.ColAnnualFee.AutoSize = true;
            this.ColAnnualFee.Location = new System.Drawing.Point(287, 8);
            this.ColAnnualFee.Name = "ColAnnualFee";
            this.ColAnnualFee.Size = new System.Drawing.Size(61, 13);
            this.ColAnnualFee.TabIndex = 2;
            this.ColAnnualFee.Text = "Annual Fee";
            // 
            // ColFullName
            // 
            this.ColFullName.AutoSize = true;
            this.ColFullName.Location = new System.Drawing.Point(55, 8);
            this.ColFullName.Name = "ColFullName";
            this.ColFullName.Size = new System.Drawing.Size(54, 13);
            this.ColFullName.TabIndex = 1;
            this.ColFullName.Text = "Full Name";
            // 
            // AllAccounts
            // 
            this.AllAccounts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AllAccounts.FormattingEnabled = true;
            this.AllAccounts.Location = new System.Drawing.Point(7, 24);
            this.AllAccounts.Name = "AllAccounts";
            this.AllAccounts.Size = new System.Drawing.Size(488, 199);
            this.AllAccounts.TabIndex = 4;
            this.AllAccounts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.AllAccounts_DrawItem);
            this.AllAccounts.SelectedIndexChanged += new System.EventHandler(this.AllAccounts_SelectedIndexChanged);
            this.AllAccounts.DoubleClick += new System.EventHandler(this.AllAccounts_DoubleClick);
            // 
            // ColActive
            // 
            this.ColActive.AutoSize = true;
            this.ColActive.Location = new System.Drawing.Point(7, 8);
            this.ColActive.Name = "ColActive";
            this.ColActive.Size = new System.Drawing.Size(37, 13);
            this.ColActive.TabIndex = 0;
            this.ColActive.Text = "Active";
            // 
            // ActAdd
            // 
            this.ActAdd.Location = new System.Drawing.Point(7, 232);
            this.ActAdd.Name = "ActAdd";
            this.ActAdd.Size = new System.Drawing.Size(75, 23);
            this.ActAdd.TabIndex = 5;
            this.ActAdd.Text = "&Add...";
            this.ActAdd.UseVisualStyleBackColor = true;
            this.ActAdd.Click += new System.EventHandler(this.ActAdd_Click);
            // 
            // AccountManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActClose;
            this.ClientSize = new System.Drawing.Size(504, 263);
            this.Controls.Add(this.ActClose);
            this.Controls.Add(this.ActDelete);
            this.Controls.Add(this.ActEdit);
            this.Controls.Add(this.ColStartDate);
            this.Controls.Add(this.ColAnnualFee);
            this.Controls.Add(this.ColFullName);
            this.Controls.Add(this.AllAccounts);
            this.Controls.Add(this.ColActive);
            this.Controls.Add(this.ActAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AccountManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 3 - Account Manager";
            this.Load += new System.EventHandler(this.AccountManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button ActClose;
        internal System.Windows.Forms.Button ActDelete;
        internal System.Windows.Forms.Button ActEdit;
        internal System.Windows.Forms.Label ColStartDate;
        internal System.Windows.Forms.Label ColAnnualFee;
        internal System.Windows.Forms.Label ColFullName;
        internal System.Windows.Forms.ListBox AllAccounts;
        internal System.Windows.Forms.Label ColActive;
        internal System.Windows.Forms.Button ActAdd;
    }
}

