using MenuPlanner.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MenuPlanner.Controllers
{
  [Authorize]
  public class MenuAdminController : Controller
  {
    private RestaurantEntities db = new RestaurantEntities();

    // GET: /MenuAdmin/
    public async Task<ActionResult> Index()
    {
      var menus = db.Menus.Include(m => m.MenuCard);
      return View(await menus.ToListAsync());
    }

    // GET: /MenuAdmin/Details/5
    public async Task<ActionResult> Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Menu menu = await db.Menus.FindAsync(id);
      if (menu == null)
      {
        return HttpNotFound();
      }
      return View(menu);
    }

    // GET: /MenuAdmin/Create
    public ActionResult Create()
    {
      ViewBag.MenuCardId = new SelectList(db.MenuCards, "Id", "Name");
      return View();
    }

    // POST: /MenuAdmin/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "Id,MenuCardId,Text,Price,Active,Order,Type,Day")] Menu menu)
    {
      if (ModelState.IsValid)
      {
        db.Menus.Add(menu);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      ViewBag.MenuCardId = new SelectList(db.MenuCards, "Id", "Name", menu.MenuCardId);
      return View(menu);
    }

    // GET: /MenuAdmin/Edit/5
    public async Task<ActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Menu menu = await db.Menus.FindAsync(id);
      if (menu == null)
      {
        return HttpNotFound();
      }
      ViewBag.MenuCardId = new SelectList(db.MenuCards, "Id", "Name", menu.MenuCardId);
      return View(menu);
    }

    // POST: /MenuAdmin/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "Id,MenuCardId,Text,Price,Active,Order,Type,Day")] Menu menu)
    {
      if (ModelState.IsValid)
      {
        db.Entry(menu).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      ViewBag.MenuCardId = new SelectList(db.MenuCards, "Id", "Name", menu.MenuCardId);
      return View(menu);
    }

    // GET: /MenuAdmin/Delete/5
    public async Task<ActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Menu menu = await db.Menus.FindAsync(id);
      if (menu == null)
      {
        return HttpNotFound();
      }
      return View(menu);
    }

    // POST: /MenuAdmin/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
      Menu menu = await db.Menus.FindAsync(id);
      db.Menus.Remove(menu);
      await db.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
