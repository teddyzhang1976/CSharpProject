using System;
using System.Messaging;

namespace Wrox.ProCSharp.Messaging
{
  class Program
  {
    static void Main()
    {
      try
      {
        // string queueName = @".\MyNewPublicQueue";
        string queueName = @".\private$\MyNewPrivateQueue";
        using (var queue = MessageQueue.Create(queueName))
        {
          queue.Label = "Demo Queue";
          Console.WriteLine("Queue created:");
          Console.WriteLine("\tPath: {0}", queue.Path);
          Console.WriteLine("\tFormatName: {0}", queue.FormatName);
        }
      }
      catch (MessageQueueException ex)
      {
        Console.WriteLine(ex.Message);
      }
      Console.ReadLine();
    }
  }
}

