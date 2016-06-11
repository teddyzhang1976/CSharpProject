using System;
using System.Runtime.Remoting;

namespace Wrox.ProCSharp.Remoting
{
    class Client
    {
        static void Main()
        {
            RemotingConfiguration.Configure("RemoteClient.exe.config", false);
            Console.WriteLine("wait for server...");
            Console.ReadLine();

            var sink = new EventSink();
            var obj = new RemoteObject();
            if (!RemotingServices.IsTransparentProxy(obj))
            {
                Console.WriteLine("check your remoting configuration");
                return;
            }

            // register client sink in server - subscribe to event

            obj.Status += sink.StatusHandler;
            obj.LongWorking(5000);

            // unsubscribe from event
            obj.Status -= sink.StatusHandler;
            obj.LongWorking(5000);
            Console.WriteLine("press return to exit");
            Console.ReadLine();
        }
    }
}



