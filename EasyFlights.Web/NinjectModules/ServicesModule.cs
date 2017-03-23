using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;
using EasyFlights.Services.Services.Typeahead;

namespace EasyFlights.Web.NinjectModules
{
    using Ninject.Modules;

    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITypeaheadProvider<City>>().To<TypeaheadService>();
        }
    }
}