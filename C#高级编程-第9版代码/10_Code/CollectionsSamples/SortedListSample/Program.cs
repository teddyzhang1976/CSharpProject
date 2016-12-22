using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Collections
{
  class Program
  {
    static void Main()
    {
      var books = new SortedList<string, string>();
      books.Add("Professional WPF Programming", "978–0–470–04180–2");
      books.Add("Professional ASP.NET MVC 3", "978–1–1180–7658–3");

      books["Beginning Visual C# 2010"] = "978–0–470-50226-6";
      books["Professional C# 4 and .NET 4"] = "978–0–470–50225–9";

      foreach (KeyValuePair<string, string> book in books)
      {
        Console.WriteLine("{0}, {1}", book.Key, book.Value);
      }

      foreach (string isbn in books.Values)
      {
        Console.WriteLine(isbn);
      }

      foreach (string title in books.Keys)
      {
        Console.WriteLine(title);
      }

      {
        string isbn;
        string title = "Professional C# 7.0";
        if (!books.TryGetValue(title, out isbn))
        {
          Console.WriteLine("{0} not found", title);
        }
      }



    }
  }
}
