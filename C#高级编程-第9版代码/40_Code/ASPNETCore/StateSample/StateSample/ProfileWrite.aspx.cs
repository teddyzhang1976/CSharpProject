using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateSample
{
  public partial class ProfileWrite : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      this.Context.Profile["Color"] = TextBox1.Text;
      this.Context.Profile.Save();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      dynamic p = this.Context.Profile;
      p.Color = "Red";
      p.UserInfo.Name = "Christian";

      var cart = new ShoppingCart();
      cart.Items.Add(new Item { Description = "Sample1", Cost = 20.30M });
      cart.Items.Add(new Item { Description = "Sample2", Cost = 14.30M });

      p.ShoppingCart = cart;
      p.Save();

    }
  }
}