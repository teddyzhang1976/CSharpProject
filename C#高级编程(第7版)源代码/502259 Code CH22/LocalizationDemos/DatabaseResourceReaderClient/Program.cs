using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrox.ProCSharp.Localization;
using System.Globalization;

namespace Wrox.ProCSharp.Localization
{
    class Program
    {
        static void Main()
        {
            var rm = new DatabaseResourceManager(@"server=(local)\sqlexpress;database=LocalizationDemo;trusted_connection=true");

            string spanishWelcome = rm.GetString("Welcome", new CultureInfo("es-ES"));
            string italianThankyou = rm.GetString("ThankYou", new CultureInfo("it"));
            string threadDefaultGoodMorning = rm.GetString("GoodMorning");

        }
    }
}
