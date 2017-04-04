using System.Collections.Generic;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Services.DtoMappers
{
    public class TicketDtoMapper : ITicketDtoMapper
    {
        public List<TicketDto> Map(List<Ticket> tickets)
        {
            var answer = new List<TicketDto>();
            foreach (Ticket ticket in tickets)
            {
                answer.Add(new TicketDto()
                {
                    FlightClass = ticket.FlightClass,
                    Passenger = null,
                    Price = ticket.Fare,
                    Seat = new SeatDto()
                    {
                        IsBooked = true, Number = ticket.Seat
                    },
                    TicketNumber = ticket.Id
                });
            }
            return answer;
        }
    }
}
