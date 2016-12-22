using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateSample
{
  public partial class ViewState1 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      Label1.Text = string.Format("TextBox1.Text: {0}", TextBox1.Text);
      Label2.Text = string.Format("ViewState[\"state1\"] {0}", ViewState["state1"]);
      ViewState["state1"] = TextBox1.Text;
    }
  }
}