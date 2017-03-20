using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFlights.Data
{
    public class Aircraft : BaseEntity
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
    }
}
