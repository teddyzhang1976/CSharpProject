using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Configuration;
using System.Data;

namespace Wrox.ProCSharp.EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // EntityClientDemo();
            EntitiesDemo();

            int a = 3;
            if (a == 5 - 2)
            {
                Console.WriteLine("yes");
            }
        }

        private static void EntitiesDemo()
        {
            using (var data = new BooksEntities())
            {
                foreach (var book in data.Books)
                {
                    Console.WriteLine("{0}, {1}", book.Title, book.Publisher);
                }
            }

        }


        static void EntityClientDemo()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BooksEntities"].ConnectionString;
            var connection = new EntityConnection(connectionString);
            connection.Open();

            EntityCommand command = connection.CreateCommand();
            command.CommandText = "[BooksEntities].[Books]";
            // command.CommandText = "SELECT Books.Title, Books.Publisher FROM [BooksEntities].[Books]";
            // command.CommandText = "SELECT VALUE it FROM BooksEntities.Books AS it WHERE it.Publisher = @Publisher";
            command.Parameters.AddWithValue("Publisher", "Wrox Press");
            EntityDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SequentialAccess);
            while (reader.Read())
            {
                Console.WriteLine("{0}, {1}", reader["Title"], reader["Publisher"]);
            }
            reader.Close();
        }
    }
}
