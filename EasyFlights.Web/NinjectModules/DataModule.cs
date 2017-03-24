using EasyFlights.Data.Repositories.Base;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;
using EasyFlights.Services.Services;

namespace EasyFlights.Web.NinjectModules
{
    using Data.DataContexts;

    using EasyFlights.Data.Repositories.Flights;

    using Ninject.Modules;
    using Ninject.Web.Common;

    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            // Data contexts
            this.Bind<IDataContext>().To<EasyFlightsDataContext>().InRequestScope();

            // Repositories
            this.Bind<IFlightsRepository>().To<FlightsRepository>().InRequestScope();
            this.Bind<IRepository<BaseEntity>>().To<Repository<BaseEntity>>();
        }
    }
}