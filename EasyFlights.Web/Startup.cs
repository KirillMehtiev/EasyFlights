using System.Web.Http;
using EasyFlights.Web.App_Start;
using EasyFlights.Web.Util;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Newtonsoft.Json.Serialization;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: Microsoft.Owin.OwinStartup(typeof(EasyFlights.Web.Startup))]

namespace EasyFlights.Web
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            config.DependencyResolver = new NinjectDependencyResolver(NinjectWebCommon.CreateKernel());
            //app.UseNinjectMiddleware(NinjectWebCommon.CreateKernel).UseNinjectWebApi(config);
            app.UseWebApi(config);
        }
    }
}
