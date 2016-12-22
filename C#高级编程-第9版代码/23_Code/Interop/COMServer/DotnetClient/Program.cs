using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Wrox.ProCSharp.Interop.Server;


namespace Wrox.ProCSharp.Interop.Client
{
  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      var obj = new COMDemo();
      IWelcome welcome = obj;
      Console.WriteLine(welcome.Greeting("Stephanie"));

      obj.Completed += () => Console.WriteLine("Calculation completed");


      IMath math;
      math = (IMath)welcome;
      int x = math.Add(4, 5);
      Console.WriteLine(x);

      Marshal.ReleaseComObject(math);

    }
  }
}
