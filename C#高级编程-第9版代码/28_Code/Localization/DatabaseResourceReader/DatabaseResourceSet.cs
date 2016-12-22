using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Resources;

namespace Wrox.ProCSharp.Localization
{
    public class DatabaseResourceSet : ResourceSet
    {
        internal DatabaseResourceSet(string connectionString, CultureInfo culture)
            : base(new DatabaseResourceReader(connectionString, culture))
        {
        }

        public override Type GetDefaultReader()
        {
            return typeof(DatabaseResourceReader);
        }
    }

}
