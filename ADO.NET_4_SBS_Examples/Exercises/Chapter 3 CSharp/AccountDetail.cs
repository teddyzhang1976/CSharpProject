// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 3 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_3_CSharp
{
    public partial class AccountDetail : Form
    {
        private DataRow AccountEntry;
        private DataTable AccountTable;

        public AccountDetail()
        {
            InitializeComponent();
        }

        public bool EditAccount(ref DataRow whichAccount, DataTable baseTable)
        {
            // ----- Prompt the user to edit the account.
            AccountEntry = whichAccount;
            AccountTable = baseTable;
            if (this.ShowDialog() == DialogResult.OK)
                return true;
            else
                return false;
        }

        private void AccountDetail_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.

        }

        private void TextFields_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire field.
            ((TextBox)sender).SelectAll();
        }

        private void ActOK_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Perform some basic data checks.
            DataRow workArea;

            // ----- Annual Fee, if supplied, must be numeric.
            if ((AnnualFee.Text.Trim().Length > 0) &&
                    (IsNumeric(AnnualFee.Text) == false))
            {
                MessageBox.Show("Annual Fee, if supplied, must be numeric.");
                return;
            }

            // ----- Start Date, if supplied, must be a valid date.
            if ((StartDate.Text.Trim().Length > 0) &&
                    (IsDate(StartDate.Text) == false))
            {
                MessageBox.Show("Start Date, if supplied, must be a valid date.");
                return;
            }

            // ----- Obtain the record to update.
            workArea = AccountEntry;
            if (workArea == null)
                workArea = AccountTable.NewRow();
            workArea.ClearErrors();

            try
            {
                // ----- Save the changes in the record.
                workArea.BeginEdit();

                // ----- Check for column-level errors.
                if (workArea.HasErrors)
                {
                    ReportRowError(workArea);
                    workArea.CancelEdit();
                    return;
                }

                // ----- Check for row-level errors.
                workArea.EndEdit();
                if (workArea.HasErrors)
                {
                    ReportRowError(workArea);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // ----- Success.
            AccountEntry = workArea;
            this.DialogResult = DialogResult.OK;
        }

        private void ReportRowError(DataRow whichRow, string messagePrefix = "")
        {
            // ----- Show first column-level or row-level error.
            string errorText = "";
            DataColumn[] errorColumns = whichRow.GetColumnsInError();

            if (errorColumns.Count() > 0)
                errorText = whichRow.GetColumnError(errorColumns[0]);
            else if (whichRow.RowError.Length > 0)
                errorText = whichRow.RowError;
            if (errorText.Length == 0)
                errorText = "An unknown error occurred.";
            MessageBox.Show(messagePrefix + errorText);
        }

        private bool IsNumeric(string baseString)
        {
            // ----- Do a quick test for a valid decimal string.
            decimal result;

            if ((baseString == null) || (baseString.Trim().Length == 0))
                return false;
            return decimal.TryParse(baseString, out result);
        }

        private bool IsDate(string baseString)
        {
            // ----- Do a quick test for a valid date string.
            DateTime result;

            if ((baseString == null) || (baseString.Trim().Length == 0))
                return false;
            return DateTime.TryParse(baseString, out result);
        }
    }
}
