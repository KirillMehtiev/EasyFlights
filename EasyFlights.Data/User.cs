using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFlights.Data
{
    [Table("User", Schema = "usr")]
    public class User : BaseEntity
    {
        public ICollection<Order> Orders { get; set; }
    }
}
