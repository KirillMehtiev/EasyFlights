using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Engines.RouteBuilding;
using EasyFlights.Services.Common;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.Services.Searching
{
    public class SearchingService : ISearchingService
    {
        private readonly IRouteBuilder routeBuilder;

        public SearchingService(IRouteBuilder routeBuilder)
        {
            this.routeBuilder = routeBuilder;
        }
        
        public async Task<IEnumerable<RouteDto>> FindRoutesBetweenCitiesAsync(int deaprtureCityId, int destinationCityId, int numberOfPassengers, DateTime departureTime, DateTime? returnTime)
        {
            // TODO: move error messages to resources
            Guard.ArgumentValid(deaprtureCityId > 0, "Given parameter has to be greater then 0", nameof(deaprtureCityId));
            Guard.ArgumentValid(destinationCityId > 0, "Given parameter has to be greater then 0", nameof(destinationCityId));
            Guard.ArgumentValid(numberOfPassengers > 0, "Given parameter has to be greater then 0", nameof(numberOfPassengers));

            // fake
            return new List<RouteDto>();
        }
    }
}
