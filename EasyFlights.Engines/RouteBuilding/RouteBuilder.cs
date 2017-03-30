using System;
using System.Collections.Concurrent;
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

        private BlockingCollection<Route> allRoutes;

        public async Task<IEnumerable<Route>> BuildAsync(Airport departure, Airport destination, DateTime departureDate, int numberOfPassengers)
        {
            this.allRoutes = new BlockingCollection<Route>();

            List<Flight> startPointFlights = departure.Flights
                                                .Where(flight => this.FligthIsAvailable(flight, departureDate, numberOfPassengers))
                                                .ToList();

            var tasks = new List<Task>();
            foreach (Flight startPointFlight in startPointFlights)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    var currentRoute = new Stack<Flight>();
                    currentRoute.Push(startPointFlight);

                    this.FindAllRoutes(currentRoute, startPointFlight, destination, numberOfPassengers);
                }));
            }
            await Task.WhenAll(tasks);

            var result  = new List<Route>(this.allRoutes);

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
                IEnumerable<Airport> visitedAirports = currentRoute
                                                        .Select(f => f.DepartureAirport)
                                                        .ToList();

                if (!visitedAirports.Contains(flight.DestinationAirport))
                {
                    List<Flight> availableFlights = flight.DestinationAirport.Flights
                                                                        .Where(f => this.FligthIsAvailable(f, flight.ScheduledArrivalTime, numberOfPassengers))
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
