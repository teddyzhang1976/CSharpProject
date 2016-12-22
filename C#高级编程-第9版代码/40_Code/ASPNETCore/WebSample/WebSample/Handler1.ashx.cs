using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSample
{
  /// <summary>
  /// Summary description for Handler1
  /// </summary>
  public class Handler1 : IHttpHandler
  {

    public void ProcessRequest(HttpContext context)
    {
      HttpRequest request = context.Request;
      HttpResponse response = context.Response;
      response.ContentType = "text/html";
      response.Write("<!DOCTYPE H<ML>");
      response.Write("<html>");
      response.Write("<head>");
      response.Write("<meta charset=\"UTF-8\">");
      response.Write("<title>Sample Handler</title>");
      response.Write("</head>");
      response.Write("<body>");
      response.Write("<h1>Hello from the custom handler</h1>");
      response.Write("<div>");
      response.Write(request.UserAgent);
      response.Write("</div>");
      response.Write("</body>");
      response.Write("</html>");
    }

    public bool IsReusable
    {
      get
      {
        return false;
      }
    }
  }
}