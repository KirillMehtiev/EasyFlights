using System;
using System.Collections.Generic;
using System.Linq;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Web.ApiControllers;
using EasyFlights.Web.Util.Converters;
using EasyFlights.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyFlights.WebApi.Tests.ApiControllers
{
    [TestClass]
    public class FlightsControllerTestcs
    {
        [TestMethod]
        public void GetFlightsBySomeId()
        {
            // Arrange
            var mock = new Mock<IRouteConverter>();
            mock.Setup(x => x.ConvertRouteIdToFlights("id")).Returns(new List<FlightDto>
            {
                new FlightDto()
                {
                    Aircraft = new AircraftDto(), DefaultFare = 100,
                    DepartureAirportTitle = "Departure",
                    DestinationAirportTitle = "Destination",
                    Duration = TimeSpan.FromHours(3),
                    ScheduledDepartureTime = DateTime.Now.AddHours(2),
                    ScheduledArrivalTime = DateTime.Now.AddHours(5)
                }
            });
            var ctrl = new FlightsController(mock.Object);

            // Act
            var expected = "Destination";
            List<FlightViewModel> flights = ctrl.GetFlights("id");
            string result = flights.FirstOrDefault()?.DestinationAirport;

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
