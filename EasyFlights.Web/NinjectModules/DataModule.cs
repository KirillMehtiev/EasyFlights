using EasyFlights.Data.Repositories.Base;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;
using EasyFlights.Services.Services;

namespace EasyFlights.Web.NinjectModules
{
    using Data.DataContexts;
    using Ninject.Modules;
    using Ninject.Web.Common;

    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            // Data contexts
            this.Bind<IDataContext>().To<EasyFlightsDataContext>().InRequestScope();

            // Repositories
            this.Bind<IRepository<BaseEntity>>().To<Repository<BaseEntity>>();


            // Services
        }
    }
}