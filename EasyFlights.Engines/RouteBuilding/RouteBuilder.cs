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

        public async Task<IEnumerable<Route>> BuildAsync(Airport departure, Airport destination, DateTime departureDate, int numberOfPassengers)
        {
            var currentDepartureDate = departureDate;

            var allRoutes = new List<Route>();

            var visitedAiports = new List<Airport>();
            var currentPath = new Queue<Airport>();

            var currentRoute = new List<Flight>();

            visitedAiports.Add(departure);
            currentPath.Enqueue(departure);

            while (currentPath.Any())
            {
                var currentAiport = currentPath.Dequeue();

                if (currentAiport == destination)
                {
                    // save path
                    allRoutes.Add(new Route()
                    {
                        Flights = new List<Flight>(currentRoute)
                    });

                    currentRoute.RemoveAt(currentRoute.Count - 1);
                }
                else
                {
                    var airportsConnectedToCurrent = currentAiport.Flights
                                                                    .Where(flight => this.FligthIsAvailable(flight, currentDepartureDate, numberOfPassengers))
                                                                    .Select(flight =>
                                                                        new
                                                                        {
                                                                            flight = flight,
                                                                            airport = flight.DestinationAirport
                                                                        });

                    foreach (var pair in airportsConnectedToCurrent)
                    {
                        if (!visitedAiports.Contains(pair.airport))
                        {
                            visitedAiports.Add(pair.airport);
                            currentPath.Enqueue(pair.airport);

                            currentRoute.Add(pair.flight);

                            currentDepartureDate = pair.flight.ScheduledArrivalTime;
                        }
                    }
                }
            }

            return allRoutes;
        }


        private bool FligthIsAvailable(Flight flight, DateTime departureDate, int numberOfRequestedSeats)
        {
            var delay = TimeSpan.FromHours(15);

            return
                flight.ScheduledDepartureTime.Subtract(departureDate) <= delay &&
                flight.Aircraft.Capacity - flight.Tickets.Count >= numberOfRequestedSeats;
        }
    }
}
