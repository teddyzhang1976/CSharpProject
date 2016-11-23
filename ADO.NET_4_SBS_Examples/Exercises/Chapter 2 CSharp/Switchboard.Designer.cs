namespace Chapter_2_CSharp
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
            this.ActDesigner = new System.Windows.Forms.Button();
            this.ActColumns = new System.Windows.Forms.Button();
            this.ActNoColumns = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ActDesigner
            // 
            this.ActDesigner.Location = new System.Drawing.Point(8, 74);
            this.ActDesigner.Name = "ActDesigner";
            this.ActDesigner.Size = new System.Drawing.Size(280, 23);
            this.ActDesigner.TabIndex = 2;
            this.ActDesigner.Text = "Show &Designer Table";
            this.ActDesigner.UseVisualStyleBackColor = true;
            this.ActDesigner.Click += new System.EventHandler(this.ActDesigner_Click);
            // 
            // ActColumns
            // 
            this.ActColumns.Location = new System.Drawing.Point(8, 42);
            this.ActColumns.Name = "ActColumns";
            this.ActColumns.Size = new System.Drawing.Size(280, 23);
            this.ActColumns.TabIndex = 1;
            this.ActColumns.Text = "Show Table with &Columns";
            this.ActColumns.UseVisualStyleBackColor = true;
            this.ActColumns.Click += new System.EventHandler(this.ActColumns_Click);
            // 
            // ActNoColumns
            // 
            this.ActNoColumns.Location = new System.Drawing.Point(8, 10);
            this.ActNoColumns.Name = "ActNoColumns";
            this.ActNoColumns.Size = new System.Drawing.Size(280, 23);
            this.ActNoColumns.TabIndex = 0;
            this.ActNoColumns.Text = "Show Table with &No Columns";
            this.ActNoColumns.UseVisualStyleBackColor = true;
            this.ActNoColumns.Click += new System.EventHandler(this.ActNoColumns_Click);
            // 
            // Switchboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 106);
            this.Controls.Add(this.ActDesigner);
            this.Controls.Add(this.ActColumns);
            this.Controls.Add(this.ActNoColumns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Switchboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 2 - Switchboard";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ActDesigner;
        internal System.Windows.Forms.Button ActColumns;
        internal System.Windows.Forms.Button ActNoColumns;
    }
}

