using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _02_UserControl
{
    public partial class AddressControl : UserControl
    {
        public AddressControl()
        {
            InitializeComponent();
        }

        private void OnValidatePassword(object sender, CancelEventArgs e)
        {
            bool defined = !string.IsNullOrEmpty(this.postcode.Text);

            this.errorProvider1.SetError(this.postcode, defined ? "" : "The postcode is mandatory");
        }
    }
}
