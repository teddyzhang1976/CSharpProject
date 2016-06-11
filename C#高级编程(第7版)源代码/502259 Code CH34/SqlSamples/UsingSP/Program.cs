using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Wrox.ProCSharp.SqlServer
{
    class Program
    {
        static void Main()
        {
            string connectionString = @"server=(local);database=AdventureWorks;trusted_connection=true";
            var connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "GetCustomerOrdersCLR";
            command.CommandType = CommandType.StoredProcedure;
            var param = new SqlParameter("@customerId", 3);
            command.Parameters.Add(param);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Console.WriteLine("{0} {1:d}", reader["SalesOrderID"], reader["OrderDate"]);
            }
            reader.Close();

        }
    }
}
