using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace Wrox.ProCSharp.EnterpriseServices
{
    [EventTrackingEnabled(true)]
    [ComVisible(true)]
    [Description("Simple Serviced Component Sample")]
    public class SimpleComponent : ServicedComponent, IGreeting
    {
        public string Welcome(string name)
        {
            // simulate some processing time
            System.Threading.Thread.Sleep(1000);
            return "Hello, " + name;
        }

    }
}
