using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppSupport;

namespace ClientWinForms
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void GetDatesBtn_Click(object sender, EventArgs e)
        {
            DateService dateService= new DateService();
            textBox1.Text = dateService.GetLongDateInfoString();
            textBox2.Text = dateService.GetShortDateInfoString();
        }

    }
}
