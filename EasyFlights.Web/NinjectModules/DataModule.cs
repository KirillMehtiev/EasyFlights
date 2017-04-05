using EasyFlights.Data.DataContexts;
using EasyFlights.Data.Repositories.Airports;
using EasyFlights.Data.Repositories.Base;
using EasyFlights.Data.Repositories.Cities;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.Entities;
using EasyFlights.DomainModel.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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


            this.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();  
                     
            // Repositories
            this.Bind<IFlightsRepository>().To<FlightsRepository>().InRequestScope();
            this.Bind<ICitiesRepository>().To<CitiesRepository>().InRequestScope();
            this.Bind<IAirportsRepository>().To<AirportsRepository>().InRequestScope();
            this.Bind<IRepository<City>>().To<Repository<City>>().InRequestScope();
        }
    }
}