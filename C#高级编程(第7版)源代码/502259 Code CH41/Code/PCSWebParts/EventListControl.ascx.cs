using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class EventListControl : System.Web.UI.UserControl
{
   private IDateProvider provider;

   protected void Page_Load(object sender, EventArgs e)
   {
      if (!Page.IsPostBack)
      {
         SetDateLabel();
      }
   }

   private void SetDateLabel()
   {
      StringBuilder sb = new StringBuilder();
      foreach (DateTime date in SelectedDates)
      {
         sb.AppendLine(date.ToString("yyyy.MM.dd"));
      }
      selectedDatesLabel.Text = sb.ToString();
   }

   private bool IsConnected
   {
      get
      {
         if (ViewState["isConnected"] != null)
         {
            return (bool)ViewState["isConnected"];
         }
         else
         {
            return false;
         }
      }
      set
      {
         ViewState["isConnected"] = value;
      }
   }

   public SelectedDatesCollection SelectedDates
   {
      get
      {
         if (IsConnected && provider != null)
         {
            return provider.SelectedDates;
         }
         else
         {
            return new SelectedDatesCollection(new ArrayList( new DateTime[1] { DateTime.Today }));
         }
      }
   }

   [ConnectionConsumer("Date Consumer", "DateConsumer")]
   public void GetDate(IDateProvider provider)
   {
      this.provider = provider;
      IsConnected = true;
      SetDateLabel();
   }
}
