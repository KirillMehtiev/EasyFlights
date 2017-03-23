using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;
using EasyFlights.Services.Services.Typeahead;
using EasyFlights.Services.Services.FlightProvider;
using Ninject.Modules;

namespace EasyFlights.Web.NinjectModules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITypeaheadProvider<City>>().To<TypeaheadByCitiesService>();
            this.Bind<IFlightProvider>().To<FlightProvider>();
        }
    }
}