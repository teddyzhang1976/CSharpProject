namespace _2_Listen
{
	partial class AskApproval
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
            this.label2 = new System.Windows.Forms.Label();
            this.expenseID = new System.Windows.Forms.TextBox();
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectReport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.reason = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please approve or reject the expense report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Expense Report ID";
            // 
            // expenseID
            // 
            this.expenseID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.expenseID.Location = new System.Drawing.Point(116, 34);
            this.expenseID.Name = "expenseID";
            this.expenseID.Size = new System.Drawing.Size(249, 20);
            this.expenseID.TabIndex = 2;
            // 
            // approveButton
            // 
            this.approveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.approveButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.approveButton.Location = new System.Drawing.Point(209, 199);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(75, 23);
            this.approveButton.TabIndex = 5;
            this.approveButton.Text = "&Approve";
            this.approveButton.UseVisualStyleBackColor = true;
            // 
            // rejectReport
            // 
            this.rejectReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rejectReport.DialogResult = System.Windows.Forms.DialogResult.No;
            this.rejectReport.Location = new System.Drawing.Point(290, 199);
            this.rejectReport.Name = "rejectReport";
            this.rejectReport.Size = new System.Drawing.Size(75, 23);
            this.rejectReport.TabIndex = 6;
            this.rejectReport.Text = "&Reject";
            this.rejectReport.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Reason";
            // 
            // reason
            // 
            this.reason.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reason.Location = new System.Drawing.Point(116, 64);
            this.reason.Multiline = true;
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(249, 129);
            this.reason.TabIndex = 4;
            // 
            // AskApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 234);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rejectReport);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.expenseID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AskApproval";
            this.Text = "Approve Expense Report";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button rejectReport;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox reason;
        public System.Windows.Forms.TextBox expenseID;
	}
}