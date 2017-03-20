namespace EasyFlights.DomainModel
{
    public enum FlightClass
    {
        Economy    = 0,
        Business   = 1,
        FirstClass = 2
    }

    public class Ticket : BaseEntity
    {
        
        public double Fare { get; set; }
        public double Discount { get; set; }
        public int Seat { get; set; }
        public FlightClass FlightClass { get; set; }

        public virtual Passenger Passenger { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Order Order { get; set; }
    }
}
