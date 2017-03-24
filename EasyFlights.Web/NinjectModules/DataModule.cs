using EasyFlights.Data.DataContexts;
using EasyFlights.Data.Repositories.Cities;
using EasyFlights.Data.Repositories.Flights;
using Ninject.Modules;
using Ninject.Web.Common;

namespace EasyFlights.Web.NinjectModules
{

    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            // Data contexts
            this.Bind<IDataContext>().To<EasyFlightsDataContext>().InRequestScope();

            // Repositories
            this.Bind<IFlightsRepository>().To<FlightsRepository>().InRequestScope();
            this.Bind<ICitiesRepository>().To<CitiesRepository>();
        }
    }
}