using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;

namespace Wrox.ProCSharp.Remoting
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("wait for server...");
            Console.ReadLine();

            RemotingConfiguration.Configure("HelloClient.exe.config", false);
            Hello obj = new Hello();
            //ILease lease = (ILease)obj.GetLifetimeService();
            //if (lease != null)
            //{
            //    Console.WriteLine("Lease Configuration:");
            //    Console.WriteLine("InitialLeaseTime: {0}", lease.InitialLeaseTime);
            //    Console.WriteLine("RenewOnCallTime: {0}", lease.RenewOnCallTime);
            //    Console.WriteLine("SponsorshipTimeout: {0}", lease.SponsorshipTimeout);
            //    Console.WriteLine(lease.CurrentLeaseTime);
            //}

            if (obj == null)
            {
                Console.WriteLine("could not locate server");
                return;
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(obj.Greeting("Stephanie"));
            }

            // async version
            Func<string, string> d = new Func<string, string>(obj.Greeting);
            IAsyncResult ar = d.BeginInvoke("Stephanie", null, null);

            // do some work and then wait
            ar.AsyncWaitHandle.WaitOne();
            string greeting = null;
            if (ar.IsCompleted)
            {
                greeting = d.EndInvoke(ar);
            }

            Console.WriteLine(greeting);


        }
    }
}
