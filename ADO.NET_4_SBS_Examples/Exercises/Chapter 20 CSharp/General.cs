// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 20 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Chapter_20_CSharp
{
    static class General
    {
        static public string GetConnectionString()
        {
            // ----- Build a connection string for the active database.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = @"(local)\SQLExpress";
            builder.InitialCatalog = "StepSample";
            builder.IntegratedSecurity = true;
            return builder.ConnectionString;
        }
    }
}
