using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Resources;

namespace Wrox.ProCSharp.Localization
{
    public class DatabaseResourceReader : IResourceReader
    {
        private string connectionString;
        private string language;

        public DatabaseResourceReader(string connectionString,
              CultureInfo culture)
        {
            this.connectionString = connectionString;
            this.language = culture.Name;
        }

        public System.Collections.IDictionaryEnumerator GetEnumerator()
        {
            var dict = new Dictionary<string, string>();

            var connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            if (string.IsNullOrEmpty(language))
            {
              language = "Default";
            }

            command.CommandText = "SELECT [key], [" + language + "] " +
                                  "FROM Messages";

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(1) != System.DBNull.Value)
                    {
                        dict.Add(reader.GetString(0).Trim(), reader.GetString(1));
                    }
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number != 207)  // ignore missing columns in the database
                    throw;              // rethrow all other exceptions
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return dict.GetEnumerator();
        }

        public void Close()
        {
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        void IDisposable.Dispose()
        {
        }



    }
}
