using System;
using Wrox.ProCSharp.WinServices;

namespace TestQuoteServer
{
    class Program
    {
        static void Main()
        {
            QuoteServer qs = new QuoteServer("quotes.txt", 4567);
            qs.Start();
            Console.WriteLine("Hit return to exit");
            Console.ReadLine();
            qs.Stop();

        }
    }
}
