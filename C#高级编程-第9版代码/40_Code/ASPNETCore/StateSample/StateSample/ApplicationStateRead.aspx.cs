using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateSample
{
  public partial class ApplicationStateRead : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      int userCount = (int)Application["UserCount"];
      Label1.Text = userCount.ToString();
    }
  }
}