using System;
using System.Security.Principal;
using System.Threading;


namespace Wrox.ProCSharp.Security
{
    class Program
    {
        static void Main()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            WindowsPrincipal principal = (WindowsPrincipal)Thread.CurrentPrincipal;
            WindowsIdentity identity = (WindowsIdentity)principal.Identity;
            Console.WriteLine("IdentityType: " + identity.ToString());
            Console.WriteLine("Name: {0}", identity.Name);
            Console.WriteLine("‘Users’?: {0} ", principal.IsInRole(WindowsBuiltInRole.User));
            Console.WriteLine("‘Administrators’? {0}", principal.IsInRole(WindowsBuiltInRole.Administrator));
            Console.WriteLine("Authenticated: {0}", identity.IsAuthenticated);
            Console.WriteLine("AuthType: {0}", identity.AuthenticationType);
            Console.WriteLine("Anonymous? {0}", identity.IsAnonymous);
            Console.WriteLine("Token: {0}", identity.Token);
        }
    }
}
