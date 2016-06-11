using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MRB : System.Web.UI.UserControl
{
   public DataSet MRBData
   {
       get
       {
           if (Application["mrbData"] == null)
           {
               Application.Lock();
               MRBService.MRBService service = new MRBService.MRBService();
               service.Credentials = System.Net.CredentialCache.DefaultCredentials;
               Application["mrbData"] = service.GetData();
               Application.UnLock();
           }
           return Application["mrbData"] as DataSet;
       }
       set
       {
           Application.Lock();
           if (value == null && Application["mrbData"] != null)
           {
               Application.Remove("mrbData");
           }
           else
           {
               Application["mrbData"] = value;
           }
           Application.UnLock();
       }
   }

   private DataView EventData
   {
       get
       {
           return MRBData.Tables["Events"].DefaultView;
       }
   }

   private DataView RoomData
   {
       get
       {
           return MRBData.Tables["Rooms"].DefaultView;
       }
   }

   private DataView AttendeeData
   {
       get
       {
           return MRBData.Tables["Attendees"].DefaultView;
       }
   }

   private DataView EventDetailData
   {
       get
       {
           if (EventList != null && EventList.SelectedValue != null)
           {
               return new DataView(MRBData.Tables["Events"], "ID=" +
                 EventList.SelectedValue.ToString(), "",
                 DataViewRowState.CurrentRows);
           }
           else
           {
               return null;
           }
       }
   }

   protected override void OnDataBinding(EventArgs e)
   {
       roomList.DataSource = RoomData;
       attendeeList.DataSource = AttendeeData;
       EventList.DataSource = EventData;
       FormView1.DataSource = EventDetailData;
       base.OnDataBinding(e);
   }

   protected void Page_Load(object sender, EventArgs e)
   {
      if (!this.IsPostBack)
      {
         nameBox.Text = Context.User.Identity.Name;
         DateTime trialDate = DateTime.Now;
         calendar.SelectedDate = GetFreeDate(trialDate);
         DataBind();
      }
   }

   protected void submitButton_Click(object sender, EventArgs e)
   {
      if (Page.IsValid)
      {
         System.Text.StringBuilder sb = new System.Text.StringBuilder();
         foreach (ListItem attendee in attendeeList.Items)
         {
            if (attendee.Selected)
            {
               sb.AppendFormat("{0} ({1}), ", attendee.Text, attendee.Value);
            }
         }
         sb.AppendFormat(" and {0}", nameBox.Text);
         string attendees = sb.ToString();

         try
         {
             MRBService.MRBService service = new MRBService.MRBService();
             if (service.AddEvent(eventBox.Text, int.Parse(roomList.SelectedValue),
                 attendees, calendar.SelectedDate) == 1)
             {
                 MRBData = null;
                 DataBind();
                 calendar.SelectedDate =
                   GetFreeDate(calendar.SelectedDate.AddDays(1));
             }
         }
         catch
         {
         }
      }
   }

   private System.DateTime GetFreeDate(System.DateTime trialDate)
   {
      if (EventData.Count > 0)
      {
         System.DateTime testDate;
         bool trialDateOK = false;
         while (!trialDateOK)
         {
            trialDateOK = true;
            foreach (DataRowView testRow in EventData)
            {
               testDate = (System.DateTime)testRow["EventDate"];
               if (testDate.Date == trialDate.Date)
               {
                  trialDateOK = false;
                  trialDate = trialDate.AddDays(1);
               }
            }
         }
      }
      return trialDate;
   }

   protected void calendar_SelectionChanged(object sender, EventArgs e)
   {
      System.DateTime trialDate = calendar.SelectedDate;
      calendar.SelectedDate = GetFreeDate(trialDate);
   }

   protected void calendar_DayRender(object sender, DayRenderEventArgs e)
   {
      if (EventData.Count > 0)
      {
         System.DateTime testDate;
         foreach (DataRowView testRow in EventData)
         {
            testDate = (System.DateTime)testRow["EventDate"];
            if (testDate.Date == e.Day.Date)
            {
               e.Cell.BackColor = System.Drawing.Color.Red;
            }
         }
      }
   }

   protected void EventList_SelectedIndexChanged(object sender, EventArgs e)
   {
       FormView1.DataSource = EventDetailData;
       EventList.DataSource = EventData;
       EventList.DataBind();
       FormView1.DataBind();
   }

   protected void EventList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
   {
       EventList.SelectedIndex = e.NewSelectedIndex;
   }
}
