using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;
using EasyFlights.Services.Services.Flight;
using EasyFlights.Services.Services.Searching;
using EasyFlights.Services.Services.Typeahead;
using Ninject.Modules;

namespace EasyFlights.Web.NinjectModules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITypeaheadProvider<City>>().To<TypeaheadService>();
            this.Bind<ISearchingService>().To<SearchingService>();
            this.Bind<IFlightService>().To<FlightService>();
        }
    }
}