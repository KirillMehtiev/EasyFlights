using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFlights.Data
{
    public class Airport : BaseEntity
    {
        public string Title { get; set; }
        public string AirportCode { get; set; }
        public City City { get; set; }
        public TimeZone TimeZone { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
