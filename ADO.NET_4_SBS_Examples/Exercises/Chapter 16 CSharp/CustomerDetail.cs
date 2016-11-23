// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 16 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_16_CSharp
{
    public partial class CustomerDetail : Form
    {
        private Customer ActiveCustomer;
        private SalesOrderEntities ActiveContext;

        public CustomerDetail()
        {
            InitializeComponent();
        }

        public bool EditCustomer(ref Customer oneCustomer, SalesOrderEntities context)
        {
            // ----- Prompt the user to edit a new or existing customer.
            this.ActiveCustomer = oneCustomer;
            this.ActiveContext = context;
            if (this.ShowDialog() == DialogResult.OK)
            {
                if (oneCustomer == null) oneCustomer = this.ActiveCustomer;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void TextFields_Enter(System.Object sender, System.EventArgs e)
        {
            // ----- Highlight the entire text.
            ((TextBox)sender).SelectAll();
        }

        private void CustomerDetail_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Load in the list of states/regions.

            // ----- Add each state to the state drop-down.
            StateName.Items.Add(new ItemData("<Not Selected>", -1L));
            foreach (StateRegion scanState in this.ActiveContext.StateRegions.OrderBy("it.FullName"))
            {
                StateName.Items.Add(new ItemData(scanState.FullName, scanState.ID));
            }
            StateName.SelectedIndex = 0;

            // ----- Fill in the existing details.
            if (this.ActiveCustomer != null)
            {
                CustomerName.Text = this.ActiveCustomer.FullName;
                if (this.ActiveCustomer.Address1 != null)
                    Address1.Text = this.ActiveCustomer.Address1;
                if (this.ActiveCustomer.Address2 != null)
                    Address2.Text = this.ActiveCustomer.Address2;
                if (this.ActiveCustomer.City != null)
                    CityName.Text = this.ActiveCustomer.City;
                if (this.ActiveCustomer.StateRegion != null)
                    StateName.SelectedIndex = StateName.Items.IndexOf(this.ActiveCustomer.StateRegion);
                if (this.ActiveCustomer.PostalCode != null)
                    PostalCode.Text = this.ActiveCustomer.PostalCode;
                if (this.ActiveCustomer.PhoneNumber != null)
                    PhoneNumber.Text = this.ActiveCustomer.PhoneNumber;
                if (this.ActiveCustomer.WebSite != null)
                    WebSite.Text = this.ActiveCustomer.WebSite;
                AnnualFee.Value = this.ActiveCustomer.AnnualFee;
            }
        }

        private bool SaveFormData()
        {
            // ----- Update the customer instance with the edited values.
            Customer toUpdate;

            if (this.ActiveCustomer == null)
            {
                // ----- New customer.
                toUpdate = new Customer();
            }
            else
            {
                // ----- Existing customer.
                toUpdate = this.ActiveCustomer;
            }

            // ----- Update the individual fields.

            // ----- Update the database.
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the customer record: " + ex.Message);
                return false;
            }
        }

        private bool VerifyFormData()
        {
            // ----- A customer name is required.
            if (CustomerName.Text.Trim().Length == 0)
            {
                MessageBox.Show("A customer name is required.");
                CustomerName.Focus();
                return false;
            }

            // ----- Success.
            return true;
        }

        private void ActOK_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Confirm and save the data.
            if (VerifyFormData() == false) return;
            if (SaveFormData() == false) return;
            this.DialogResult = DialogResult.OK;
        }
    }
}
