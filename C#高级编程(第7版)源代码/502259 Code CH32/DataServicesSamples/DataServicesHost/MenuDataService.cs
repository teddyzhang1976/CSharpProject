using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;

namespace Wrox.ProCSharp.DataServices
{
    public class MenuDataService : DataService<MenuCardDataModel>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Menus", EntitySetRights.All);
            config.SetEntitySetAccessRule("Categories", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);

            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;       
        }

        [WebGet(UriTemplate="GetMenusByName?name={name}", BodyStyle=WebMessageBodyStyle.Bare)]
        public IQueryable<Menu> GetMenusByName(string name)
        {
            return (from m in CurrentDataSource.Menus
                    where m.Name.StartsWith(name)
                    select m).AsQueryable();
        }
    }
}
