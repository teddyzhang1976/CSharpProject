using System;
using System.Messaging;

namespace Wrox.ProCSharp.Messaging
{
  class Program
  {
    static void Main()
    {
      var queue = new MessageQueue(@".\Private$\MyPrivateQueue");
      queue.Formatter = new XmlMessageFormatter(new string[] { "System.String" });

      Message message = queue.Receive();
      Console.WriteLine(message.Body);
    }
  }
}

