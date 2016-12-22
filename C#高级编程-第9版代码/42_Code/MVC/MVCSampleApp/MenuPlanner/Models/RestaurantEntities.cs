using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MenuPlanner.Models
{
  public class RestaurantEntities : DbContext
  {
    private const string connectionString = @"server=(localdb)\v11.0;database=Restaurant;trusted_connection=true";

    public RestaurantEntities()
      : base(connectionString)
    {
    }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuCard> MenuCards { get; set; }
  }
}