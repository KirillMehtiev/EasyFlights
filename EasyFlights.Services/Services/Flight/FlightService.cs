using System;
using System.Collections.Generic;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.Services.Flight
{
    using Flight = EasyFlights.DomainModel.Entities.Flight;

    /// <summary>
    /// Concrete flight provider implementation
    /// </summary>
    public class FlightService : IFlightProvider
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
