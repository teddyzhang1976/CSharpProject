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
   private DataView eventData;

   private DataView EventData
   {
      get
      {
         if (eventData == null)
         {
            eventData = MRBEventData.Select(new DataSourceSelectArguments()) as DataView;
         }
         return eventData;
      }
      set
      {
         eventData = value;
      }
   }

   protected void Page_Load(object sender, EventArgs e)
   {
      if (!this.IsPostBack)
      {
         nameBox.Text = Context.User.Identity.Name;
         DateTime trialDate = DateTime.Now;
         calendar.SelectedDate = GetFreeDate(trialDate);
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
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["MRBConnectionString"].ConnectionString);
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("INSERT INTO [Events] (Name, Room, AttendeeList, EventDate) VALUES  (@Name, @Room, @AttendeeList, @EventDate)", conn);
            insertCommand.Parameters.Add("Name", SqlDbType.VarChar, 255).Value = eventBox.Text;
            insertCommand.Parameters.Add("Room", SqlDbType.Int, 4).Value = roomList.SelectedValue;
            insertCommand.Parameters.Add("AttendeeList", SqlDbType.Text, 16).Value = attendees;
            insertCommand.Parameters.Add("EventDate", SqlDbType.DateTime, 8).Value = calendar.SelectedDate;

            conn.Open();
            int queryResult = insertCommand.ExecuteNonQuery();
            conn.Close();
            if (queryResult == 1)
            {
               EventData = null;
               calendar.SelectedDate =
                  GetFreeDate(calendar.SelectedDate.AddDays(1));
               EventList.DataBind();
            }
            else
            {
               throw new System.Data.DataException("Unknown data error.");
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
      EventList.DataBind();
   }
}
