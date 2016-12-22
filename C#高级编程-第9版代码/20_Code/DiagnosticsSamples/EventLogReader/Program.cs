using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Eventing;

namespace EventLogReader
{
  class Program
  {
    static void Main(string[] args)
    {
      EventLogQuery query = new EventLogQuery("path", PathType.LogName, "query");
      EventLogWatcher watcher = new EventLogWatcher(query);
      watcher.EventRecordWritten += (sender, e) =>
        {
          Console.WriteLine(e.EventRecord);
        };
      watcher.Enabled = true;
    }
  }
}
