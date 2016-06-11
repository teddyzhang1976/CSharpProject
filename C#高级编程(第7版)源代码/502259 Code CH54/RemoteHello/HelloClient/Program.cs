using System;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting;

namespace Wrox.ProCSharp.Remoting
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press return after the server is started");
            Console.ReadLine();

            ChannelServices.RegisterChannel(new IpcChannel(), false);
            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            //Hello obj = (Hello)Activator.GetObject(
            //                             typeof(Hello), "tcp://localhost:8086/Hi");


            RemotingConfiguration.RegisterActivatedClientType(typeof(Hello), "ipc://myIPCPort/HelloApp");
            // Hello obj = (Hello)Activator.CreateInstance(typeof(Hello), null, new object[] { new UrlAttribute("ipc://myIPCPort") });
            // Hello obj = (Hello)Activator.CreateInstance(typeof(Hello), null, new object[] { new UrlAttribute("tcp://127.0.0.1:8086/HelloApp") });
            Hello obj = new Hello();
            if (obj == null)
            {
                Console.WriteLine("could not locate server");
                return;
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(obj.Greeting("Stephanie"));
            }
        }
    }
}
