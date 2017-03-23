using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.Services.FlightProvider
{
    using EasyFlights.DomainModel.Entities;

    /// <summary>
    /// Concrete flight provider implementation
    /// </summary>
    public class FlightProvider : IFlightProvider
    {
        public IEnumerable<Flight> GetFlights(
            Airport departure,
            Airport arrival,
            DateTime departureDate,
            DateTime? returnDate,
            int numberOfPeople = 1)
        {
            throw new NotImplementedException();
        }
    }
}
