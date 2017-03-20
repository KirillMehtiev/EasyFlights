using System.Collections.Generic;

namespace EasyFlights.DomainModel.Identity
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}