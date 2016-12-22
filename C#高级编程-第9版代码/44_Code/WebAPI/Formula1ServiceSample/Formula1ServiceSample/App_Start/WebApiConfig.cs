using Formula1ServiceSample.Models;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace Formula1ServiceSample
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services

      var builder = new ODataConventionModelBuilder();
      builder.EntitySet<Racer>("Racer");
      builder.EntitySet<RaceResult>("RaceResult");
      builder.EntitySet<Race>("Race");
      builder.EntitySet<Circuit>("Circuit");
      config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
