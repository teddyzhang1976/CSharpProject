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
    public partial class ManageCustomers : Form
    {
        // ----- Local information store of customer elements.
        private class CustomerInfo
        {
            public long ID;
            public string Name;
            public decimal AnnualFee;
            public int TotalOrders;

            public override bool Equals(Object obj)
            {
                // ----- Locate a matching customer ID.
                if (obj.GetType() == typeof(long))
                {
                    if (this.ID == (long)obj) return true; else return false;
                }
                else
                    return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        public ManageCustomers()
        {
            InitializeComponent();
        }

        private void ManageCustomers_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Start with the list of customers.
            RefreshCustomerList();
        }

        private void AllCustomers_DoubleClick(System.Object sender, System.EventArgs e)
        {
            // ----- Same as the View Orders button.
            ActViewOrders.PerformClick();
        }

        private void AllCustomers_DrawItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            // ----- Draw a single display item.
            System.Drawing.Brush useBrush;
            CustomerInfo itemDetail;
            StringFormat ellipsesFormat;

            // ----- Ignore undrawable items.
            if (e.Index == -1) return;

            // ----- Draw the background of the item.
            if ((e.State & DrawItemState.Selected) != 0)
                useBrush = SystemBrushes.HighlightText;
            else
                useBrush = SystemBrushes.WindowText;
            e.DrawBackground();

            // ----- Extract the detail from the list.
            itemDetail = (CustomerInfo)AllCustomers.Items[e.Index];

            // ----- Some data may not fit.
            ellipsesFormat = new StringFormat();
            ellipsesFormat.Trimming = StringTrimming.EllipsisCharacter;

            // ----- Draw the text of the item.
            e.Graphics.DrawString(itemDetail.Name, e.Font, useBrush,
                new Rectangle(0, e.Bounds.Top, ColAnnualFee.Left - ColCustomerName.Left - 5,
                e.Bounds.Height), ellipsesFormat);
            e.Graphics.DrawString(string.Format("{0:c}", itemDetail.AnnualFee),
                e.Font, useBrush, ColAnnualFee.Left, e.Bounds.Top);
            e.Graphics.DrawString(itemDetail.TotalOrders.ToString(),
                e.Font, useBrush, ColOrders.Left, e.Bounds.Top);

            // ----- If the ListBox has focus, draw a focus rectangle.
            e.DrawFocusRectangle();
        }

        private void AllCustomers_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            // ----- Enable the controls as needed.
            ActRename.Enabled = (AllCustomers.SelectedIndex != -1);
            ActAnnualFee.Enabled = (AllCustomers.SelectedIndex != -1);
            ActViewOrders.Enabled = (AllCustomers.SelectedIndex != -1);
        }

        private void ActRename_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Rename the selected customer.
            CustomerInfo whichCustomer;

            // ----- Access the customer record.
            if (AllCustomers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer from the list.");
                return;
            }
            whichCustomer = (CustomerInfo)AllCustomers.SelectedItem;

            // ----- Prompt to rename the customer.
            if ((new RenameCustomer()).PromptUser(whichCustomer.ID) == true)
            {
                // ----- Refresh the list to show the new name.
                RefreshCustomerList();
                AllCustomers.SelectedIndex = AllCustomers.Items.IndexOf(whichCustomer.ID);
            }
        }

        private void ActAnnualFee_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Change the annual fee of the selected customer.
            CustomerInfo whichCustomer;

            // ----- Access the customer record.
            if (AllCustomers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer from the list.");
                return;
            }
            whichCustomer = (CustomerInfo)AllCustomers.SelectedItem;

            // ----- Prompt to rename the customer.
            if ((new ChangeAnnualFee()).PromptUser(whichCustomer.ID) == true)
            {
                // ----- Refresh the list to show the annual fee.
                RefreshCustomerList();
                AllCustomers.SelectedIndex = AllCustomers.Items.IndexOf(whichCustomer.ID);
            }
        }

        private void ActViewOrders_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Display the orders of the selected customer.
            CustomerInfo whichCustomer;

            // ----- Access the customer record.
            if (AllCustomers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer from the list.");
                return;
            }
            whichCustomer = (CustomerInfo)AllCustomers.SelectedItem;

            // ----- Prompt to rename the customer.
            (new ViewOrders()).ShowOrders(whichCustomer.ID);
        }

        private void RefreshCustomerList()
        {
            // ----- Load in the list of customers.
            String sqlText;
            SqlDataReader customerReader = null;
            SqlConnection linkToDB = null;
            CustomerInfo oneCustomer;

            // ----- Clear any previous customers.
            AllCustomers.Items.Clear();

            // ----- Retrieve the customers.
            sqlText = @"SELECT CU.ID, CU.FullName, CU.AnnualFee, COUNT(OE.ID) AS Orders
                FROM Customer AS CU LEFT JOIN OrderEntry AS OE ON
                CU.ID = OE.Customer GROUP BY CU.ID, CU.FullName, CU.AnnualFee
                ORDER BY CU.FullName";
            try
            {
                // ----- Access the database.
                linkToDB = General.OpenConnection();
                if (linkToDB == null) return;

                // ----- Read in the records.
                customerReader = General.OpenReader(sqlText, linkToDB);
                while (customerReader.Read())
                {
                    // ----- Add a new customer entry.
                    oneCustomer = new CustomerInfo();
                    oneCustomer.ID = (long)customerReader["ID"];
                    oneCustomer.Name = (string)customerReader["FullName"];
                    oneCustomer.AnnualFee = (decimal)customerReader["AnnualFee"];
                    oneCustomer.TotalOrders = (int)customerReader["Orders"];
                    AllCustomers.Items.Add(oneCustomer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while accessing customer list: " + ex.Message);
            }
            finally
            {
                if (customerReader != null) customerReader.Close();
                if (linkToDB != null) linkToDB.Dispose();
            }
        }
    }
}
