using System;

public class Login
{
  // Alter this connection string here - all other examples use this class
  // Note: The Northwind database no longer ships with SQL 2005 - you can however download it
  // here - http://www.microsoft.com/downloads/details.aspx?FamilyID=06616212-0356-46a0-8da2-eebc53a68034
  //
  // If you are using SQL Express, change the datasource from "." to ".\sqlexpress".
  public static string Connection
  {
    get { return @"data source=.;initial catalog=Northwind;integrated security=SSPI;"; }
  }
}