using ClientApp.Formula1Service;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Client - wait for the service to run");
      Console.ReadLine();

      ReadSample();
      // CreateSample();
      // UpdateSample();
    }

    private static void UpdateSample()
    {
      Uri serviceRoot = new Uri("http://localhost:36089/odata");
      var container = new Container(serviceRoot);
      var r1 = (from r in container.Racer
                where r.Firstname == "Sebastian" && r.Lastname == "Vettel"
                select r).FirstOrDefault();
      r1.Starts = 120;
      r1.Wins = 39;
      container.UpdateObject(r1);
      DataServiceResponse resp = container.SaveChanges();

    }

    private static void CreateSample()
    {
      Uri serviceRoot = new Uri("http://localhost:36089/odata");
      var container = new Container(serviceRoot);
      container.AddToRacer(new Racer { Firstname = "Valtteri", Lastname = "Botas", Country = "Finland", Wins = 0, Starts = 19 });
      DataServiceResponse resp = container.SaveChanges();
     
    }

    private static void ReadSample()
    {
      Uri serviceRoot = new Uri("http://localhost:36089/odata");
      var container = new Container(serviceRoot);
      var q = from r in container.Racer
              where r.Country == "Austria"
              orderby r.Wins descending
              select r;
      foreach (var r in q)
      {
        Console.WriteLine("{0} {1}", r.Firstname, r.Lastname);
      }
    }
  }
}
