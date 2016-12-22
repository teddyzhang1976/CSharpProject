using MVCSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSampleApp.Controllers
{
  public class HelperMethodsController : Controller
  {
    //
    // GET: /HelperMethods/
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult HelperWithMenu()
    {
      var menu = new Menu
      {
        Id = 1,
        Text = "Schweinsbraten mit Knödel und Sauerkraut",
        Price = 6.9,
        Date = new DateTime(2012, 10, 5),
        Category = "Main"
      };
      return View(menu);
    }

    public ActionResult HelperList()
    {
      var cars = new Dictionary<int, string>();
      cars.Add(1, "Red Bull Racing");
      cars.Add(2, "McLaren");
      cars.Add(3, "Lotus");
      cars.Add(4, "Ferrari");
      return View(cars.ToSelectListItems(4));
    }

    public ActionResult StronglyTypedMenu()
    {
      var menu = new Menu
      {
        Id = 1,
        Text = "Schweinsbraten mit Knödel und Sauerkraut",
        Price = 6.9,
        Date = new DateTime(2013, 10, 5),
        Category = "Main"
      };
      return View(menu);
    }

    public ActionResult Create()
    {
      return View(new Menu());
    }

    public ActionResult Display()
    {
      var menu = new Menu
      {
        Id = 1,
        Text = "Schweinsbraten mit Knödel und Sauerkraut",
        Price = 6.9,
        Date = new DateTime(2013, 10, 5),
        Category = "Main"
      };
      return View(menu);
    }

  }
}