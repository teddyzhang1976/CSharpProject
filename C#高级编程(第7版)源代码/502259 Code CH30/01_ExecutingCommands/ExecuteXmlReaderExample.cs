using System;
using System.Data.SqlClient;
using System.Xml;

public class ExecuteXmlReaderExample
{
   public static void Main(string[] args)
   {
      string source = "server=(local);" +
                      "integrated security=SSPI;" +
                      "database=Northwind";
      string select = "SELECT ContactName,CompanyName " +
                      "FROM Customers FOR XML AUTO";
      SqlConnection conn = new SqlConnection(source);
      conn.Open();
      SqlCommand cmd = new SqlCommand(select, conn);
      XmlReader xr = cmd.ExecuteXmlReader();
      xr.Read();
      string data;
      do
      {
         data = xr.ReadOuterXml();
         if (!string.IsNullOrEmpty(data))
            Console.WriteLine(data);
      } while (!string.IsNullOrEmpty(data));
      conn.Close();
   }
}
