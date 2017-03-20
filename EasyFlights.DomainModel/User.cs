using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFlights.DomainModel
{
    [Table("User", Schema = "usr")]
    public class User : BaseEntity
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
}
