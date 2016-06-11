using System;
using System.ServiceModel;

namespace Wrox.ProCSharp.WCF
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("wait for service...");
            Console.ReadLine();
            var binding = new WSHttpBinding();
            var address = new EndpointAddress("http://localhost:8732/Design_Time_Addresses/StateServiceSample/Service1/");

            var factory = new ChannelFactory<IStateService>(binding, address);

            IStateService channel = factory.CreateChannel();
            channel.Init(1);
            Console.WriteLine(channel.GetState());
            channel.SetState(2);
            Console.WriteLine(channel.GetState());
            try
            {
                channel.SetState(-1);
            }
            catch (FaultException<StateFault> ex)
            {
                Console.WriteLine(ex.Message);
                StateFault detail = ex.Detail;
                Console.WriteLine(detail.BadState);

            }

            channel.Close();

            factory.Close();

            Console.ReadLine();

        }
    }
}
