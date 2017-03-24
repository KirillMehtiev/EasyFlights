using System.Collections.Generic;

namespace EasyFlights.DomainModel.Entities
{
    public class Airport : BaseEntity
    {
        public string Title { get; set; }

        public string AirportCodeIata { get; set; }

        public string AirportCodeIcao { get; set; }

        public decimal TimeZoneOffset { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
