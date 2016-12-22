using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProCSharpSample
{
  public partial class CheckLogin : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Context.User.Identity.IsAuthenticated)
      {
        this.userInfo.Text = User.Identity.GetUserName();
      }
      else
      {
//        this.userInfo.Text = "not authenticated";
        Response.Redirect("/Account/Login.aspx");
      }
    }
  }
}