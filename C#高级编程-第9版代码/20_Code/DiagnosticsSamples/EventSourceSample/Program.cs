using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http;

namespace EventSourceSample
{
  class Program
  {
    private static MyListener listener;
    static void Main()
    {
      string name = MyAdvancedProjectEventSource.GetName(typeof(MyAdvancedProjectEventSource));
     // IEnumerable<EventSource> eventSources = MyProjectEventSource.GetSources();
      IEnumerable<EventSource> eventSources = EventSource.GetSources();
      InitListener(eventSources);
    //  MyProjectEventSource.Log.Startup();
      MyAdvancedProjectEventSource.Log.Startup();
      MyAdvancedProjectEventSource.Log.SomeTask();
      MyAdvancedProjectEventSource.Log.Startup2();
      NetworkRequestSample();
      Console.ReadLine();
      listener.Dispose();
    }

    private static void InitListener(IEnumerable<EventSource> sources)
    {
      listener = new MyListener();
      foreach (var source in sources)
      {
        listener.EnableEvents(source, EventLevel.LogAlways, (EventKeywords)15L);
      }

    }

    private static async void NetworkRequestSample()
    {
      try
      {
        var client = new HttpClient();
        string url = "http://www.cninnovation.com";
     //   MyProjectEventSource.Log.CallService(url);
        MyAdvancedProjectEventSource.Log.CallService(url);

        string result = await client.GetStringAsync(url);
     //   Console.WriteLine(result);
        Console.WriteLine("Complete.................");
      }
      catch (Exception ex)
      {
     //   MyProjectEventSource.Log.ServiceError(ex.Message, ex.HResult);
        MyAdvancedProjectEventSource.Log.ServiceError(ex.Message, ex.HResult);
      }

    }


  }
}
