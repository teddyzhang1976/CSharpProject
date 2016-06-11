using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 0)
        {
            this.NoQuerystringLabel.Text = "None.";
        }
        else
        {
            GridView1.DataSource = from string key in Request.QueryString.Keys
                                   select
                                       new
                                       {
                                           Name = key,
                                           Value = Request.QueryString[key]
                                       };
            GridView1.DataBind();
        }

        if (Page.RouteData.Values.Count == 0)
        {
            this.NoRoutingLabel.Text = "None.";
        }
        else
        {
            GridView2.DataSource = from key in Page.RouteData.Values.Keys
                                   select
                                       new
                                       {
                                           Name = key,
                                           Value = Page.RouteData.Values[key]
                                       };
            GridView2.DataBind();
        }
    }
}
