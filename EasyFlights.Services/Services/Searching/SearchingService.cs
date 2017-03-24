using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Cities;
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
        
        public async Task<IEnumerable<RouteDto>> FindRoutesBetweenAirportsAsync(int departureAirportId, int destinationAirportId, int numberOfPassengers, DateTime departureTime, DateTime? returnTime)
        {
            // TODO: move error messages to resources
            Guard.ArgumentValid(departureAirportId > 0, "Given parameter has to be greater then 0", nameof(departureAirportId));
            Guard.ArgumentValid(destinationAirportId > 0, "Given parameter has to be greater then 0", nameof(destinationAirportId));
            Guard.ArgumentValid(numberOfPassengers > 0, "Given parameter has to be greater then 0", nameof(numberOfPassengers));

            Airport departureAirport = await this.citiesRepository.FindByIdAsync(departureAirportId);
            Airport destinationAirport = await this.citiesRepository.FindByIdAsync(destinationAirportId);

            Guard.ArgumentValid(departureAirport != null, "Airport with given id does not exist", nameof(departureAirportId));
            Guard.ArgumentValid(destinationAirport != null, "Airport with given id does not exist", nameof(destinationAirportId));

            IEnumerable<RouteDto> routes = await this.FindRoutesBetweenCitiesAsync(departureAirport, destinationAirport, numberOfPassengers, departureTime);

            // TODO: add a rule for the date validation
            if (returnTime.HasValue)
            {
                IEnumerable<RouteDto> reverseRoutes = await this.FindRoutesBetweenCitiesAsync(destinationAirport, departureAirport, numberOfPassengers, returnTime.Value);
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
                decimal totalCost = route.Flights.Sum(flight => flight.DefaultFare);
                TimeSpan totalTime = new TimeSpan(route.Flights.Sum(flight =>
                {
                    return (flight.ScheduledDepartureTime - flight.ScheduledArrivalTime).Ticks;
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

                       // TODO: figure out what this dto should contain
                       Aircraft = new AircraftDto()
                    }).ToList(),
                TotalCost = totalCost,
                TotalTime = totalTime
            };
        }
    }
}
