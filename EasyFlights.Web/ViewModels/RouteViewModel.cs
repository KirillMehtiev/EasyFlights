using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace EasyFlights.Web.ViewModels
{
    public class RouteViewModel
    {
        public string DeparturePlace { get; set; }

        public string DestinationPlace { get; set; }

        public string ArrivalTime { get; set; }

        public string DepartureTime { get; set; }

        public IEnumerable<FlightViewModel> Flights { get; set; }

        public decimal TotalCoast { get; set; }

        public string TotalTime { get; set; }

        public string Id { get; set; }
    }
}