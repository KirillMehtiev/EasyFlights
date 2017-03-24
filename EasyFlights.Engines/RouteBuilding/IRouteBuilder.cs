using System;
using System.Collections.Generic;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Engines.RouteBuilding
{
    /// <summary>
    /// Abstraction for route builder
    /// </summary>
    public interface IRouteBuilder
    {
        Route Build(Airport departure, Airport destination, DateTime departureDate);
    }
}
