using System;
using System.Windows.Forms;

namespace Wrox.ProCSharp.Localization
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string culture = String.Empty;
            if (args.Length == 1)
            {
                culture = args[0];
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BookOfTheDayForm(culture));
        }
    }
}
