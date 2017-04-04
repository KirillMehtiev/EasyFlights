using System;
using System.Collections.Generic;
using System.Linq;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Enums;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Web.ApiControllers;
using EasyFlights.Web.Util.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyFlights.WebApi.Tests.ApiControllers
{
    [TestClass]
    public class TicketsControllerTests
    {
        
        [TestMethod]
        public void GetPassengers()
        {
            // Arrange
            TicketsController controller = GetController("id");

            // Act
            var expected = "User's first name";

            // Assert
            Assert.AreEqual(expected, controller.GetPassengers("id", 1).FirstOrDefault()?.FirstName);
        }

        [TestMethod]
        public void GetTickets()
        {
            // Arrange
            TicketsController controller = GetController("id");

            // Act
            var expected = "Arrival";

            // Assert
            TicketsForRouteDto dto = controller.GetTicketsForRoute("id", controller.GetPassengers("id", 1));
            Assert.AreEqual(expected, dto.ArrivalAirport);
        }

        private TicketsController GetController(string routeId)
        {
            var converterMock = new Mock<IRouteConverter>();
            var mapperMock = new Mock<ITicketsForRouteMapper>();
            var routeDto = new RouteDto()
            {
                Flights = new List<FlightDto>()
                {
                    new FlightDto()
                    {
                        Aircraft = new AircraftDto()
                        {
                            Capacity = 100,
                            ModelName = "Name"
                        },
                        Tickets = new List<TicketDto>()
                        {
                            new TicketDto()
                            {
                                Passenger = new PassengerDto()
                                {
                                    FirstName = "User's first name"
                                }
                            }
                        }
                    }
                }
            };
            converterMock.Setup(x => x.RestoreRouteFromRouteIdAsync(routeId)).ReturnsAsync(routeDto);
            mapperMock.Setup(x => x.Map(It.IsAny<List<FlightDto>>(), It.IsAny<List<PassengerDto>>()))
                .Returns(new TicketsForRouteDto()
                {
                    ArrivalAirport = "Arrival"
                });
            return new TicketsController(converterMock.Object, mapperMock.Object);
        }
        
        private PassengerDto GeneratePassengerFromUser()
        {
            return new PassengerDto()
            {
                Birthday = DateTime.MaxValue,
                DocumentNumber = "user's document number",
                FirstName = "User's first name",
                LastName = "User's last name",
                Sex = Sex.Male
            };
        }
    }
}
