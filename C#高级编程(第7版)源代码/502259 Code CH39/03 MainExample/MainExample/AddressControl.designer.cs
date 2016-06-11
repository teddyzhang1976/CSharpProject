namespace MainExample
{
    partial class AddressControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.addressLine1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addressLine2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addressLine3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addressLine4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.postcode = new System.Windows.Forms.TextBox();
            this.addressErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.addressErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address Line 1";
            // 
            // addressLine1
            // 
            this.addressLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLine1.Location = new System.Drawing.Point(98, 4);
            this.addressLine1.Name = "addressLine1";
            this.addressLine1.Size = new System.Drawing.Size(160, 20);
            this.addressLine1.TabIndex = 1;
            this.addressLine1.Tag = "";
            this.addressLine1.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateAddress1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address Line 2";
            // 
            // addressLine2
            // 
            this.addressLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLine2.Location = new System.Drawing.Point(98, 30);
            this.addressLine2.Name = "addressLine2";
            this.addressLine2.Size = new System.Drawing.Size(160, 20);
            this.addressLine2.TabIndex = 3;
            this.addressLine2.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateAddress2);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address Line 3";
            // 
            // addressLine3
            // 
            this.addressLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLine3.Location = new System.Drawing.Point(98, 56);
            this.addressLine3.Name = "addressLine3";
            this.addressLine3.Size = new System.Drawing.Size(160, 20);
            this.addressLine3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Address Line 4";
            // 
            // addressLine4
            // 
            this.addressLine4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLine4.Location = new System.Drawing.Point(98, 82);
            this.addressLine4.Name = "addressLine4";
            this.addressLine4.Size = new System.Drawing.Size(160, 20);
            this.addressLine4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Postcode";
            // 
            // postcode
            // 
            this.postcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.postcode.Location = new System.Drawing.Point(98, 108);
            this.postcode.Name = "postcode";
            this.postcode.Size = new System.Drawing.Size(160, 20);
            this.postcode.TabIndex = 9;
            this.postcode.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidatePostcode);
            // 
            // addressErrorProvider
            // 
            this.addressErrorProvider.ContainerControl = this;
            // 
            // AddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.postcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addressLine4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addressLine3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addressLine2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addressLine1);
            this.Controls.Add(this.label1);
            this.Name = "AddressControl";
            this.Size = new System.Drawing.Size(285, 133);
            ((System.ComponentModel.ISupportInitialize)(this.addressErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addressLine1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addressLine2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addressLine3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox addressLine4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox postcode;
        private System.Windows.Forms.ErrorProvider addressErrorProvider;
    }
}
