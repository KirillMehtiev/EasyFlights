using System.Data.Entity;
using System;
using EasyFlights.Data.DataContexts;
using EasyFlights.Data.Repositories.Airports;
using EasyFlights.Data.Repositories.Base;
using EasyFlights.Data.Repositories.Cities;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.Entities;
using Ninject.Modules;
using Ninject.Web.Common;
using EasyFlights.Data.Repositories.Orders;
using EasyFlights.DomainModel.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace EasyFlights.Web.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            // Data contexts
            this.Bind<EasyFlightsDataContext>().ToSelf().InRequestScope();
            this.Bind<IDataContext>().To<EasyFlightsDataContext>().InRequestScope();

            //this.Bind<DbContext>().ToMethod(context => (DbContext) context.Kernel.GetService(typeof(IDataContext))).InRequestScope();
           // this.Bind<DbContext>().To<EasyFlightsDataContext>().InRequestScope();

            // Repositories
            this.Bind<IFlightsRepository>().To<FlightsRepository>().InRequestScope();
            this.Bind<ICitiesRepository>().To<CitiesRepository>().InRequestScope();
            this.Bind<IAirportsRepository>().To<AirportsRepository>().InRequestScope();
            this.Bind<IRepository<City>>().To<Repository<City>>().InRequestScope();
            this.Bind<IOrderRepository>().To<OrderRepository>().InRequestScope();
        }

        private object UserManager<T>()
        {
            throw new NotImplementedException();
        }
    }
}