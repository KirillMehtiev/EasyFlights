using System;
using System.Collections.Generic;
using System.Web.Http;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.WebApi.ApiControllers
{
    public class TypeaheadController : ApiController
    {
        private readonly ITypeaheadProvider<City> provider;

        public TypeaheadController(ITypeaheadProvider<City> provider)
        {
            this.provider = provider;
        }

        [System.Web.Http.HttpPost]
        public List<City> GetCitiesForTypeahead(string name)
        {
            try
            {
                return provider.GetTypeahead(name);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}
