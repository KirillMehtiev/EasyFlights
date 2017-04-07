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

        public void AddOrder(Order order)
        {
            orderRepository.AddOrder(order);
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
                            DepartureDate = flight.ScheduledDepartureTime.ToString(),
                            OrderId = order.Id
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
            var duration = new TimeSpan();

            duration = tickets.Aggregate(duration, (current, ticket) => current + this.CalculateDuration(ticket));

            var result = new OrderDto()
            {
                DepartureDate = firstTicket.Flight.DepartureAirport.Title,
                DestinationPlace = lastLast.Flight.DestinationAirport.Title,
                Cost = tickets.Sum(s => s.Fare),
                OrderDate = order.OrderDate.ToString("d"),
                DeparturePlace = firstTicket.Flight.ScheduledDepartureTime.ToString("yyyy mmmm dd"),
                Duration = $"{duration.Days} day(s) {duration.Hours} hour(s) {duration.Minutes} minute(s)",
                Tickets = ToTicketDto(tickets)
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
                TicketNumber = t.Id
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
