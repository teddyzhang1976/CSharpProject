using System;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Permissions;

namespace Wrox.ProCSharp.Security
{
  class Program
  {
    static void Main()
    {
      PermissionSet permSet = new PermissionSet(PermissionState.None);
      permSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
      // permSet.AddPermission(new FileIOPermission(FileIOPermissionAccess.AllAccess, "c:/temp"));

      AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;

      AppDomain newDomain = AppDomain.CreateDomain(
          "Sandboxed domain", AppDomain.CurrentDomain.Evidence, setup, permSet);
      ObjectHandle oh = newDomain.CreateInstance("RequireFileIOPermissionsDemo", "Wrox.ProCSharp.Security.RequirePermissionsDemo");
      object o = oh.Unwrap();
      var io = o as RequirePermissionsDemo;
      string path = @"c:\temp\file.txt";
      Console.WriteLine("has {0}permissions to write to {1}", io.RequireFilePermissions(path) ? null : "no ", path);
    }
  }
}
