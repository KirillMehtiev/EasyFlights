using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Common;
using EasyFlights.Services.Interfaces;
using EasyFlights.Web.Infrastructure;
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

        private readonly IFlightService flightService;

        public OrdersController(
            IManageOrdersService manageOrderService,
            IApplicationUserManager applicationUserManager,
            IFlightsRepository flightRepository,
            IFlightService flightService)
        {
            this.manageOrderService = manageOrderService;
            this.applicationUserManager = applicationUserManager;
            this.flightRepository = flightRepository;
            this.flightService = flightService;
        }

        // GET api/<controller>
        [HttpGet]
        [Route("GetOrdersForUser")]
        public async Task<IEnumerable<ShortOrderViewModel>> GetOrdersForUser()
        {
            var userId = User.Identity.GetUserId();
            var orders = await manageOrderService.GetOrdersForUser(userId);

            return MapToShortOrderViewModels(orders.OrderByDescending(o => o.OrderDate));
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById")]
        public async Task<DetailedOrderViewModel> Get(int orderId)
        {
            var order = await GetOrderForCurrentUser(orderId);
            var result = MapToDetailedOrderViewModel(order);

            return result;
        }

        [HttpGet]
        [Route("getOrderForEdit")]
        public async Task<IEnumerable<EditOrderPassengerInformationViewModel>> GetPassengerInformationForOrder(int orderId)
        {
            var order = await GetOrderForCurrentUser(orderId);

            var result = MapToEditOrderPassengerInformationViewModel(order);

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

            var ticketsForBookingGroupedByFlightId = ticketsForBooking.GroupBy(x => x.FlightId).ToList();

            foreach (var tickets in ticketsForBookingGroupedByFlightId)
            {
                var flightId = tickets.Key;

                var count = tickets.Count(ticket => ticket.FlightId == flightId && ticket.Seat == 0);

                var availibleSeats = await flightService.GetAvailableSeats(
                    count,
                    flightId,
                    ticketsForBooking.Where(ticket => ticket.Seat != 0).Select(s => s.Seat).ToList());

                foreach (var ticket in tickets)
                {
                    if (ticket.Seat == 0)
                        AssignSeatToTicket(availibleSeats, ticket);
                }
            }

            ticketsForBooking = ticketsForBookingGroupedByFlightId.SelectMany(ticket => ticket).ToList();

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
        [HttpDelete]
        [Route("Delete")]
        public async Task<IHttpActionResult> Delete(int orderId)
        {
            var userId = User.Identity.GetUserId();
            await this.manageOrderService.DeleteOrder(orderId, userId);

            return Ok();
        }

        private async Task<OrderDto> GetOrderForCurrentUser(int orderId)
        {
            var userId = User.Identity.GetUserId();
            return await this.manageOrderService.GetOrderByIdForUserAsync(orderId, userId);
        }

        private IEnumerable<EditOrderPassengerInformationViewModel> MapToEditOrderPassengerInformationViewModel(
            OrderDto order)
        {
            var tickets = order.Tickets.ToList();
            var passengers = order.Tickets.Distinct().Select(p => p.Passenger);
            var result = new List<EditOrderPassengerInformationViewModel>();

            foreach (var passenger in passengers)
            {
                result.Add(new EditOrderPassengerInformationViewModel
                {
                    FirstName = passenger.FirstName,
                    LastName = passenger.LastName,
                    Birthday = passenger.Birthday.ToString("d"),
                    DocumentNumber = passenger.DocumentNumber,
                    Sex = passenger.Sex,
                    Tickets = MapToEditOrderTicketViewModel(tickets)
                });
            }

            return result;
        }

        private IEnumerable<EditOrderTicketViewModel> MapToEditOrderTicketViewModel(IEnumerable<TicketDto> tickets)
        {
            return tickets.Select(ticket => new EditOrderTicketViewModel
            {
                DepartureAirport = ticket.DeparturePlace,
                DestinationAirport = ticket.DestinationPlace,
                DepartureTime = ticket.DepartureDate,
                Seat = ticket.Seat.Number,
                Fare = ticket.Price,
                FlightId = ticket.FlightId
            });
        }

        private IEnumerable<ShortOrderViewModel> MapToShortOrderViewModels(IEnumerable<OrderDto> orders)
        {
            return orders.Select(order => new ShortOrderViewModel
            {
                DepartureAirport = order.DeparturePlace,
                DestinationAirport = order.DestinationPlace,
                Cost = order.Cost,
                DateOfOrdering = order.OrderDate.ToString(Format.DateFormat),
                SetOffDate = order.DepartureDate,
                Duration = order.Duration,
                OrderId = order.OrderId,
                ArrivalCity = order.ArrivalCity,
                DepartureCity = order.DepartureCity
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
                    DeparturePlace = ticket.DeparturePlace,
                    DestinationPlace = ticket.DestinationPlace,
                    DepartureDate = ticket.DepartureDate,
                    Duration = order.Duration,
                    ArrivalTime =  order.ArrivalTime
                };

                tickets.Add(detailedTicketViewModel);
            }

            return new DetailedOrderViewModel()
            {
                OrderedDate = order.OrderDate.ToString(Format.DateFormat),
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

        private List<TicketForBookingViewModel> GetTicketWithoutSeats(List<TicketForBookingViewModel> tickets)
        {
            return tickets.Where(ticket => ticket.Seat == 0).ToList();
        }

        private void AssignSeatToTicket(List<int> seats, TicketForBookingViewModel ticket)
        {
            var random = new Random();
            var randomValue = random.Next(1, seats.Count);
            var seat = seats[randomValue - 1];
            ticket.Seat = seat;
            seats.Remove(seat);
        }
    }
}