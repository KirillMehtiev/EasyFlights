using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace EasyFlights.Web.ViewModels
{
    public class FlightViewModel
    {
        [JsonProperty("departureAirport")]
        public string DepartureAirportTitle { get; set; }

        [JsonProperty("destinationAirport")]
        public string DestinationAirportTitle { get; set; }

        [JsonProperty("departureTime")]
        public string ScheduledDepartureTime { get; set; }

        [JsonProperty("arrivalTime")]
        public string ScheduledArrivalTime { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("fare")]
        public decimal Fare { get; set; }
    }
}