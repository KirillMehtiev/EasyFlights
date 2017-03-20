using System;
using System.Collections.Generic;

namespace EasyFlights.DomainModel.Identity
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
