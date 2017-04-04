using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Enums;
using EasyFlights.Web.Util.Converters;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Tickets")]
    public class TicketsController : ApiController
    {
        private IRouteConverter converter;

        public TicketsController(IRouteConverter converter)
        {
            this.converter = converter;
        }

        [HttpPost]
        [Route("GetPassengers")]
        public List<PassengerDto> GetPassengers([FromBody] string routeId, int numberOfPassengers)
        {
            RouteDto route = converter.RestoreRouteFromRouteIdAsync(routeId).Result;
            var available = true;
            foreach (FlightDto flight in route.Flights)
            {
                if (numberOfPassengers > flight.Aircraft.Capacity - flight.Tickets.Count)
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
            answer.Add(new PassengerDto()
            {
                BirthDate = DateTime.Now,
                DocumentNumber = "user's document number",
                FirstName = "User's first name",
                LastName = "User's last name",
                Sex = Sex.Male // it's truly random, belive me
            });
            for (var i = 1; i < numberOfPassengers; i++)
            {
                answer.Add(new PassengerDto()
                {
                    BirthDate = DateTime.MinValue,
                    DocumentNumber = string.Empty,
                    FirstName = string.Empty,
                    LastName = string.Empty
                });
            }
            return answer;
        }

        [HttpPost]
        [Route("GetTickets")]
        public TicketsForRouteDto GetTicketsForRoute([FromBody] string routeId, List<PassengerDto> passengers)
        {
            var ticketsForRoute = new TicketsForRouteDto();
            RouteDto route = converter.RestoreRouteFromRouteIdAsync(routeId).Result;
            return ticketsForRoute;
            
        }
    }
}
