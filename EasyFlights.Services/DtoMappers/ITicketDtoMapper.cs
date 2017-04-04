using System.Collections.Generic;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Services.DtoMappers
{
    public interface ITicketDtoMapper
    {
        List<TicketDto> Map(List<Ticket> tickets);
    }
}
