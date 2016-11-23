// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 18 - Visual Basic Version
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

namespace Chapter_18_CSharp
{
    public partial class OrderViewer : Form
    {
        // ----- Fields used to monitor the active database content.
        private DataSet CustomerSet = new DataSet();

        public OrderViewer()
        {
            InitializeComponent();
        }

        private void OrderViewer_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.
            SqlCommand retrieveCommand;
            SqlConnection linkToDB;
            SqlDataAdapter orderAdapter = new SqlDataAdapter();

            // ----- Open the database.
            linkToDB = new SqlConnection(GetConnectionString());

            // ----- Build the command for the customer and order records.
            retrieveCommand = new SqlCommand(
                "SELECT * FROM Customer;SELECT * FROM OrderEntry", linkToDB);
            orderAdapter.SelectCommand = retrieveCommand;

            // ----- Using the basic external-internal syntax is quick.
            orderAdapter.TableMappings.Add("Table", "Customer");
            orderAdapter.TableMappings.Add("Table1", "Order");

            // ----- Load the data from the database into local storage.
            try
            {
                CustomerSet = new DataSet();
                orderAdapter.Fill(CustomerSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred loading customer orders: " + ex.Message);
            }
        }

        private void ActView_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Try to display one or more customer orders.
            DataTable customerTable;
            DataTable orderTable;

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

            // ----- Locate the customer and order tables.
            customerTable = CustomerSet.Tables["Customer"];
            orderTable = CustomerSet.Tables["Order"];

            // ----- Build an ad hoc table of status codes.
            var statusTable = new [] {
                new { Code = "P", Description = "Active Order" },
                new { Code = "C", Description = "Completed / Shipped"},
                new { Code = "X", Description = "Canceled" }};

            // ----- Retrieve all customer orders.

            // ----- If this is a single customer query, apply the filter.
            if (OptOneCustomer.Checked == true)
            {
                // ----- Filter and display the orders. Try the extension
                //       method way of filtering.

            }
            else
            {
                // ----- Just display the original full results.

            }
        }

        public string GetConnectionString()
        {
            // ----- Build a connection string for the active database.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = @"(local)\SQLExpress";
            builder.InitialCatalog = "StepSample";
            builder.IntegratedSecurity = true;
            return builder.ConnectionString;
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
