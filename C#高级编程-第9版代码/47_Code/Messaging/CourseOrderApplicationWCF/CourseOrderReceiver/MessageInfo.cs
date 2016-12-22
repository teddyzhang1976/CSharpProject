using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Messaging
{
  public class MessageInfo
  {
    public string Label { get; set; }
    public string Id { get; set; }

    public override string ToString()
    {
      return Label;
    }
  }
}
