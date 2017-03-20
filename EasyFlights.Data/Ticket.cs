using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFlights.Data
{
    public enum FlightClass
    {
        Economy    = 0,
        Business   = 1,
        FirstClass = 2
    }

    public class Ticket : BaseEntity
    {
        public Passenger Passenger { get; set; }
        public double Fare { get; set; }
        public double Discount { get; set; }
        public Flight Flight { get; set; }
        public int Seat { get; set; }
        public FlightClass FlightClass { get; set; }
    }
}
