using System.Collections.Generic;
using System.Linq;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.DomainModel.DTOs
{
    /// <summary>
    /// Represents a route requested by passenger
    /// </summary>
    public class Route
    {
        public Route()
        {
            this.Flights = new List<Flight>();
        }

        public ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            string result = "|";

            foreach (Flight flight in this.Flights.Reverse())
            {
                result += $"{flight.DestinationAirport.Title}({flight.ScheduledDepartureTime})  -->  ";
            }

            result += "|";

            return result;
        }
    }
}
