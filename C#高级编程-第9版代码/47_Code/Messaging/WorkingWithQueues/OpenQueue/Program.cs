using System;
using System.Messaging;

namespace Wrox.ProCSharp.Messaging
{
  class Program
  {
    static void Main()
    {
      string queueName = @".\mynewpublicqueue";
      if (MessageQueue.Exists(queueName))
      {
        MessageQueue queue = new MessageQueue(queueName);
        //...
      }
      else
      {
        Console.WriteLine("Queue {0} does not exist", queueName);
      }
    }
  }
}

