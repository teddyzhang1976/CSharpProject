using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace StateSample
{
  public class Global : System.Web.HttpApplication
  {

    protected void Application_Start(object sender, EventArgs e)
    {
      Application["UserCount"] = 0;
    }

    protected void Session_Start(object sender, EventArgs e)
    {
      try
      {
        Application.Lock();
        int userCount = (int)Application["UserCount"];
        Application["UserCount"] = ++userCount;
      }
      finally
      {
        Application.UnLock();
      }

    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {

    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {

    }

    protected void Application_Error(object sender, EventArgs e)
    {

    }

    protected void Session_End(object sender, EventArgs e)
    {

    }

    protected void Application_End(object sender, EventArgs e)
    {
    }
  }
}