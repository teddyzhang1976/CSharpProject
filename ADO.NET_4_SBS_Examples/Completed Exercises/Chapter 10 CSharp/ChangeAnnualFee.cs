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
    public partial class ChangeAnnualFee : Form
    {
        private long ActiveCustomerID;

        public ChangeAnnualFee()
        {
            InitializeComponent();
        }

        public bool PromptUser(long whichCustomer)
        {
            // ----- Prompt the user to change a customer's annual fee.
            ActiveCustomerID = whichCustomer;
            if (this.ShowDialog() == DialogResult.OK)
                return true;
            else
                return false;
        }

        private void ChangeAnnualFee_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.
            string sqlText;
            SqlCommand commandWrapper;
            SqlDataReader customerReader = null;

            // ----- Retrieve the customer data.
            using (SqlConnection linkToDB = General.OpenConnection())
            {
                // ----- Build the parameterized query.
                sqlText = "SELECT FullName, AnnualFee FROM Customer WHERE ID = @CustID";
                commandWrapper = new SqlCommand(sqlText, linkToDB);
                commandWrapper.Parameters.AddWithValue("@CustID", ActiveCustomerID);
                commandWrapper.Connection = linkToDB;

                // ----- Process the query.
                try
                {
                    customerReader = commandWrapper.ExecuteReader();
                    customerReader.Read();
                    CustomerName.Text = (string)customerReader["FullName"];
                    CurrentFee.Text = string.Format("{0:0.00}", (decimal)customerReader["AnnualFee"]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred accessing customer record: " + ex.Message);
                    ActOK.Enabled = false;
                    return;
                }
                finally
                {
                    if (customerReader != null) customerReader.Close();
                }
            }
            NewFee.Text = CurrentFee.Text;
        }

        private void NewFee_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
        }

        private void ActOK_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Verify and save the data.
            string sqlText;
            SqlCommand commandWrapper;
            decimal feeValue;

            // ----- The fee is required, and must be a valid number.
            if (decimal.TryParse(NewFee.Text, out feeValue) == false)
            {
                MessageBox.Show("Please supply a valid annual fee.");
                return;
            }

            // ----- Don't bother if nothing changed.
            if (decimal.Parse(CurrentFee.Text) == feeValue)
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            // ----- Save the new fee.
            sqlText = "UPDATE Customer SET AnnualFee = @NewFee WHERE ID = @CustID";
            commandWrapper = new SqlCommand(sqlText);
            commandWrapper.Parameters.AddWithValue("@NewFee", feeValue);
            commandWrapper.Parameters.AddWithValue("@CustID", ActiveCustomerID);
            try
            {
                General.ExecuteSQL(commandWrapper);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred updating annual fee: " + ex.Message);
                return;
            }

            // ----- Success.
            this.DialogResult = DialogResult.OK;
        }
    }
}
