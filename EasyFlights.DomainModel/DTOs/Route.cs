using System.Collections.Generic;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.DomainModel.DTOs
{
    /// <summary>
    /// Represents a route requested by passenger
    /// </summary>
    public class Route
    {
        public ICollection<Flight> Flights { get; set; }
    }
}
