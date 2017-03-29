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
        public RouteBuilder()
        {
        }

        class flight
        {
            public Flight actual;
            public Flight parent;
        }

        public async Task<IEnumerable<Route>> BuildAsync(Airport departure, Airport destination, DateTime departureDate, int numberOfPassengers)
        {
            var allPossibleRoutes = new List<Route>();

            var queue = new Queue<flight>();
            var usedFligths = new List<Flight>();

            var currentDepartureDate = departureDate;

            var firstFlights = departure.Flights.Where(flight => this.FligthIsAvailable(flight, currentDepartureDate, numberOfPassengers));

            foreach (Flight flight in firstFlights)
            {
                queue.Enqueue(new flight()
                {
                    actual = flight
                });
                usedFligths.Add(flight);
            }

            flight res = null;
            var all = new List<flight>();

            while (queue.Any())
            {
                var currentFlight = queue.Dequeue();

                all.Add(currentFlight);

                if (currentFlight.actual.DestinationAirport == destination)
                {
                    //save
                    res = currentFlight;

                    allPossibleRoutes.Add(this.MakeRoute(currentFlight, all));
                }
                else
                {
                    var availableFlights = currentFlight.actual.DestinationAirport.Flights.Where(flight => this.FligthIsAvailable(flight, currentDepartureDate, numberOfPassengers)).ToList();

                    foreach (Flight availableFlight in availableFlights)
                    {
                        if (!usedFligths.Contains(availableFlight))
                        {
                            usedFligths.Add(availableFlight);

                            queue.Enqueue(new flight()
                            {
                                actual = availableFlight,
                                parent = currentFlight.actual
                            });

                            currentDepartureDate = availableFlight.ScheduledArrivalTime;
                        }
                    }
                }
            }

            var routes = allPossibleRoutes.Select(route => route.ToString()).ToArray();

            return allPossibleRoutes;
        }

        private bool FligthIsAvailable(Flight flight, DateTime departureDate, int numberOfRequestedSeats)
        {
            TimeSpan maxDelay = TimeSpan.FromHours(15);
            TimeSpan minDelay = TimeSpan.FromHours(1);

            TimeSpan timeDifference = flight.ScheduledDepartureTime.Subtract(departureDate);

            return
                timeDifference.TotalMinutes > 0 &&
                timeDifference >= minDelay &&
                timeDifference <= maxDelay &&
                flight.Aircraft.Capacity - flight.Tickets.Count >= numberOfRequestedSeats;
        }

        private Route MakeRoute(flight f, List<flight> all)
        {
            var route = new Route();
            route.Flights.Add(f.actual);

            while (f.parent != null)
            {
                route.Flights.Add(f.parent);

                f = all.FirstOrDefault(h => h.actual == f.parent);
            }

            return route;
        }
    }
}
