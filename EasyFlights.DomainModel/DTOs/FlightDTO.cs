using System;

namespace EasyFlights.DomainModel.DTOs
{
    public class FlightDto
    {
        public DateTime ScheduledDepartureTime { get; set; }

        public DateTime ScheduledArrivalTime { get; set; }

        public string DepartureAirportTitle { get; set; }

        public string DestinationAirportTitle { get; set; }

        public AircraftDto Aircraft { get; set; }
    }
}
