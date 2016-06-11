using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using PCSMVCMagicShop.Models;

namespace PCSMVCMagicShop.Controllers
{
   public class ProductsController : Controller
   {
      private MagicShopEntities entities = new MagicShopEntities();
      //
      // GET: /Products/

      public ActionResult Index()
      {
         return View(entities.Products.ToList());
      }

      //
      // GET: /Products/Details/5

      public ActionResult Details(int id)
      {
         var product = (from e in entities.Products where e.ProductId == id select e).FirstOrDefault();
         if (product != null)
         {
            return View(product);
         }
         else
         {
            return RedirectToAction("Index");
         }
      }

      //
      // GET: /Products/Create

      public ActionResult Create()
      {
         return View();
      }

      //
      // POST: /Products/Create

      [AcceptVerbs(HttpVerbs.Post)]
      public ActionResult Create([Bind(Exclude = "ProductId")] Product productToCreate)
      {
         try
         {
            if (!ModelState.IsValid)
            {
               return View();
            }

            entities.AddToProducts(productToCreate);
            entities.SaveChanges();
            return RedirectToAction("Index");
         }
         catch
         {
            return View();
         }
      }

      //
      // GET: /Products/Edit/5

      public ActionResult Edit(int id)
      {
         var productToEdit = (from p in entities.Products
                              where p.ProductId == id
                              select p).First();

         return View(productToEdit);
      }

      //
      // POST: /Products/Edit/5

      [AcceptVerbs(HttpVerbs.Post)]
      public ActionResult Edit(Product productToEdit)
      {
         try
         {
            var originalProduct = (from p in entities.Products
                                   where p.ProductId == productToEdit.ProductId
                                   select p).First();

            if (!ModelState.IsValid)
            {
               return View(originalProduct);
            }

            entities.ApplyCurrentValues(originalProduct.EntityKey.EntitySetName, productToEdit);
            entities.SaveChanges();

            return RedirectToAction("Index");

         }
         catch
         {
            return View();
         }
      }
   }
}
