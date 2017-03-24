using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Web.ApiControllers
{
    using System.Threading.Tasks;
    using EasyFlights.Web.Util;

    public class RoutesController : ApiController
    {
        private readonly ISearchingService searchingService;

        public RoutesController(ISearchingService searchingService)
        {
            this.searchingService = searchingService;
        }

        // GET api/<controller>
        public async Task<IEnumerable<string>> Get(int departureAirportId, int destinationAirportId, DateTime departureTime)
        {
            DateTime? returnDate = null;
            var numberOfPeople = 1;
            
            var routes = await this.searchingService.FindRoutesBetweenAirportsAsync(
                departureAirportId,
                destinationAirportId,
                numberOfPeople,
                departureTime,
                returnDate);

            var result = routes.Select(Mapper.MapToRouteViewModel);

            return null;
        }

    }
}