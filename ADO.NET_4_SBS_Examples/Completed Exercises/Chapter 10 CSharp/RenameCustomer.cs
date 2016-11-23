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
    public partial class RenameCustomer : Form
    {
        private long ActiveCustomerID;

        public RenameCustomer()
        {
            InitializeComponent();
        }

        public bool PromptUser(long whichCustomer)
        {
            // ----- Prompt the user to rename a customer record.
            ActiveCustomerID = whichCustomer;
            if (this.ShowDialog() == DialogResult.OK)
                return true;
            else
                return false;
        }

        private void RenameCustomer_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.
            string sqlText;
            SqlCommand commandWrapper;

            // ----- Retrieve the customer name.
            using (SqlConnection linkToDB = General.OpenConnection())
            {
                // ----- Build the parameterized query.
                sqlText = "SELECT FullName FROM Customer WHERE ID = @CustID";
                commandWrapper = new SqlCommand(sqlText, linkToDB);
                commandWrapper.Parameters.AddWithValue("@CustID", ActiveCustomerID);

                // ----- Process the query.
                try
                {
                    CurrentName.Text = (string)commandWrapper.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred accessing customer name: " + ex.Message);
                    ActOK.Enabled = false;
                    return;
                }
            }
            NewName.Text = CurrentName.Text;
        }

        private void NewName_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
        }

        private void ActOK_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Verify and save the data.
            string sqlText;
            SqlCommand commandWrapper;

            // ----- The name is required.
            if (NewName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please supply a new customer name.");
                return;
            }

            // ----- Don't bother if nothing changed.
            if (CurrentName.Text == NewName.Text)
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            // ----- Make sure this name isn't used by another record.
            sqlText = @"SELECT COUNT(*) FROM Customer WHERE ID <> @CustID
                AND UPPER(FullName) = @TestName";
            commandWrapper = new SqlCommand(sqlText);
            commandWrapper.Parameters.AddWithValue("@CustID", ActiveCustomerID);
            commandWrapper.Parameters.AddWithValue("@TestName", NewName.Text.Trim().ToUpper());
            try
            {
                if ((int)General.ExecuteSQLReturn(commandWrapper) > 0)
                {
                    MessageBox.Show("That name is already in use.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred accessing customer name: " + ex.Message);
                return;
            }

            // ----- Save the new name.
            sqlText = "UPDATE Customer SET FullName = @NewName WHERE ID = @CustID";
            commandWrapper = new SqlCommand(sqlText);
            commandWrapper.Parameters.AddWithValue("@NewName", NewName.Text.Trim());
            commandWrapper.Parameters.AddWithValue("@CustID", ActiveCustomerID);
            try
            {
                General.ExecuteSQL(commandWrapper);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred updating customer name: " + ex.Message);
                return;
            }

            // ----- Success.
            this.DialogResult = DialogResult.OK;
        }
    }
}
