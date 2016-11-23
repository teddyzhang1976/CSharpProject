namespace PortFolio.View.AccountManager
{
    partial class UpdateAccountPasswordDlg
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
            this.oldPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.accountPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.accountPasswordConfirmTextBox = new System.Windows.Forms.TextBox();
            this.updateAccountPasswordButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "旧密码：";
            // 
            // oldPasswordTextBox
            // 
            this.oldPasswordTextBox.Location = new System.Drawing.Point(125, 26);
            this.oldPasswordTextBox.Name = "oldPasswordTextBox";
            this.oldPasswordTextBox.Size = new System.Drawing.Size(100, 21);
            this.oldPasswordTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "新密码：";
            // 
            // accountPasswordTextBox
            // 
            this.accountPasswordTextBox.Location = new System.Drawing.Point(125, 65);
            this.accountPasswordTextBox.Name = "accountPasswordTextBox";
            this.accountPasswordTextBox.Size = new System.Drawing.Size(100, 21);
            this.accountPasswordTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "新密码确认：";
            // 
            // accountPasswordConfirmTextBox
            // 
            this.accountPasswordConfirmTextBox.Location = new System.Drawing.Point(125, 108);
            this.accountPasswordConfirmTextBox.Name = "accountPasswordConfirmTextBox";
            this.accountPasswordConfirmTextBox.Size = new System.Drawing.Size(100, 21);
            this.accountPasswordConfirmTextBox.TabIndex = 1;
            // 
            // updateAccountPasswordButton
            // 
            this.updateAccountPasswordButton.Location = new System.Drawing.Point(24, 184);
            this.updateAccountPasswordButton.Name = "updateAccountPasswordButton";
            this.updateAccountPasswordButton.Size = new System.Drawing.Size(101, 31);
            this.updateAccountPasswordButton.TabIndex = 2;
            this.updateAccountPasswordButton.Text = "确定";
            this.updateAccountPasswordButton.UseVisualStyleBackColor = true;
            this.updateAccountPasswordButton.Click += new System.EventHandler(this.updateAccountPasswordButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdateAccountPasswordDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.updateAccountPasswordButton);
            this.Controls.Add(this.accountPasswordConfirmTextBox);
            this.Controls.Add(this.accountPasswordTextBox);
            this.Controls.Add(this.oldPasswordTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateAccountPasswordDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateAccountPassword";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox oldPasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox accountPasswordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox accountPasswordConfirmTextBox;
        private System.Windows.Forms.Button updateAccountPasswordButton;
        private System.Windows.Forms.Button button2;
    }
}