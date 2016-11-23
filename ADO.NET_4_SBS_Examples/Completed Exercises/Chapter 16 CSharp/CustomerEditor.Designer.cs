namespace Chapter_16_CSharp
{
    partial class CustomerEditor
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
            this.ActDelete = new System.Windows.Forms.Button();
            this.ActEdit = new System.Windows.Forms.Button();
            this.AllCustomers = new System.Windows.Forms.ListBox();
            this.ActAdd = new System.Windows.Forms.Button();
            this.LabelCustomers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ActDelete
            // 
            this.ActDelete.Enabled = false;
            this.ActDelete.Location = new System.Drawing.Point(296, 88);
            this.ActDelete.Name = "ActDelete";
            this.ActDelete.Size = new System.Drawing.Size(75, 23);
            this.ActDelete.TabIndex = 4;
            this.ActDelete.Text = "&Delete";
            this.ActDelete.UseVisualStyleBackColor = true;
            this.ActDelete.Click += new System.EventHandler(this.ActDelete_Click);
            // 
            // ActEdit
            // 
            this.ActEdit.Enabled = false;
            this.ActEdit.Location = new System.Drawing.Point(296, 56);
            this.ActEdit.Name = "ActEdit";
            this.ActEdit.Size = new System.Drawing.Size(75, 23);
            this.ActEdit.TabIndex = 3;
            this.ActEdit.Text = "&Edit...";
            this.ActEdit.UseVisualStyleBackColor = true;
            this.ActEdit.Click += new System.EventHandler(this.ActEdit_Click);
            // 
            // AllCustomers
            // 
            this.AllCustomers.FormattingEnabled = true;
            this.AllCustomers.Location = new System.Drawing.Point(8, 24);
            this.AllCustomers.Name = "AllCustomers";
            this.AllCustomers.Size = new System.Drawing.Size(280, 160);
            this.AllCustomers.Sorted = true;
            this.AllCustomers.TabIndex = 1;
            this.AllCustomers.SelectedIndexChanged += new System.EventHandler(this.AllCustomers_SelectedIndexChanged);
            // 
            // ActAdd
            // 
            this.ActAdd.Location = new System.Drawing.Point(296, 24);
            this.ActAdd.Name = "ActAdd";
            this.ActAdd.Size = new System.Drawing.Size(75, 23);
            this.ActAdd.TabIndex = 2;
            this.ActAdd.Text = "&Add...";
            this.ActAdd.UseVisualStyleBackColor = true;
            this.ActAdd.Click += new System.EventHandler(this.ActAdd_Click);
            // 
            // LabelCustomers
            // 
            this.LabelCustomers.AutoSize = true;
            this.LabelCustomers.Location = new System.Drawing.Point(8, 8);
            this.LabelCustomers.Name = "LabelCustomers";
            this.LabelCustomers.Size = new System.Drawing.Size(56, 13);
            this.LabelCustomers.TabIndex = 0;
            this.LabelCustomers.Text = "&Customers";
            // 
            // CustomerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 196);
            this.Controls.Add(this.ActDelete);
            this.Controls.Add(this.ActEdit);
            this.Controls.Add(this.AllCustomers);
            this.Controls.Add(this.ActAdd);
            this.Controls.Add(this.LabelCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CustomerEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 16 - Customer Editor";
            this.Load += new System.EventHandler(this.CustomerEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button ActDelete;
        internal System.Windows.Forms.Button ActEdit;
        internal System.Windows.Forms.ListBox AllCustomers;
        internal System.Windows.Forms.Button ActAdd;
        internal System.Windows.Forms.Label LabelCustomers;
    }
}

