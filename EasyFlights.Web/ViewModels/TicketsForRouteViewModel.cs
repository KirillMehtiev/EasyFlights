using System;
using System.Collections.Generic;

namespace EasyFlights.Web.ViewModels
{
    public class TicketsForRouteViewModel
    {
        public string DepartureAirport { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalAirport { get; set; }

        public string ArrivalCity { get; set; }

        public string Duration { get; set; }

        public decimal TotalPrice { get; set; }

        public List<FlightViewModel> Flights { get; set; }
    }
}