using System;
using System.Runtime.Remoting;

namespace Wrox.ProCSharp.Remoting
{
    class Program
    {
        static void Main()
        {
            RemotingConfiguration.Configure("RemoteServer.exe.config", false);
            Console.WriteLine("press return to exit");
            Console.ReadLine();
        }
    }
}
