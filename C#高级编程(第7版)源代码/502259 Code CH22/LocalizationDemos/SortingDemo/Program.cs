using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace SortingDemo
{
    class Program
    {
        static void Main()
        {
            string[] names = {"Alabama", "Texas", "Washington",
                              "Virginia", "Wisconsin", "Wyoming",
                              "Kentucky", "Missouri", "Utah", "Hawaii",
                              "Kansas", "Louisiana", "Alaska", "Arizona"};

            Thread.CurrentThread.CurrentCulture = new CultureInfo("fi-FI");

            Array.Sort(names);
            DisplayNames("Sorted using the Finnish culture", names);

            // sort using the invariant culture
            Array.Sort(names, System.Collections.Comparer.DefaultInvariant);
            DisplayNames("Sorted using the invariant culture", names);
        }

        static void DisplayNames(string title, IEnumerable<string> e)
        {
            Console.WriteLine(title);
            foreach (string s in e)
                Console.Write(s + "—");
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
