using System;
using System.Collections.Generic;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyFlights.Engines.Tests.RouteBuilding
{
    [TestClass]
    public class RouteGeneralInfoCalculatorTests
    {
        [TestMethod]
        public void GetTotalCost_ForGivenRoute_ReturnsTotalCost()
        {
            // Arrange
            Route fakeRoute = this.CreateFakeRoute();
            decimal expectedTotalCost = 10 + 15;

            var routeGeneralInfoCalculator = new RouteGeneralInfoCalculator();

            // Act
            var result = routeGeneralInfoCalculator.GetTotalCost(fakeRoute);

            // Assert
            Assert.AreEqual(expectedTotalCost, result);
        }

        [TestMethod]
        public void GetTotalTime_ForGivenRoute_ReturnsTotalTime()
        {
            // Arrange
            Route fakeRoute = this.CreateFakeRoute();
            TimeSpan expectedTotalTime = TimeSpan.FromHours((15 - 13) + 12);

            var routeGeneralInfoCalculator = new RouteGeneralInfoCalculator();

            // Act
            var result = routeGeneralInfoCalculator.GetTotalTime(fakeRoute);

            // Assert
            bool calculatedTotalTimeIsApproximatelyTheSameAsExpected = Math.Abs((expectedTotalTime - result).Minutes) < 0.001;
            Assert.IsTrue(calculatedTotalTimeIsApproximatelyTheSameAsExpected);
        }

        private Route CreateFakeRoute()
        {
            return new Route()
            {
                Flights = new List<Flight>()
                {
                    new Flight()
                    {
                        DepartureAirport = new Airport(),
                        DestinationAirport = new Airport(),
                        DefaultFare = 10,
                        ScheduledDepartureTime = DateTime.Now,
                        ScheduledArrivalTime = DateTime.Now.AddHours(12)
                    },
                    new Flight()
                    {
                        DepartureAirport = new Airport(),
                        DestinationAirport = new Airport(),
                        DefaultFare = 15,
                        ScheduledDepartureTime = DateTime.Now.AddHours(13),
                        ScheduledArrivalTime = DateTime.Now.AddHours(15)
                    }
                }
            };
        }
    }
}
