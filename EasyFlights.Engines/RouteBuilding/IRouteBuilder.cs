using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Engines.RouteBuilding
{
    /// <summary>
    /// Abstraction for a route builder
    /// </summary>
    public interface IRouteBuilder
    {
        Task<IEnumerable<Route>> BuildAsync(Airport departure, Airport destination, DateTime departureDate, int numberOfPassengers);
    }
}
