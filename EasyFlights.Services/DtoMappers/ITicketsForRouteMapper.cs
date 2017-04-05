using System.Collections.Generic;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Services.DtoMappers
{
    public interface ITicketsForRouteMapper
    {
        TicketsForRouteDto Map(RouteDto route, List<PassengerDto> passengers);
    }
}
