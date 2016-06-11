using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class MyPageBase : Page
{
   protected override void OnPreInit(EventArgs e)
   {
      // theming
      if (Session["SessionTheme"] != null)
      {
         Page.Theme = Session["SessionTheme"] as string;
      }
      else
      {
         Page.Theme = "DefaultTheme";
      }

      // base call
      base.OnPreInit(e);
   }
}
