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
        public List<AirportViewModel> GetAirportsForTypeahead(string name)
        {
            var airports = new List<AirportViewModel>();
            List<City> cities = provider.GetTypeahead(name);
            if (cities == null || cities.Count == 0)
            {
                return new List<AirportViewModel>();
            }
            foreach (City city in cities)
            {
                foreach (Airport airport in city.Airports)
                {
                    airports.Add(new AirportViewModel()
                    {
                        Id = airport.Id,
                        City = airport.City?.Name,
                        Country = airport.City?.Country?.Name,
                        Name = airport.Title
                    });
                }
            }
            return airports;
        }
    }
}
