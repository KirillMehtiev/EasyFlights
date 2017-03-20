namespace EasyFlights.DomainModel.Identity
{
    public enum FlightClass
    {
        Economy    = 0,
        Business   = 1,
        FirstClass = 2
    }

    public class Ticket : BaseEntity
    {
        public virtual Passenger Passenger { get; set; }
        public double Fare { get; set; }
        public double Discount { get; set; }
        public virtual Flight Flight { get; set; }
        public int Seat { get; set; }
        public FlightClass FlightClass { get; set; }
    }
}
