using EasyFlights.Data.Repositories.Orders;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using EasyFlights.Services.Common;

namespace EasyFlights.Services.Services.Cabinet
{
    using System.Linq;

    public class ManageOrdersService : IManageOrdersService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IFlightDtoMapper flightMapper;

        public ManageOrdersService(IOrderRepository orderRepository, IFlightDtoMapper flightMapper)
        {
            this.flightMapper = flightMapper;
            this.orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> GetOrdersForUser(string userId)
        {
            var orders = await orderRepository.GetOrdersByUserId(userId);

            return CreateOrderResponse(orders);
        }

        public async Task<OrderDto> GetOrderByIdForUserAsync(int orderId, string userId)
        {
            Guard.ArgumentValid(orderId > 0, "Invalid order id.", nameof(orderId));

            Order order = await this.orderRepository.FindByIdAsync(orderId);

            Guard.ArgumentValid(order.User.Id == userId, $"Order with id {order.Id} does not belong to user with id {order.User.Id}", nameof(userId));

            Guard.ArgumentValid(order != null, $"Order with id = {orderId} does't exist.", nameof(orderId));

            return this.MapOrderToDto(order);
        }

        public void AddOrder(ApplicationUser user, Order order)
        {
            orderRepository.AddOrder(user, order);
        }

        private List<OrderDto> CreateOrderResponse(List<Order> orders)
        {
            var flight = new FlightDto();
            var ordersResponse = new List<OrderDto>();

            foreach (var order in orders)
            {
                foreach (var ticket in order.Tickets)
                {
                    flight = flightMapper.Map(ticket.Flight);

                    ordersResponse.Add(
                        new OrderDto
                        {
                            DeparturePlace = flight.DepartureAirportTitle,
                            DestinationPlace = flight.DestinationAirportTitle,
                            OrderDate = order.OrderDate.ToString(),
                            Cost = ticket.Fare,
                            Duration = flight.Duration.ToString(),
                            DepartureDate = ""
                        });
                }
            }

            return ordersResponse;
        }

        private OrderDto MapOrderToDto(Order order)
        {
            Guard.ArgumentValid(order.Tickets != null, $"Order id {order.Id} does not have tickets", nameof(order.Tickets));

            var tickets = order.Tickets;
            var firstTicket = order.Tickets.FirstOrDefault();
            var lastLast = order.Tickets.LastOrDefault();
            var duration = TimeSpan.MinValue;

            foreach (var ticket in tickets)
            {
                duration += CalculateDuration(ticket);
            }

            return new OrderDto()
            {
                DepartureDate = firstTicket.Flight.DepartureAirport.Title,
                DestinationPlace = lastLast.Flight.DestinationAirport.Title,
                Cost = tickets.Sum(s => s.Fare),
                OrderDate = order.OrderDate.ToString("d"),
                DeparturePlace = firstTicket.Flight.ScheduledDepartureTime.ToString("yyyy mmmm dd"),
                Duration = $"{duration.Days} day(s) {duration.Hours} hour(s) {duration.Minutes} minute(s)",
                Tickets = ToTicketDto(tickets)
            };
        }

        private IEnumerable<TicketDto> ToTicketDto(IEnumerable<Ticket> ticket)
        {
            return null;
        }

        private PassengerDto ToPassengerDto(Passenger passenger)
        {
            return null;
        }

        private TimeSpan CalculateDuration(Ticket ticket)
        {
            return ticket.Flight.ScheduledArrivalTime - ticket.Flight.ScheduledDepartureTime;
        }

    }
}
