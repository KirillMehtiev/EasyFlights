using System.Collections.Generic;

namespace EasyFlights.DomainModel.Identity
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Airport> Airports { get; set; }
    }
}
