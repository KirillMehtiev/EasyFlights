using EasyFlights.Engines.Infrastructure;
using EasyFlights.Engines.RouteBuilding;
using Ninject.Modules;
using Ninject.Web.Common;

namespace EasyFlights.Web.NinjectModules
{
    public class EnginesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRouteBuilder>().To<RouteBuilder>().InRequestScope();
            this.Bind<IRouteGeneralInfoCalculator>().To<RouteGeneralInfoCalculator>().InRequestScope();

            this.Bind<IAppSettings>().To<AppSettings>().InRequestScope();
        }
    }
}