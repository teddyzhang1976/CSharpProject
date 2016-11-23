// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 9 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Chapter_9_CSharp
{
    sealed class General
    {
        private General() { }

        public static string DBText(string origText)
        {
            // ----- Prepare a text string for use in a SQL statement.
            if ((origText == null) || (origText.Length == 0))
                return "NULL";
            else
                return "'" + origText.Replace("'", "''") + "'";
        }

        public static void ExecuteSQL(string sqlText, SqlConnection linkToDB)
        {
            // ----- Execute a SQL statement with no expected return values.
            try
            {
                SqlCommand commandWraper = new SqlCommand(sqlText, linkToDB);
                commandWraper.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database non-query failed: " + ex.Message);
            }
        }

        public static object ExecuteSQLReturn(string sqlText, SqlConnection linkToDB)
        {
            // ----- Execute a SQL statement with a scalar return value.
            try
            {
                SqlCommand commandWraper = new SqlCommand(sqlText, linkToDB);
                return commandWraper.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database scalar query failed: " + ex.Message);
                return null;
            }
        }

        public static string GetConnectionString()
        {
            // ----- Build a connection string for the active database.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = @"(local)\SQLExpress";
            builder.InitialCatalog = "StepSample";
            builder.IntegratedSecurity = true;
            return builder.ConnectionString;
        }

        public static SqlConnection OpenConnection()
        {
            // ----- Open a connection to the database.
            try
            {
                SqlConnection linkToDB = new SqlConnection(GetConnectionString());
                linkToDB.Open();
                return linkToDB;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message);
                return null;
            }
        }

        public static SqlDataReader OpenReader(string sqlText, SqlConnection linkToDB)
        {
            // ----- Open a DataReader for the given SQL statement.
            try
            {
                SqlCommand commandWraper = new SqlCommand(sqlText, linkToDB);
                return commandWraper.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database query failed: " + ex.Message);
                return null;
            }
        }
    }
}
