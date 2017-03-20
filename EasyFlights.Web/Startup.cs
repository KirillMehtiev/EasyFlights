using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EasyFlights.Web.Startup))]

namespace EasyFlights.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
