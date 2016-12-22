namespace SelfPlacingWindow
{
    partial class Form1
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
            SaveSettings();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonChooseColor = new System.Windows.Forms.Button();
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonChooseColor
            // 
            this.buttonChooseColor.Location = new System.Drawing.Point(-2, 225);
            this.buttonChooseColor.Name = "buttonChooseColor";
            this.buttonChooseColor.Size = new System.Drawing.Size(104, 23);
            this.buttonChooseColor.TabIndex = 3;
            this.buttonChooseColor.Text = "Choose Color";
            // 
            // listBoxMessages
            // 
            this.listBoxMessages.Location = new System.Drawing.Point(-2, 17);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(288, 199);
            this.listBoxMessages.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.buttonChooseColor);
            this.Controls.Add(this.listBoxMessages);
            this.Name = "Form1";
            this.Text = "SelfPlacingWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChooseColor;
        private System.Windows.Forms.ListBox listBoxMessages;
    }
}

