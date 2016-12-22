using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProCSharpSample
{
  public partial class ReserveRoom : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Label label = Master.FindControl("LabelBottom") as Label;
      if (label != null)
      {
        label.Text = "Hello from the content page";
      }


    }

    protected void OnRoomSelection(object sender, EventArgs e)
    {

    }
  }
}