using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;


public partial class Triggers
{
    // [SqlTrigger(Name = "InsertContact", Target = "Person.Contact", Event = "FOR INSERT")]
    public static void InsertContact()
    {
        SqlTriggerContext triggerContext = SqlContext.TriggerContext;

        if (triggerContext.TriggerAction == TriggerAction.Insert)
        {
            var connection = new SqlConnection("Context Connection=true");
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT EmailAddress FROM INSERTED";
            connection.Open();
            string email = (string)command.ExecuteScalar();
            connection.Close();

            if (!Regex.IsMatch(email,
                  @"([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$"))
            {
                throw new FormatException("Invalid email");
            }
        }
    }

}
