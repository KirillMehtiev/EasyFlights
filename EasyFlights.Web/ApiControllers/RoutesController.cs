using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyFlights.Services.Interfaces;
using System.Threading.Tasks;
using EasyFlights.Web.Util;
using EasyFlights.Web.Util.Mappers;
using EasyFlights.Web.Util.Mappers.Interfaces;
using EasyFlights.Web.ViewModels;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Web.ApiControllers
{
    public class RoutesController : ApiController
    {
        private readonly ISearchingService searchingService;

        public RoutesController(ISearchingService searchingService)
        {
            this.searchingService = searchingService;
        }

        // GET api/<controller>
        public async Task<IEnumerable<RouteViewModel>> Get(int departureAirportId, int destinationAirportId, DateTime departureTime)
        {
            DateTime? returnDate = null;
            var numberOfPeople = 1;

            var routes = await searchingService.FindRoutesBetweenAirportsAsync(
                departureAirportId,
                destinationAirportId,
                numberOfPeople,
                departureTime,
                returnDate);

            var result = routes.Select(new RouteMapper().MapToRouteViewModel);

            return result;
        }

        [HttpGet]
        public Country GetCountry()
        {
            return new Country { Id = 4, Name = "Kharkiv" };
        }

        [HttpPost]
        public Country TakeCountry([FromBody] Country country)
        {
            return new Country { Id = 5, Name = "Kharkiv2" };
        }
    }
}