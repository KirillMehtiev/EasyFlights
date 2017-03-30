using System;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Engines.RouteBuilding
{
    public interface IRouteGeneralInfoCalculator
    {
        decimal GetTotalCost(Route route);

        TimeSpan GetTotalTime(Route route);
    }
}
