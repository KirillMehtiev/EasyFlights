using System.Collections.Generic;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Services.Interfaces;
using EasyFlights.Web.ApiControllers;
using EasyFlights.Web.Infrastructure;
using EasyFlights.Web.Util.Converters;
using EasyFlights.Web.ViewModels;
using EasyFlights.Web.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EasyFlights.Services.Services.Cabinet;
using EasyFlights.Services.Interfaces;
using EasyFlights.Data.Repositories.Flights;

namespace EasyFlights.WebApi.Tests.ApiControllers
{
    [TestClass]
    public class TicketsControllerTests
    {
        //[TestMethod]
        //public async void GetTickets()
        //{
        //    // Arrange
        //    TicketsController controller = GetController("id");

        //    // Act
        //    var expected = "Arrival";

        //    // Assert
        //    TicketsForRouteViewModel model = await controller.GetTicketsForRouteAsync(new GetTicketsWrapper() { RouteId = "id", Passengers = new List<PassengerViewModel>() });
        //    Assert.AreEqual(expected, model.ArrivalAirport);
        //}

        //private TicketsController GetController(string routeId)
        //{
        //    var converterMock = new Mock<IRouteConverter>();
        //    var mapperMock = new Mock<ITicketsForRouteMapper>();
        //    var flightRepositoryMock = new Mock<IFlightsRepository>();
        //    var manageOrdersServiceMock = new Mock<IManageOrdersService>();
        //    var userManagerMock = new Mock<IApplicationUserManager>();
        //    var routeDto = new RouteDto()
        //    {
        //        Flights = new List<FlightDto>()
        //        {
        //            new FlightDto()
        //            {
        //                Aircraft = new AircraftDto()
        //                {
        //                    Capacity = 100,
        //                    ModelName = "Name"
        //                },
        //                Tickets = new List<TicketDto>()
        //                {
        //                    new TicketDto()
        //                    {
        //                        Passenger = new PassengerDto()
        //                        {
        //                            FirstName = "User's first name"
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    };
        //    converterMock.Setup(x => x.RestoreRouteFromRouteIdAsync(routeId)).ReturnsAsync(routeDto);
        //    mapperMock.Setup(x => x.Map(It.IsAny<RouteDto>(), It.IsAny<List<PassengerDto>>()))
        //        .ReturnsAsync(new TicketsForRouteDto()
        //        {
        //            ArrivalAirport = "Arrival"
        //        });

        //    return new TicketsController(converterMock.Object, mapperMock.Object, manageOrdersServiceMock.Object, userManagerMock.Object, flightRepositoryMock.Object);
        //}
    }
}
