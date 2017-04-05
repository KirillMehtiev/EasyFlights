using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Enums;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Web.Util.Converters;
using EasyFlights.Web.ViewModels;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Tickets")]
    public class TicketsController : ApiController
    {
        private IRouteConverter converter;
        private ITicketsForRouteMapper dtoMapper;

        public TicketsController(IRouteConverter converter, ITicketsForRouteMapper dtoMapper)
        {
            this.converter = converter;
            this.dtoMapper = dtoMapper;
        }

        [HttpGet]
        [Route("GetPassengers")]
        public async Task<List<PassengerViewModel>> GetPassengersAsync(string routeId, int numberOfPassengers)
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
                return new List<PassengerViewModel>();
            }
            var answer = new List<PassengerViewModel>();
            answer.Add(GeneratePassengerFromUser());
            for (var i = 1; i < numberOfPassengers; i++)
            {
                answer.Add(new PassengerViewModel()
                {
                    Birthday = DateTime.MinValue.ToShortDateString(),
                    DocumentNumber = string.Empty,
                    FirstName = string.Empty,
                    LastName = string.Empty
                });
            }
            return answer;
        }

        [HttpPost]
        [Route("GetTickets")]
        public async Task<TicketsForRouteViewModel> GetTicketsForRouteAsync([FromBody] string routeId, List<PassengerDto> passengers)
        {
            RouteDto route = await converter.RestoreRouteFromRouteIdAsync(routeId);
            TicketsForRouteDto dto = this.dtoMapper.Map(route, passengers);
            var model = new TicketsForRouteViewModel();
            
            return model;
        }

        private PassengerViewModel GeneratePassengerFromUser()
        {
            return new PassengerViewModel()
            {
                Birthday = DateTime.MaxValue.ToShortDateString(),
                DocumentNumber = "user's document number",
                FirstName = "User's first name",
                LastName = "User's last name",
                Sex = Sex.Male // it's truly random, belive me
            };
        }
    }
}
