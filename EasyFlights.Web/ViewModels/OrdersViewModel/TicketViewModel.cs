using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyFlights.Web.ViewModels.OrdersViewModels
{
    public class TicketViewModel
    {
        public string FirstName { get; set; }

        public string LasName { get; set; }

        public string DepartureAirport { get; set; }

        public string DestinationAirport { get; set; }

        public string Dduration { get; set; }

        public string Fare { get; set; }

        public string DepartureTime { get; set; }

        public string Seat { get; set; }
    }
}