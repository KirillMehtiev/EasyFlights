using EasyFlights.Engines;
using Ninject.Modules;

namespace EasyFlights.Web.NinjectModules
{
    public class EnginesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRouteBuilder>().To<RouteBuilder>();
        }
    }
}