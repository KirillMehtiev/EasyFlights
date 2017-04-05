using System;
using System.Collections.Generic;

namespace EasyFlights.DomainModel.DTOs
{
    public class TicketsForRouteDto
    {
        public string DepartureAirport { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalAirport { get; set; }

        public string ArrivalCity { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal TotalPrice { get; set; }

        public List<FlightDto> Flights { get; set; }
    }
}
