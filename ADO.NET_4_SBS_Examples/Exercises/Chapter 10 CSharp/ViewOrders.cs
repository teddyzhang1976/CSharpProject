// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 10 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_10_CSharp
{
    public partial class ViewOrders : Form
    {
        // ----- Local information store of customer orders.
        private class OrderInfo
        {
            public long ID;
            public DateTime OrderDate;
            public decimal OrderTotal;
        }

        private long ActiveCustomerID;

        public ViewOrders()
        {
            InitializeComponent();
        }

        public void ShowOrders(long whichCustomer)
        {
            // ----- Display the orders for a customer.
            ActiveCustomerID = whichCustomer;
            this.ShowDialog();
        }

        private void ViewOrders_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.
            String sqlText;
            SqlCommand commandWrapper;
            SqlDataReader customerReader = null;
            OrderInfo oneOrder;

            // ----- Retrieve the customer data.
            using (SqlConnection linkToDB = General.OpenConnection())
            {
                try
                {
                    // ----- Process the query. The GetCustomerOrders stored procedure
                    //       returns to sets of records, one for the customer and one
                    //       for the orders.

                    // ----- First read the customer record.

                    // ----- Read the next set, which contains the orders.

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred accessing order data: " + ex.Message);
                    return;
                }
                finally
                {
                    if (customerReader != null) customerReader.Close();
                }
            }
        }

        private void AllOrders_DrawItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            // ----- Draw a single display item.
            System.Drawing.Brush useBrush;
            OrderInfo itemDetail;

            // ----- Ignore undrawable items.
            if (e.Index == -1) return;

            // ----- Draw the background of the item.
            if ((e.State & DrawItemState.Selected) != 0)
                useBrush = SystemBrushes.HighlightText;
            else
                useBrush = SystemBrushes.WindowText;
            e.DrawBackground();

            // ----- Extract the detail from the list.
            itemDetail = (OrderInfo)AllOrders.Items[e.Index];

            // ----- Draw the text of the item.
            e.Graphics.DrawString(itemDetail.ID.ToString(), e.Font, useBrush, 0, e.Bounds.Top);
            e.Graphics.DrawString(string.Format("{0:M/d/yyyy}", itemDetail.OrderDate),
                e.Font, useBrush, ColOrderDate.Left - ColOrderID.Left, e.Bounds.Top);
            e.Graphics.DrawString(string.Format("{0:c}", itemDetail.OrderTotal),
                e.Font, useBrush, ColOrderTotal.Left - ColOrderID.Left, e.Bounds.Top);

            // ----- If the ListBox has focus, draw a focus rectangle.
            e.DrawFocusRectangle();
        }
    }
}
