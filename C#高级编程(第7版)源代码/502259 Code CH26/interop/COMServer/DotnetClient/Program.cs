using System;
using Wrox.ProCSharp.Interop.Server;

namespace Wrox.ProCSharp.Interop.Client
{
    class Program
    {

        static void Main(string[] args)
        {
            COMDemo obj = new COMDemo();
            IWelcome welcome = obj;
            Console.WriteLine(welcome.Greeting("Stephanie"));

            IMath math;
            math = (IMath)welcome;
            int x = math.Add(4, 5);
            Console.WriteLine(x);

        }
    }
}
