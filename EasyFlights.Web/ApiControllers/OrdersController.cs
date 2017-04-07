using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Web.Infrastructure;
using EasyFlights.Web.Util.Converters;

namespace EasyFlights.Web.ApiControllers
{
    using System.Threading.Tasks;

    using EasyFlights.DomainModel.DTOs;
    using EasyFlights.Services.Interfaces;
    using EasyFlights.Web.ViewModels.OrdersViewModel;

    using Microsoft.AspNet.Identity;
    using ViewModels.OrdersViewModels;

    [Authorize]
    public class OrdersController : ApiController
    {
        private readonly IManageOrdersService manageOrderService;
        private IRouteConverter converter;
        private ITicketsForRouteMapper dtoMapper;
        private readonly IFlightsRepository flightRepository;
        private readonly IApplicationUserManager applicationUserManager;

        public OrdersController(IRouteConverter converter,
            ITicketsForRouteMapper dtoMapper,
            IManageOrdersService manageOrderService,
            IApplicationUserManager applicationUserManager,
            IFlightsRepository flightRepository)
        {
            this.manageOrderService = manageOrderService;
            this.converter = converter;
            this.dtoMapper = dtoMapper;
            this.applicationUserManager = applicationUserManager;
            this.flightRepository = flightRepository;
        }

        // GET api/<controller>
        public async Task<IEnumerable<ShortOrderViewModel>> Get()
        {
            var userId = User.Identity.GetUserId();
            var orders = await manageOrderService.GetOrdersForUser(userId);

            return MapToShortOrderViewModels(orders);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        [Route("BookTickets")]
        public async Task BookTicketsAsync([FromBody] BookOrderViewModel orderModel)
        {
            //var orderDateTime = DateTime.Now.ToUniversalTime();

            //orderModel.RouteId = "137";
            //var flights = new List<Flight>();
            //var ticketsForOrder = new List<Ticket>();

            //var user = await applicationUserManager.FindByEmailAsync(User.Identity.Name);
            //var route = await converter.RestoreRouteFromRouteIdAsync(orderModel.RouteId);

            //foreach (var flight in route.Flights)
            //{
            //    flights.Add(await flightRepository.GetFlightsById(flight.Id));
            //}

            //foreach (var flight in flights)
            //{
            //    foreach (var ticket in orderModel.Tickets)
            //    {
            //        var newTicket = CreateTicket(ticket, flight);
            //        ticketsForOrder.Add(newTicket);
            //    }
            //}

            //var order = new Order
            //{
            //    OrderDate = orderDateTime,
            //    Tickets = ticketsForOrder,
            //    User = user
            //};

            //try
            //{
            //    manageOrderService.AddOrder(user, order);
            //}
            //catch (Exception ex)
            //{

            //}
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private IEnumerable<ShortOrderViewModel> MapToShortOrderViewModels(IEnumerable<OrderDto> orders)
        {
            return orders.Select(order => new ShortOrderViewModel
            {
                DepartureCity = order.DepartureCity,
                DestinationCity = order.DestinationCity,
                Cost = order.Cost,
                DateOfOrdering = order.DateOfOrdering,
                SetOffDate = order.SetOffDate,
                Duration = order.Duration
            });
        }
        private Ticket CreateTicket(TicketDto ticket, Flight flight)
        {
            return new Ticket
            {
                Passenger = new Passenger
                {
                    FirstName = ticket.Passenger.FirstName,
                    LastName = ticket.Passenger.LastName,
                    DocumentNumber = ticket.Passenger.DocumentNumber,
                    Sex = ticket.Passenger.Sex,
                    BirthDate = ticket.Passenger.Birthday
                },
                Fare = ticket.Price,
                Seat = ticket.Seat.Number,
                FlightClass = ticket.FlightClass,
                Flight = flight
            };
        }
    }
}