// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 19 - C# Version
//       by Tim Patrick

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace Chapter_19_CSharp
{
    static class General
    {
        static public string GetConnectionString()
        {
            // ----- Build a connection string for the active database.
            SqlConnectionStringBuilder sqlPortion = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder();

            // ----- Build the provider portion of the connection string.
            sqlPortion.DataSource = @"(local)\SQLExpress";
            sqlPortion.InitialCatalog = "StepSample";
            sqlPortion.IntegratedSecurity = true;

            // ----- Build the Entity Client connection string.
            builder.Metadata = "res://*/SalesOrder.csdl|res://*/SalesOrder.ssdl|res://*/SalesOrder.msl";
            builder.Provider = "System.Data.SqlClient";
            builder.ProviderConnectionString = sqlPortion.ConnectionString;
            return builder.ConnectionString;
        }
    }
}
