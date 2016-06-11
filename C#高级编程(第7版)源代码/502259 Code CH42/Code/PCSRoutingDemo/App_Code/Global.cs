using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global : HttpApplication
{
    protected void Application_Start(object sender, EventArgs e)
    {
        RouteTable.Routes.Add("TestRoute", new Route("Target/{targetparameter}",
           new PageRouteHandler("~/Target.aspx")));
    }
}