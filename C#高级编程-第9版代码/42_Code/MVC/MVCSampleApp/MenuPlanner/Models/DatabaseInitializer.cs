using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MenuPlanner.Models
{
  public class DatabaseInitializer : DropCreateDatabaseAlways<RestaurantEntities>
  {
    protected override void Seed(RestaurantEntities context)
    {
      context.MenuCards.AddOrUpdate(c => c.Name,
        new MenuCard { Name = "Breakfast", Active = true, Order = 1 },
        new MenuCard { Name = "Vegetarian", Active = true, Order = 2 },
        new MenuCard { Name = "Steaks", Active = true, Order = 3 });
      base.Seed(context);
    }
  }
}