using MVCSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSampleApp.Controllers
{
  public class HomeController : Controller
  {
    //
    // GET: /Home/
    public ActionResult Index()
    {
      return View();
    }

    public string Hello()
    {
      return "Hello, ASP.NET MVC";
    }

    public string Greeting(string name)
    {
      return HttpUtility.HtmlEncode("Hello, " + name);
    }

    public string Greeting2(string id)
    {
      return HttpUtility.HtmlEncode("Hello, " + id);
    }

    public int Add(int x, int y)
    {
      return x + y;
    }

    public ActionResult ContentDemo()
    {
      return Content("Hello World", "text/plain");
    }
    public ActionResult JavaScriptDemo()
    {
      return JavaScript("<script>function foo { alert('foo'); }</script>");
    }

    public ActionResult JsonDemo()
    {
      var m = new Menu
      {
        Id = 3,
        Text = "Grilled sausage with sauerkraut und potatoes",
        Price = 12.90,
        Category = "Main"
      };
      return Json(m, JsonRequestBehavior.AllowGet);
    }

    public ActionResult RedirectDemo()
    {
      return Redirect("http://www.cninnovation.com");
    }

    public ActionResult RedirectRouteDemo()
    {
      return RedirectToRoute(new { controller = "Home", action = "Hello" });
    }


  }
}