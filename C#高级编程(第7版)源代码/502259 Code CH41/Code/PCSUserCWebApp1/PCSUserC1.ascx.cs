using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PCSUserC1 : System.Web.UI.UserControl
{
    protected Suit currentSuit;

    public Suit Suit
    {
        get
        {
            return currentSuit;
        }
        set
        {
            currentSuit = value;
            suitPic.ImageUrl = "~/Images/" + currentSuit.ToString() + ".bmp";
            suitLabel.Text = currentSuit.ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}