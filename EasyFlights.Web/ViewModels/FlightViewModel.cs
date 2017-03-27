using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

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
    }
}