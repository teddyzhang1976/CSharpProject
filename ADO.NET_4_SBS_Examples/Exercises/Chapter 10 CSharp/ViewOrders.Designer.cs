namespace Chapter_10_CSharp
{
    partial class ViewOrders
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
            this.ColOrderTotal = new System.Windows.Forms.Label();
            this.ColOrderDate = new System.Windows.Forms.Label();
            this.ColOrderID = new System.Windows.Forms.Label();
            this.LabelOrders = new System.Windows.Forms.Label();
            this.AnnualFee = new System.Windows.Forms.Label();
            this.LabelAnnualFee = new System.Windows.Forms.Label();
            this.CustomerName = new System.Windows.Forms.Label();
            this.AllOrders = new System.Windows.Forms.ListBox();
            this.LabelCustomer = new System.Windows.Forms.Label();
            this.ActClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ColOrderTotal
            // 
            this.ColOrderTotal.AutoSize = true;
            this.ColOrderTotal.Location = new System.Drawing.Point(248, 56);
            this.ColOrderTotal.Name = "ColOrderTotal";
            this.ColOrderTotal.Size = new System.Drawing.Size(60, 13);
            this.ColOrderTotal.TabIndex = 7;
            this.ColOrderTotal.Text = "Order Total";
            // 
            // ColOrderDate
            // 
            this.ColOrderDate.AutoSize = true;
            this.ColOrderDate.Location = new System.Drawing.Point(152, 56);
            this.ColOrderDate.Name = "ColOrderDate";
            this.ColOrderDate.Size = new System.Drawing.Size(59, 13);
            this.ColOrderDate.TabIndex = 6;
            this.ColOrderDate.Text = "Order Date";
            // 
            // ColOrderID
            // 
            this.ColOrderID.AutoSize = true;
            this.ColOrderID.Location = new System.Drawing.Point(80, 56);
            this.ColOrderID.Name = "ColOrderID";
            this.ColOrderID.Size = new System.Drawing.Size(47, 13);
            this.ColOrderID.TabIndex = 5;
            this.ColOrderID.Text = "Order ID";
            // 
            // LabelOrders
            // 
            this.LabelOrders.AutoSize = true;
            this.LabelOrders.Location = new System.Drawing.Point(8, 56);
            this.LabelOrders.Name = "LabelOrders";
            this.LabelOrders.Size = new System.Drawing.Size(41, 13);
            this.LabelOrders.TabIndex = 4;
            this.LabelOrders.Text = "Orders:";
            // 
            // AnnualFee
            // 
            this.AnnualFee.AutoSize = true;
            this.AnnualFee.Location = new System.Drawing.Point(80, 32);
            this.AnnualFee.Name = "AnnualFee";
            this.AnnualFee.Size = new System.Drawing.Size(27, 13);
            this.AnnualFee.TabIndex = 3;
            this.AnnualFee.Text = "N/A";
            this.AnnualFee.UseMnemonic = false;
            // 
            // LabelAnnualFee
            // 
            this.LabelAnnualFee.AutoSize = true;
            this.LabelAnnualFee.Location = new System.Drawing.Point(8, 32);
            this.LabelAnnualFee.Name = "LabelAnnualFee";
            this.LabelAnnualFee.Size = new System.Drawing.Size(64, 13);
            this.LabelAnnualFee.TabIndex = 2;
            this.LabelAnnualFee.Text = "Annual Fee:";
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSize = true;
            this.CustomerName.Location = new System.Drawing.Point(80, 8);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(27, 13);
            this.CustomerName.TabIndex = 1;
            this.CustomerName.Text = "N/A";
            this.CustomerName.UseMnemonic = false;
            // 
            // AllOrders
            // 
            this.AllOrders.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AllOrders.FormattingEnabled = true;
            this.AllOrders.Location = new System.Drawing.Point(80, 72);
            this.AllOrders.Name = "AllOrders";
            this.AllOrders.Size = new System.Drawing.Size(248, 95);
            this.AllOrders.TabIndex = 8;
            this.AllOrders.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.AllOrders_DrawItem);
            // 
            // LabelCustomer
            // 
            this.LabelCustomer.AutoSize = true;
            this.LabelCustomer.Location = new System.Drawing.Point(8, 8);
            this.LabelCustomer.Name = "LabelCustomer";
            this.LabelCustomer.Size = new System.Drawing.Size(54, 13);
            this.LabelCustomer.TabIndex = 0;
            this.LabelCustomer.Text = "Customer:";
            // 
            // ActClose
            // 
            this.ActClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ActClose.Location = new System.Drawing.Point(254, 176);
            this.ActClose.Name = "ActClose";
            this.ActClose.Size = new System.Drawing.Size(75, 23);
            this.ActClose.TabIndex = 9;
            this.ActClose.Text = "Close";
            this.ActClose.UseVisualStyleBackColor = true;
            // 
            // ViewOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ActClose;
            this.ClientSize = new System.Drawing.Size(339, 208);
            this.ControlBox = false;
            this.Controls.Add(this.ColOrderTotal);
            this.Controls.Add(this.ColOrderDate);
            this.Controls.Add(this.ColOrderID);
            this.Controls.Add(this.LabelOrders);
            this.Controls.Add(this.AnnualFee);
            this.Controls.Add(this.LabelAnnualFee);
            this.Controls.Add(this.CustomerName);
            this.Controls.Add(this.AllOrders);
            this.Controls.Add(this.LabelCustomer);
            this.Controls.Add(this.ActClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ViewOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 10 - View Orders";
            this.Load += new System.EventHandler(this.ViewOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label ColOrderTotal;
        internal System.Windows.Forms.Label ColOrderDate;
        internal System.Windows.Forms.Label ColOrderID;
        internal System.Windows.Forms.Label LabelOrders;
        internal System.Windows.Forms.Label AnnualFee;
        internal System.Windows.Forms.Label LabelAnnualFee;
        internal System.Windows.Forms.Label CustomerName;
        internal System.Windows.Forms.ListBox AllOrders;
        internal System.Windows.Forms.Label LabelCustomer;
        internal System.Windows.Forms.Button ActClose;
    }
}