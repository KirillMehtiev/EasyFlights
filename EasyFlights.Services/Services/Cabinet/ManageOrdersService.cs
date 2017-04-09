using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Orders;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Common;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Services.Services.Cabinet
{

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

            return orders.Select(MapOrderToDto).ToList();
        }

        public async Task<OrderDto> GetOrderByIdForUserAsync(int orderId, string userId)
        {
            var order = await GetOrder(orderId, userId);

            return this.MapOrderToDto(order);
        }

        public void AddOrder(Order order)
        {
            orderRepository.AddOrder(order);
        }

        public async Task DeleteOrder(int orderId, string userId)
        {
            var order = await GetOrder(orderId, userId);

            this.orderRepository.Delete(order);
            this.orderRepository.SaveChanges();
        }

        private async Task<Order> GetOrder(int orderId, string userId)
        {
            Guard.ArgumentValid(orderId > 0, "Invalid order id.", nameof(orderId));

            Order order = await this.orderRepository.FindByIdAsync(orderId);

            Guard.ArgumentValid(order.User.Id == userId, $"Order with id {order.Id} does not belong to user with id {order.User.Id}", nameof(userId));

            Guard.ArgumentValid(order != null, $"Order with id = {orderId} does't exist.", nameof(orderId));

            return order;
        }

        private OrderDto MapOrderToDto(Order order)
        {
            Guard.ArgumentValid(order.Tickets != null, $"Order id {order.Id} does not have tickets", nameof(order.Tickets));

            var tickets = order.Tickets;
            var firstTicket = order.Tickets.FirstOrDefault();
            var lastLast = order.Tickets.LastOrDefault();
            var duration = new TimeSpan();
            
            duration = tickets.Aggregate(duration, (current, ticket) => current + this.CalculateDuration(ticket));

            var result = new OrderDto()
            {
                DepartureDate = firstTicket.Flight.ScheduledDepartureTime.ToString(Format.DateTimeFormat),
                DestinationPlace = lastLast.Flight.DestinationAirport.Title,
                Cost = tickets.Sum(s => s.Fare),
                OrderDate = order.OrderDate.ToString(Format.DateTimeFormat),
                DeparturePlace = firstTicket.Flight.DepartureAirport.Title,
                Duration = duration.ToString(Format.TimeSpanFormat),
                Tickets = ToTicketDto(tickets),
                OrderId = order.Id
            };

            return result;
        }

        private IEnumerable<TicketDto> ToTicketDto(IEnumerable<Ticket> ticket)
        {
            return ticket.Select(t => new TicketDto
            {
                Passenger = ToPassengerDto(t.Passenger),
                FlightClass = t.FlightClass,
                Price = t.Fare,
                Seat = ToSeatDto(t.Seat),
                TicketNumber = t.Id,
                DestinationPlace = t.Flight.DestinationAirport.Title,
                DeparturePlace = t.Flight.DepartureAirport.Title,
                DepartureDate = t.Flight.ScheduledDepartureTime.ToString("f")
            });
        }

        private PassengerDto ToPassengerDto(Passenger passenger)
        {
            return new PassengerDto()
            {
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                Birthday = passenger.BirthDate,
                DocumentNumber = passenger.DocumentNumber,
                Sex = passenger.Sex
            };
        }

        private SeatDto ToSeatDto(int seatNumber)
        {
            return new SeatDto
            {
                Number = seatNumber
            };
        }

        private TimeSpan CalculateDuration(Ticket ticket)
        {
            return ticket.Flight.ScheduledArrivalTime - ticket.Flight.ScheduledDepartureTime;
        }

    }
}
