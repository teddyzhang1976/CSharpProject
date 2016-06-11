using System;
using System.Data;
using System.Data.SqlClient;

namespace Wrox.ProCSharp.SqlServer
{
    class Program
    {
        static void Main()
        {
            string connectionString = @"server=(local);database=ProCSharp;trusted_connection=true";
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Location FROM Cities";
            connection.Open();

            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {

                Console.WriteLine("{0,-10} {1}", reader[1].ToString(),
                      reader[2].ToString());
            }
            reader.Close();

        }
    }
}
