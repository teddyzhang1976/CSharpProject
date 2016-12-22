using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourceSample
{
  [EventSource(Name="EventSourceSample", Guid="45FFF0E2-7198-4E4F-9FC3-DF6934680096")]
  class MyAdvancedProjectEventSource : EventSource
  {
    public class Keywords
    {
      public const EventKeywords Network = (EventKeywords)1;
      public const EventKeywords Database = (EventKeywords)2;
      public const EventKeywords Diagnostics = (EventKeywords)4;
      public const EventKeywords Performance = (EventKeywords)8;
    }

    public class Tasks
    {
      public const EventTask CreateMenus = (EventTask)1;
      public const EventTask QueryMenus = (EventTask)2;
    }
    //private MyAdvancedProjectEventSource()
    //{
    //}
    public static MyAdvancedProjectEventSource Log = new MyAdvancedProjectEventSource();

    [Event(1, Opcode=EventOpcode.Start, Level=EventLevel.Verbose)]
    public void Startup()
    {
      base.WriteEvent(1);
    }
    [Event(2, Opcode=EventOpcode.Info, Keywords=Keywords.Network, Level=EventLevel.Verbose, Message="{0}")]
    public void CallService(string url)
    {
      base.WriteEvent(2);
    }

    [Event(3, Opcode=EventOpcode.Info, Keywords=Keywords.Network, Level=EventLevel.Error, Message="{0} error: {1}")]
    public void ServiceError(string message, int error)
    {
      base.WriteEvent(3);
    }

    [Event(4, Opcode=EventOpcode.Info, Task=Tasks.CreateMenus, Level=EventLevel.Verbose, Keywords=Keywords.Network)]
    public void SomeTask()
    {
      base.WriteEvent(4);
    }
    [Event(5, Opcode = EventOpcode.Start, Level = EventLevel.Verbose)]
    public void Startup2()
    {
      base.WriteEvent(5);
    }
  }
}
