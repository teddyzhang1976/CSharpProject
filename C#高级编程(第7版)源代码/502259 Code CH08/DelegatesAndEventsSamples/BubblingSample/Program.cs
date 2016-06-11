using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Element a = new Element("a", null);
            Element b = new Element("b", a);
            Element c = new Element("c", b);
            Element d = new Element("d", a);

            a.Click += (sender, e) =>
                {
                    Console.WriteLine("event arrived in a");
                };
        }
    }
}
