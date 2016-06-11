using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomAction
{
    public partial class CustomActionForm : Form
    {
        public CustomActionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Custom action was executed.", "Custom Action");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Custom action was canceled.", "Custom Action");
            Application.Exit();
        }
    }
}
