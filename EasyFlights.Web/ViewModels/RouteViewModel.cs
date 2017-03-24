using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace EasyFlights.Web.ViewModels
{
    public class RouteViewModel
    {
        [JsonProperty("departurePlace")]
        public string DeparturePlace { get; set; }

        [JsonProperty("destinationPlace")]
        public string DestinationPlace { get; set; }

        [JsonProperty("arrivalPlace")]
        public string ArrivalPlace { get; set; }

        [JsonProperty("departureDate")]
        public string DepartureDate { get; set; }

        [JsonProperty("flights")]
        public IEnumerable<FlightViewModel> Flights { get; set; }

        [JsonProperty("totalCoast")]
        public decimal TotalCoast { get; set; }

        [JsonProperty("totalTime")]
        public string TotalTime { get; set; }
    }
}