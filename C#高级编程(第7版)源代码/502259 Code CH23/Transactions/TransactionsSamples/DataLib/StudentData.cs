using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Wrox.ProCSharp.Transactions
{
    public class StudentData
    {
        public void AddStudent(Student student)
        {
            var connection = new SqlConnection(Properties.Settings.Default.CourseManagementConnectionString);
            connection.Open();
            try
            {
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO Students " +
                      "(FirstName, LastName, Company) VALUES " +
                      "(@FirstName, @LastName, @Company)";
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@Company", student.Company);

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddStudent(Student student, Transaction tx)
        {
            SqlConnection connection = new SqlConnection(
                  Properties.Settings.Default.CourseManagementConnectionString);
            connection.Open();
            try
            {
                if (tx != null)
                    connection.EnlistTransaction(tx);
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO Students (FirstName, LastName, Company) " +
                      "VALUES (@FirstName, @LastName, @Company)";
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@Company", student.Company);

                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

    }
}

