using System.Web;
using System.Web.Mvc;

namespace Formula1ServiceSample
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
