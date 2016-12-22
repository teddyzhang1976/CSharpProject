using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDemo
{
  [Serializable]
  public class ParentCultureException : Exception
  {
    public ParentCultureException() { }
    public ParentCultureException(string message) : base(message) { }
    public ParentCultureException(string message, Exception inner) : base(message, inner) { }
    protected ParentCultureException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
      : base(info, context) { }
  }
}
