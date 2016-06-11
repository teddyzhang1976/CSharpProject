namespace MainExample
{
    partial class DataViewExample
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
            this.originalData = new System.Windows.Forms.DataGridView ();
            this.getData = new System.Windows.Forms.Button ();
            this.comboBox1 = new System.Windows.Forms.ComboBox ();
            this.filteredData = new System.Windows.Forms.DataGridView ();
            this.label1 = new System.Windows.Forms.Label ();
            ((System.ComponentModel.ISupportInitialize)(this.originalData)).BeginInit ();
            ((System.ComponentModel.ISupportInitialize)(this.filteredData)).BeginInit ();
            this.SuspendLayout ();
            // 
            // originalData
            // 
            this.originalData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.originalData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.originalData.Location = new System.Drawing.Point (12, 12);
            this.originalData.Name = "originalData";
            this.originalData.Size = new System.Drawing.Size (600, 214);
            this.originalData.TabIndex = 0;
            // 
            // getData
            // 
            this.getData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.getData.Location = new System.Drawing.Point (536, 501);
            this.getData.Name = "getData";
            this.getData.Size = new System.Drawing.Size (75, 23);
            this.getData.TabIndex = 1;
            this.getData.Text = "Get Data";
            this.getData.UseVisualStyleBackColor = true;
            this.getData.Click += new System.EventHandler (this.getData_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange (new object[] {
            "Added",
            "CurrentRows",
            "Deleted",
            "ModifiedCurrent",
            "ModifiedOriginal",
            "None",
            "OriginalRows",
            "Unchanged"});
            this.comboBox1.Location = new System.Drawing.Point (108, 232);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size (502, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler (this.comboBox1_SelectedIndexChanged);
            // 
            // filteredData
            // 
            this.filteredData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filteredData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filteredData.Location = new System.Drawing.Point (12, 259);
            this.filteredData.Name = "filteredData";
            this.filteredData.Size = new System.Drawing.Size (598, 236);
            this.filteredData.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point (13, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size (29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (624, 536);
            this.Controls.Add (this.label1);
            this.Controls.Add (this.filteredData);
            this.Controls.Add (this.comboBox1);
            this.Controls.Add (this.getData);
            this.Controls.Add (this.originalData);
            this.Name = "Form1";
            this.Text = "04_DataSourceDataView";
            ((System.ComponentModel.ISupportInitialize)(this.originalData)).EndInit ();
            ((System.ComponentModel.ISupportInitialize)(this.filteredData)).EndInit ();
            this.ResumeLayout (false);
            this.PerformLayout ();

        }

        #endregion

        private System.Windows.Forms.DataGridView originalData;
        private System.Windows.Forms.Button getData;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView filteredData;
        private System.Windows.Forms.Label label1;
    }
}

