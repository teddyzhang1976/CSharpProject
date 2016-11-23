namespace Chapter_16_CSharp
{
    partial class CustomerDetail
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
            this.Address1 = new System.Windows.Forms.TextBox();
            this.Address2 = new System.Windows.Forms.TextBox();
            this.CityName = new System.Windows.Forms.TextBox();
            this.PostalCode = new System.Windows.Forms.TextBox();
            this.PhoneNumber = new System.Windows.Forms.TextBox();
            this.WebSite = new System.Windows.Forms.TextBox();
            this.LabelAnnualFee = new System.Windows.Forms.Label();
            this.LabelWebSite = new System.Windows.Forms.Label();
            this.LabelPhone = new System.Windows.Forms.Label();
            this.P = new System.Windows.Forms.Label();
            this.LabelState = new System.Windows.Forms.Label();
            this.LabelCity = new System.Windows.Forms.Label();
            this.LabelAddress2 = new System.Windows.Forms.Label();
            this.LabelAddress1 = new System.Windows.Forms.Label();
            this.ActCancel = new System.Windows.Forms.Button();
            this.StateName = new System.Windows.Forms.ComboBox();
            this.AnnualFee = new System.Windows.Forms.NumericUpDown();
            this.CustomerName = new System.Windows.Forms.TextBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.ActOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualFee)).BeginInit();
            this.SuspendLayout();
            // 
            // Address1
            // 
            this.Address1.Location = new System.Drawing.Point(96, 32);
            this.Address1.MaxLength = 50;
            this.Address1.Name = "Address1";
            this.Address1.Size = new System.Drawing.Size(192, 20);
            this.Address1.TabIndex = 3;
            this.Address1.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // Address2
            // 
            this.Address2.Location = new System.Drawing.Point(96, 56);
            this.Address2.MaxLength = 50;
            this.Address2.Name = "Address2";
            this.Address2.Size = new System.Drawing.Size(192, 20);
            this.Address2.TabIndex = 5;
            this.Address2.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // CityName
            // 
            this.CityName.Location = new System.Drawing.Point(96, 80);
            this.CityName.MaxLength = 25;
            this.CityName.Name = "CityName";
            this.CityName.Size = new System.Drawing.Size(192, 20);
            this.CityName.TabIndex = 7;
            this.CityName.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // PostalCode
            // 
            this.PostalCode.Location = new System.Drawing.Point(96, 128);
            this.PostalCode.MaxLength = 10;
            this.PostalCode.Name = "PostalCode";
            this.PostalCode.Size = new System.Drawing.Size(192, 20);
            this.PostalCode.TabIndex = 11;
            this.PostalCode.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.Location = new System.Drawing.Point(96, 152);
            this.PhoneNumber.MaxLength = 15;
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Size = new System.Drawing.Size(192, 20);
            this.PhoneNumber.TabIndex = 13;
            this.PhoneNumber.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // WebSite
            // 
            this.WebSite.Location = new System.Drawing.Point(96, 176);
            this.WebSite.MaxLength = 150;
            this.WebSite.Name = "WebSite";
            this.WebSite.Size = new System.Drawing.Size(192, 20);
            this.WebSite.TabIndex = 15;
            this.WebSite.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelAnnualFee
            // 
            this.LabelAnnualFee.AutoSize = true;
            this.LabelAnnualFee.Location = new System.Drawing.Point(8, 202);
            this.LabelAnnualFee.Name = "LabelAnnualFee";
            this.LabelAnnualFee.Size = new System.Drawing.Size(64, 13);
            this.LabelAnnualFee.TabIndex = 16;
            this.LabelAnnualFee.Text = "Annual &Fee:";
            // 
            // LabelWebSite
            // 
            this.LabelWebSite.AutoSize = true;
            this.LabelWebSite.Location = new System.Drawing.Point(8, 178);
            this.LabelWebSite.Name = "LabelWebSite";
            this.LabelWebSite.Size = new System.Drawing.Size(54, 13);
            this.LabelWebSite.TabIndex = 14;
            this.LabelWebSite.Text = "&Web Site:";
            // 
            // LabelPhone
            // 
            this.LabelPhone.AutoSize = true;
            this.LabelPhone.Location = new System.Drawing.Point(8, 154);
            this.LabelPhone.Name = "LabelPhone";
            this.LabelPhone.Size = new System.Drawing.Size(41, 13);
            this.LabelPhone.TabIndex = 12;
            this.LabelPhone.Text = "P&hone:";
            // 
            // P
            // 
            this.P.AutoSize = true;
            this.P.Location = new System.Drawing.Point(8, 130);
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(67, 13);
            this.P.TabIndex = 10;
            this.P.Text = "&Postal Code:";
            // 
            // LabelState
            // 
            this.LabelState.AutoSize = true;
            this.LabelState.Location = new System.Drawing.Point(8, 106);
            this.LabelState.Name = "LabelState";
            this.LabelState.Size = new System.Drawing.Size(32, 13);
            this.LabelState.TabIndex = 8;
            this.LabelState.Text = "&State";
            // 
            // LabelCity
            // 
            this.LabelCity.AutoSize = true;
            this.LabelCity.Location = new System.Drawing.Point(8, 82);
            this.LabelCity.Name = "LabelCity";
            this.LabelCity.Size = new System.Drawing.Size(27, 13);
            this.LabelCity.TabIndex = 6;
            this.LabelCity.Text = "&City:";
            // 
            // LabelAddress2
            // 
            this.LabelAddress2.AutoSize = true;
            this.LabelAddress2.Location = new System.Drawing.Point(8, 58);
            this.LabelAddress2.Name = "LabelAddress2";
            this.LabelAddress2.Size = new System.Drawing.Size(57, 13);
            this.LabelAddress2.TabIndex = 4;
            this.LabelAddress2.Text = "Address &2:";
            // 
            // LabelAddress1
            // 
            this.LabelAddress1.AutoSize = true;
            this.LabelAddress1.Location = new System.Drawing.Point(8, 34);
            this.LabelAddress1.Name = "LabelAddress1";
            this.LabelAddress1.Size = new System.Drawing.Size(57, 13);
            this.LabelAddress1.TabIndex = 2;
            this.LabelAddress1.Text = "Address &1:";
            // 
            // ActCancel
            // 
            this.ActCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActCancel.Location = new System.Drawing.Point(216, 232);
            this.ActCancel.Name = "ActCancel";
            this.ActCancel.Size = new System.Drawing.Size(75, 23);
            this.ActCancel.TabIndex = 19;
            this.ActCancel.Text = "Cancel";
            this.ActCancel.UseVisualStyleBackColor = true;
            // 
            // StateName
            // 
            this.StateName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StateName.FormattingEnabled = true;
            this.StateName.Location = new System.Drawing.Point(96, 104);
            this.StateName.Name = "StateName";
            this.StateName.Size = new System.Drawing.Size(192, 21);
            this.StateName.TabIndex = 9;
            // 
            // AnnualFee
            // 
            this.AnnualFee.Location = new System.Drawing.Point(96, 200);
            this.AnnualFee.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.AnnualFee.Name = "AnnualFee";
            this.AnnualFee.Size = new System.Drawing.Size(192, 20);
            this.AnnualFee.TabIndex = 17;
            // 
            // CustomerName
            // 
            this.CustomerName.Location = new System.Drawing.Point(96, 8);
            this.CustomerName.MaxLength = 50;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(192, 20);
            this.CustomerName.TabIndex = 1;
            this.CustomerName.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(8, 10);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(85, 13);
            this.LabelName.TabIndex = 0;
            this.LabelName.Text = "Customer &Name:";
            // 
            // ActOK
            // 
            this.ActOK.Location = new System.Drawing.Point(136, 232);
            this.ActOK.Name = "ActOK";
            this.ActOK.Size = new System.Drawing.Size(75, 23);
            this.ActOK.TabIndex = 18;
            this.ActOK.Text = "OK";
            this.ActOK.UseVisualStyleBackColor = true;
            this.ActOK.Click += new System.EventHandler(this.ActOK_Click);
            // 
            // CustomerDetail
            // 
            this.AcceptButton = this.ActOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActCancel;
            this.ClientSize = new System.Drawing.Size(299, 264);
            this.ControlBox = false;
            this.Controls.Add(this.Address1);
            this.Controls.Add(this.Address2);
            this.Controls.Add(this.CityName);
            this.Controls.Add(this.PostalCode);
            this.Controls.Add(this.PhoneNumber);
            this.Controls.Add(this.WebSite);
            this.Controls.Add(this.LabelAnnualFee);
            this.Controls.Add(this.LabelWebSite);
            this.Controls.Add(this.LabelPhone);
            this.Controls.Add(this.P);
            this.Controls.Add(this.LabelState);
            this.Controls.Add(this.LabelCity);
            this.Controls.Add(this.LabelAddress2);
            this.Controls.Add(this.LabelAddress1);
            this.Controls.Add(this.ActCancel);
            this.Controls.Add(this.StateName);
            this.Controls.Add(this.AnnualFee);
            this.Controls.Add(this.CustomerName);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.ActOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CustomerDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 16 - Edit Customer";
            this.Load += new System.EventHandler(this.CustomerDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AnnualFee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox Address1;
        internal System.Windows.Forms.TextBox Address2;
        internal System.Windows.Forms.TextBox CityName;
        internal System.Windows.Forms.TextBox PostalCode;
        internal System.Windows.Forms.TextBox PhoneNumber;
        internal System.Windows.Forms.TextBox WebSite;
        internal System.Windows.Forms.Label LabelAnnualFee;
        internal System.Windows.Forms.Label LabelWebSite;
        internal System.Windows.Forms.Label LabelPhone;
        internal System.Windows.Forms.Label P;
        internal System.Windows.Forms.Label LabelState;
        internal System.Windows.Forms.Label LabelCity;
        internal System.Windows.Forms.Label LabelAddress2;
        internal System.Windows.Forms.Label LabelAddress1;
        internal System.Windows.Forms.Button ActCancel;
        internal System.Windows.Forms.ComboBox StateName;
        internal System.Windows.Forms.NumericUpDown AnnualFee;
        internal System.Windows.Forms.TextBox CustomerName;
        internal System.Windows.Forms.Label LabelName;
        internal System.Windows.Forms.Button ActOK;
    }
}