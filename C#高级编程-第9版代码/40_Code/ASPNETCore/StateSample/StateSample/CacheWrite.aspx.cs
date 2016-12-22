using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateSample
{
  public partial class CacheWrite : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      Cache.Add(key: "cache1", value: TextBox1.Text, dependencies: null, absoluteExpiration: Cache.NoAbsoluteExpiration, slidingExpiration: TimeSpan.FromMinutes(30), priority: CacheItemPriority.Normal, onRemoveCallback: null);
    }
  }
}