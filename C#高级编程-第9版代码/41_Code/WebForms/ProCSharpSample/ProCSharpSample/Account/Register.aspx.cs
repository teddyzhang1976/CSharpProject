using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProCSharpSample.Account
{
  public partial class Register : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void OnRegister(object sender, EventArgs e)
    {
      string username = this.textUsername.Text;
      string password = this.textPassword.Text;

      var userStore = new UserStore<IdentityUser>();
      var manager = new UserManager<IdentityUser>(userStore);

      var user = new IdentityUser() { UserName = username };
      IdentityResult result = manager.Create(user, password);

      if (result.Succeeded)
      {
        StatusText.Text = string.Format("User {0} was created successfully!", user.UserName);
      }
      else
      {
        StatusText.Text = result.Errors.FirstOrDefault();
      }

    }
  }
}