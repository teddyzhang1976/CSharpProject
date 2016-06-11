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
    public partial class ButtonExample : Form
    {
        public ButtonExample()
        {
            InitializeComponent();
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked the default button");
        }

        private void threeState_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (null != cb)
                threeStateState.Text = string.Format("State is {0}", cb.CheckState);
        }
    }
}
