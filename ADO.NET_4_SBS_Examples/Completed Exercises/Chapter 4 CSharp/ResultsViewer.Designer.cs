namespace Chapter_4_CSharp
{
    partial class ResultsViewer
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
            this.ActClose = new System.Windows.Forms.Button();
            this.ResultsDisplay = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // ActClose
            // 
            this.ActClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActClose.Location = new System.Drawing.Point(590, 256);
            this.ActClose.Name = "ActClose";
            this.ActClose.Size = new System.Drawing.Size(75, 23);
            this.ActClose.TabIndex = 1;
            this.ActClose.Text = "Close";
            this.ActClose.UseVisualStyleBackColor = true;
            // 
            // ResultsDisplay
            // 
            this.ResultsDisplay.AllowUserToAddRows = false;
            this.ResultsDisplay.AllowUserToDeleteRows = false;
            this.ResultsDisplay.AllowUserToOrderColumns = true;
            this.ResultsDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ResultsDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsDisplay.Location = new System.Drawing.Point(8, 8);
            this.ResultsDisplay.MultiSelect = false;
            this.ResultsDisplay.Name = "ResultsDisplay";
            this.ResultsDisplay.ReadOnly = true;
            this.ResultsDisplay.RowHeadersVisible = false;
            this.ResultsDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ResultsDisplay.Size = new System.Drawing.Size(656, 240);
            this.ResultsDisplay.TabIndex = 0;
            // 
            // ResultsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActClose;
            this.ClientSize = new System.Drawing.Size(672, 286);
            this.ControlBox = false;
            this.Controls.Add(this.ActClose);
            this.Controls.Add(this.ResultsDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ResultsViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 4 - Processed Results";
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ActClose;
        internal System.Windows.Forms.DataGridView ResultsDisplay;
    }
}