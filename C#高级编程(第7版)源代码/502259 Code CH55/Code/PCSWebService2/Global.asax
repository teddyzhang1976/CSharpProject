<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        System.Data.DataSet ds;
        System.Data.SqlClient.SqlConnection sqlConnection1;
        System.Data.SqlClient.SqlDataAdapter daAttendees;
        System.Data.SqlClient.SqlDataAdapter daRooms;
        System.Data.SqlClient.SqlDataAdapter daEvents;

        using (sqlConnection1 = new System.Data.SqlClient.SqlConnection())
        {
            sqlConnection1.ConnectionString =
              ConfigurationManager.ConnectionStrings["MRBConnectionString"]
                .ConnectionString;

            sqlConnection1.Open();

            ds = new System.Data.DataSet();
            daAttendees = new System.Data.SqlClient.SqlDataAdapter(
                              "SELECT * FROM Attendees", sqlConnection1);
            daRooms = new System.Data.SqlClient.SqlDataAdapter(
                              "SELECT * FROM Rooms", sqlConnection1);
            daEvents = new System.Data.SqlClient.SqlDataAdapter(
                              "SELECT * FROM Events", sqlConnection1);

            daAttendees.Fill(ds, "Attendees");
            daRooms.Fill(ds, "Rooms");
            daEvents.Fill(ds, "Events");
        }

        Application["ds"] = ds;
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
