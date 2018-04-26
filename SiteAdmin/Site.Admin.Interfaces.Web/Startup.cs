using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteAdmin.Interfaces.Web.Startup))]
namespace SiteAdmin.Interfaces.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
