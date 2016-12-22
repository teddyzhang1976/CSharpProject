using System.Threading;

namespace Wrox.ProCSharp.WPF
{
  public class Data
  {
    public string ProcessSomeData
    {
      get
      {
        Thread.Sleep(8000);
        return "the final result is here";
      }
    }
  }
}
