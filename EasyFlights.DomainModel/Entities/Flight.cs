using System;
using System.Collections.Generic;

namespace EasyFlights.DomainModel.Entities
{
    public class Flight : BaseEntity
    {
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime ScheduledArrivalTime { get; set; }

        public virtual Aircraft Aircraft { get; set; }

        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport DestinationAirport { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
