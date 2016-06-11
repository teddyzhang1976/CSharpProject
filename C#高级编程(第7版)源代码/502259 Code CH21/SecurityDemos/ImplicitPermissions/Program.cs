using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Permissions;

namespace Wrox.ProCSharp.Security
{
    class Program
    {
        static void Main()
        {
            CodeAccessPermission permissionA =
               new FileIOPermission(FileIOPermissionAccess.AllAccess, @"C:\");
            CodeAccessPermission permissionB =
               new FileIOPermission(FileIOPermissionAccess.Read, @"C:\temp");
            if (permissionB.IsSubsetOf(permissionA))
            {
                Console.WriteLine("PermissionB is a subset of PermissionA");
            }

        }
    }
}
