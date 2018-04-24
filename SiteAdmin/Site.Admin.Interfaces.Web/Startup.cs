using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Site.Admin.Interfaces.Web.Startup))]
namespace Site.Admin.Interfaces.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
