using System;
using System.Collections.Generic;
using System.Linq;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.Infrastructure;

namespace EasyFlights.Engines.RouteBuilding
{
    public class RouteBuilder : IRouteBuilder
    {
        private readonly double minAmountOfHoursToWait;
        private readonly double maxAmountOfHoursToWait;

        public RouteBuilder(IAppSettings appSettings)
        {
            this.minAmountOfHoursToWait = appSettings.MinAmountOfHoursToWaitFlight;
            this.maxAmountOfHoursToWait = appSettings.MaxAmountOfHoursToWaitFlight;
        }

        public IEnumerable<Route> Build(Airport departure, Airport destination, DateTime departureDate, int numberOfPassengers)
        {
            var allRoutes = new List<Route>();

            List<Flight> startPointFlights = departure.Flights
                                                .Where(flight => this.FlightIsAvailable(flight, departureDate, numberOfPassengers))
                                                .ToList();

            foreach (Flight startPointFlight in startPointFlights)
            {
                var currentRoute = new Stack<Flight>();
                currentRoute.Push(startPointFlight);

                this.FindAllRoutes(allRoutes, currentRoute, startPointFlight, destination, numberOfPassengers);
            }

            return allRoutes;
        }

        private void FindAllRoutes(List<Route> allRoutes, Stack<Flight> currentRoute, Flight flight, Airport destination, int numberOfPassengers)
        {
            if (flight.DestinationAirport == destination)
            {
                allRoutes.Add(new Route()
                {
                    Flights = new List<Flight>(currentRoute.Reverse())
                });
            }
            else
            {
                IEnumerable<Airport> visitedAirports = currentRoute.Select(f => f.DepartureAirport);

                if (!visitedAirports.Contains(flight.DestinationAirport))
                {
                    List<Flight> availableFlights = flight.DestinationAirport.Flights
                                                                        .Where(f => this.FlightIsAvailable(f, flight.ScheduledArrivalTime, numberOfPassengers))
                                                                        .ToList();

                    foreach (Flight availableFlight in availableFlights)
                    {
                        currentRoute.Push(availableFlight);
                        FindAllRoutes(allRoutes, currentRoute, availableFlight, destination, numberOfPassengers);
                        currentRoute.Pop();
                    }
                }
            }
        }

        private bool FlightIsAvailable(Flight flight, DateTime departureDate, int numberOfRequestedSeats)
        {
            TimeSpan maxDelay = TimeSpan.FromHours(this.maxAmountOfHoursToWait);
            TimeSpan minDelay = TimeSpan.FromHours(this.minAmountOfHoursToWait);

            TimeSpan timeDifference = flight.ScheduledDepartureTime.Subtract(departureDate);

            return
                timeDifference >= minDelay &&
                timeDifference <= maxDelay &&
                flight.Aircraft.Capacity - flight.Tickets.Count >= numberOfRequestedSeats;
        }
    }
}
