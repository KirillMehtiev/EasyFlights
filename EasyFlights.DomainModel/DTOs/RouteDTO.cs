using System.Collections.Generic;

namespace EasyFlights.DomainModel.DTOs
{
    public class RouteDto
    {
        public ICollection<FlightDto> Flights { get; set; }
    }
}
