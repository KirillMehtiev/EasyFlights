using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Enums;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Services.Interfaces;
using EasyFlights.Web.Infrastructure;
using EasyFlights.Web.Util.Converters;
using EasyFlights.Web.ViewModels;
using EasyFlights.Web.Wrappers;
using Microsoft.AspNet.Identity;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Tickets")]
    public class TicketsController : ApiController
    {
        private IRouteConverter converter;
        private ITicketsForRouteMapper dtoMapper;
        private readonly IFlightsRepository flightRepository;
        private readonly IApplicationUserManager applicationUserManager;

        private readonly IManageOrdersService manageOrderService;

        public TicketsController(IRouteConverter converter,
            ITicketsForRouteMapper dtoMapper,
            IManageOrdersService manageOrderService,
            IApplicationUserManager applicationUserManager,
            IFlightsRepository flightRepository)
        {
            this.converter = converter;
            this.dtoMapper = dtoMapper;
            this.manageOrderService = manageOrderService;
            this.applicationUserManager = applicationUserManager;
            this.flightRepository = flightRepository;
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
            TicketsForRouteDto dto = await dtoMapper.Map(route, passengersDto);
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

        [HttpGet]
        [Route("GetUser")]
        public async Task<IHttpActionResult> GeneratePassengerFromUserAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = await applicationUserManager.FindByIdAsync(User.Identity.GetUserId());
                var model = new PassengerViewModel()
                {
                    Birthday =
                        (user.DateOfBirth != null)
                            ? user.DateOfBirth?.ToShortDateString()
                            : DateTime.Now.ToShortDateString(),
                    DocumentNumber = string.Empty,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Sex = user.Sex ?? Sex.Male
                };
                return Ok(model);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
