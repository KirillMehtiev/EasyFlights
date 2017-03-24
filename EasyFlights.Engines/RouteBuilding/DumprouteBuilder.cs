using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Engines.RouteBuilding
{
    public class DumpRouteBuilder : IRouteBuilder
    {
        public async Task<IEnumerable<Route>> BuildAsync(Airport departure, Airport destination, DateTime departureDate, int numberOfPassengers)
        {
            return this.CreateFakeRoutes(departure, destination, departureDate);
        }

        private IEnumerable<Route> CreateFakeRoutes(Airport departure, Airport destination, DateTime departureDate)
        {
            var transferAiport1 = new Airport()
            {
                Title = "transferAirport1"
            };
            var transferAiport2 = new Airport()
            {
                Title = "transferAirport2"
            };

            return new List<Route>()
            {
                new Route()
                {
                    Flights = new List<Flight>()
                    {
                        new Flight()
                        {
                            ScheduledDepartureTime = departureDate,
                            ScheduledArrivalTime = departureDate.AddHours(8),
                            DefaultFare = 1000,
                            Aircraft = new Aircraft(),
                            DepartureAirport = departure,
                            DestinationAirport = transferAiport1
                        },
                        new Flight()
                        {
                            ScheduledDepartureTime = departureDate.AddHours(9),
                            ScheduledArrivalTime = departureDate.AddHours(12),
                            DefaultFare = 1000,
                            Aircraft = new Aircraft(),
                            DepartureAirport = transferAiport1,
                            DestinationAirport = transferAiport2
                        },
                        new Flight()
                        {
                            ScheduledDepartureTime = departureDate.AddHours(14),
                            ScheduledArrivalTime = departureDate.AddHours(17),
                            DefaultFare = 1000,
                            Aircraft = new Aircraft(),
                            DepartureAirport = transferAiport2,
                            DestinationAirport = destination
                        }
                    }
                },
                new Route()
                {
                    Flights = new List<Flight>()
                    {
                        new Flight()
                        {
                            ScheduledDepartureTime = departureDate,
                            ScheduledArrivalTime = departureDate.AddHours(12),
                            DefaultFare = 1000,
                            Aircraft = new Aircraft(),
                            DepartureAirport = departure,
                            DestinationAirport = transferAiport2
                        },
                        new Flight()
                        {
                            ScheduledDepartureTime = departureDate.AddHours(15),
                            ScheduledArrivalTime = departureDate.AddHours(17),
                            DefaultFare = 1000,
                            Aircraft = new Aircraft(),
                            DepartureAirport = transferAiport2,
                            DestinationAirport = destination
                        }
                    }
                }
            };
        }
    }
}
