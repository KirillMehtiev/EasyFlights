using System.Collections.Generic;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Services.DtoMappers
{
    public interface ITicketsForRouteMapper
    {
        TicketsForRouteDto Map(List<FlightDto> flights, List<PassengerDto> passengers);
    }
}
