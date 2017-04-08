using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Enums;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.DtoMappers
{
    public class TicketsForRouteMapper : ITicketsForRouteMapper
    {
        private IFlightService service;

        public TicketsForRouteMapper(IFlightService service)
        {
            this.service = service;
        }

        public async Task<TicketsForRouteDto> Map(RouteDto route, List<PassengerDto> passengers)
        {
            var dto = new TicketsForRouteDto();
            dto.Flights = route.Flights.ToList();
            foreach (FlightDto flight in dto.Flights)
            {
                if (flight.Tickets == null)
                {
                    flight.Tickets = new List<TicketDto>();
                }
                List<int> availableSeats = await service.GetAvailableSeats(passengers.Count, flight.Id, null);
                for (var i = 0; i < passengers.Count; i++)
                {
                    flight.Tickets.Add(new TicketDto()
                    {
                        FlightClass = FlightClass.Economy,
                        Passenger = passengers[i],
                        Price = flight.DefaultFare,
                        Seat = new SeatDto() { IsBooked = true, Number = availableSeats[i] },
                        TicketNumber = i
                    });
                    dto.TotalPrice += flight.DefaultFare;
                }
            }
            dto.DepartureAirport = dto.Flights.FirstOrDefault()?.DepartureAirportTitle;
            dto.DepartureCity = dto.Flights.FirstOrDefault()?.DepartureCity;
            dto.ArrivalAirport = dto.Flights.Last()?.DestinationAirportTitle;
            dto.ArrivalCity = dto.Flights.Last()?.DestinationCity;
            TimeSpan? timeSpan = dto.Flights.Last()?.ScheduledArrivalTime - dto.Flights.FirstOrDefault()?.ScheduledDepartureTime;
            if (timeSpan != null)
            {
                dto.Duration = (TimeSpan)timeSpan;
            }
            return dto;
        }
    }
}
