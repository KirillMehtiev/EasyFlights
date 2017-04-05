using System.Collections.Generic;
using System.Linq;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Web.ApiControllers;
using EasyFlights.Web.Util.Converters;
using EasyFlights.Web.ViewModels;
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
            Assert.AreEqual(expected, controller.GetPassengersAsync("id", 1).Result.FirstOrDefault()?.FirstName);
        }

        [TestMethod]
        public async void GetTickets()
        {
            // Arrange
            TicketsController controller = GetController("id");

            // Act
            var expected = "Arrival";

            // Assert
            TicketsForRouteViewModel model = await controller.GetTicketsForRouteAsync("id", await controller.GetPassengersAsync("id", 1));
            Assert.AreEqual(expected, model.ArrivalAirport);
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
            mapperMock.Setup(x => x.Map(It.IsAny<RouteDto>(), It.IsAny<List<PassengerDto>>()))
                .Returns(new TicketsForRouteDto()
                {
                    ArrivalAirport = "Arrival"
                });
            return new TicketsController(converterMock.Object, mapperMock.Object);
        }
     }
}
