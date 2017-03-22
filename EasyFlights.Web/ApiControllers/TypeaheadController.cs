using System.Collections.Generic;
using System.Web.Http;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.WebApi.ApiControllers
{
    public class TypeaheadController : ApiController
    {
        private readonly ITypeaheadProvider<CityDto> provider;

        public TypeaheadController(ITypeaheadProvider<CityDto> provider)
        {
            this.provider = provider;
        }

        [HttpPost]
        public List<CityDto> GetCitiesForTypeahead(string name)
        {
            return provider.GetTypeahead(name);
        }
    }
}
