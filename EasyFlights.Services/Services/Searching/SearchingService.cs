using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Airports;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;
using EasyFlights.Services.Common;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.Services.Searching
{
    public class SearchingService : ISearchingService
    {
        private readonly IAirportsRepository citiesRepository;
        private readonly IRouteBuilder routeBuilder;

        public SearchingService(IAirportsRepository citiesRepository, IRouteBuilder routeBuilder)
        {
            this.citiesRepository = citiesRepository;
            this.routeBuilder = routeBuilder;
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
            IEnumerable<RouteDto> routes = await this.FindRoutesBetweenCitiesAsync(departureAirport, destinationAirport, numberOfPassengers, departureTime);
            Guard.OperationValid(routes.Any(), "Impossible to find a route between given cities for the specified time of departure.");

            if (returnTime.HasValue)
            {
                IEnumerable<RouteDto> reverseRoutes = await this.FindRoutesBetweenCitiesAsync(destinationAirport, departureAirport, numberOfPassengers, returnTime.Value);
                Guard.OperationValid(reverseRoutes.Any(), "Impossible to find a route between given cities for the specified time of return.");

                routes = routes.Concat(reverseRoutes);
            }

            return routes.ToList();
        }

        private async Task<IEnumerable<RouteDto>> FindRoutesBetweenCitiesAsync(Airport departureAirport, Airport destinationAirport, int numberOfPassengers, DateTime departureTime)
        {
            IEnumerable<Route> routes = await this.routeBuilder.BuildAsync(departureAirport, destinationAirport, departureTime, numberOfPassengers);

            var result = new List<RouteDto>();
            foreach (Route route in routes)
            {
                if (route.Flights == null || !route.Flights.Any())
                {
                    // route does not contain any flight
                    // so, skip it
                    continue;
                }

                decimal totalCost = route.Flights.Sum(flight => flight.DefaultFare);

                var totalTime = TimeSpan.FromMinutes(route.Flights.Sum(flight =>
                {
                    return (flight.ScheduledArrivalTime - flight.ScheduledDepartureTime).TotalMinutes;
                }));

                result.Add(this.MapRouteToRouteDto(route, totalCost, totalTime));
            }

            return result;
        }

        private RouteDto MapRouteToRouteDto(Route route, decimal totalCost, TimeSpan totalTime)
        {
            return new RouteDto()
            {
                Flights = route.Flights
                    .Select(flight => new FlightDto()
                    {
                       ScheduledDepartureTime = flight.ScheduledDepartureTime,
                       ScheduledArrivalTime = flight.ScheduledArrivalTime,
                       DepartureAirportTitle = flight.DepartureAirport.Title,
                       DestinationAirportTitle = flight.DestinationAirport.Title,
                       Duration = flight.ScheduledDepartureTime - flight.ScheduledArrivalTime,
                       DefaultFare = flight.DefaultFare,
                       Id = flight.Id,

                       // TODO: figure out what this dto should contain
                        Aircraft = new AircraftDto()
                    }).ToList(),
                TotalCost = totalCost,
                TotalTime = totalTime
            };
        }
    }
}
