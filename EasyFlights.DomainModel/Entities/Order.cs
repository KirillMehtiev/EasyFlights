using System;
using System.Collections.Generic;
using EasyFlights.DomainModel.Entities.Identity;

namespace EasyFlights.DomainModel.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
