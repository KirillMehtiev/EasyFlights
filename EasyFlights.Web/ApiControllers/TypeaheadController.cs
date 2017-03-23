using System.Collections.Generic;
using System.Web.Http;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;
using EasyFlights.WebApi.ViewModels;

namespace EasyFlights.WebApi.ApiControllers
{
    public class TypeaheadController : ApiController
    {
        private readonly ITypeaheadProvider<City> provider;

        public TypeaheadController(ITypeaheadProvider<City> provider)
        {
            this.provider = provider;
        }

        [HttpPost]
        public List<CityViewModel> GetCitiesForTypeahead(string name)
        {
            var cities = new List<CityViewModel>();
            provider.GetTypeahead(name)
                .ForEach(x => cities.Add(new CityViewModel() { Id = x.Id, Name = x?.Name, Country = x?.Country?.Name}));
            return cities;
        }
    }
}
