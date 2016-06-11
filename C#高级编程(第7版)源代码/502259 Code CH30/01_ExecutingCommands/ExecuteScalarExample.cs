using System;
using System.Data.SqlClient;

public class ExecuteScalarExample
{
   public static void Main(string[] args)
   {
      string source = "server=(local);" +
                      "integrated security=SSPI;" +
                      "database=Northwind";
      string select = "SELECT COUNT(*) FROM Customers";
      SqlConnection conn = new SqlConnection(source);
      conn.Open();
      SqlCommand cmd = new SqlCommand(select, conn);
      object o = cmd.ExecuteScalar();
      Console.WriteLine(o);
   }
}
