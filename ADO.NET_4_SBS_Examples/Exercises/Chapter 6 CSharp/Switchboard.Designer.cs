namespace Chapter_6_CSharp
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
            this.ActDataView = new System.Windows.Forms.Button();
            this.ActAggregate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ActDataView
            // 
            this.ActDataView.Location = new System.Drawing.Point(8, 40);
            this.ActDataView.Name = "ActDataView";
            this.ActDataView.Size = new System.Drawing.Size(224, 23);
            this.ActDataView.TabIndex = 1;
            this.ActDataView.Text = "Data Views and Tables";
            this.ActDataView.UseVisualStyleBackColor = true;
            this.ActDataView.Click += new System.EventHandler(this.ActDataView_Click);
            // 
            // ActAggregate
            // 
            this.ActAggregate.Location = new System.Drawing.Point(8, 8);
            this.ActAggregate.Name = "ActAggregate";
            this.ActAggregate.Size = new System.Drawing.Size(224, 23);
            this.ActAggregate.TabIndex = 0;
            this.ActAggregate.Text = "Aggregate Functions";
            this.ActAggregate.UseVisualStyleBackColor = true;
            this.ActAggregate.Click += new System.EventHandler(this.ActAggregate_Click);
            // 
            // Switchboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 73);
            this.Controls.Add(this.ActDataView);
            this.Controls.Add(this.ActAggregate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Switchboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 6";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ActDataView;
        internal System.Windows.Forms.Button ActAggregate;
    }
}

