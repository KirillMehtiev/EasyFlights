using System.Web;
using EasyFlights.DomainModel.Entities;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Services.Interfaces;
using EasyFlights.Services.Services.Cabinet;
using EasyFlights.Services.Services.Flight;
using EasyFlights.Services.Services.Searching;
using EasyFlights.Services.Services.Typeahead;
using EasyFlights.Web.Infrastructure;
using EasyFlights.Web.Util.Converters;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Ninject.Modules;
using Ninject.Web.Common;

namespace EasyFlights.Web.NinjectModules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            // Identity
            this.Bind<IAuthenticationManager>().ToMethod((context) => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            this.Bind<IApplicationUserManager>().To<ApplicationUserManager>().InRequestScope();
            this.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().InRequestScope();
            this.Bind<IdentityFactoryOptions<ApplicationUserManager>>()
                .ToMethod(x => new IdentityFactoryOptions<ApplicationUserManager>()
                {
                    DataProtectionProvider = Startup.DataProtectionProvider
                });

            // Services
            this.Bind<ITypeaheadProvider<City>>().To<TypeaheadService>();
            this.Bind<ISearchingService>().To<SearchingService>();
            this.Bind<IFlightService>().To<FlightService>();
            this.Bind<IManageOrdersService>().To<ManageOrdersService>();

            // Dto mappers
            this.Bind<IFlightDtoMapper>().To<FlightDtoMapper>();
            this.Bind<IRouteDtoMapper>().To<RouteDtoMapper>();
            this.Bind<IRouteConverter>().To<RouteConverter>();
            this.Bind<ITicketsForRouteMapper>().To<TicketsForRouteMapper>();
        }
    }
}