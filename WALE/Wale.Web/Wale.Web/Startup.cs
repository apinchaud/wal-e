using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wale.Web.Startup))]
namespace Wale.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
