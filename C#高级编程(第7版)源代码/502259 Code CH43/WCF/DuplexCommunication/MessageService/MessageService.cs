using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.WCF
{
   public class MessageService : IMyMessage
   {
      public void MessageToServer(string message)
      {
         Console.WriteLine("message from the client: {0}", message);
         IMyMessageCallback callback =
               OperationContext.Current.
                     GetCallbackChannel<IMyMessageCallback>();

         callback.OnCallback("message from the server");

         Task.Factory.StartNew(new Action<object>(TaskCallback), callback);
         // new Thread(ThreadCallback).Start(callback);
      }
      private void TaskCallback(object callback)
      {
          IMyMessageCallback messageCallback = callback as IMyMessageCallback;
          for (int i = 0; i < 10; i++)
          {
              messageCallback.OnCallback("message " + i.ToString());
              Thread.Sleep(1000);
          }
      }

      //private void ThreadCallback(object callback)
      //{
      //   IMyMessageCallback messageCallback = callback as IMyMessageCallback;
      //   for (int i = 0; i < 10; i++)
      //   {
      //      messageCallback.OnCallback("message " + i.ToString());
      //      Thread.Sleep(1000);
      //   }
      //}
   }

}
