using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Default : MyPageBase
{
   private void ApplyTheme(string themeName)
   {
      if (Session["SessionTheme"] != null)
      {
         Session.Remove("SessionTheme");
      }
      Session.Add("SessionTheme", themeName);
      Response.Redirect("~/Configuration/Themes", true);
   }

   protected void applyDefaultTheme_Click(object sender, EventArgs e)
   {
      ApplyTheme("DefaultTheme");
   }

   protected void applyBareTheme_Click(object sender, EventArgs e)
   {
      ApplyTheme("BareTheme");
   }

   protected void applyLuridTheme_Click(object sender, EventArgs e)
   {
      ApplyTheme("LuridTheme");
   }
}
