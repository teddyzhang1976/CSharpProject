using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MenuPlanner.Startup))]
namespace MenuPlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
