using System.Web;

namespace Wrox.ProCSharp.ASPNETCore
{
  public class SampleHandler : IHttpHandler
  {
    private string responseString = @"
<!DOCTYPE HTML>
<html>
<head>
  <meta charset=""UTF-8"">
  <title>Sample Handler</title>
</head>
<body>
  <h1>Hello from the custom handler</h1>
  <div>{0}</div>
</body>
</html>";

    public bool IsReusable
    {
      get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {
      HttpRequest request = context.Request;
      HttpResponse response = context.Response;
      response.ContentType = "text/html";
      response.Write(string.Format(responseString, request.UserAgent));
    }
  }
}
