using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Wrox.ProCSharp.Security
{
  class Program
  {
    static void Main(string[] args)
    {
      string filename = null;
      if (args.Length == 0)
        return;

      filename = args[0];

      using (FileStream stream = File.Open(filename, FileMode.Open))
      {
        FileSecurity securityDescriptor = stream.GetAccessControl();
        AuthorizationRuleCollection rules =
              securityDescriptor.GetAccessRules(true, true, typeof(NTAccount));

        foreach (AuthorizationRule rule in rules)
        {
          var fileRule = rule as FileSystemAccessRule;
          Console.WriteLine("Access type: {0}", fileRule.AccessControlType);
          Console.WriteLine("Rights: {0}", fileRule.FileSystemRights);
          Console.WriteLine("Identity: {0}",
                fileRule.IdentityReference.Value);
          Console.WriteLine();
        }
      }
    }
  }
}
