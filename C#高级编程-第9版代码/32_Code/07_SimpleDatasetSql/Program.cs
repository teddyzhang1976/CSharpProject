using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SimpleDatasetSql
{
    class Program
    {
        static void Main(string[] args)
        {
            string select = "SELECT ContactName,CompanyName FROM Customers";

            using (SqlConnection conn = new SqlConnection(GetDatabaseConnection()))
            {
                SqlDataAdapter da = new SqlDataAdapter(select, conn);

                DataSet ds = new DataSet();

                da.Fill(ds, "Customers");

                foreach (DataRow row in ds.Tables["Customers"].Rows)
                    Console.WriteLine("'{0}' from {1}",
                        row[0],
                        row[1]);

                conn.Close();
            }
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
