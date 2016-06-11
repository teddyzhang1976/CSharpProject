using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using authenticateService;

public partial class _Default : System.Web.UI.Page
{
    protected Service myService;
    protected bool authenticated;

    protected void Page_Load(object sender, EventArgs e)
    {
        myService = new Service();
        myService.Credentials = CredentialCache.DefaultCredentials;
        CookieContainer serviceCookie;

        if (ViewState["serviceCookie"] == null)
        {
            serviceCookie = new CookieContainer();
        }
        else
        {
            serviceCookie = (CookieContainer)ViewState["serviceCookie"];
        }
        myService.CookieContainer = serviceCookie;

        AuthenticationToken header = new AuthenticationToken();
        if (ViewState["AuthenticationTokenHeader"] != null)
        {
            header.InnerToken = (Guid)ViewState["AuthenticationTokenHeader"];
        }
        else
        {
            header.InnerToken = Guid.Empty;
        }
        myService.AuthenticationTokenValue = header;
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        Guid authenticationTokenHeader = myService.Login(userNameBox.Text,
                                                 passwordBox.Text);
        tokenLabel.Text = authenticationTokenHeader.ToString();
        if (ViewState["AuthenticationTokenHeader"] != null)
        {
            ViewState.Remove("AuthenticationTokenHeader");
        }
        ViewState.Add("AuthenticationTokenHeader", authenticationTokenHeader);
        if (ViewState["serviceCookie"] != null)
        {
            ViewState.Remove("serviceCookie");
        }
        ViewState.Add("serviceCookie", myService.CookieContainer);
    }

    protected void invokeButton_Click(object sender, EventArgs e)
    {
        resultLabel.Text = myService.DoSomething();
        if (ViewState["serviceCookie"] != null)
        {
            ViewState.Remove("serviceCookie");
        }
        ViewState.Add("serviceCookie", myService.CookieContainer);
    }
}