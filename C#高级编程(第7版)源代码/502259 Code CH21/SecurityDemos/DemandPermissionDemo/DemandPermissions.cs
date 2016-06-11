using System;
using System.Security;
using System.Security.Permissions;
using System.IO;

[assembly: AllowPartiallyTrustedCallers()]


namespace Wrox.ProCSharp.Security
{
    [SecuritySafeCritical]
    public class DemandPermissions
    {
        public void DemandFileIOPermissions(string path)
        {
            var fileIOPermission = new FileIOPermission(PermissionState.Unrestricted);
            fileIOPermission.Demand();

            //...
        }
    }
}
