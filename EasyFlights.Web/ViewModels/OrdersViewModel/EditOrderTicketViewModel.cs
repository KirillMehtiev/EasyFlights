using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyFlights.Web.ViewModels.OrdersViewModel
{
    public class EditOrderTicketViewModel
    {
        public string DepartureAirport { get; set; }

        public string DestinationAirport { get; set; }

        public int Seat { get; set; }

        public string Duration { get; set; }

        public decimal Fare { get; set; }

        public string DepartureTime { get; set; }

        public int FlightId { get; set; }
    }
}