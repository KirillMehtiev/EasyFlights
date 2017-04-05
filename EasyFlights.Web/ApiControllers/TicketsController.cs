using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Enums;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Web.Util.Converters;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Tickets")]
    public class TicketsController : ApiController
    {
        private IRouteConverter converter;
        private ITicketsForRouteMapper mapper;

        public TicketsController(IRouteConverter converter, ITicketsForRouteMapper mapper)
        {
            this.converter = converter;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetPassengersAsync")]
        public async Task<List<PassengerDto>> GetPassengersAsync(string routeId, int numberOfPassengers)
        {
            RouteDto route = await converter.RestoreRouteFromRouteIdAsync(routeId);
            var available = true;
            foreach (FlightDto flight in route.Flights)
            {
                if (numberOfPassengers > flight.Aircraft.Capacity - flight.Tickets?.Count)
                {
                    available = false;
                    break;
                }
            }
            if (!available)
            {
                return new List<PassengerDto>();
            }
            var answer = new List<PassengerDto>();
            answer.Add(GeneratePassengerFromUser());
            for (var i = 1; i < numberOfPassengers; i++)
            {
                answer.Add(new PassengerDto()
                {
                    Birthday = DateTime.MinValue,
                    DocumentNumber = string.Empty,
                    FirstName = string.Empty,
                    LastName = string.Empty
                });
            }
            return answer;
        }

        [HttpPost]
        [Route("GetTickets")]
        public async Task<TicketsForRouteDto> GetTicketsForRouteAsync([FromBody] string routeId, List<PassengerDto> passengers)
        {
            RouteDto route = await converter.RestoreRouteFromRouteIdAsync(routeId);
            return mapper.Map(route.Flights.ToList(), passengers);      
        }

        private PassengerDto GeneratePassengerFromUser()
        {
            return new PassengerDto()
            {
                Birthday = DateTime.MaxValue,
                DocumentNumber = "user's document number",
                FirstName = "User's first name",
                LastName = "User's last name",
                Sex = Sex.Male // it's truly random, belive me
            };
        }
    }
}
