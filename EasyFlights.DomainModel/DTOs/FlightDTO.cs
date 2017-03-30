using System;

namespace EasyFlights.DomainModel.DTOs
{
    public class FlightDto
    {
        public DateTime ScheduledDepartureTime { get; set; }

        public DateTime ScheduledArrivalTime { get; set; }

        public string DepartureAirportTitle { get; set; }

        public string DestinationAirportTitle { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal DefaultFare { get; set; }

        public AircraftDto Aircraft { get; set; }

        public int Id { get; set; }
    }
}
