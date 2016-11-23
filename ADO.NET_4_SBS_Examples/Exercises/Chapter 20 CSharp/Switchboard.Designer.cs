namespace Chapter_20_CSharp
{
    partial class Switchboard
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
            this.ActStatesYear = new System.Windows.Forms.Button();
            this.ActOrderViewer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ActStatesYear
            // 
            this.ActStatesYear.Location = new System.Drawing.Point(72, 40);
            this.ActStatesYear.Name = "ActStatesYear";
            this.ActStatesYear.Size = new System.Drawing.Size(152, 23);
            this.ActStatesYear.TabIndex = 3;
            this.ActStatesYear.Text = "States By Year";
            this.ActStatesYear.UseVisualStyleBackColor = true;
            this.ActStatesYear.Click += new System.EventHandler(this.ActStatesYear_Click);
            // 
            // ActOrderViewer
            // 
            this.ActOrderViewer.Location = new System.Drawing.Point(72, 8);
            this.ActOrderViewer.Name = "ActOrderViewer";
            this.ActOrderViewer.Size = new System.Drawing.Size(152, 23);
            this.ActOrderViewer.TabIndex = 2;
            this.ActOrderViewer.Text = "Order Viewer";
            this.ActOrderViewer.UseVisualStyleBackColor = true;
            this.ActOrderViewer.Click += new System.EventHandler(this.ActOrderViewer_Click);
            // 
            // Switchboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 70);
            this.Controls.Add(this.ActStatesYear);
            this.Controls.Add(this.ActOrderViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Switchboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 20 - Switchboard";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ActStatesYear;
        internal System.Windows.Forms.Button ActOrderViewer;
    }
}

