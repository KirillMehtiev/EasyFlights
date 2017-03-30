using System;
using System.Collections.Generic;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Engines.Tests.RouteBuilding
{
    public partial class RouteBuilderTests
    {
        private int currentAirportId = 1;
        private int currentFlightId = 1;

        private List<Airport> CreateFakeGraph()
        {
            DateTime time = DateTime.Today;

            Airport a = this.CreateAiport("A");
            Airport b = this.CreateAiport("B");
            Airport c = this.CreateAiport("C");
            Airport d = this.CreateAiport("D");
            Airport e = this.CreateAiport("E");
            Airport f = this.CreateAiport("F");

            a.Flights.Add(this.ConnectToAirports(a, b, time.AddHours(0.5)));
            a.Flights.Add(this.ConnectToAirports(a, c, time.AddHours(1)));

            b.Flights.Add(this.ConnectToAirports(b, a, time.AddHours(12)));
            b.Flights.Add(this.ConnectToAirports(b, e, time.AddHours(4)));

            c.Flights.Add(this.ConnectToAirports(c, d, time.AddHours(3.5)));
            c.Flights.Add(this.ConnectToAirports(c, e, time.AddHours(2.5)));

            d.Flights.Add(this.ConnectToAirports(d, c, time.AddHours(5)));
            d.Flights.Add(this.ConnectToAirports(d, a, time.AddHours(4)));

            e.Flights.Add(this.ConnectToAirports(e, d, time.AddHours(11)));
            e.Flights.Add(this.ConnectToAirports(e, f, time.AddHours(6)));

            f.Flights.Add(this.ConnectToAirports(f, d, time.AddHours(8)));

            return new List<Airport>() { a, b, c, d, e, f };
        }

        private Airport CreateAiport(string title)
        {
            return new Airport()
            {
                Id = this.currentAirportId++,
                Title = title,
                Flights = new List<Flight>()
            };
        }

        private Flight ConnectToAirports(Airport departure, Airport destination, DateTime departureTime)
        {
            return new Flight()
            {
                Id = currentFlightId++,
                DepartureAirport = departure,
                DestinationAirport = destination,
                ScheduledDepartureTime = departureTime,
                ScheduledArrivalTime = departureTime.AddHours(0.8),
                Tickets = new List<Ticket>(),
                Aircraft = new Aircraft()
                {
                    Capacity = 100
                }
            };
        }
    }
}
