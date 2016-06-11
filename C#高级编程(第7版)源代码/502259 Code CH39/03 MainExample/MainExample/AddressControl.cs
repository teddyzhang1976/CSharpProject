using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainExample
{
    public partial class AddressControl : UserControl
    {
        public AddressControl()
        {
            InitializeComponent();
        }

        public string AddressLine1
        {
            get { return this.addressLine1.Text; }
            set { this.addressLine1.Text = value; }
        }

        public string AddressLine2
        {
            get { return this.addressLine2.Text; }
            set { this.addressLine2.Text = value; }
        }

        public string AddressLine3
        {
            get { return this.addressLine3.Text; }
            set { this.addressLine3.Text = value; }
        }

        public string AddressLine4
        {
            get { return this.addressLine4.Text; }
            set { this.addressLine4.Text = value; }
        }

        public string Postcode
        {
            get { return this.postcode.Text; }
            set { this.postcode.Text = value; }
        }

        private void OnValidateAddress1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.addressLine1.Text))
                addressErrorProvider.SetError(this.addressLine1, "Address Line 1 is mandatory");
        }

        private void OnValidateAddress2(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.addressLine2.Text))
                addressErrorProvider.SetError(this.addressLine2, "Address Line 2 is mandatory");
        }

        private void OnValidatePostcode(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.postcode.Text))
                addressErrorProvider.SetError(this.postcode, "The postcode is mandatory");
        }

        private bool IsValid(TextBox tb)
        {
            return !string.IsNullOrEmpty(tb.Text);
        }
    }
}
