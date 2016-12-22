using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Interop
{
  class Program
  {
    static void Main(string[] args)
    {
      Type t = Type.GetTypeFromProgID("COMServer.COMDemo");
      dynamic o = Activator.CreateInstance(t);
      Console.WriteLine(o.Greeting("Angela"));

    }
  }
}
