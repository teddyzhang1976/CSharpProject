using System;
using System.IO;
using System.Security;
using System.Threading.Tasks;


[assembly: AllowPartiallyTrustedCallers()]

namespace Wrox.ProCSharp.Security
{
  [SecuritySafeCritical]
  public class RequirePermissionsDemo : MarshalByRefObject
  {
    public bool RequireFilePermissions(string path)
    {
      bool accessAllowed = true;

      try
      {
        StreamWriter writer = File.CreateText(path);
        writer.WriteLine("written successfully");
        writer.Close();
      }
      catch (SecurityException)
      {
        accessAllowed = false;
      }

      return accessAllowed;
    }
  }
}
