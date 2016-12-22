using System.Threading;

namespace Wrox.ProCSharp.WPF
{
  public class Information
  {
    public string Info1
    {
      get
      {
        return "please wait...";
      }
    }

    public string Info2
    {
      get
      {
        Thread.Sleep(5000);
        return "please wait a little more";
      }
    }
  }
}
