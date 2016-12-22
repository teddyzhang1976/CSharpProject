using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create & open the database connection
            using (SqlConnection conn = new SqlConnection(GetDatabaseConnection()))
            {
                conn.Open();

                // Ensure the stored procs exist
                InitialiseDatabase(conn);

                // Create a DataSet
                DataSet ds = new DataSet();

                // Create a data adapter to fill the DataSet
                SqlDataAdapter da = new SqlDataAdapter();

                // Set the data adapters select co
                da.SelectCommand = GenerateSelectCommand(conn);

                da.Fill(ds, "Region");

                // Now loop through rows in the region table...
                Console.WriteLine("Data selected via a stored procedure");

                foreach (DataRow aRow in ds.Tables["Region"].Rows)
                {
                    Console.WriteLine("  {0,-3} {1}", aRow[0], aRow[1]);
                }

                conn.Close();
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
        /// Add in the stored procs if we need to
        /// </summary>
        /// <param name="conn"></param>
        private static void InitialiseDatabase(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(Strings.SelectProc, conn);
            cmd.ExecuteNonQuery();
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
