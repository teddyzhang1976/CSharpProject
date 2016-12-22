using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

[assembly: Switch("Wrox.ProCSharp.Diagnostics", typeof(SourceSwitch))]

namespace Wrox.ProCSharp.Diagnostics
{
  public class Program
  {
    internal static SourceSwitch traceSwitch = new SourceSwitch("Wrox.ProCSharp.Diagnostics") { Level = SourceLevels.Verbose };
    internal static TraceSource trace = new TraceSource("Wrox.ProCSharp.Diagnostics"); // { Switch = traceSwitch };

    static void TraceSourceDemo1()
    {
      trace.TraceInformation("Info message");

      trace.TraceEvent(TraceEventType.Error, 3, "Error message");
      trace.TraceData(TraceEventType.Information, 2, "data1", 4, 5);
      trace.Close();
    }


    //static void ThreadMethod()
    //{
    //    Trace.CorrelationManager.ActivityId = Guid.NewGuid();
    //    trace.TraceEvent(TraceEventType.Verbose, 5, "ThreadMethod started");

    //    trace.TraceEvent(TraceEventType.Verbose, 6, "ThreadMethod ended");
    //}

    static void Main()
    {
      if (Trace.CorrelationManager.ActivityId == Guid.Empty)
      {
        Guid newGuid = Guid.NewGuid();
        Trace.CorrelationManager.ActivityId = newGuid;
        //  trace.TraceTransfer(0, "Main activity", newGuid);
      }
      trace.TraceEvent(TraceEventType.Start, 0, "Main started");

      // start a logical operation
      Trace.CorrelationManager.StartLogicalOperation("Main");

      TraceSourceDemo1();

      StartActivityA();

      Trace.CorrelationManager.StopLogicalOperation();

      Thread.Sleep(3000);

      trace.TraceEvent(TraceEventType.Stop, 0, "Main stopped");
      Console.WriteLine("Main stopped");
    }

    private static void StartActivityA()
    {
      Guid oldGuid = Trace.CorrelationManager.ActivityId;
      Guid newActivityId = Guid.NewGuid();
      Trace.CorrelationManager.ActivityId = newActivityId;

      Trace.CorrelationManager.StartLogicalOperation("StartActivityA");

      trace.TraceEvent(TraceEventType.Verbose, 0, "starting Foo in StartNewActivity");
      Foo();

      trace.TraceEvent(TraceEventType.Verbose, 0, "starting a new task");
      Task.Run(() => WorkForATask());

      Trace.CorrelationManager.StopLogicalOperation();
      Trace.CorrelationManager.ActivityId = oldGuid;
    }

    private static void WorkForATask()
    {
      trace.TraceEvent(TraceEventType.Start, 0, "WorkForATask started");

      trace.TraceEvent(TraceEventType.Verbose, 0, "running WorkForATask");

      trace.TraceEvent(TraceEventType.Stop, 0, "WorkForATask completed");
    }

    private static void Foo()
    {
      Trace.CorrelationManager.StartLogicalOperation("Foo operation");

      trace.TraceEvent(TraceEventType.Verbose, 0, "running Foo");

      Trace.CorrelationManager.StopLogicalOperation();
    }


  }
}
