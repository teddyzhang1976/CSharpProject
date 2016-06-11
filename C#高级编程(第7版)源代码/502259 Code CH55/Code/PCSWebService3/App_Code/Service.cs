using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public AuthenticationToken AuthenticationTokenHeader;

    public Service()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(true)]
    public Guid Login(string userName, string password)
    {
        if ((userName == "Karli") && (password == "Cheese"))
        {
            Guid currentUser = Guid.NewGuid();
            Session["currentUser"] = currentUser;
            return currentUser;
        }
        else
        {
            Session["currentUser"] = null;
            return Guid.Empty;
        }
    }

    [WebMethod(true)]
    [SoapHeaderAttribute("AuthenticationTokenHeader",
                         Direction = SoapHeaderDirection.In)]
    public string DoSomething()
    {
        if (Session["currentUser"] != null &&
            AuthenticationTokenHeader != null &&
            AuthenticationTokenHeader.InnerToken
            == (Guid)Session["currentUser"])
        {
            return "Authentication OK.";
        }
        else
        {
            return "Authentication failed.";
        }
    }
}