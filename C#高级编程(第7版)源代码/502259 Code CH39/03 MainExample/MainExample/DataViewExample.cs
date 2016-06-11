using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;

namespace MainExample
{
    public partial class DataViewExample : Form
    {
        public DataViewExample()
        {
            InitializeComponent();
        }

        private void getData_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["northwind"].ConnectionString))
            {
                string select = "SELECT * FROM products";

                SqlDataAdapter da = new SqlDataAdapter(select, con);

                DataSet ds = new DataSet();

                da.Fill(ds, "Products");

                originalData.AutoGenerateColumns = true;
                originalData.DataSource = ds.Tables["Products"];

                DataView dv = new DataView(ds.Tables["Products"]);

                filteredData.AutoGenerateColumns = true;
                filteredData.DataSource = dv;

                comboBox1.SelectedIndex = 6;
                comboBox1.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataViewRowState state;

            switch (comboBox1.Text)
            {
                case "Added":
                    state = DataViewRowState.Added;
                    break;
                case "CurrentRows":
                    state = DataViewRowState.CurrentRows;
                    break;
                case "Deleted":
                    state = DataViewRowState.Deleted;
                    break;
                case "ModifiedCurrent":
                    state = DataViewRowState.ModifiedCurrent;
                    break;
                case "ModifiedOriginal":
                    state = DataViewRowState.ModifiedOriginal;
                    break;
                case "None":
                    state = DataViewRowState.None;
                    break;
                case "OriginalRows":
                    state = DataViewRowState.OriginalRows;
                    break;
                case "Unchanged":
                    state = DataViewRowState.Unchanged;
                    break;
                default:
                    state = DataViewRowState.OriginalRows;
                    break;
            }

            try
            {
                ((DataView)filteredData.DataSource).RowStateFilter = state;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}