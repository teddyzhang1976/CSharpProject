using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSample
{
  public partial class RequestSample : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      HttpBrowserCapabilities browserCapabilities = Request.Browser;
      Response.Write("<ul>");
      foreach (var key in browserCapabilities.Capabilities.Keys)
      {
        Response.Write("<li>");
        Response.Write(string.Format("{0}: {1}", key, browserCapabilities.Capabilities[key]));
        Response.Write("</li>");
      }
      Response.Write("</ul>");
    }
  }
}