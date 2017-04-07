using System.Collections.Generic;

namespace EasyFlights.DomainModel.DTOs
{
    public class OrderDto
    {
        public string DeparturePlace { get; set; }

        public string DestinationPlace { get; set; }

        public decimal Cost { get; set; }

        public string OrderDate { get; set; }

        public string DepartureDate { get; set; }

        public string Duration { get; set; }

        public IEnumerable<TicketDto> Tickets { get; set; }
    }
}
