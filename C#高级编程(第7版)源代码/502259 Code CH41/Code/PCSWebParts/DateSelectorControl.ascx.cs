using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DateSelectorControl : System.Web.UI.UserControl, IDateProvider
{
   protected void Page_Load(object sender, EventArgs e)
   {
      if (!Page.IsPostBack)
      {
         Calendar1.SelectedDate = DateTime.Today;
      }
   }

   public SelectedDatesCollection SelectedDates
   {
      get
      {
         return Calendar1.SelectedDates;
      }
   }

   [ConnectionProvider("Date Provider", "DateProvider")]
   public IDateProvider ProvideDate()
   {
      return this;
   }
}
