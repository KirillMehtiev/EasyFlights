using System.Collections.Generic;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.DomainModel.Entities.Enums;

namespace EasyFlights.Services.DtoMappers
{
    public class TicketsForRouteMapper : ITicketsForRouteMapper
    {
        public TicketsForRouteDto Map(List<FlightDto> flights, List<PassengerDto> passengers)
        {
            var dto = new TicketsForRouteDto();
            foreach (FlightDto flight in flights)
            {
                foreach (PassengerDto passenger in passengers)
                {
                    flight.Tickets.Add(new TicketDto()
                    {
                        FlightClass = FlightClass.Economy,
                        Passenger = passenger,
                        Price = flight.DefaultFare
                        
                    });
                }
            }
            return dto;
        }
    }
}
