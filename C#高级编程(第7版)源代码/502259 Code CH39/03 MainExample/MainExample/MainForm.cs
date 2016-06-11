using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace MainExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void fileExit_Click(object sender, EventArgs e)
        {
            CancelEventArgs cancel = new CancelEventArgs(false);

            Application.Exit(cancel);
        }

        /// <summary>
        /// Displays the button example child form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExample_Click(object sender, EventArgs e)
        {
            ButtonExample buttonForm = new ButtonExample();
            buttonForm.MdiParent = this;
            buttonForm.Show();
        }

        /// <summary>
        /// Display the list control example
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listExample_Click(object sender, EventArgs e)
        {
            ListExample listForm = new ListExample();
            listForm.MdiParent = this;
            listForm.Show();
        }

        private void validationExample_Click(object sender, EventArgs e)
        {
            ValidationExample validationForm = new ValidationExample();
            validationForm.MdiParent = this;
            validationForm.Show();
        }

        private void textBoxExample_Click(object sender, EventArgs e)
        {
            TexBoxExample form = new TexBoxExample();
            form.MdiParent = this;
            form.Show();
        }

        private void panelExample_Click(object sender, EventArgs e)
        {
            PanelExample form = new PanelExample();
            form.MdiParent = this;
            form.Show();
        }

        private void splitterExample_Click(object sender, EventArgs e)
        {
            SplitterExample form = new SplitterExample();
            form.MdiParent = this;
            form.Show();
        }

        private void userControlExample_Click(object sender, EventArgs e)
        {
            UserControlExample form = new UserControlExample();
            form.MdiParent = this;
            form.Show();
        }

        private void dataSetExample_Click(object sender, EventArgs e)
        {
            DataGridViewExample form = new DataGridViewExample(grid =>
                {
                    string customers = "SELECT * FROM Customers";

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["northwind"].ConnectionString))
                    {
                        DataSet ds = new DataSet();

                        SqlDataAdapter da = new SqlDataAdapter(customers, con);

                        da.Fill(ds, "Customers");

                        grid.AutoGenerateColumns = true;
                        grid.DataSource = ds;
                        grid.DataMember = "Customers";
                    }
                });
            form.MdiParent = this;
            form.Show();
        }

        private void arrayDataSourceExample_Click(object sender, EventArgs e)
        {
            DataGridViewExample form = new DataGridViewExample(grid =>
                {
// Uncomment this to see the problem with adding strings on screen without wrapping them
//                    string[] items = new string[] { "One", "Two", "Three" };

                    Item[] items = new Item[] { new Item ( "One" ) , 
                                         new Item ( "Two" ) , 
                                         new Item ( "Three" ) };

                    grid.AutoGenerateColumns = true;
                    grid.DataSource = items;
                });
            form.MdiParent = this;
            form.Show();
        }

        private void dataTableSourceExample_Click(object sender, EventArgs e)
        {
            DataGridViewExample form = new DataGridViewExample(grid =>
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["northwind"].ConnectionString))
                    {
                        string select = "SELECT * FROM products";

                        SqlDataAdapter da = new SqlDataAdapter(select, con);

                        DataSet ds = new DataSet();

                        da.Fill(ds, "Products");

                        grid.AutoGenerateColumns = true;
                        grid.DataSource = ds.Tables["Products"];
                    }
                });
            form.MdiParent = this;
            form.Show();
        }

        private void dataViewExample_Click(object sender, EventArgs e)
        {
            DataViewExample form = new DataViewExample();
            form.MdiParent = this;
            form.Show();
        }

        private void genericListExample_Click(object sender, EventArgs e)
        {
            DataGridViewExample form = new DataGridViewExample(grid =>
            {
                List<Person> people = new List<Person>();

                people.Add(new Person("Fred", Sex.Male, new DateTime(1970, 12, 14)));
                people.Add(new Person("Bill", Sex.Male, new DateTime(1976, 10, 29)));
                people.Add(new Person("Jack", Sex.Male, new DateTime(1945, 5, 17)));
                people.Add(new Person("Jane", Sex.Female, new DateTime(1982, 1, 3)));
                grid.AutoGenerateColumns = true;
                grid.DataSource = people;
            });
            form.MdiParent = this;
            form.Show();
        }

    }

 

}
