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
    public partial class AccountManager : Form
    {
        private DataTable CustomerAccounts;

        public AccountManager()
        {
            InitializeComponent();
        }

        private void AccountManager_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.
            DataColumn oneColumn;

            // ----- Build the table of account details.
            CustomerAccounts = new DataTable("Account");

            // ----- Add the event handlers.
            CustomerAccounts.ColumnChanging += new DataColumnChangeEventHandler(this.CustomerAccounts_ColumnChanging);
            CustomerAccounts.RowChanging += new DataRowChangeEventHandler(this.CustomerAccounts_RowChanging);

            // ----- ID is the primary key.
            oneColumn = CustomerAccounts.Columns.Add("ID", typeof(long));
            oneColumn.AutoIncrement = true;
            oneColumn.ReadOnly = true;
            CustomerAccounts.PrimaryKey = new DataColumn[] {oneColumn};

            // ----- Enforce unique account names, up to 30 characters.
            oneColumn = CustomerAccounts.Columns.Add("FullName", typeof(string));
            oneColumn.MaxLength = 30;
            oneColumn.AllowDBNull = false;
            oneColumn.Unique = true;

            // ----- Accounts are active by default.
            oneColumn = CustomerAccounts.Columns.Add("Active", typeof(bool));
            oneColumn.DefaultValue = true;

            // ----- The last two columns are optional.
            CustomerAccounts.Columns.Add("AnnualFee", typeof(decimal));
            CustomerAccounts.Columns.Add("StartDate", typeof(DateTime));

            // ----- Build some sample data rows.

            CustomerAccounts.AcceptChanges();

            // ----- Add each row to the display list as well.
            foreach (DataRow scanRow in CustomerAccounts.Rows)
                AllAccounts.Items.Add(scanRow);
        }

        private void ActAdd_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Add a new account.
            DataRow editRecord;
            bool addComplete = false;

            // ----- Keep prompting the user until the data is valid.
            editRecord = CustomerAccounts.NewRow();
            while (addComplete == false)
            {
                // ----- Prompt the user.
                editRecord.ClearErrors();
                if ((new AccountDetail()).EditAccount(ref editRecord,
                    CustomerAccounts) == false) return;

                // ----- The user completed edits to the row. Commit the changes.
                try
                {
                    CustomerAccounts.Rows.Add(editRecord);
                    CustomerAccounts.AcceptChanges();
                    addComplete = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The account could not be added due to the following error: " +
                        ex.Message);
                }
            }

            // ----- Add this item to the display list.
            AllAccounts.Items.Add(editRecord);
        }

        private void ActEdit_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Edit the selected account.
            DataRow editRecord;
            bool editComplete = false;

            // ----- Ignore if no item is active.
            if (AllAccounts.SelectedIndex == -1) return;
            editRecord = (DataRow)AllAccounts.SelectedItem;

            // ----- Keep prompting the user until the data is valid.
            while (editComplete == false)
            {
                // ----- Prompt the user.
                editRecord.ClearErrors();
                if ((new AccountDetail()).EditAccount(ref editRecord, CustomerAccounts) == false)
                {
                    CustomerAccounts.RejectChanges();
                    AllAccounts.Refresh();
                    return;
                }

                // ----- The user completed edits to the row. Commit the changes.
                try
                {
                    CustomerAccounts.AcceptChanges();
                    editComplete = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The account could not be changed due to the following error: " +
                        ex.Message);
                }
            }

            // ----- Refresh the item in the display list.
            AllAccounts.Refresh();
        }

        private void ActDelete_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Delete the selected account.
            DataRow editRecord;

            // ----- Ignore if no item is active.
            if (AllAccounts.SelectedIndex == -1) return;
            editRecord = (DataRow)AllAccounts.SelectedItem;

            // ----- Prompt the user.
            if (MessageBox.Show("Really delete the selected account?", this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) !=
                DialogResult.Yes) return;

            // ----- Remove the record from the table.
            try
            {
                editRecord.Delete();
                CustomerAccounts.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The account could not be deleted due to the following error: " +
                    ex.Message);
                CustomerAccounts.RejectChanges();
                return;
            }

            // ----- Remove from the display list.
            AllAccounts.Items.Remove(editRecord);
            ActEdit.Enabled = false;
            ActDelete.Enabled = false;
        }

        private void ActClose_Click(System.Object sender, System.EventArgs e)
        {
            // ----- End the sample.
            this.Close();
        }

        private void AllAccounts_DoubleClick(System.Object sender, System.EventArgs e)
        {
            // ----- Same as the edit button.
            if (ActEdit.Enabled == true) ActEdit.PerformClick();
        }

        private void AllAccounts_DrawItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            // ----- Draw a single display item.
            System.Drawing.Brush useBrush;
            DataRow itemDetail;
            StringFormat ellipsesFormat;
            Font activeColFont;
            const int ActiveCharacter = 0xFC;   // Wingdings checkmark
            const int InactiveCharacter = 0xFB; // Wingdings x-mark

            // ----- Ignore undrawable items.
            if (e.Index == -1) return;

            // ----- Draw the background of the item.
            if ((e.State & DrawItemState.Selected) != 0)
                useBrush = SystemBrushes.HighlightText;
            else
                useBrush = SystemBrushes.WindowText;
            e.DrawBackground();

            // ----- Extract the detail from the list.
            itemDetail = (DataRow)AllAccounts.Items[e.Index];

            // ----- Some data may not fit.
            ellipsesFormat = new StringFormat();
            ellipsesFormat.Trimming = StringTrimming.EllipsisCharacter;

            // ----- Draw the account name.
            e.Graphics.DrawString((string)itemDetail["FullName"], e.Font, useBrush,
                new Rectangle(ColFullName.Left - ColActive.Left,
                e.Bounds.Top, ColAnnualFee.Left - ColFullName.Left - 5,
                e.Bounds.Height), ellipsesFormat);

            // ----- Draw the annual fee, if needed.
            if (DBNull.Value.Equals(itemDetail["AnnualFee"]) == false)
                e.Graphics.DrawString(string.Format("{0:c}", (decimal)itemDetail["AnnualFee"]),
                    e.Font, useBrush, ColAnnualFee.Left - ColActive.Left, e.Bounds.Top);

            // ----- Draw the start date, if needed.
            if (DBNull.Value.Equals(itemDetail["StartDate"]) == false)
                e.Graphics.DrawString(string.Format("{0:d}", (DateTime)itemDetail["StartDate"]),
                    e.Font, useBrush, ColStartDate.Left - ColActive.Left, e.Bounds.Top);

            // ----- Use a special font to show the active status.
            activeColFont = new Font("Wingdings", AllAccounts.Font.Size);

            // ----- The display color for the active status differs as well.
            if ((e.State & DrawItemState.Selected) != 0)
                useBrush = SystemBrushes.HighlightText;
            else if ((bool)itemDetail["Active"] == true)
                useBrush = Brushes.Green;
            else
                useBrush = Brushes.Red;

            // ----- Indicate the active status of this row.
            if ((bool)itemDetail["Active"] == true)
            {
                // ----- Active account.
                e.Graphics.DrawString(new string(new char[] {(char)ActiveCharacter}),
                    activeColFont, useBrush, 0, e.Bounds.Top);
            }
            else
            {
                // ----- Inactive account.
                e.Graphics.DrawString(new string(new char[] {(char)InactiveCharacter}),
                    activeColFont, useBrush, 0, e.Bounds.Top);
            }
            activeColFont.Dispose();

            // ----- If the ListBox has focus, draw a focus rectangle.
            e.DrawFocusRectangle();
        }

        private void AllAccounts_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Enable action buttons as needed.
            ActEdit.Enabled = (AllAccounts.SelectedIndex != -1);
            ActDelete.Enabled = (AllAccounts.SelectedIndex != -1);
        }

        private void CustomerAccounts_ColumnChanging(System.Object sender, System.Data.DataColumnChangeEventArgs e)
        {
            // ----- Some columns have special business rules.

        }

        private void CustomerAccounts_RowChanging(System.Object sender, System.Data.DataRowChangeEventArgs e)
        {
            // ----- The start date is required for active accounts.

        }
    }
}
