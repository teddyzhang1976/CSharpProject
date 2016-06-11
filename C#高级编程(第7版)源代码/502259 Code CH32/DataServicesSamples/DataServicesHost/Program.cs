using System;
using System.Data.Services;

namespace Wrox.ProCSharp.DataServices
{
    class Program
    {
        static void Main()
        {
            DataServiceHost host = new DataServiceHost(typeof(MenuDataService), new Uri[] { new Uri("http://localhost:9000/Samples") });

            host.Open();

            Console.WriteLine("service running");
            Console.WriteLine("Press return to exit");
            Console.ReadLine();

            host.Close();
        }
    }
}
