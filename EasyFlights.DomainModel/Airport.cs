using System;
using System.Collections.Generic;

namespace EasyFlights.DomainModel
{
    public class Airport : BaseEntity
    {
        public string Title { get; set; }
        public string AirportCode { get; set; }
        public virtual City City { get; set; }
        public TimeZone TimeZone { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
