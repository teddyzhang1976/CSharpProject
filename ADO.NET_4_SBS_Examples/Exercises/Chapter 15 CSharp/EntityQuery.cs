// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 15 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_15_CSharp
{
    public partial class EntityQuery : Form
    {
        private SalesOrderEntities ActiveContext;

        public EntityQuery()
        {
            InitializeComponent();
        }

        private void ActSimpleRetrieval_Click(System.Object sender, System.EventArgs e)
		{
            // ----- Simple retrieval of all entities in a set.
            ObjectSet<Customer> query;

            // ----- Clear any previous results.
            DisplayResults.DataSource = null;

            try
			{
                // ----- Retrieve the customer entities directly.
                ActiveContext = new SalesOrderEntities(GetConnectionString());
                query = ActiveContext.CreateObjectSet<Customer>();

                // ----- Display the results to the user.
                DisplayResults.DataSource = query;
                MessageBox.Show(query.Count() + "{0} result(s)");
			}
            catch (Exception ex)
			{
                MessageBox.Show("Error during record retrieval: " + ex.Message);
			}
		}

        private void ActSingleEntity_Click(System.Object sender, System.EventArgs e)
		{
            // ----- Query of single entity.
            string sqlText;
            ObjectQuery<Customer> query;

            // ----- Clear any previous results.
            DisplayResults.DataSource = null;

            try
			{
                // ----- Retrieve the customer entities via a query.

                // ----- Display the results to the user.
                DisplayResults.DataSource = query;
                MessageBox.Show(query.Count() + " result(s)");
			}
            catch (Exception ex)
			{
                MessageBox.Show("Error during single record retrieval: " + ex.Message);
			}
		}

        private void ActAnonymousType_Click(System.Object sender, System.EventArgs e)
		{
            // ----- Query that returns a custom (anonymous) type.
            string sqlText;
            ObjectQuery<DbDataRecord> query;

            // ----- Clear any previous results.
            DisplayResults.DataSource = null;

            try
			{
                // ----- Retrieve the entity data via a query.
                ActiveContext = new SalesOrderEntities(GetConnectionString());
                sqlText = @"SELECT CU.FullName, OE.ID, OE.OrderDate, OE.Total
                    FROM Customers AS CU INNER JOIN
                    OrderEntries AS OE ON CU.ID = OE.Customer";
                query = new ObjectQuery<DbDataRecord>(sqlText, ActiveContext);

                // ----- Display the results to the user.
                DisplayResults.DataSource = query;
                MessageBox.Show(query.Count() + " result(s)");
			}
            catch (Exception ex)
			{
                MessageBox.Show("Error during anonymous record retrieval: " + ex.Message);
			}
		}

        private void ActNavigationProperty_Click(System.Object sender, System.EventArgs e)
		{
            // ----- Query that includes use of a navagation property.
            string sqlText;
            ObjectQuery<DbDataRecord> query;

            // ----- Clear any previous results.
            DisplayResults.DataSource = null;

            try
            {
                // ----- Retrieve the data by following the navigation property.
                ActiveContext = new SalesOrderEntities(GetConnectionString());
                sqlText = @"SELECT CU.FullName, CU.State.Abbreviation
                    FROM Customers AS CU";
                query = new ObjectQuery<DbDataRecord>(sqlText, ActiveContext);

                // ----- Display the results to the user.
                DisplayResults.DataSource = query;
                MessageBox.Show(query.Count() + " result(s)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during navigation property retrieval: " + ex.Message);
            }
		}

        private void ActDataTable_Click(System.Object sender, System.EventArgs e)
		{
            // ----- Query that returns an ADO.NET DataTable.
            DataRow oneRow;
            DataTable resultsAsTable;
            EntityCommand query;
            EntityDataReader results = null;
			string sqlText;

            // ----- Clear any previous results.
            DisplayResults.DataSource = null;

            // ----- Build a storage area for the results.
            resultsAsTable = new DataTable();
            resultsAsTable.Columns.Add("CustomerID", typeof(long));
            resultsAsTable.Columns.Add("CustomerName", typeof(string));
            resultsAsTable.Columns.Add("AnnualFee", typeof(decimal));

            // ----- Connect to the entity provider.
            using (EntityConnection linkToDB = new EntityConnection(GetConnectionString()))
			{
                try
				{
                    linkToDB.Open();
				}
                catch (Exception ex)
				{
                    MessageBox.Show("Error opening the data connection: " + ex.Message);
                    return;
				}

                // ----- Retrieve the data via a parameterized query.

                try
				{

                }
                catch (Exception ex)
				{
                    MessageBox.Show("Error processing parameterized query: " + ex.Message);
                    return;
				}

                try
				{
                    // ----- Move each row into the DataTable.

                }
                catch (Exception ex)
				{
                    MessageBox.Show("Error saving query results: " + ex.Message);
                    return;
				}
                finally
				{
                    results.Close();
				}

                // ----- Display the results to the user.
                try
				{
                    DisplayResults.DataSource = resultsAsTable;
                    MessageBox.Show(resultsAsTable.Rows.Count + " result(s)");
				}
                catch (Exception ex)
				{
                    MessageBox.Show("Error displaying query results: " + ex.Message);
				}
			}
		}

        public string GetConnectionString()
		{
            // ----- Build a connection string for the active database.
            SqlConnectionStringBuilder sqlPortion = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder();

            // ----- Build the provider portion of the connection string.
            sqlPortion.DataSource = @"(local)\SQLExpress";
            sqlPortion.InitialCatalog = "StepSample";
            sqlPortion.IntegratedSecurity = true;

            // ----- Build the Entity Client connection string.
            builder.Metadata = "res://*/SalesOrder.csdl|res://*/SalesOrder.ssdl|res://*/SalesOrder.msl";
            builder.Provider = "System.Data.SqlClient";
            builder.ProviderConnectionString = sqlPortion.ConnectionString;
            return builder.ConnectionString;
		}

        private void ActProcess_Click(System.Object sender, System.EventArgs e)
		{
            // ----- Let the user supply a custom query.
            string sqlText;
            ObjectQuery<DbDataRecord> query;

            // ----- Check for a valid query.
            if (CustomQuery.Text.Trim().Length == 0)
			{
                MessageBox.Show("Please supply a query.");
                return;
			}

            // ----- Clear any previous results.
            DisplayResults.DataSource = null;

            try
			{
                // ----- Retrieve the custom query content.
                ActiveContext = new SalesOrderEntities(GetConnectionString());
                sqlText = CustomQuery.Text;
                query = new ObjectQuery<DbDataRecord>(sqlText, ActiveContext);

                // ----- Display the results to the user.
                DisplayResults.DataSource = query;
                MessageBox.Show(query.Count() + " result(s)");
			}
            catch (Exception ex)
			{
                MessageBox.Show("Error processing query: " + ex.Message);
			}
		}
    }
}
