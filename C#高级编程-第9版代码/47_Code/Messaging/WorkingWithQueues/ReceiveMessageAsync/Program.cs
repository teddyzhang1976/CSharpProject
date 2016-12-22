using System;
using System.Messaging;
using System.Threading;

namespace Wrox.ProCSharp.Messaging
{
  class Program
  {
    static void Main()
    {
      var queue = new MessageQueue(@".\Private$\MyPrivateQueue");
      queue.Formatter = new XmlMessageFormatter(new string[] { "System.String" });


      queue.ReceiveCompleted += MessageArrived;

      queue.BeginReceive();
      // thread does not wait
      // can do something else
      for (int i = 0; i < 100; i++)
      {
        Console.WriteLine("...");
        Thread.Sleep(1000);
      }

    }

    public static void MessageArrived(object source, ReceiveCompletedEventArgs e)
    {
      MessageQueue queue = (MessageQueue)source;
      Message message = queue.EndReceive(e.AsyncResult);
      Console.WriteLine(message.Body);
    }

  }
}


