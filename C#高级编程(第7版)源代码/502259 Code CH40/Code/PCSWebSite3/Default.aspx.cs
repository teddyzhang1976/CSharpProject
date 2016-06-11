using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      if (!this.IsPostBack)
      {
         DateTime trialDate = DateTime.Now;
         calendar.SelectedDate = GetFreeDate(trialDate);
      }
   }

   protected void submitButton_Click(object sender, EventArgs e)
   {
      if (this.IsValid)
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
            System.Data.SqlClient.SqlConnection conn =
               new System.Data.SqlClient.SqlConnection(
                  ConfigurationManager.ConnectionStrings[
                  "MRBConnectionString"].ConnectionString);
            System.Data.SqlClient.SqlCommand insertCommand =
               new System.Data.SqlClient.SqlCommand("INSERT INTO [Events] "
                  + "(Name, Room, AttendeeList, EventDate) VALUES (@Name, "
                  + "@Room, @AttendeeList, @EventDate)", conn);
            insertCommand.Parameters.Add(
               "Name", SqlDbType.VarChar, 255).Value = eventBox.Text;
            insertCommand.Parameters.Add(
               "Room", SqlDbType.Int, 4).Value = roomList.SelectedValue;
            insertCommand.Parameters.Add(
               "AttendeeList", SqlDbType.Text, 16).Value = attendees;
            insertCommand.Parameters.Add(
               "EventDate", SqlDbType.DateTime, 8).Value =
               calendar.SelectedDate;

            conn.Open();
            int queryResult = insertCommand.ExecuteNonQuery();
            conn.Close();

            if (queryResult == 1)
            {
               resultLabel.Text = "Event Added.";
               EventData = null;
               calendar.SelectedDate =
                  GetFreeDate(calendar.SelectedDate.AddDays(1));
               GridView1.DataBind();
               EventList.DataBind();
            }
            else
            {
               throw new System.Data.DataException("Unknown data error.");
            }
         }
         catch
         {
            resultLabel.Text = "Event not added due to DB access "
                                   + "problem.";
         }
      }
   }

   private DataView eventData;
   private DataView EventData
   {
      get
      {
         if (eventData == null)
         {
            eventData =
              MRBEventData.Select(new DataSourceSelectArguments())
              as DataView;
         }
         return eventData;
      }
      set
      {
         eventData = value;
      }
   }

   private DateTime GetFreeDate(DateTime trialDate)
   {
      if (EventData.Count > 0)
      {
         DateTime testDate;
         bool trialDateOK = false;
         while (!trialDateOK)
         {
            trialDateOK = true;
            foreach (DataRowView testRow in EventData)
            {
               testDate = (DateTime)testRow["EventDate"];
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
      DateTime trialDate = calendar.SelectedDate;
      calendar.SelectedDate = GetFreeDate(trialDate);
   }

   protected void calendar_DayRender(object sender, DayRenderEventArgs e)
   {
      if (EventData.Count > 0)
      {
         DateTime testDate;
         foreach (DataRowView testRow in EventData)
         {
            testDate = (DateTime)testRow["EventDate"];
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