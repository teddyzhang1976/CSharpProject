namespace Chapter_10_CSharp
{
    partial class ChangeAnnualFee
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
            this.CustomerName = new System.Windows.Forms.Label();
            this.LabelCustomer = new System.Windows.Forms.Label();
            this.LabelNew = new System.Windows.Forms.Label();
            this.CurrentFee = new System.Windows.Forms.Label();
            this.ActCancel = new System.Windows.Forms.Button();
            this.NewFee = new System.Windows.Forms.TextBox();
            this.LabelCurrent = new System.Windows.Forms.Label();
            this.ActOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSize = true;
            this.CustomerName.Location = new System.Drawing.Point(88, 10);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(27, 13);
            this.CustomerName.TabIndex = 1;
            this.CustomerName.Text = "N/A";
            this.CustomerName.UseMnemonic = false;
            // 
            // LabelCustomer
            // 
            this.LabelCustomer.AutoSize = true;
            this.LabelCustomer.Location = new System.Drawing.Point(8, 10);
            this.LabelCustomer.Name = "LabelCustomer";
            this.LabelCustomer.Size = new System.Drawing.Size(54, 13);
            this.LabelCustomer.TabIndex = 0;
            this.LabelCustomer.Text = "Customer:";
            // 
            // LabelNew
            // 
            this.LabelNew.AutoSize = true;
            this.LabelNew.Location = new System.Drawing.Point(8, 58);
            this.LabelNew.Name = "LabelNew";
            this.LabelNew.Size = new System.Drawing.Size(53, 13);
            this.LabelNew.TabIndex = 4;
            this.LabelNew.Text = "&New Fee:";
            // 
            // CurrentFee
            // 
            this.CurrentFee.AutoSize = true;
            this.CurrentFee.Location = new System.Drawing.Point(88, 34);
            this.CurrentFee.Name = "CurrentFee";
            this.CurrentFee.Size = new System.Drawing.Size(27, 13);
            this.CurrentFee.TabIndex = 3;
            this.CurrentFee.Text = "N/A";
            this.CurrentFee.UseMnemonic = false;
            // 
            // ActCancel
            // 
            this.ActCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActCancel.Location = new System.Drawing.Point(238, 88);
            this.ActCancel.Name = "ActCancel";
            this.ActCancel.Size = new System.Drawing.Size(75, 23);
            this.ActCancel.TabIndex = 7;
            this.ActCancel.Text = "Cancel";
            this.ActCancel.UseVisualStyleBackColor = true;
            // 
            // NewFee
            // 
            this.NewFee.Location = new System.Drawing.Point(88, 56);
            this.NewFee.MaxLength = 10;
            this.NewFee.Name = "NewFee";
            this.NewFee.Size = new System.Drawing.Size(224, 20);
            this.NewFee.TabIndex = 5;
            this.NewFee.Enter += new System.EventHandler(this.NewFee_Enter);
            // 
            // LabelCurrent
            // 
            this.LabelCurrent.AutoSize = true;
            this.LabelCurrent.Location = new System.Drawing.Point(8, 34);
            this.LabelCurrent.Name = "LabelCurrent";
            this.LabelCurrent.Size = new System.Drawing.Size(65, 13);
            this.LabelCurrent.TabIndex = 2;
            this.LabelCurrent.Text = "Current Fee:";
            // 
            // ActOK
            // 
            this.ActOK.Location = new System.Drawing.Point(158, 88);
            this.ActOK.Name = "ActOK";
            this.ActOK.Size = new System.Drawing.Size(75, 23);
            this.ActOK.TabIndex = 6;
            this.ActOK.Text = "OK";
            this.ActOK.UseVisualStyleBackColor = true;
            this.ActOK.Click += new System.EventHandler(this.ActOK_Click);
            // 
            // ChangeAnnualFee
            // 
            this.AcceptButton = this.ActOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActCancel;
            this.ClientSize = new System.Drawing.Size(320, 123);
            this.ControlBox = false;
            this.Controls.Add(this.CustomerName);
            this.Controls.Add(this.LabelCustomer);
            this.Controls.Add(this.LabelNew);
            this.Controls.Add(this.CurrentFee);
            this.Controls.Add(this.ActCancel);
            this.Controls.Add(this.NewFee);
            this.Controls.Add(this.LabelCurrent);
            this.Controls.Add(this.ActOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChangeAnnualFee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 10 - Change Annual Fee";
            this.Load += new System.EventHandler(this.ChangeAnnualFee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label CustomerName;
        internal System.Windows.Forms.Label LabelCustomer;
        internal System.Windows.Forms.Label LabelNew;
        internal System.Windows.Forms.Label CurrentFee;
        internal System.Windows.Forms.Button ActCancel;
        internal System.Windows.Forms.TextBox NewFee;
        internal System.Windows.Forms.Label LabelCurrent;
        internal System.Windows.Forms.Button ActOK;
    }
}