using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace Wrox.ProCSharp.Localization
{
   public class DatabaseResourceManager: ResourceManager
   {
      private string connectionString;
      private Dictionary<string, DatabaseResourceSet> resourceSets;

      public DatabaseResourceManager(string connectionString)
      {
         this.connectionString = connectionString;
         resourceSets = new Dictionary<string, DatabaseResourceSet>();

      }

      protected override ResourceSet InternalGetResourceSet(CultureInfo culture, bool createIfNotExists, bool tryParents)
      {
          DatabaseResourceSet rs = null;
          if (resourceSets.ContainsKey(culture.Name))
          {
              rs = resourceSets[culture.Name];
          }
          else
          {
              rs = new DatabaseResourceSet(connectionString, culture);
              resourceSets.Add(culture.Name, rs);
          }
          return rs;
      }
   }

}
