using System;
using System.Collections.Generic;

namespace EasyFlights.DomainModel.Identity
{
    public class Flight : BaseEntity
    {
        public virtual Aircraft Aircraft { get; set; }
        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport DestinationAirport { get; set; }
        public DateTime ScheduledDeparture { get; set; }
        public DateTime ScheduledArrival { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
