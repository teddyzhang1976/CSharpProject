using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new SortedList<string, string>();
            books.Add("C# 2008 Wrox Box", "978–0–470–047205–7");
            books.Add("Professional ASP.NET MVC 1.0", "978–0–470–38461–9");

            books["Beginning Visual C# 2008"] = "978–0–470-19135-4";
            books["Professional C# 2008"] = "978–0–470–19137–6";

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
