using ProCSharpSample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProCSharpSample.DataAccess
{
  public partial class ShowReservations : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void OnContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
    {
      //var data = new RoomReservationEntities();
      //e.Context = (System.Data.Objects.ObjectContext)(data as IObjectContextAdapter).ObjectContext;
    }
  }
}