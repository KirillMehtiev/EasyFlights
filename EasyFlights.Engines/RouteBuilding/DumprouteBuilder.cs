using System;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Engines.RouteBuilding
{
    public class DumpRouteBuilder : IRouteBuilder
    {
        Route IRouteBuilder.Build(Airport departure, Airport destination, DateTime departureDate)
        {
            throw new NotImplementedException();
        }
    }
}
