using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyFlights.Web.Util.Converters;

namespace EasyFlights.WebApi.Tests.Util.Convertors
{
    using EasyFlights.DomainModel.DTOs;
    using EasyFlights.DomainModel.Entities;

    [TestClass]
    class RouteConverterTests
    {
        private readonly IRouteConverter routeConverter;

        public RouteConverterTests(IRouteConverter routeConverter)
        {
            this.routeConverter = routeConverter;
        }

        [TestMethod]
        public void ConvertRouteToRouteId_CreateExpectedId()
        {
            // Arrange
            var flights = new List<FlightDto>() { new FlightDto() { Id = 1 }, new FlightDto() { Id = 2 } };
            var route = new RouteDto()
            {
                Flights = flights
            };
            var expectedId = "1-2";

            // Act
            var createdId = this.routeConverter.ConvertRouteToRouteId(route);

            // Assert
            Assert.AreEqual(expectedId, createdId);
        }

        [TestMethod]
        public void RestoreRouteFromRouteIdAsync_RestoreExpectedRoute()
        {

        }
    }
}

