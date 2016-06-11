using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void GetCustomerOrdersCLR(int customerId)
    {
        SqlConnection connection = new SqlConnection("Context Connection=true");
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT SalesOrderID, OrderDate, DueDate, " +
              "ShipDate " +
              "FROM Sales.SalesOrderHeader " +
              "WHERE (CustomerID = @CustomerID)" +
              "ORDER BY SalesOrderID";

        command.Parameters.Add("@CustomerID", SqlDbType.Int);
        command.Parameters["@CustomerID"].Value = customerId;

        SqlDataReader reader = command.ExecuteReader();
        SqlPipe pipe = SqlContext.Pipe;
        pipe.Send(reader);
        connection.Close();

    }
};
