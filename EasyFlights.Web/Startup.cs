[assembly: Microsoft.Owin.OwinStartup(typeof(EasyFlights.Web.Startup))]

namespace EasyFlights.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
