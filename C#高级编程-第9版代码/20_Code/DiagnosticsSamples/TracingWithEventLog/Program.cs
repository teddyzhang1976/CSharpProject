using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracingWithEventLog
{
  class Program
  {
    static void Main(string[] args)
    {
      TraceSource source = new TraceSource("Demo");
      source.TraceEvent(TraceEventType.Verbose, 11, "HEllo Main");
      source.Flush();
      source.Close();
    }
  }
}
