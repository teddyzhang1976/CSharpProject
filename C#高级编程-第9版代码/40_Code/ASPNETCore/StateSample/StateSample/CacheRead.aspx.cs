using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateSample
{
  public partial class CacheRead : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      object cache1 = Cache["cache1"];
      if (cache1 != null)
      {
        Label1.Text = cache1.ToString();
      }
      else
      {
        Label1.Text = "cache item empty";
      }
    }
  }
}