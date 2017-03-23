using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Engines
{
    /// <summary>
    /// Abstraction for route builder
    /// </summary>
    public interface IRouteBuilder
    {
        IEnumerable<Flight> Build(
            Airport departure,
            Airport arrival,
            DateTime departureDate,
            DateTime? returnDate,
            int numberOfPeople = 1);
    }
}
