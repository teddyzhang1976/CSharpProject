using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace Wrox.ProCSharp.Interop
{
  [SecurityCritical]
  internal static class NativeMethods
  {
    [DllImport("kernel32.dll", SetLastError = true,
       EntryPoint = "CreateHardLinkW", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool CreateHardLink(
          [In, MarshalAs(UnmanagedType.LPWStr)] string newFileName,
          [In, MarshalAs(UnmanagedType.LPWStr)] string existingFileName,
          IntPtr securityAttributes);


    internal static void CreateHardLink(string oldFileName,
                                        string newFileName)
    {
      if (!CreateHardLink(newFileName, oldFileName, IntPtr.Zero))
      {
        var ex = new Win32Exception(Marshal.GetLastWin32Error());
        throw new IOException(ex.Message, ex);
      }
    }
  }

  public static class FileUtility
  {
    [FileIOPermission(SecurityAction.LinkDemand, Unrestricted = true)]
    public static void CreateHardLink(string oldFileName,
                                      string newFileName)
    {
      NativeMethods.CreateHardLink(oldFileName, newFileName);
    }
  }
}

