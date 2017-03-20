using System;
using System.Collections.Generic;

namespace EasyFlights.DomainModel.Identity
{
    public class Airport : BaseEntity
    {
        public string Title { get; set; }
        public string AirportCodeIata { get; set; }
        public string AirportCodeIcao { get; set; }
        public virtual City City { get; set; }
        public int TimeZoneOffset { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
