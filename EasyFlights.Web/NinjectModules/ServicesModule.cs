using EasyFlights.Data.Repositories.Base;
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
            this.Bind<IRepository<BaseEntity>>().To<Repository<BaseEntity>>();
         //   this.Bind<ITypeaheadProvider<CityDto>>().To<TypeaheadByCitiesService>();
        }
    }
}