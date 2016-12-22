using MVCSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSampleApp.Controllers
{
  public class ViewsDemoController : Controller
  {
    //
    // GET: /ViewsDemo/
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult PassingData()
    {
      ViewBag.MyData = "Hello from the controller";
      return View();
    }

    public ActionResult PassingAModel()
    {
      var menus = new List<Menu>
      {
        new Menu { Id=1, Text="Schweinsbraten mit Knödel und Sauerkraut", 
                   Price=6.9, Category="Main" },
        new Menu { Id=2, Text="Erdäpfelgulasch mit Tofu und Gebäck", 
                   Price=6.9, Category="Vegetarian" },
        new Menu { Id=3, 
                   Text="Tiroler Bauerngröst'l mit Spiegelei und Krautsalat", 
                   Price=6.9, Category="Main" }
      };
      return View(menus);
    }

    public ActionResult LayoutSample()
    {
      return View();
    }

    public ActionResult LayoutUsingSections()
    {
      return View();
    }

    public ActionResult UseAPartialView1()
    {
      return View(new EventsAndMenus());
    }




    public ActionResult UseAPartialView2()
    {
      return View();
    }

    public ActionResult UseAPartialView3()
    {
      return View();
    }

    public ActionResult ShowEvents()
    {
      ViewBag.EventsTitle = "Live Events";
      return PartialView(new EventsAndMenus().Events);
    }

  }
}