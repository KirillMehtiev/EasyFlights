using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Web.Infrastructure;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Services.Common;
using EasyFlights.Services.Interfaces;
using EasyFlights.Web.ViewModels.OrdersViewModel;
using EasyFlights.Web.ViewModels.OrdersViewModels;
using Microsoft.AspNet.Identity;

namespace EasyFlights.Web.ApiControllers
{
    [Authorize]
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {
        private readonly IManageOrdersService manageOrderService;
        private readonly IFlightsRepository flightRepository;
        private readonly IApplicationUserManager applicationUserManager;

        public OrdersController(
            IManageOrdersService manageOrderService,
            IApplicationUserManager applicationUserManager,
            IFlightsRepository flightRepository)
        {
            this.manageOrderService = manageOrderService;
            this.applicationUserManager = applicationUserManager;
            this.flightRepository = flightRepository;
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetOrdersForUser")]
        public async Task<IEnumerable<ShortOrderViewModel>> GetOrdersForUser()
        {
            var userId = User.Identity.GetUserId();
            var orders = await manageOrderService.GetOrdersForUser(userId);

            return MapToShortOrderViewModels(orders);
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById")]
        public async Task<DetailedOrderViewModel> Get(int orderId)
        {
            var userId = User.Identity.GetUserId();
            var order = await this.manageOrderService.GetOrderByIdForUserAsync(orderId, userId);
            var result = MapToDetailedOrderViewModel(order);

            return result;
        }

        // POST api/<controller>
        [HttpPost]
        [Route("BookTickets")]
        public async Task BookTicketsAsync([FromBody] List<TicketForBookingViewModel> ticketsForBooking)
        {
            var orderDateTime = DateTime.UtcNow;

            var ticketsForOrder = new List<Ticket>();

            var user = await applicationUserManager.FindByEmailAsync(User.Identity.Name);

            foreach (var ticket in ticketsForBooking)
            {
                var flight = await flightRepository.GetFlightsById(ticket.FlightId);
                var newTicket = CreateTicket(ticket, flight);
                ticketsForOrder.Add(newTicket);
            }

            var order = new Order
            {
                OrderDate = orderDateTime,
                Tickets = ticketsForOrder,
                User = user
            };

            manageOrderService.AddOrder(order);
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
                DepartureCity = order.DeparturePlace,
                DestinationCity = order.DestinationPlace,
                Cost = order.Cost,
                DateOfOrdering = order.OrderDate,
                SetOffDate = order.DepartureDate,
                Duration = order.Duration.Remove(0, 1),
                OrderId = order.OrderId

            });
        }

        private DetailedOrderViewModel MapToDetailedOrderViewModel(OrderDto order)
        {
            var tickets = new List<DetailedTicketViewModel>();

            foreach (var ticket in order.Tickets)
            {
                var passenger = ticket.Passenger;
                var seat = ticket.Seat;
                var detailedTicketViewModel = new DetailedTicketViewModel
                {
                    FirstName = passenger.FirstName,
                    LastName = passenger.LastName,
                    Birthday = passenger.Birthday.ToString(Format.DateFormat),
                    DocumentNumber = passenger.DocumentNumber,
                    Sex = passenger.Sex,
                    Seat = seat?.Number ?? int.MinValue,
                    Price = ticket.Price,
                    DeparturePlace = order.DeparturePlace,
                    DestinationPlace = order.DestinationPlace,
                    DepartureDate = order.DepartureDate
                };

                tickets.Add(detailedTicketViewModel);
            }

            return new DetailedOrderViewModel()
            {
                OrderedDate = order.OrderDate,
                Tickets = tickets
            };
        }

        private Ticket CreateTicket(TicketForBookingViewModel ticket, Flight flight)
        {
            return new Ticket
            {
                Passenger = new Passenger
                {
                    FirstName = ticket.FirstName,
                    LastName = ticket.LastName,
                    DocumentNumber = ticket.DocumentNumber,
                    Sex = ticket.Sex,
                    BirthDate = ticket.Birthday
                },
                Fare = flight.DefaultFare,
                Seat = ticket.Seat,
                Flight = flight
            };
        }
    }
}