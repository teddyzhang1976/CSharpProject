namespace Chapter_10_CSharp
{
    partial class RenameCustomer
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
            this.LabelNew = new System.Windows.Forms.Label();
            this.CurrentName = new System.Windows.Forms.Label();
            this.ActCancel = new System.Windows.Forms.Button();
            this.NewName = new System.Windows.Forms.TextBox();
            this.LabelCurrent = new System.Windows.Forms.Label();
            this.ActOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelNew
            // 
            this.LabelNew.AutoSize = true;
            this.LabelNew.Location = new System.Drawing.Point(8, 34);
            this.LabelNew.Name = "LabelNew";
            this.LabelNew.Size = new System.Drawing.Size(63, 13);
            this.LabelNew.TabIndex = 2;
            this.LabelNew.Text = "&New Name:";
            // 
            // CurrentName
            // 
            this.CurrentName.AutoSize = true;
            this.CurrentName.Location = new System.Drawing.Point(88, 10);
            this.CurrentName.Name = "CurrentName";
            this.CurrentName.Size = new System.Drawing.Size(27, 13);
            this.CurrentName.TabIndex = 1;
            this.CurrentName.Text = "N/A";
            this.CurrentName.UseMnemonic = false;
            // 
            // ActCancel
            // 
            this.ActCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActCancel.Location = new System.Drawing.Point(238, 64);
            this.ActCancel.Name = "ActCancel";
            this.ActCancel.Size = new System.Drawing.Size(75, 23);
            this.ActCancel.TabIndex = 5;
            this.ActCancel.Text = "Cancel";
            this.ActCancel.UseVisualStyleBackColor = true;
            // 
            // NewName
            // 
            this.NewName.Location = new System.Drawing.Point(88, 32);
            this.NewName.MaxLength = 50;
            this.NewName.Name = "NewName";
            this.NewName.Size = new System.Drawing.Size(224, 20);
            this.NewName.TabIndex = 3;
            this.NewName.Enter += new System.EventHandler(this.NewName_Enter);
            // 
            // LabelCurrent
            // 
            this.LabelCurrent.AutoSize = true;
            this.LabelCurrent.Location = new System.Drawing.Point(8, 10);
            this.LabelCurrent.Name = "LabelCurrent";
            this.LabelCurrent.Size = new System.Drawing.Size(75, 13);
            this.LabelCurrent.TabIndex = 0;
            this.LabelCurrent.Text = "Current Name:";
            // 
            // ActOK
            // 
            this.ActOK.Location = new System.Drawing.Point(158, 64);
            this.ActOK.Name = "ActOK";
            this.ActOK.Size = new System.Drawing.Size(75, 23);
            this.ActOK.TabIndex = 4;
            this.ActOK.Text = "OK";
            this.ActOK.UseVisualStyleBackColor = true;
            this.ActOK.Click += new System.EventHandler(this.ActOK_Click);
            // 
            // RenameCustomer
            // 
            this.AcceptButton = this.ActOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActCancel;
            this.ClientSize = new System.Drawing.Size(320, 97);
            this.ControlBox = false;
            this.Controls.Add(this.LabelNew);
            this.Controls.Add(this.CurrentName);
            this.Controls.Add(this.ActCancel);
            this.Controls.Add(this.NewName);
            this.Controls.Add(this.LabelCurrent);
            this.Controls.Add(this.ActOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RenameCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 10 - Rename Customer";
            this.Load += new System.EventHandler(this.RenameCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LabelNew;
        internal System.Windows.Forms.Label CurrentName;
        internal System.Windows.Forms.Button ActCancel;
        internal System.Windows.Forms.TextBox NewName;
        internal System.Windows.Forms.Label LabelCurrent;
        internal System.Windows.Forms.Button ActOK;
    }
}