using System.Collections.Generic;

namespace EasyFlights.Web.ViewModels
{
    public class FlightViewModel
    {
        public string DepartureAirport { get; set; }

        public string DestinationAirport { get; set; }

        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }

        public string Duration { get; set; }

        public decimal Fare { get; set; }

        public List<TicketVIewModel> Tickets { get; set; }
    }
}