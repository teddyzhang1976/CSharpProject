using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for MRBService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class MRBService : System.Web.Services.WebService
{
    public MRBService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataSet GetData()
    {
        return (DataSet)Application["ds"];
    }

   [WebMethod]
   public int AddEvent(string eventName, int eventRoom,
                       string eventAttendees, DateTime eventDate)
   {
       System.Data.SqlClient.SqlConnection sqlConnection1;
       System.Data.SqlClient.SqlDataAdapter daEvents;
       DataSet ds;

       using (sqlConnection1 = new System.Data.SqlClient.SqlConnection())
       {
           sqlConnection1.ConnectionString =
              ConfigurationManager.ConnectionStrings["MRBConnectionString"]
                 .ConnectionString;

           System.Data.SqlClient.SqlCommand insertCommand =
              new System.Data.SqlClient.SqlCommand("INSERT INTO [Events] (Name, Room, "
                 + "AttendeeList, EventDate) VALUES  (@Name, @Room, @AttendeeList, "
                 + "@EventDate)", sqlConnection1);
           insertCommand.Parameters.Add("Name", SqlDbType.VarChar, 255).Value
              = eventName;
           insertCommand.Parameters.Add("Room", SqlDbType.Int, 4).Value
              = eventRoom;
           insertCommand.Parameters.Add("AttendeeList", SqlDbType.Text, 16).Value
              = eventAttendees;
           insertCommand.Parameters.Add("EventDate", SqlDbType.DateTime, 8).Value
              = eventDate;

           sqlConnection1.Open();

           int queryResult = insertCommand.ExecuteNonQuery();

           if (queryResult == 1)
           {
               daEvents = new System.Data.SqlClient.SqlDataAdapter(
                              "SELECT * FROM Events", sqlConnection1);
               ds = (DataSet)Application["ds"];
               ds.Tables["Events"].Clear();
               daEvents.Fill(ds, "Events");
               Application.Lock();
               Application["ds"] = ds;
               Application.UnLock();
           }

           return queryResult;
       }
   }
}
