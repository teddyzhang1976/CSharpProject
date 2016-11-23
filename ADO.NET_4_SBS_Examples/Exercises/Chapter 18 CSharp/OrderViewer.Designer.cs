namespace Chapter_18_CSharp
{
    partial class OrderViewer
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
            this.OptOneCustomer = new System.Windows.Forms.RadioButton();
            this.CustomerID = new System.Windows.Forms.TextBox();
            this.LabelCustomerID = new System.Windows.Forms.Label();
            this.OptAllCustomers = new System.Windows.Forms.RadioButton();
            this.AllOrders = new System.Windows.Forms.DataGridView();
            this.ActView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AllOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // OptOneCustomer
            // 
            this.OptOneCustomer.AutoSize = true;
            this.OptOneCustomer.Location = new System.Drawing.Point(8, 32);
            this.OptOneCustomer.Name = "OptOneCustomer";
            this.OptOneCustomer.Size = new System.Drawing.Size(158, 17);
            this.OptOneCustomer.TabIndex = 1;
            this.OptOneCustomer.Text = "Include One Customer by &ID";
            this.OptOneCustomer.UseVisualStyleBackColor = true;
            this.OptOneCustomer.CheckedChanged += new System.EventHandler(this.CustomerOptions_CheckedChanged);
            // 
            // CustomerID
            // 
            this.CustomerID.Enabled = false;
            this.CustomerID.Location = new System.Drawing.Point(112, 56);
            this.CustomerID.MaxLength = 8;
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Size = new System.Drawing.Size(100, 20);
            this.CustomerID.TabIndex = 3;
            this.CustomerID.Enter += new System.EventHandler(this.CustomerID_Enter);
            // 
            // LabelCustomerID
            // 
            this.LabelCustomerID.AutoSize = true;
            this.LabelCustomerID.Location = new System.Drawing.Point(32, 58);
            this.LabelCustomerID.Name = "LabelCustomerID";
            this.LabelCustomerID.Size = new System.Drawing.Size(68, 13);
            this.LabelCustomerID.TabIndex = 2;
            this.LabelCustomerID.Text = "&Customer ID:";
            // 
            // OptAllCustomers
            // 
            this.OptAllCustomers.AutoSize = true;
            this.OptAllCustomers.Checked = true;
            this.OptAllCustomers.Location = new System.Drawing.Point(8, 8);
            this.OptAllCustomers.Name = "OptAllCustomers";
            this.OptAllCustomers.Size = new System.Drawing.Size(126, 17);
            this.OptAllCustomers.TabIndex = 0;
            this.OptAllCustomers.TabStop = true;
            this.OptAllCustomers.Text = "Include &All Customers";
            this.OptAllCustomers.UseVisualStyleBackColor = true;
            this.OptAllCustomers.CheckedChanged += new System.EventHandler(this.CustomerOptions_CheckedChanged);
            // 
            // AllOrders
            // 
            this.AllOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllOrders.Location = new System.Drawing.Point(8, 88);
            this.AllOrders.Name = "AllOrders";
            this.AllOrders.ReadOnly = true;
            this.AllOrders.Size = new System.Drawing.Size(432, 192);
            this.AllOrders.TabIndex = 5;
            // 
            // ActView
            // 
            this.ActView.Location = new System.Drawing.Point(365, 56);
            this.ActView.Name = "ActView";
            this.ActView.Size = new System.Drawing.Size(75, 23);
            this.ActView.TabIndex = 4;
            this.ActView.Text = "View";
            this.ActView.UseVisualStyleBackColor = true;
            this.ActView.Click += new System.EventHandler(this.ActView_Click);
            // 
            // OrderViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 293);
            this.Controls.Add(this.OptOneCustomer);
            this.Controls.Add(this.CustomerID);
            this.Controls.Add(this.LabelCustomerID);
            this.Controls.Add(this.OptAllCustomers);
            this.Controls.Add(this.AllOrders);
            this.Controls.Add(this.ActView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OrderViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 18 - Order Viewer";
            this.Load += new System.EventHandler(this.OrderViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AllOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RadioButton OptOneCustomer;
        internal System.Windows.Forms.TextBox CustomerID;
        internal System.Windows.Forms.Label LabelCustomerID;
        internal System.Windows.Forms.RadioButton OptAllCustomers;
        internal System.Windows.Forms.DataGridView AllOrders;
        internal System.Windows.Forms.Button ActView;
    }
}

