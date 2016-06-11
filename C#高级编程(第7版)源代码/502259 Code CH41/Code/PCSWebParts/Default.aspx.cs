using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      if (!IsPostBack)
      {
         foreach (WebPartDisplayMode mode in WebPartManager1.SupportedDisplayModes)
         {
            string modeName = mode.Name;
            if (mode.IsEnabled(WebPartManager1))
            {
               displayMode.Items.Add(modeName);
            }
         }
      }
   }

   protected void WebPartManager1_DisplayModeChanged(object sender, WebPartDisplayModeEventArgs e)
   {
      if (WebPartManager1.DisplayMode != WebPartManager.BrowseDisplayMode
         && WebPartManager1.DisplayMode != WebPartManager.DesignDisplayMode)
      {
         editorPH.Visible = true;
      }
      else
      {
         editorPH.Visible = false;
      }
      displayMode.SelectedValue = WebPartManager1.DisplayMode.Name;
   }

   protected void displayMode_SelectedIndexChanged(object sender, EventArgs e)
   {
      WebPartDisplayMode mode = WebPartManager1.SupportedDisplayModes[displayMode.SelectedValue];
      if (mode != null)
      {
         WebPartManager1.DisplayMode = mode;
      }
   }

   protected void resetButton_Click(object sender, EventArgs e)
   {
      WebPartManager1.Personalization.ResetPersonalizationState();
   }
}
