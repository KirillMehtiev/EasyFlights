using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Services.DtoMappers
{
    public interface IFlightDtoMapper
    {
        FlightDto Map(Flight model);
    }
}
