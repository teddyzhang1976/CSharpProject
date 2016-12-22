using System;
using System.Diagnostics;
using System.IO;

namespace Wrox.ProCSharp.Tracing
{
  class Program
  {
    static void CreateEventSource(bool deletefirst)
    {
      if (deletefirst)
      {
        

        EventLog.DeleteEventSource("EventLogDemoApp");
        EventLog.Delete("ProCSharpLog");
      }

      string logName = "ProCSharpLog";
      string sourceName = "EventLogDemoApp";
      string resourceFile = @"c:\procsharp\TracingAndEvents\EventLogDemo\EventLogDemo\EventLogDemoMessages.dll";


      if (!EventLog.SourceExists(sourceName))
      {
        //  string resourceFile = @"%SystemRoot%\System32\EventLogDemoMessages.dll";            
        if (!File.Exists(resourceFile))
        {
          Console.WriteLine("Message resource file does not exist");
          return;
        }

        EventSourceCreationData eventSource = new EventSourceCreationData(sourceName, logName);

        eventSource.CategoryResourceFile = resourceFile;
        eventSource.CategoryCount = 4;
        eventSource.MessageResourceFile = resourceFile;
        eventSource.ParameterResourceFile = resourceFile;

        EventLog.CreateEventSource(eventSource);
      }
      else
      {
        logName = EventLog.LogNameFromSourceName(sourceName, ".");
      }

      EventLog evLog = new EventLog(logName, ".", sourceName);
      evLog.RegisterDisplayName(resourceFile, 5001);



      using (var log = new EventLog(logName, ".", sourceName))
      {
        EventInstance info = new EventInstance(1000, 4, EventLogEntryType.Information);
        log.WriteEvent(info);

        EventInstance info2 = new EventInstance(1001, 4, EventLogEntryType.Error);
        log.WriteEvent(info2, "avalon");

        EventInstance info3 = new EventInstance(1002, 3, EventLogEntryType.Error);
        byte[] addionalInfo = { 1, 2, 3 };
        log.WriteEvent(info3, addionalInfo);



        //log.WriteEntry("Message 1");
        //log.WriteEntry("Message 2", EventLogEntryType.Warning);
        //log.WriteEntry("Message 3", EventLogEntryType.Information, 33);
      }





      //EventLog.WriteEntry("EventLogDemoApp", "Message 1");
      //EventLog.WriteEntry("EventLogDemoApp", "Message 2", EventLogEntryType.Warning);
      //EventLog.WriteEntry("EventLogDemoApp", "Message 3", EventLogEntryType.Error, 37);


    }

    static void Main()
    {
      CreateEventSource(false);
    }
  }
}
