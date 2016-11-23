// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 16 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_16_CSharp
{
    public partial class CustomerEditor : Form
    {
        private SalesOrderEntities ActiveContext;

        public CustomerEditor()
        {
            InitializeComponent();
        }

        private void AllCustomers_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Enable the buttons as needed.
            ActEdit.Enabled = (bool)(AllCustomers.SelectedIndex != -1);
            ActDelete.Enabled = (bool)(AllCustomers.SelectedIndex != -1);
        }

        private void CustomerEditor_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            // ----- Close the context.
            if (ActiveContext != null) ActiveContext.Dispose();
        }

        private void CustomerEditor_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.

            // ----- Create the context. It will remain during the entire program.
            try
            {
                ActiveContext = new SalesOrderEntities(GetConnectionString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
                Application.Exit();
            }

            // ----- Display the existing customers.
            try
            {
                foreach (Customer scanCustomer in ActiveContext.Customers)
                {
                    AllCustomers.Items.Add(new ItemData(scanCustomer.FullName, scanCustomer.ID));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void ActAdd_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Add a new customer to the database.
            Customer newCustomer = null;

            // ----- Prompt the user.
            if ((new CustomerDetail()).EditCustomer(ref newCustomer, ActiveContext) == false) return;

            // ----- Add the customer to the list.
            AllCustomers.Items.Add(new ItemData(newCustomer.FullName, newCustomer.ID));
        }

        private void ActEdit_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Edit an existing customer.
            Customer whichCustomer;

            // ----- Don't bother if no customer is selected.
            if (AllCustomers.SelectedIndex == -1) return;

            // ----- Locate the customer record.
            whichCustomer = ActiveContext.Customers.Where("it.ID = @lookupID",
                new ObjectParameter("lookupID", ItemData.GetItemData(
                AllCustomers.SelectedItem))).First();

            // ----- Prompt the user.
            if ((new CustomerDetail()).EditCustomer(ref whichCustomer, ActiveContext) == false) return;

            // ----- Update the customer in the list.
            AllCustomers.Items[AllCustomers.SelectedIndex] =
                new ItemData(whichCustomer.FullName, whichCustomer.ID);
        }

        private void ActDelete_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Delete a customer record.
            Customer whichCustomer = null;

            // ----- Don't bother if no customer is selected.
            if (AllCustomers.SelectedIndex == -1) return;

            // ----- Locate the customer record.

            if (whichCustomer == null) return;

            // ----- Confirm with the user.
            if (MessageBox.Show("Really delete the customer '" +
                whichCustomer.FullName + "'?", "Delete Customer",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes) return;

            // ----- If this customer has orders, don't delete it.
            if (whichCustomer.OrderEntries.Count > 0)
            {
                MessageBox.Show("You cannot delete this customer because it has orders.");
                return;
            }

            // ----- Delete the customer from the database.
            try
            {
                ActiveContext.DeleteObject(whichCustomer);
                ActiveContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer record: " + ex.Message);
                return;
            }

            // ----- Delete the customer from the display.
            AllCustomers.Items.RemoveAt(AllCustomers.SelectedIndex);
            ActEdit.Enabled = false;
            ActDelete.Enabled = false;
        }

        private string GetConnectionString()
        {
            // ----- Build a connection string for the active database.
            SqlConnectionStringBuilder sqlPortion = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder();

            // ----- Build the provider portion of the connection string.
            sqlPortion.DataSource = @"(local)\SQLExpress";
            sqlPortion.InitialCatalog = "StepSample";
            sqlPortion.IntegratedSecurity = true;

            // ----- Build the Entity Client connection string.
            builder.Metadata = "res://*/SalesOrder.csdl|res://*/SalesOrder.ssdl|res://*/SalesOrder.msl";
            builder.Provider = "System.Data.SqlClient";
            builder.ProviderConnectionString = sqlPortion.ConnectionString;
            return builder.ConnectionString;
        }
    }
}
