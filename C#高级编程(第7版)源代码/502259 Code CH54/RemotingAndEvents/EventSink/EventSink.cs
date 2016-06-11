using System;
using System.Runtime.Remoting.Messaging;

namespace Wrox.ProCSharp.Remoting
{
    public class EventSink : MarshalByRefObject
    {
        public EventSink()
        {
        }
        public void StatusHandler(object sender, StatusEventArgs e)
        {
            Console.WriteLine("EventSink: Event occurred: " + e.Message);
        }
    }
}

