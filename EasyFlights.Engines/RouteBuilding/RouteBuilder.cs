using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Engines.RouteBuilding
{
    public class RouteBuilder : IRouteBuilder
    {
        private double minAmountOfHoursToWait = 0.5;
        private double maxAmountOfHoursToWait = 24.0;

        private Stack<Flight> currentRoute;
        private List<Route> allRoutes;

        public RouteBuilder()
        {
        }

        public async Task<IEnumerable<Route>> BuildAsync(Airport departure, Airport destination, DateTime departureDate, int numberOfPassengers)
        {
            this.allRoutes = new List<Route>();

            var startPointFlights = departure.Flights
                                                .Where(flight => this.FligthIsAvailable(flight, departureDate, numberOfPassengers))
                                                .ToList();

            foreach (Flight startPointFlight in startPointFlights)
            {
                this.currentRoute = new Stack<Flight>();
                this.currentRoute.Push(startPointFlight);

                this.FindAllRoutes(startPointFlight, destination, startPointFlight.ScheduledArrivalTime, numberOfPassengers);
            }

            var result  = new List<Route>(this.allRoutes);

            // avoid a lack of memory
            this.allRoutes = null;
            this.currentRoute = null;

            return result;
        }

        private void FindAllRoutes(Flight flight, Airport destination, DateTime departureDate, int numberOfPassengers)
        {
            if (flight.DestinationAirport == destination)
            {
                this.allRoutes.Add(new Route()
                {
                    Flights = new List<Flight>(this.currentRoute.Reverse())
                });
            }
            else
            {
                var visitedAirports = this.currentRoute.Select(f => f.DepartureAirport);

                if (!visitedAirports.Contains(flight.DestinationAirport))
                {
                    var availableFlights = flight.DestinationAirport.Flights
                                                                        .Where(f => this.FligthIsAvailable(f, flight.ScheduledArrivalTime, numberOfPassengers))
                                                                        .ToList();

                    foreach (Flight availableFlight in availableFlights)
                    {
                        this.currentRoute.Push(availableFlight);
                        FindAllRoutes(availableFlight, destination, departureDate, numberOfPassengers);
                        this.currentRoute.Pop();
                    }
                }
            }
        }

        private bool FligthIsAvailable(Flight flight, DateTime departureDate, int numberOfRequestedSeats)
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
