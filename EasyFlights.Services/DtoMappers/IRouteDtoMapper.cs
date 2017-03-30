using System;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Services.DtoMappers
{
    public interface IRouteDtoMapper
    {
        RouteDto Map(Route model, decimal totalCost, TimeSpan totalTime);
    }
}
