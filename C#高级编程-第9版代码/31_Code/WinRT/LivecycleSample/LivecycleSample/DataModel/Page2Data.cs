using LivecycleSample.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LivecycleSample.DataModel
{
  [DataContract]
  public class Page2Data : BindableBase
  {
    private string data;

    [DataMember]
    public string Data
    {
      get { return data; }
      set { SetProperty(ref data, value); }
    }
  }

}
