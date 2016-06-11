namespace ExcelVBAInterop
{
   partial class NamingDialog
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
         this.sheetNameBox = new System.Windows.Forms.TextBox();
         this.includeDatePrefixBox = new System.Windows.Forms.CheckBox();
         this.okButton = new System.Windows.Forms.Button();
         this.cancelButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(67, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Sheet name:";
         // 
         // sheetNameBox
         // 
         this.sheetNameBox.Location = new System.Drawing.Point(16, 30);
         this.sheetNameBox.Name = "sheetNameBox";
         this.sheetNameBox.Size = new System.Drawing.Size(248, 20);
         this.sheetNameBox.TabIndex = 1;
         // 
         // includeDatePrefixBox
         // 
         this.includeDatePrefixBox.AutoSize = true;
         this.includeDatePrefixBox.Checked = true;
         this.includeDatePrefixBox.CheckState = System.Windows.Forms.CheckState.Checked;
         this.includeDatePrefixBox.Location = new System.Drawing.Point(16, 57);
         this.includeDatePrefixBox.Name = "includeDatePrefixBox";
         this.includeDatePrefixBox.Size = new System.Drawing.Size(113, 17);
         this.includeDatePrefixBox.TabIndex = 2;
         this.includeDatePrefixBox.Text = "Include date prefix";
         this.includeDatePrefixBox.UseVisualStyleBackColor = true;
         // 
         // okButton
         // 
         this.okButton.Location = new System.Drawing.Point(16, 81);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(75, 23);
         this.okButton.TabIndex = 3;
         this.okButton.Text = "OK";
         this.okButton.UseVisualStyleBackColor = true;
         this.okButton.Click += new System.EventHandler(this.okButton_Click);
         // 
         // cancelButton
         // 
         this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cancelButton.Location = new System.Drawing.Point(97, 81);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.Size = new System.Drawing.Size(75, 23);
         this.cancelButton.TabIndex = 4;
         this.cancelButton.Text = "Cancel";
         this.cancelButton.UseVisualStyleBackColor = true;
         this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
         // 
         // NamingDialog
         // 
         this.AcceptButton = this.okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cancelButton;
         this.ClientSize = new System.Drawing.Size(276, 121);
         this.Controls.Add(this.cancelButton);
         this.Controls.Add(this.okButton);
         this.Controls.Add(this.includeDatePrefixBox);
         this.Controls.Add(this.sheetNameBox);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "NamingDialog";
         this.Text = "Rename Sheet";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox sheetNameBox;
      private System.Windows.Forms.CheckBox includeDatePrefixBox;
      private System.Windows.Forms.Button okButton;
      private System.Windows.Forms.Button cancelButton;
   }
}