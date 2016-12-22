using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateSample
{
  public partial class SessionRead : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      object state1 = Session["state1"];
      if (state1 != null)
      {
        Label1.Text = state1.ToString();
      }
    }
  }
}