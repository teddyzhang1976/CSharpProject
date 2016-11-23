// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 12 - C#
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
using System.Transactions;

namespace Chapter_12_CSharp
{
    public partial class AccountTransfer : Form
    {
        private const string CheckingAccountID = "123456789";
        private const string SavingsAccountID = "987654321";

        public AccountTransfer()
        {
            InitializeComponent();
        }

        private void AccountTransfer_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Load in the account balances.
            RefreshBalances();
        }

        private void ActTransfer_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Initiate a transfer. First check for a valid transfer amount.
            if (IsNumeric(TransferAmount.Text) == false)
            {
                MessageBox.Show("The transfer amount must be a valid number.");
                return;
            }

            // ----- Local or distributed?
            if (UseDistributed.Checked)
            {
                if (TransferDistributed() == false) return;
            }
            else
            {
                if (TransferLocal() == false) return;
            }

            // ----- Update the display.
            RefreshBalances();
        }

        private void TransferAmount_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
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

        private bool IsNumeric(string baseString)
        {
            // ----- Do a quick test for a valid decimal string.
            decimal result;

            if ((baseString == null) || (baseString.Trim().Length == 0))
                return false;
            return decimal.TryParse(baseString, out result);
        }

        private void RefreshBalances()
        {
            // ----- Prepare the form.
            decimal result;
            string sqlText;
            SqlCommand accountCommand;

            using (SqlConnection linkToDB = new SqlConnection(GetConnectionString()))
            {
                // ----- Open the database.
                try
                {
                    linkToDB.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error accessing the database: " + ex.Message);
                    return;
                }

                // ----- Build a statement to get the balances.
                sqlText = "SELECT Balance FROM BankAccount WHERE AccountNumber = @ID";
                accountCommand = new SqlCommand(sqlText, linkToDB);

                // ----- Get the checking account value.
                try
                {
                    accountCommand.Parameters.AddWithValue("@ID", CheckingAccountID);
                    result = (decimal)accountCommand.ExecuteScalar();
                    CheckingBalance.Text = string.Format("{0:c}", result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving checking account balance: " + ex.Message);
                    return;
                }

                // ----- Get the savings account value.
                try
                {
                    accountCommand.Parameters["@ID"].Value = SavingsAccountID;
                    result = (decimal)accountCommand.ExecuteScalar();
                    SavingsBalance.Text = string.Format("{0:c}", result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving savings account balance: " + ex.Message);
                    return;
                }
            }
        }

        private bool TransferDistributed()
        {
            // ----- Transfer money using a local transaction.
            string sqlText;
            decimal toTransfer;
            SqlCommand withdrawal;
            SqlCommand deposit;

            // ----- Retrieve the transfer amount.
            toTransfer = decimal.Parse(TransferAmount.Text);

            // ----- Create the withdrawal and deposit connections.
            using (SqlConnection sourceLink = new SqlConnection(GetConnectionString()))
            {
                using (SqlConnection destLink = new SqlConnection(GetConnectionString()))
                {
                    // ----- Prepare and perform the withdrawal.
                    sqlText = @"UPDATE BankAccount SET Balance = Balance - @ToTransfer
                        WHERE AccountNumber = @FromAccount";
                    withdrawal = new SqlCommand(sqlText, sourceLink);
                    withdrawal.Parameters.AddWithValue("@ToTransfer", toTransfer);
                    if (OptFromChecking.Checked)
                        withdrawal.Parameters.AddWithValue("@FromAccount", CheckingAccountID);
                    else
                        withdrawal.Parameters.AddWithValue("@FromAccount", SavingsAccountID);

                    // ----- Prepare and perform the deposit.
                    sqlText = @"UPDATE BankAccount SET Balance = Balance + @ToTransfer
                        WHERE AccountNumber = @ToAccount";
                    deposit = new SqlCommand(sqlText, destLink);
                    deposit.Parameters.AddWithValue("@ToTransfer", toTransfer);
                    if (OptFromChecking.Checked)
                        deposit.Parameters.AddWithValue("@ToAccount", SavingsAccountID);
                    else
                        deposit.Parameters.AddWithValue("@ToAccount", CheckingAccountID);

                    // ----- Perform the transfer.
                    try
                    {
                        // ----- Perform the withdrawal.
                        sourceLink.Open();
                        withdrawal.ExecuteNonQuery();

                        // ----- Perform the deposit.
                        destLink.Open();
                        deposit.ExecuteNonQuery();

                        // ----- Transfer complete. Commit the transaction.

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error transferring funds: " + ex.Message);
                        return false;
                    }
                }
            }

            // ----- Successful transaction.
            return true;
        }

        private bool TransferLocal()
        {
            // ----- Transfer money using a local transaction.
            string sqlText;
            decimal toTransfer;
            SqlCommand withdrawal;
            SqlCommand deposit;
            SqlTransaction envelope;

            // ----- Retrieve the transfer amount.
            toTransfer = decimal.Parse(TransferAmount.Text);

            using (SqlConnection linkToDB = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    // ----- The database must be opened to create the transaction.

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error accessing the database: " + ex.Message);
                    return false;
                }

                // ----- Prepare and perform the withdrawal.

                // ----- Prepare and perform the deposit.

                // ----- Perform the transfer.
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error transferring funds: " + ex.Message);

                    // ----- Do a rollback instead.
                    try
                    {

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Error cancelling the transaction: " + ex2.Message);
                    }
                    return false;
                }
            }

            // ----- Successful transaction.
            return true;
        }
    }
}
