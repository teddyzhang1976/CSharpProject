namespace MainExample
{
    partial class UserControlExample
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
            this.addressControl1 = new MainExample.AddressControl();
            this.SuspendLayout();
            // 
            // addressControl1
            // 
            this.addressControl1.AddressLine1 = "";
            this.addressControl1.AddressLine2 = "";
            this.addressControl1.AddressLine3 = "";
            this.addressControl1.AddressLine4 = "";
            this.addressControl1.Location = new System.Drawing.Point(13, 13);
            this.addressControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addressControl1.Name = "addressControl1";
            this.addressControl1.Postcode = "";
            this.addressControl1.Size = new System.Drawing.Size(404, 166);
            this.addressControl1.TabIndex = 0;
            // 
            // UserControlExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 329);
            this.Controls.Add(this.addressControl1);
            this.Name = "UserControlExample";
            this.Text = "UserControlExample";
            this.ResumeLayout(false);

        }

        #endregion

        private AddressControl addressControl1;
    }
}