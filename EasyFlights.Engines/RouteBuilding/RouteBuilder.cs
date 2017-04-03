using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Engines.RouteBuilding
{
    public class RouteBuilder : IRouteBuilder
    {
        private readonly double minAmountOfHoursToWait;
        private readonly double maxAmountOfHoursToWait;

        private List<Route> allRoutes;

        public RouteBuilder()
        {
            // this.minAmountOfHoursToWait = Convert.ToDouble(ConfigurationManager.AppSettings["minAmountOfHoursToWaitFlight"]);
            // this.maxAmountOfHoursToWait = Convert.ToDouble(ConfigurationManager.AppSettings["maxAmountOfHoursToWaitFlight"]);
            this.minAmountOfHoursToWait = 0.5;
            this.maxAmountOfHoursToWait = 24;
        }

        public async Task<IEnumerable<Route>> BuildAsync(Airport departure, Airport destination, DateTime departureDate, int numberOfPassengers)
        {
            this.allRoutes = new List<Route>();

            List<Flight> startPointFlights = departure.Flights
                                                .Where(flight => this.FlightIsAvailable(flight, departureDate, numberOfPassengers))
                                                .ToList();

            foreach (Flight startPointFlight in startPointFlights)
            {
                var currentRoute = new Stack<Flight>();
                currentRoute.Push(startPointFlight);

                this.FindAllRoutes(currentRoute, startPointFlight, destination, numberOfPassengers);
            }

            var result = new List<Route>(this.allRoutes);

            // avoid a lack of memory
            this.allRoutes = null;

            return result;
        }

        private void FindAllRoutes(Stack<Flight> currentRoute, Flight flight, Airport destination, int numberOfPassengers)
        {
            if (flight.DestinationAirport == destination)
            {
                this.allRoutes.Add(new Route()
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
                        FindAllRoutes(currentRoute, availableFlight, destination, numberOfPassengers);
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
