using System.Collections.Generic;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Services.DtoMappers
{
    public interface ITicketsForRouteMapper
    {
        Task<TicketsForRouteDto> Map(RouteDto route, List<PassengerDto> passengers);
    }
}
