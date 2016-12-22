using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace ProCSharpSample.Secure
{
  public partial class Login : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        if (User.Identity.IsAuthenticated)
        {
          loginForm.Visible = false;
          StatusText.Text = "Hello, " + User.Identity.GetUserName();
        }
        else
        {
          loginForm.Visible = true;
        }
      }
    }

    protected void OnLogin(object sender, EventArgs e)
    {
      string username = this.textUsername.Text;
      string password = this.textPassword.Text;

      var userStore = new UserStore<IdentityUser>();
      var userManager = new UserManager<IdentityUser>(userStore);
      IdentityUser user = userManager.Find(username,password);

      if (user != null)
      {
        ClaimsIdentity userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;


        authenticationManager.SignIn(new AuthenticationProperties() {  IsPersistent = false }, userIdentity);
        Response.Redirect(Request.QueryString["ReturnUrl"]);
      }
      else
      {
        StatusText.Text = "Invalid username or password.";
      }
    }
  }
}