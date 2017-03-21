using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFlights.DomainModel.Entities.Enums
{
    /// <summary>
    /// Types of flight classes.
    /// </summary>
    public enum FlightClass
    {
        /// <summary>
        /// Represents an economy class.
        /// </summary>
        Economy = 0,

        /// <summary>
        /// Represents a business class.
        /// </summary>
        Business = 1,

        /// <summary>
        /// Represents first class.
        /// </summary>
        FirstClass = 2
    }
}
