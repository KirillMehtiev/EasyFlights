using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Services.Interfaces
{
    /// <summary>
    /// Abstraction for flights provider
    /// </summary>
    public interface IFlightProvider
    {
        IEnumerable<Flight> GetFlights(
            Airport departure,
            Airport arrival,
            DateTime departureDate,
            DateTime? returnDate,
            int numberOfPeople = 1);
    }
}
