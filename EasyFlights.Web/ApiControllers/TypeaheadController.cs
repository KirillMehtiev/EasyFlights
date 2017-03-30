using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;
using EasyFlights.Web.ViewModels;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Typeahead")]
    public class TypeaheadController : ApiController
    {
        private readonly ITypeaheadProvider<City> provider;

        public TypeaheadController(ITypeaheadProvider<City> provider)
        {
            this.provider = provider;
        }

        [HttpGet]
        [Route("airports")]
        public async Task<List<TypeaheadViewModel>> GetAirportsForTypeaheadAsync(string name)
        {
            var airports = new List<TypeaheadViewModel>();
            List<City> cities = await provider.GetTypeaheadAsync(name);
            if (cities == null || cities.Count == 0)
            {
                return new List<TypeaheadViewModel>();
            }
            foreach (City city in cities)
            {
                foreach (Airport airport in city.Airports)
                {
                    airports.Add(new TypeaheadViewModel
                    {
                        Id = airport.Id,
                        Label = $"{airport.City?.Country?.Name}, {airport.City?.Name}, {airport.Title}",
                        Value = airport.Title
                    });
                }
            }
            return airports;
        }
    }
}
