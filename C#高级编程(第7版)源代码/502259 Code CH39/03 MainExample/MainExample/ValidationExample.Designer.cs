namespace MainExample
{
    partial class ValidationExample
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ageText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.postcodeText = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Age";
            // 
            // ageText
            // 
            this.ageText.Location = new System.Drawing.Point(89, 6);
            this.ageText.Name = "ageText";
            this.ageText.Size = new System.Drawing.Size(157, 22);
            this.ageText.TabIndex = 1;
            this.ageText.Validating += new System.ComponentModel.CancelEventHandler(this.ageText_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Postcode";
            // 
            // postcodeText
            // 
            this.postcodeText.Location = new System.Drawing.Point(89, 41);
            this.postcodeText.Name = "postcodeText";
            this.postcodeText.Size = new System.Drawing.Size(157, 22);
            this.postcodeText.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ValidationExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 401);
            this.Controls.Add(this.postcodeText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ageText);
            this.Controls.Add(this.label1);
            this.Name = "ValidationExample";
            this.Text = "ValidationExample";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ageText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox postcodeText;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}