using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Services.DtoMappers
{
    public class FlightDtoMapper : IFlightDtoMapper
    {
        public FlightDto Map(Flight model)
        {
            return new FlightDto()
            {
                ScheduledDepartureTime = model.ScheduledDepartureTime,
                ScheduledArrivalTime = model.ScheduledArrivalTime,
                DepartureAirportTitle = model.DepartureAirport.Title,
                DestinationAirportTitle = model.DestinationAirport.Title,
                Duration = model.ScheduledDepartureTime - model.ScheduledArrivalTime,
                DefaultFare = model.DefaultFare,
                Id = model.Id,

                // TODO: figure out what this dto should contain
                Aircraft = new AircraftDto()
            };
        }
    }
}
