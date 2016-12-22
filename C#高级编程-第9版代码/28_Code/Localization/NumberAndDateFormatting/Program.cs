using System;
using System.Globalization;
using System.Threading;

namespace NumberAndDateFormatting
{
    class Program
    {
        static void Main()
        {
            // NumberFormatDemo();
            DateFormatDemo();
        }

        private static void DateFormatDemo()
        {
            DateTime d = new DateTime(2013, 09, 27);

            // current culture
            Console.WriteLine(d.ToLongDateString());

            // use IFormatProvider
            Console.WriteLine(d.ToString("D", new CultureInfo("fr-FR")));

            // use culture of thread
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            Console.WriteLine("{0}: {1}", ci.ToString(), d.ToString("D"));

            ci = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentCulture = ci;
            Console.WriteLine("{0}: {1}", ci.ToString(), d.ToString("D"));
        }

        private static void NumberFormatDemo()
        {
            int val = 1234567890;

            // culture of the current thread
            Console.WriteLine(val.ToString("N"));

            // use IFormatProvider
            Console.WriteLine(val.ToString("N", new CultureInfo("fr-FR")));

            // change the culture of the thread
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            Console.WriteLine(val.ToString("N"));
        }
    }
}
