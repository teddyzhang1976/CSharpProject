using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateSample
{
  public partial class ProfileRead : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      dynamic profile = Context.Profile;
      Response.Write(string.Format("Color: {0}", profile.Color));
      Response.Write("<br />");
      Response.Write(string.Format("Name: {0}", profile.UserInfo.Name));
      Response.Write("<br />");
      ShoppingCart shoppingCart = profile.ShoppingCart;
      foreach (var item in shoppingCart.Items)
      {
        Response.Write(string.Format("{0} {1}", item.Description, item.Cost));
        Response.Write("<br />");
      }
      Response.Write(shoppingCart.TotalCost);
      Response.Write("<br />");
    }
  }
}