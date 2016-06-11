using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainExample
{
    public partial class ValidationExample : Form
    {
        public ValidationExample()
        {
            InitializeComponent();
        }

        private void ageText_Validating(object sender, CancelEventArgs e)
        {
            // Get the text from the age control and validate it
            int age;
            bool valid = false;

            if (Int32.TryParse(this.ageText.Text, out age))
            {
                // Now check the age
                if ((age > 0) && (age < 66))
                    valid = true;
            }
            if (valid)
                errorProvider1.SetError(this.ageText, string.Empty);
            else
                errorProvider1.SetError(this.ageText, "The age must be numeric and between 1 and 65");
        }
    }
}
