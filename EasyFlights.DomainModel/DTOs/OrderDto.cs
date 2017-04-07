using System.Collections.Generic;

namespace EasyFlights.DomainModel.DTOs
{
    public class OrderDto
    {
        public string DepartureCity { get; set; }

        public string DestinationCity { get; set; }

        public decimal Cost { get; set; }

        public string DateOfOrdering { get; set; }

        public string SetOffDate { get; set; }

        public string Duration { get; set; }

        public IEnumerable<TicketDto> Tickets { get; set; }
    }
}
