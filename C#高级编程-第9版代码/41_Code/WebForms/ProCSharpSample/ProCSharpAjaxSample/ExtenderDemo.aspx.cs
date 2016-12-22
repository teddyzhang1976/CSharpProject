using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProCSharpAjaxSample
{
  public partial class ExtenderDemo : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void OnSelect(object sender, EventArgs e)
    {
      favoriteColorLabel.Text = ((LinkButton)sender).Text;
      favoriteColorLabel.Style["color"] = ((LinkButton)sender).Style["color"];
    }

  }
}