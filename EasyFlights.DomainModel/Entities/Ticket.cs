using EasyFlights.DomainModel.Entities.Enums;

namespace EasyFlights.DomainModel.Entities
{
    public class Ticket : BaseEntity
    {
        public decimal Fare { get; set; }

        public decimal Discount { get; set; }

        public int Seat { get; set; }

        public FlightClass FlightClass { get; set; }

        public virtual Passenger Passenger { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual Order Order { get; set; }
    }
}
