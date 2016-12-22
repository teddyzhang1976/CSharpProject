using System;
using System.Messaging;

namespace Wrox.ProCSharp.Messaging
{
  class Program
  {
    static void Main()
    {
      foreach (var queue in MessageQueue.GetPrivateQueuesByMachine("localhost"))
      {
        Console.WriteLine(queue.Path);
        Console.WriteLine(queue.FormatName);
      }
    }
  }
}

