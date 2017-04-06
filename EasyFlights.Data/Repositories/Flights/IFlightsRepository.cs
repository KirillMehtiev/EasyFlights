using System;
using System.Collections.Generic;
using EasyFlights.Data.Repositories.Base;
using EasyFlights.DomainModel.Entities;
using System.Threading.Tasks;

namespace EasyFlights.Data.Repositories.Flights
{
    /// <summary>
    /// Interface for Flights
    /// </summary>
    public interface IFlightsRepository : IRepository<Flight>
    {
        IEnumerable<Flight> GetFlightsByDeparture(Airport departureAirport, DateTime departureTime);
        Task<Flight> GetFlightsById(int flightId);
    }
}
