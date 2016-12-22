using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourceSample
{
  class MyListener : EventListener
  {

    protected override void OnEventSourceCreated(EventSource eventSource)
    {
      Console.WriteLine("created {0} {1}", eventSource.Name, eventSource.Guid);
      // base.OnEventSourceCreated(eventSource);
      //base.EnableEvents(eventSource, EventLevel.Verbose, MyAdvancedProjectEventSource.Keywords.Network|MyAdvancedProjectEventSource.Keywords.Diagnostics);
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
      Console.WriteLine("event id: {0} source: {1}", eventData.EventId, eventData.EventSource.Name);
      foreach (var payload in eventData.Payload)
      {
        Console.WriteLine("\t{0}", payload);
      }
    }
  }
}
