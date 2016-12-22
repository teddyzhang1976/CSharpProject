using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Configuration;

[assembly: OwinStartup(typeof(ProCSharpSample.AuthenticationStartup))]

namespace ProCSharpSample
{
  public class AuthenticationStartup
  {
    public void Configuration(IAppBuilder app)
    {
      // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

      app.UseCookieAuthentication(new CookieAuthenticationOptions
      {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString("/Account/Login")
      });
      app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    }
  }
}
