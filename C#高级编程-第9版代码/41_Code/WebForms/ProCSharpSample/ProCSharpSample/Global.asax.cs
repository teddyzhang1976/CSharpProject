using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace ProCSharpSample
{
  public class Global : System.Web.HttpApplication
  {
    protected void Application_Start(object sender, EventArgs e)
    {
      RouteConfig.RegisterRoutes(RouteTable.Routes);

      ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
          new ScriptResourceDefinition
      {
        Path = "~/scripts/jquery-2.0.3.min.js",
        DebugPath = "~/scripts/jquery-2.0.3.js",
        CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.0.3.min.js",
        CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.0.3.js"
      });

    }
  }
}