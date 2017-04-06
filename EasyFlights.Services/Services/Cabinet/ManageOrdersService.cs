﻿using EasyFlights.Data.Repositories.Orders;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.DomainModel.Entities.Identity;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                            DepartureCity = flight.DepartureAirportTitle,
                            DestinationCity = flight.DestinationAirportTitle,
                            DateOfOrdering = order.OrderDate.ToString(),
                            Cost = ticket.Fare,
                            Duration = flight.Duration.ToString(),
                            SetOffDate = ""
                        });
                }
            }

            return ordersResponse;
        }

    }
}
