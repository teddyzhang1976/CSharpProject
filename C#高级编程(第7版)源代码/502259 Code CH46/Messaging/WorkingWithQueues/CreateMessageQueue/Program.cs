using System;
using System.Messaging;

namespace Wrox.ProCSharp.Messaging
{
    class Program
    {
        static void Main()
        {
            using (var queue = MessageQueue.Create(@".\MyNewPublicQueue"))
            {
                queue.Label = "Demo Queue";
                Console.WriteLine("Queue created:");
                Console.WriteLine("\tPath: {0}", queue.Path);
                Console.WriteLine("\tFormatName: {0}", queue.FormatName);
            }
        }
    }
}

