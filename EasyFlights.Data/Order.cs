using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFlights.Data
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
