using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Wrox.ProCSharp.Transactions
{
    public class CourseData
    {
        public void AddCourse(Course course)
        {
            SqlConnection connection = new SqlConnection(
                  Properties.Settings.Default.CourseManagementConnectionString);
            SqlCommand courseCommand = connection.CreateCommand();
            courseCommand.CommandText =
                  "INSERT INTO Courses (Number, Title) VALUES (@Number, @Title)";
            connection.Open();
            SqlTransaction tx = connection.BeginTransaction();

            try
            {
                courseCommand.Transaction = tx;

                courseCommand.Parameters.AddWithValue("@Number", course.Number);
                courseCommand.Parameters.AddWithValue("@Title", course.Title);
                courseCommand.ExecuteNonQuery();

                tx.Commit();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error: " + ex.Message);
                tx.Rollback();
            }
            finally
            {
                connection.Close();
            }
        }
    }

}
