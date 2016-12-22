using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _01_ExecutingCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteNonQuery();
            ExecuteReader();
            ExecuteScalar();
            ExecuteXmlReader();
        }

        static void ExecuteNonQuery()
        {
            string select = "UPDATE Customers " +
                            "SET ContactName = 'Bob' " +
                            "WHERE ContactName = 'Bill'";
            SqlConnection conn = new SqlConnection(GetDatabaseConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            int rowsReturned = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} rows returned.", rowsReturned);
            conn.Close();
        }

        static void ExecuteReader()
        {
            string select = "SELECT ContactName,CompanyName FROM Customers";
            SqlConnection conn = new SqlConnection(GetDatabaseConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Contact: {0,-20} Company: {1}",
                                   reader[0], reader[1]);
            }
        }

        static void ExecuteScalar()
        {
            string select = "SELECT COUNT(*) FROM Customers";
            SqlConnection conn = new SqlConnection(GetDatabaseConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            object o = cmd.ExecuteScalar();
            Console.WriteLine(o);
        }

        static void ExecuteXmlReader()
        {
            string select = "SELECT ContactName,CompanyName " +
                            "FROM Customers FOR XML AUTO";
            SqlConnection conn = new SqlConnection(GetDatabaseConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            XmlReader xr = cmd.ExecuteXmlReader();
            xr.Read();
            string data;
            do
            {
                data = xr.ReadOuterXml();
                if (!string.IsNullOrEmpty(data))
                    Console.WriteLine(data);
            } while (!string.IsNullOrEmpty(data));
            conn.Close();

        }

        static string GetDatabaseConnection()
        {
            Console.WriteLine("Trying to connect to the Northwind database.");
            Console.WriteLine("If you don't have this installed, see http://northwinddatabase.codeplex.com/");
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
