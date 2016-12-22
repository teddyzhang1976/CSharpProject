using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Wrox.ProCSharp.ASPNETCore
{
  public class SampleModule : IHttpModule
  {
    private const string allowedAddressesFile = "AllowedAddresses.txt";
    private List<string> allowedAddresses;

    /// <summary>
    /// You will need to configure this module in the Web.config file of your
    /// web and register it with IIS before being able to use it. For more information
    /// see the following link: http://go.microsoft.com/?linkid=8101007
    /// </summary>
    #region IHttpModule Members

    public void Dispose()
    {
      //clean-up code here.
      allowedAddresses.Clear();
    }

    public void Init(HttpApplication context)
    {
      context.LogRequest += new EventHandler(OnLogRequest);
      context.PreRequestHandlerExecute += PreRequestHandlerExecute;
      context.BeginRequest += BeginRequest;
    }

    private void BeginRequest(object sender, EventArgs e)
    {
      LoadAddresses((sender as HttpApplication).Context);
    }

    private void LoadAddresses(HttpContext context)
    {
      if (allowedAddresses == null)
      {
        string path = context.Server.MapPath(allowedAddressesFile);
        allowedAddresses = File.ReadAllLines(path).ToList();

      }
    }

    private void PreRequestHandlerExecute(object sender, EventArgs e)
    {
      HttpApplication app = sender as HttpApplication;
      HttpRequest req = app.Context.Request;
      if (!allowedAddresses.Contains(req.UserHostAddress))
      {
        throw new HttpException(403, "IP address denied");
      }
    }

    #endregion

    public void OnLogRequest(Object source, EventArgs e)
    {
      //custom logging logic can go here
    }
  }
}
