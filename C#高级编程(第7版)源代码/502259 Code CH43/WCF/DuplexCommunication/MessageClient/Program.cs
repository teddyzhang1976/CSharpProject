using System;
using System.ServiceModel;

namespace Wrox.ProCSharp.WCF
{
   class ClientCallback : IMyMessageCallback
   {
      public void OnCallback(string message)
      {
         Console.WriteLine("message from the server: {0}", message);
      }
   }


   class Program
   {
      static void Main()
      {
         Console.WriteLine("Client - wait for service");
         Console.ReadLine();

         var binding = new WSDualHttpBinding();
         var address =
               new EndpointAddress("http://localhost:8732/Design_Time_Addresses/MessageService/Service1/");

         var clientCallback = new ClientCallback();
         var context = new InstanceContext(clientCallback);

         var factory = new DuplexChannelFactory<IMyMessage>(context, binding, address);

         IMyMessage messageChannel = factory.CreateChannel();

         messageChannel.MessageToServer("From the client");

         Console.WriteLine("Client - press return to exit");
         Console.ReadLine();

      }
   }
}
