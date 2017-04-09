using EasyFlights.DomainModel.Entities.Enums;

namespace EasyFlights.DomainModel.DTOs
{
    public class TicketDto
    {
        public PassengerDto Passenger { get; set; }

        public FlightClass FlightClass { get; set; }

        public SeatDto Seat { get; set; }

        public decimal Price { get; set; }
        
        public int TicketNumber { get; set; }

        public string DeparturePlace { get; set; }

        public string DestinationPlace { get; set; }

        public string DepartureDate { get; set; }

        public int FlightId { get; set; }
    }
}