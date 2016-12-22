using System;
using System.Collections.Generic;
using System.Linq;

namespace Wrox.ProCSharp.LINQ
{
  class Program
  {
    static void Main()
    {
      // LINQQuery();
      // ExtensionMethods();
      DeferredQuery();
    }

    static void DeferredQuery()
    {
      var names = new List<string> { "Nino", "Alberto", "Juan", "Mike", "Phil" };

      var namesWithJ = from n in names
                       where n.StartsWith("J")
                       orderby n
                       select n;

      Console.WriteLine("First iteration");
      foreach (string name in namesWithJ)
      {
        Console.WriteLine(name);
      }
      Console.WriteLine();

      names.Add("John");
      names.Add("Jim");
      names.Add("Jack");
      names.Add("Denny");

      Console.WriteLine("Second iteration");
      foreach (string name in namesWithJ)
      {
        Console.WriteLine(name);
      }

    }

    static void ExtensionMethods()
    {
      var champions = new List<Racer>(Formula1.GetChampions());
      IEnumerable<Racer> brazilChampions =
          champions.Where(r => r.Country == "Brazil").
                  OrderByDescending(r => r.Wins).
                  Select(r => r);

      foreach (Racer r in brazilChampions)
      {
        Console.WriteLine("{0:A}", r);
      }
    }


    static void LINQQuery()
    {
      var query = from r in Formula1.GetChampions()
                  where r.Country == "Brazil"
                  orderby r.Wins descending
                  select r;

      foreach (var r in query)
      {
        Console.WriteLine("{0:A}", r);
      }

    }
  }
}
