// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 19 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_19_CSharp
{
    public partial class OrderViewer : Form
    {
        // ----- Fields used to monitor the active database content.
        private SalesOrderEntities OrderContext;

        public OrderViewer()
        {
            InitializeComponent();
        }

        private void OrderViewer_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            // ----- Clean up.
            if (OrderContext != null) OrderContext.Dispose();
        }

        private void OrderViewer_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Open the context to the set of customer orders.
            OrderContext = new SalesOrderEntities(General.GetConnectionString());
        }

        private void ActView_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Try to display one or more customer orders.

            // ----- Check for a valid customer ID if in ID mode.
            if (OptOneCustomer.Checked == true)
            {
                if (IsNumeric(CustomerID.Text) == false)
                {
                    MessageBox.Show("Please supply a valid customer ID.");
                    return;
                }
            }

            // ----- Clear any previous results.
            AllOrders.DataSource = null;

            // ----- Build an ad hoc table of status codes.
            var statusTable = new[] {
                new { Code = "P", Description = "Active Order" },
                new { Code = "C", Description = "Completed / Shipped" },
                new { Code = "X", Description = "Canceled" }};

            // ----- Retrieve all customer orders.

            // ----- Add in the status code.

            // ----- If this is a single customer query, apply the filter.
            if (OptOneCustomer.Checked == true)
            {
                // ----- Filter and display the orders. Try the extension
                //       method way of filtering.
                var result3 = result2.Where(ord => ord.CustomerID == long.Parse(CustomerID.Text));
                AllOrders.DataSource = result3.ToList();
            }
            else
            {
                // ----- Just display the original full results.
                AllOrders.DataSource = result2.ToList();
            }
        }

        private void CustomerID_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
        }

        private void CustomerOptions_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Enable the customer ID field if needed.
            if (((RadioButton)sender).Checked == true)
                CustomerID.Enabled = OptOneCustomer.Checked;
        }

        private bool IsNumeric(string baseString)
        {
            // ----- Do a quick test for a valid decimal string.
            decimal result;

            if ((baseString == null) || (baseString.Trim().Length == 0))
                return false;
            return decimal.TryParse(baseString, out result);
        }
    }
}
