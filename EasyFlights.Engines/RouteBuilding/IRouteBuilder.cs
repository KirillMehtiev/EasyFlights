using System;
using System.Collections.Generic;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Engines.RouteBuilding
{
    /// <summary>
    /// Abstraction for a route builder
    /// </summary>
    public interface IRouteBuilder
    {
        IEnumerable<Route> Build(Airport departure, Airport destination, DateTime departureDate, int numberOfPassengers);
    }
}
