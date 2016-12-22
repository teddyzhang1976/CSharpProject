using System.Drawing;
using System.Resources;

namespace Wrox.ProCSharp.Localization
{
    class Program
    {
        static void Main()
        {
            var rw = new ResXResourceWriter("Demo.resx");
            using (Image image = Image.FromFile("logo.gif"))
            {
                rw.AddResource("WroxLogo", image);
                rw.AddResource("Title", "Professional C#");
                rw.AddResource("Chapter", "Localization");
                rw.AddResource("Author", "Christian Nagel");
                rw.AddResource("Publisher", "Wrox Press");
                rw.Close();
            }

        }
    }
}
