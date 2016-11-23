namespace Chapter_10_CSharp
{
    partial class ManageCustomers
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
            this.ActViewOrders = new System.Windows.Forms.Button();
            this.ActAnnualFee = new System.Windows.Forms.Button();
            this.ColOrders = new System.Windows.Forms.Label();
            this.ColAnnualFee = new System.Windows.Forms.Label();
            this.AllCustomers = new System.Windows.Forms.ListBox();
            this.ActRename = new System.Windows.Forms.Button();
            this.ColCustomerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ActViewOrders
            // 
            this.ActViewOrders.Enabled = false;
            this.ActViewOrders.Location = new System.Drawing.Point(280, 168);
            this.ActViewOrders.Name = "ActViewOrders";
            this.ActViewOrders.Size = new System.Drawing.Size(128, 23);
            this.ActViewOrders.TabIndex = 6;
            this.ActViewOrders.Text = "View &Orders";
            this.ActViewOrders.UseVisualStyleBackColor = true;
            this.ActViewOrders.Click += new System.EventHandler(this.ActViewOrders_Click);
            // 
            // ActAnnualFee
            // 
            this.ActAnnualFee.Enabled = false;
            this.ActAnnualFee.Location = new System.Drawing.Point(144, 168);
            this.ActAnnualFee.Name = "ActAnnualFee";
            this.ActAnnualFee.Size = new System.Drawing.Size(128, 23);
            this.ActAnnualFee.TabIndex = 5;
            this.ActAnnualFee.Text = "Change &Annual Fee";
            this.ActAnnualFee.UseVisualStyleBackColor = true;
            this.ActAnnualFee.Click += new System.EventHandler(this.ActAnnualFee_Click);
            // 
            // ColOrders
            // 
            this.ColOrders.AutoSize = true;
            this.ColOrders.Location = new System.Drawing.Point(360, 8);
            this.ColOrders.Name = "ColOrders";
            this.ColOrders.Size = new System.Drawing.Size(38, 13);
            this.ColOrders.TabIndex = 2;
            this.ColOrders.Text = "Orders";
            // 
            // ColAnnualFee
            // 
            this.ColAnnualFee.AutoSize = true;
            this.ColAnnualFee.Location = new System.Drawing.Point(248, 8);
            this.ColAnnualFee.Name = "ColAnnualFee";
            this.ColAnnualFee.Size = new System.Drawing.Size(61, 13);
            this.ColAnnualFee.TabIndex = 1;
            this.ColAnnualFee.Text = "Annual Fee";
            // 
            // AllCustomers
            // 
            this.AllCustomers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AllCustomers.FormattingEnabled = true;
            this.AllCustomers.Location = new System.Drawing.Point(8, 24);
            this.AllCustomers.Name = "AllCustomers";
            this.AllCustomers.Size = new System.Drawing.Size(424, 134);
            this.AllCustomers.TabIndex = 3;
            this.AllCustomers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.AllCustomers_DrawItem);
            this.AllCustomers.SelectedIndexChanged += new System.EventHandler(this.AllCustomers_SelectedIndexChanged);
            this.AllCustomers.DoubleClick += new System.EventHandler(this.AllCustomers_DoubleClick);
            // 
            // ActRename
            // 
            this.ActRename.Enabled = false;
            this.ActRename.Location = new System.Drawing.Point(8, 168);
            this.ActRename.Name = "ActRename";
            this.ActRename.Size = new System.Drawing.Size(128, 23);
            this.ActRename.TabIndex = 4;
            this.ActRename.Text = "&Rename Customer";
            this.ActRename.UseVisualStyleBackColor = true;
            this.ActRename.Click += new System.EventHandler(this.ActRename_Click);
            // 
            // ColCustomerName
            // 
            this.ColCustomerName.AutoSize = true;
            this.ColCustomerName.Location = new System.Drawing.Point(8, 8);
            this.ColCustomerName.Name = "ColCustomerName";
            this.ColCustomerName.Size = new System.Drawing.Size(82, 13);
            this.ColCustomerName.TabIndex = 0;
            this.ColCustomerName.Text = "&Customer Name";
            // 
            // ManageCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 201);
            this.Controls.Add(this.ActViewOrders);
            this.Controls.Add(this.ActAnnualFee);
            this.Controls.Add(this.ColOrders);
            this.Controls.Add(this.ColAnnualFee);
            this.Controls.Add(this.AllCustomers);
            this.Controls.Add(this.ActRename);
            this.Controls.Add(this.ColCustomerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 10 - Customer Management";
            this.Load += new System.EventHandler(this.ManageCustomers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button ActViewOrders;
        internal System.Windows.Forms.Button ActAnnualFee;
        internal System.Windows.Forms.Label ColOrders;
        internal System.Windows.Forms.Label ColAnnualFee;
        internal System.Windows.Forms.ListBox AllCustomers;
        internal System.Windows.Forms.Button ActRename;
        internal System.Windows.Forms.Label ColCustomerName;
    }
}

