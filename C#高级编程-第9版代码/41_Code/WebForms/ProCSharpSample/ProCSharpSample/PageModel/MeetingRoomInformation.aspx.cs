using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProCSharpSample.PageModel
{
  public partial class MeetingRoomInformation : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.PreviousPage != null)
      {
        DropDownList meetingRoomSelection = this.PreviousPage.FindControl(
          "DropDownListMeetingRooms") as DropDownList;
        if (meetingRoomSelection != null)
        {
          this.Label1.Text = meetingRoomSelection.SelectedItem.Value;
        }
      }
    }
  }
}