// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 10 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Chapter_10_CSharp
{
    sealed class General
    {
        private General() { }

        public static void ExecuteSQL(SqlCommand commandWrapper)
        {
            // ----- Execute a SQL statement with no expected return values.
            //       Let the caller handle errors.
            using (SqlConnection linkToDB = OpenConnection())
            {
                commandWrapper.Connection = linkToDB;
                commandWrapper.ExecuteNonQuery();
            }
        }

        public static object ExecuteSQLReturn(SqlCommand commandWrapper)
        {
            // ----- Execute a SQL statement with a scalar return value. Let the
            //       caller handle errors.
            using (SqlConnection linkToDB = OpenConnection())
            {
                commandWrapper.Connection = linkToDB;
                return commandWrapper.ExecuteScalar();
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
                SqlCommand commandWrapper = new SqlCommand(sqlText, linkToDB);
                return commandWrapper.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database query failed: " + ex.Message);
                return null;
            }
        }
    }
}
