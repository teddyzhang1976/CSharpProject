// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 11 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chapter_11_CSharp
{
    public partial class UnitEditor : Form
    {
        // ----- Fields used to monitor the active database content.
        private SqlDataAdapter UnitAdapter = new SqlDataAdapter();
        private DataTable UnitTable = new DataTable();

        public UnitEditor()
        {
            InitializeComponent();
        }

        private void UnitEditor_Load(System.Object sender, System.EventArgs e)
        {
            // ----- Prepare the form.
            SqlCommand unitCommand;
            SqlConnection linkToDB;

            // ----- Open the database.
            linkToDB = new SqlConnection(GetConnectionString());

            // ----- Build the selection query.
            unitCommand = new SqlCommand("SELECT * FROM UnitOfMeasure ORDER BY ID", linkToDB);
            UnitAdapter.SelectCommand = unitCommand;

            // ----- Build the insertion query.
            unitCommand = new SqlCommand(@"INSERT INTO UnitOfMeasure (ShortName, FullName)
                VALUES (@ShortName, @FullName); SET @ID = @@IDENTITY;", linkToDB);
            unitCommand.Parameters.Add("@ShortName", SqlDbType.VarChar, 15, "ShortName");
            unitCommand.Parameters.Add("@FullName", SqlDbType.VarChar, 50, "FullName");
            SqlParameter param = unitCommand.Parameters.Add("@ID", SqlDbType.BigInt, 0, "ID");
            param.Direction = ParameterDirection.Output;
            UnitAdapter.InsertCommand = unitCommand;

            // ----- Build the revision query.
            unitCommand = new SqlCommand(@"UPDATE UnitOfMeasure SET ShortName = @ShortName,
                FullName = @FullName WHERE ID = @ID", linkToDB);
            unitCommand.Parameters.Add("@ShortName", SqlDbType.VarChar, 15, "ShortName");
            unitCommand.Parameters.Add("@FullName", SqlDbType.VarChar, 50, "FullName");
            param = unitCommand.Parameters.Add("@ID", SqlDbType.BigInt, 0, "ID");
            param.SourceVersion = DataRowVersion.Original;
            UnitAdapter.UpdateCommand = unitCommand;

            // ----- Build the deletion query.
            unitCommand = new SqlCommand("DELETE FROM UnitOfMeasure WHERE ID = @ID", linkToDB);
            param = unitCommand.Parameters.Add("@ID", SqlDbType.BigInt, 0, "ID");
            param.SourceVersion = DataRowVersion.Original;
            UnitAdapter.DeleteCommand = unitCommand;

            // ----- Load the data from the database into the local editor.
            try
            {
                UnitAdapter.Fill(UnitTable);
                UnitGrid.DataSource = UnitTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred loading records: " + ex.Message);
            }
        }

        private void ActUpdate_Click(System.Object sender, System.EventArgs e)
        {
            // ----- Send the data back to the database.
            try
            {
                UnitAdapter.Update(UnitTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred during database update: " + ex.Message);
            }
        }

        public string GetConnectionString()
        {
            // ----- Build a connection string for the active database.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = @"(local)\SQLExpress";
            builder.InitialCatalog = "StepSample";
            builder.IntegratedSecurity = true;
            return builder.ConnectionString;
        }
    }
}
