using System;
using System.Security;
using System.Security.Principal;
using System.Security.Permissions;

namespace RoleBasedSecurity
{
  class Program
  {
    static void Main()
    {
      AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
      try
      {
        ShowMessage();
      }
      catch (SecurityException exception)
      {
        Console.WriteLine("Security exception caught ({0})", exception.Message);
        Console.WriteLine("The current principal must be in the local"
                          + "Users group");
      }
    }


    [PrincipalPermission(SecurityAction.Demand, Role = "BUILTIN\\Users")]
    static void ShowMessage()
    {
      Console.WriteLine("The current principal is logged in locally ");
      Console.WriteLine("(member of the local Users group)");
    }
  }
}

