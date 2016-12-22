using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Collections
{
  public class Info
  {
    public string Word { get; set; }
    public int Count { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
      return String.Format("{0} x: {1}", Count, Word);
    }
  }
}
