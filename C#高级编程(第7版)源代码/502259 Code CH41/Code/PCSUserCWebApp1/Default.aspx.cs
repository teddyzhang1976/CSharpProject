using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void suitList_SelectedIndexChanged(object sender, EventArgs e)
    {
        myUserControl.Suit = (Suit)Enum.Parse(typeof(Suit),
                                      suitList.SelectedItem.Value);
    }
}