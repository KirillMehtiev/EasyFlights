﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Web.Infrastructure;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Services.Interfaces;
using EasyFlights.Web.ViewModels.OrdersViewModel;
using EasyFlights.Web.ViewModels.OrdersViewModels;
using Microsoft.AspNet.Identity;

namespace EasyFlights.Web.ApiControllers
{
    [Authorize]
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

            manageOrderService.AddOrder(user, order);
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