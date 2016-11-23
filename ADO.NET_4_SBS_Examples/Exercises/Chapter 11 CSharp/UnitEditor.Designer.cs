namespace Chapter_11_CSharp
{
    partial class UnitEditor
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
            this.UnitGrid = new System.Windows.Forms.DataGridView();
            this.ActUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UnitGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // UnitGrid
            // 
            this.UnitGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnitGrid.Location = new System.Drawing.Point(8, 8);
            this.UnitGrid.Name = "UnitGrid";
            this.UnitGrid.Size = new System.Drawing.Size(432, 192);
            this.UnitGrid.TabIndex = 0;
            // 
            // ActUpdate
            // 
            this.ActUpdate.Location = new System.Drawing.Point(368, 208);
            this.ActUpdate.Name = "ActUpdate";
            this.ActUpdate.Size = new System.Drawing.Size(75, 23);
            this.ActUpdate.TabIndex = 1;
            this.ActUpdate.Text = "Update";
            this.ActUpdate.UseVisualStyleBackColor = true;
            this.ActUpdate.Click += new System.EventHandler(this.ActUpdate_Click);
            // 
            // UnitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 241);
            this.Controls.Add(this.UnitGrid);
            this.Controls.Add(this.ActUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UnitEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 11 - Unit Editor";
            this.Load += new System.EventHandler(this.UnitEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UnitGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView UnitGrid;
        internal System.Windows.Forms.Button ActUpdate;
    }
}

