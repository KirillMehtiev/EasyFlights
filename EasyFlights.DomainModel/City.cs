using System.Collections.Generic;

namespace EasyFlights.DomainModel
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Airport> Airports { get; set; }
    }
}
