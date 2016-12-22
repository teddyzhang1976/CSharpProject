using System;
using System.Drawing;
using System.Reflection;
using System.Resources;

namespace Wrox.ProCSharp.Localization
{
    class Program
    {
        static void Main()
        {
            var rm = new ResourceManager("Wrox.ProCSharp.Localization.Demo", Assembly.GetExecutingAssembly());
            Console.WriteLine(rm.GetString("Title"));
            Console.WriteLine(rm.GetString("Chapter"));
            Console.WriteLine(rm.GetString("Author"));
            using (Image logo = (Image)rm.GetObject("WroxLogo"))
            {
                logo.Save("logo.bmp");
            }

            StronglyTypedResources();
        }

        private static void StronglyTypedResources()
        {
            Console.WriteLine(Demo.Title);
            Console.WriteLine(Demo.Chapter);
            Console.WriteLine(Demo.Author);
            using (Bitmap logo = Demo.WroxLogo)
            {
                logo.Save("logo.bmp");
            }
        }
    }
}
