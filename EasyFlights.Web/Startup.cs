using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EasyFlights.WebApi.Startup))]

namespace EasyFlights.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
