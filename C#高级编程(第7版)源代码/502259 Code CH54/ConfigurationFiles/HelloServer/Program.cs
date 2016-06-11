using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels.Tcp;

namespace Wrox.ProCSharp.Remoting
{
    class Program
    {
        static void Main()
        {
            RemotingConfiguration.Configure("HelloServer.exe.config", false);
            Console.WriteLine("Application: {0}", RemotingConfiguration.ApplicationName);
            ShowActivatedServiceTypes();
            ShowWellKnownServiceTypes();
            System.Console.WriteLine("press return to exit");
            System.Console.ReadLine();

        }

        public static void ShowWellKnownServiceTypes()
        {
            WellKnownServiceTypeEntry[] entries =
                RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
            foreach (var entry in entries)
            {
                Console.WriteLine("Assembly: {0}", entry.AssemblyName);
                Console.WriteLine("Mode: {0}", entry.Mode);
                Console.WriteLine("URI: {0}", entry.ObjectUri);
                Console.WriteLine("Type: {0}", entry.TypeName);
            }
        }
        public static void ShowActivatedServiceTypes()
        {
            ActivatedServiceTypeEntry[] entries =
            RemotingConfiguration.GetRegisteredActivatedServiceTypes();
            foreach (var entry in entries)
            {
                Console.WriteLine("Assembly: {0}", entry.AssemblyName);
                Console.WriteLine("Type: {0}", entry.TypeName);
            }



        }
    }
}
