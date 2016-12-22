using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ReadingACLs
{
    internal class Program
    {
        private static string myFilePath;

        private static void Main()
        {
            Console.Write("Provide full file path: ");
            myFilePath = Console.ReadLine();

            try
            {
                using (FileStream myFile = new FileStream(myFilePath,
                                                          FileMode.Open, FileAccess.Read))
                {
                    FileSecurity fileSec = myFile.GetAccessControl();

                    foreach (FileSystemAccessRule fileRule in 
                        fileSec.GetAccessRules(true, true,
                                               typeof (NTAccount)))
                    {
                        Console.WriteLine("{0} {1} {2} access for {3}", myFilePath,
                                          fileRule.AccessControlType == AccessControlType.Allow
                                          ? "provides" : "denies",
                                          fileRule.FileSystemRights,
                                          fileRule.IdentityReference);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Incorrect file path given!");
            }

            Console.ReadLine();
        }
    }
}