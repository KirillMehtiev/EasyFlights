using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Enums;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Web.Infrastracture;
using EasyFlights.Web.Util.Converters;
using EasyFlights.Web.ViewModels;
using EasyFlights.Web.Wrappers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Tickets")]
    public class TicketsController : ApiController
    {
        private ApplicationUserManager userManager;
        private IRouteConverter converter;
        private ITicketsForRouteMapper dtoMapper;

        public TicketsController(IRouteConverter converter, ITicketsForRouteMapper dtoMapper, ApplicationUserManager userManager)
        {
            this.converter = converter;
            this.dtoMapper = dtoMapper;
            this.userManager = userManager;
        }

        private ApplicationUserManager UserManager => this.userManager ?? this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

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
            var answer = new List<PassengerViewModel> { await this.GeneratePassengerFromUserAsync() };
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
        public async Task<TicketsForRouteViewModel> GetTicketsForRouteAsync([FromBody] GetTicketsWrapper wrapper)
        {
            RouteDto route = await converter.RestoreRouteFromRouteIdAsync(wrapper.RouteId);
            var passengersDto = new List<PassengerDto>();
            foreach (PassengerViewModel passenger in wrapper.Passengers)
            {
                passengersDto.Add(new PassengerDto()
                {
                    Birthday = DateTime.Parse(passenger.Birthday),
                    DocumentNumber = passenger.DocumentNumber,
                    FirstName = passenger.FirstName,
                    LastName = passenger.LastName,
                    Sex = passenger.Sex
                });
            }
            TicketsForRouteDto dto = this.dtoMapper.Map(route, passengersDto);
            var model = new TicketsForRouteViewModel()
            {
                ArrivalAirport = dto.ArrivalAirport,
                ArrivalCity = dto.ArrivalCity,
                DepartureAirport = dto.DepartureAirport,
                DepartureCity = dto.DepartureCity,
                Duration = dto.Duration.ToString("d' days, 'hh':'mm"),
                Flights = new List<FlightViewModel>(),
                TotalPrice = dto.TotalPrice
            };
            foreach (FlightDto flight in dto.Flights)
            {
                var flightModel = new FlightViewModel()
                {
                    ArrivalTime = flight.ScheduledArrivalTime.ToShortDateString(),
                    DepartureAirport = flight.DepartureAirportTitle,
                    DepartureTime = flight.ScheduledDepartureTime.ToShortDateString(),
                    DestinationAirport = flight.DestinationAirportTitle,
                    Duration = flight.Duration.ToString("d' days, 'hh':'mm"),
                    Fare = flight.DefaultFare,
                    Tickets = new List<TicketVIewModel>()
                };
                foreach (TicketDto ticket in flight.Tickets)
                {
                    var ticketModel = new TicketVIewModel()
                    {
                        Class = ticket.FlightClass,
                        Fare = ticket.Price,
                        Passenger = ticket.Passenger.FirstName + " " + ticket.Passenger.LastName,
                        Seat = ticket.Seat.Number
                    };
                    flightModel.Tickets.Add(ticketModel);
                }
                model.Flights.Add(flightModel);
            }
            return model;
        }

        private async Task<PassengerViewModel> GeneratePassengerFromUserAsync()
        {
            PassengerViewModel model;
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                model = new PassengerViewModel()
                {     
                    Birthday = (user.DateOfBirth != null) ? user.DateOfBirth?.ToShortDateString() : DateTime.Now.ToShortDateString(),
                    DocumentNumber = string.Empty,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Sex = user.Sex ?? Sex.Male
                };               
            }
            else
            {
                model = new PassengerViewModel()
                {
                    Birthday = DateTime.Now.ToShortDateString(),
                    DocumentNumber = string.Empty,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    Sex = Sex.Male // it's truly random, belive me
                };
            }
            return model;
        }
    }
}
