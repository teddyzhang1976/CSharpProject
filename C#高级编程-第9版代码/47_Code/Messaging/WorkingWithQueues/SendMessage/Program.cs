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
        if (!MessageQueue.Exists(@".\Private$\MyPrivateQueue"))
        {
          MessageQueue.Create(@".\Private$\MyPrivateQueue");
        }
        var formatter = new BinaryMessageFormatter();
        var queue = new MessageQueue(@".\Private$\MyPrivateQueue");
        queue.Formatter = formatter;
        queue.Send("Sample Message", "Label");
      }
      catch (MessageQueueException ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}

