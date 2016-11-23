namespace Chapter_20_CSharp
{
    partial class StatesByYear
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
            this.StateAdmittance = new System.Windows.Forms.DataGridView();
            this.ActClose = new System.Windows.Forms.Button();
            this.LabelInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StateAdmittance)).BeginInit();
            this.SuspendLayout();
            // 
            // StateAdmittance
            // 
            this.StateAdmittance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StateAdmittance.Location = new System.Drawing.Point(8, 32);
            this.StateAdmittance.Name = "StateAdmittance";
            this.StateAdmittance.Size = new System.Drawing.Size(376, 272);
            this.StateAdmittance.TabIndex = 1;
            // 
            // ActClose
            // 
            this.ActClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActClose.Location = new System.Drawing.Point(309, 312);
            this.ActClose.Name = "ActClose";
            this.ActClose.Size = new System.Drawing.Size(75, 23);
            this.ActClose.TabIndex = 2;
            this.ActClose.Text = "Close";
            this.ActClose.UseVisualStyleBackColor = true;
            // 
            // LabelInfo
            // 
            this.LabelInfo.AutoSize = true;
            this.LabelInfo.Location = new System.Drawing.Point(8, 8);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(292, 13);
            this.LabelInfo.TabIndex = 0;
            this.LabelInfo.Text = "The number of states admitted to the union in the same year.";
            // 
            // StatesByYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActClose;
            this.ClientSize = new System.Drawing.Size(393, 345);
            this.ControlBox = false;
            this.Controls.Add(this.StateAdmittance);
            this.Controls.Add(this.ActClose);
            this.Controls.Add(this.LabelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StatesByYear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 20 - View States by Year";
            this.Load += new System.EventHandler(this.StatesByYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StateAdmittance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView StateAdmittance;
        internal System.Windows.Forms.Button ActClose;
        internal System.Windows.Forms.Label LabelInfo;
    }
}