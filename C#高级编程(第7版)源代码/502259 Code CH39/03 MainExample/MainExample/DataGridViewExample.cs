using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace MainExample
{
    public partial class DataGridViewExample : Form
    {
        public DataGridViewExample()
        {
            InitializeComponent();
        }

        public DataGridViewExample(Action<DataGridView> populate)
        {
            InitializeComponent();
            _populate = populate;
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {
            _populate(this.dataGridView1);
        }

        private Action<DataGridView> _populate;
    }
}
