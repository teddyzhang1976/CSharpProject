using System.Diagnostics.Tracing;

namespace EventSourceSample
{
 // [EventSource(Name="MyProjectSource")]
  public class MyProjectEventSource : EventSource
  {
    private MyProjectEventSource()
	  {
	  }
    public static MyProjectEventSource Log = new MyProjectEventSource();
    public void Startup()
    {
      base.WriteEvent(1);
    }
    public void CallService(string url)
    {
      base.WriteEvent(2, url);
    }

    public void ServiceError(string message, int error)
    {
      base.WriteEvent(3, message, error);
    }
  }
}
