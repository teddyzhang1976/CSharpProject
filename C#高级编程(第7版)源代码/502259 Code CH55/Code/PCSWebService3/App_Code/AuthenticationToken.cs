using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for AuthenticationToken
/// </summary>
public class AuthenticationToken : SoapHeader
{
    public Guid InnerToken;
}