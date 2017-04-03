using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Airports;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;
using EasyFlights.Services.Common;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.Services.Searching
{
    public class SearchingService : ISearchingService
    {
        private readonly IAirportsRepository citiesRepository;
        private readonly IRouteBuilder routeBuilder;
        private readonly IRouteGeneralInfoCalculator routeGeneralInfoCalculator;

        private readonly IRouteDtoMapper routeDtoMapper;

        public SearchingService(IAirportsRepository citiesRepository, IRouteBuilder routeBuilder, IRouteGeneralInfoCalculator routeGeneralInfoCalculator, IRouteDtoMapper routeDtoMapper)
        {
            this.citiesRepository = citiesRepository;
            this.routeBuilder = routeBuilder;
            this.routeGeneralInfoCalculator = routeGeneralInfoCalculator;

            this.routeDtoMapper = routeDtoMapper;
        }
        
        public async Task<IEnumerable<RouteDto>> FindRoutesBetweenAirportsAsync(int departureAirportId, int destinationAirportId, int numberOfPassengers, DateTime departureTime, DateTime? returnTime = null)
        {
            // Ensure that all params are valid.
            Guard.ArgumentValid(departureAirportId > 0, "Given parameter has to be greater then 0", nameof(departureAirportId));
            Guard.ArgumentValid(destinationAirportId > 0, "Given parameter has to be greater then 0", nameof(destinationAirportId));
            Guard.ArgumentValid(numberOfPassengers > 0, "Given parameter has to be greater then 0", nameof(numberOfPassengers));

            Airport departureAirport = await this.citiesRepository.FindByIdAsync(departureAirportId);
            Airport destinationAirport = await this.citiesRepository.FindByIdAsync(destinationAirportId);

            Guard.ArgumentValid(departureAirport != null, "Airport with given id does not exist", nameof(departureAirportId));
            Guard.ArgumentValid(destinationAirport != null, "Airport with given id does not exist", nameof(destinationAirportId));

            if (returnTime.HasValue)
            {
                Guard.ArgumentValid(returnTime.Value.Date > departureTime.Date, "The return date has to be after the departure date.", nameof(returnTime));
            }

            // Try to build routes.
            List<RouteDto> routes = this.FindRoutesBetweenCitiesAsync(departureAirport, destinationAirport, numberOfPassengers, departureTime).ToList();
            Guard.OperationValid(routes.Any(), "Impossible to find a route between given cities for the specified time of departure.");

            if (returnTime.HasValue)
            {
                IEnumerable<RouteDto> reverseRoutes = this.FindRoutesBetweenCitiesAsync(destinationAirport, departureAirport, numberOfPassengers, returnTime.Value).ToList();
                Guard.OperationValid(reverseRoutes.Any(), "Impossible to find a route between given cities for the specified time of return.");

                routes = routes.Concat(reverseRoutes).ToList();
            }

            return routes.ToList();
        }

        private IEnumerable<RouteDto> FindRoutesBetweenCitiesAsync(Airport departureAirport, Airport destinationAirport, int numberOfPassengers, DateTime departureTime)
        {
            IEnumerable<Route> routes = this.routeBuilder.Build(departureAirport, destinationAirport, departureTime, numberOfPassengers);

            var result = new List<RouteDto>();
            foreach (Route route in routes)
            {
                if (route.Flights == null || !route.Flights.Any())
                {
                    // route does not contain any flight
                    // so, skip it
                    continue;
                }
                decimal totalCost = this.routeGeneralInfoCalculator.GetTotalCost(route);
                TimeSpan totalTime = this.routeGeneralInfoCalculator.GetTotalTime(route);

                result.Add(this.routeDtoMapper.Map(route, totalCost, totalTime));
            }
            return result;
        }
    }
}
