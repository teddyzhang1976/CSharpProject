using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_DataAdapterUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create & open the database connection
            SqlConnection conn = new SqlConnection(GetDatabaseConnection());
            conn.Open();

            // Create a DataSet
            DataSet ds = new DataSet();

            // Create a Region DataTable
            CreateTable(ds);

            // Create a data adapter to fill the DataSet
            SqlDataAdapter da = new SqlDataAdapter();

            // Set the data adapters select co
            da.SelectCommand = GenerateSelectCommand(conn);
            da.InsertCommand = GenerateInsertCommand(conn);
            da.UpdateCommand = GenerateUpdateCommand(conn);
            da.DeleteCommand = GenerateDeleteCommand(conn);

            // Execute the Select Command to fill the dataset
            da.Fill(ds, "Region");

            DumpDataSet(ds, "Initial data selected from database");

            // Add a new row into the dataset
            DataRow r = ds.Tables["Region"].NewRow();

            r["RegionID"] = 999;
            r["RegionDescription"] = "North West";

            // Add the row into the DataTable
            ds.Tables["Region"].Rows.Add(r);

            DumpDataSet(ds, "New row pending inserting into database");

            // And use the data adapter to update the table
            da.Update(ds, "Region");

            DumpDataSet(ds, "New row updated and new RegionID assigned by database");

            // Capture the regionID for later...
            string regionID = r[0].ToString();

            // Now update something that's already there
            r["RegionDescription"] = "North West England";

            DumpDataSet(ds, string.Format("Changed RegionID {0} description", regionID));

            // And use the data adapter to update the table
            da.Update(ds, "Region");

            // And finally delete the row I added...
            r.Delete();

            DumpDataSet(ds, string.Format("Deleted RegionID {0}", regionID));

            // And use the data adapter to update the table
            da.Update(ds, "Region");

            // Example .XML files used late in this chapter.
            ds.WriteXml(".\\WithoutSchema.xml");
            ds.WriteXml(".\\WithSchema.xml", XmlWriteMode.WriteSchema);
        }

        /// <summary>
        /// Dump the contents of the dataset to the console
        /// </summary>
        /// <param name="ds">The dataset</param>
        /// <param name="message">A message to output</param>
        private static void DumpDataSet(DataSet ds, string message)
        {
            Console.WriteLine(message);

            foreach (DataRow aRow in ds.Tables["Region"].Rows)
            {
                if (aRow.RowState == DataRowState.Deleted)
                    Console.WriteLine("Row Deleted");
                else
                    Console.WriteLine("  {0,-3} {1,-50} {2}", aRow[0], aRow[1], aRow.RowState);
            }
        }

        /// <summary>
        /// Create a command that will select all region records
        /// </summary>
        /// <param name="conn">The database connection</param>
        /// <returns>A SqlCommand</returns>
        private static SqlCommand GenerateSelectCommand(SqlConnection conn)
        {
            SqlCommand aCommand = new SqlCommand("RegionSelect", conn);

            aCommand.CommandType = CommandType.StoredProcedure;
            aCommand.UpdatedRowSource = UpdateRowSource.None;

            return aCommand;
        }

        /// <summary>
        /// Create a command that will update a region record
        /// </summary>
        /// <param name="conn">The database connection</param>
        /// <returns>A SqlCommand</returns>
        private static SqlCommand GenerateUpdateCommand(SqlConnection conn)
        {
            SqlCommand aCommand = new SqlCommand("RegionUpdate", conn);

            aCommand.CommandType = CommandType.StoredProcedure;
            aCommand.Parameters.Add(new SqlParameter("@RegionID", SqlDbType.Int, 0, "RegionID"));
            aCommand.Parameters.Add(new SqlParameter("@RegionDescription", SqlDbType.NChar, 50, "RegionDescription"));
            aCommand.UpdatedRowSource = UpdateRowSource.None;

            return aCommand;
        }

        /// <summary>
        /// Create a command that will insert a region record
        /// </summary>
        /// <param name="conn">The database connection</param>
        /// <returns>A SqlCommand</returns>
        private static SqlCommand GenerateInsertCommand(SqlConnection conn)
        {
            SqlCommand aCommand = new SqlCommand("RegionInsert", conn);

            aCommand.CommandType = CommandType.StoredProcedure;
            aCommand.Parameters.Add(new SqlParameter("@RegionDescription", SqlDbType.NChar, 50, "RegionDescription"));
            aCommand.Parameters.Add(new SqlParameter("@RegionID", SqlDbType.Int, 0, ParameterDirection.Output,
                false, 0, 0, "RegionID", DataRowVersion.Default, null));
            aCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

            return aCommand;
        }

        /// <summary>
        /// Create a command that will delete a region record
        /// </summary>
        /// <param name="conn">The database connection</param>
        /// <returns>A SqlCommand</returns>
        private static SqlCommand GenerateDeleteCommand(SqlConnection conn)
        {
            SqlCommand aCommand = new SqlCommand("RegionDelete", conn);

            aCommand.CommandType = CommandType.StoredProcedure;
            aCommand.Parameters.Add(new SqlParameter("@RegionID", SqlDbType.Int, 0, "RegionID"));
            aCommand.UpdatedRowSource = UpdateRowSource.None;

            return aCommand;
        }

        /// <summary>
        /// Create the Region DataTable
        /// </summary>
        /// <param name="ds">The dataset within which to create the data table</param>
        private static void CreateTable(DataSet ds)
        {
            DataTable dt = new DataTable("Region");

            DataColumn regionID = new DataColumn("RegionID", typeof(int));
            regionID.AllowDBNull = false;
            regionID.AutoIncrement = true;
            regionID.AutoIncrementSeed = 1;

            DataColumn regionDescription = new DataColumn("RegionDescription", typeof(string));
            regionDescription.AllowDBNull = false;

            dt.Columns.Add(regionID);
            dt.Columns.Add(regionDescription);

            ds.Tables.Add(dt);
        }

        static string GetDatabaseConnection()
        {
            // If you are using SQL Express then use this connection string...
            //return "server=.\\SQLEXPRESS;" +
            //    "integrated security=SSPI;" +
            //    "database=Northwind";

            // And if using full SQL Server then this is most likely correct...
            return "server=(local);" +
                "integrated security=SSPI;" +
                "database=Northwind";
        }
    }
}