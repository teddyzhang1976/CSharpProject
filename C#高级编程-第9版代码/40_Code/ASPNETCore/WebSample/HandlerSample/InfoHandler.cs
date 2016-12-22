using System;
using System.Text;
using System.Web;

namespace Wrox.ProCSharp.ASPNETCore
{
  public class InfoHandler : IHttpHandler
  {
    private string responseString = @"
<!DOCTYPE HTML>
<html>
<head>
  <meta charset=""UTF-8"">
  <title>ASP.NET Info</title>
</head>
<body>
  <h1>Modules loaded:</h1>
  <div>{0}</div>
</body>
</html>";

    /// <summary>
    /// You will need to configure this handler in the Web.config file of your 
    /// web and register it with IIS before being able to use it. For more information
    /// see the following link: http://go.microsoft.com/?linkid=8101007
    /// </summary>
    #region IHttpHandler Members

    public bool IsReusable
    {
      // Return false in case your Managed Handler cannot be reused for another request.
      // Usually this would be false in case you have some state information preserved per request.
      get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
      var sb = new StringBuilder();
      sb.Append("<ul>");
      foreach (var module in context.ApplicationInstance.Modules)
      {
        sb.AppendFormat("<li>{0}</li>", module);
      }
      sb.Append("</ul>");
      context.Response.ContentType = "text/html";
      context.Response.Write(string.Format(responseString, sb.ToString()));
    }

    #endregion
  }
}
