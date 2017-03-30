using System;
using System.Linq;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Services.DtoMappers
{
    public class RouteDtoMapper : IRouteDtoMapper
    {
        private readonly IFlightDtoMapper flightMapper;

        public RouteDtoMapper(IFlightDtoMapper flightMapper)
        {
            this.flightMapper = flightMapper;
        }

        public RouteDto Map(Route route, decimal totalCost, TimeSpan totalTime)
        {
            return new RouteDto()
            {
                Flights = route.Flights.Select(flight => this.flightMapper.Map(flight)).ToList(),
                TotalCost = totalCost,
                TotalTime = totalTime
            };
        }
    }
}
