using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyFlights.Engines.Tests.RouteBuilding
{
    [TestClass]
    public partial class RouteBuilderTests
    {
        #region Build Tests

        [TestMethod]
        public async Task Build_ForFakeGraph_ReturnsAllPossibleRoutes()
        {
            // Arrange
            List<Airport> airports = this.CreateFakeGraph();

            List<Route> expectedRoutes = new List<Route>()
            {
                new Route()
                {
                    Flights = new List<Flight>()
                    {
                        // A -> C -> E -> F
                        airports[0].Flights.ElementAt(1), airports[2].Flights.ElementAt(1), airports[4].Flights.ElementAt(1)
                    }
                },
                new Route()
                {
                    Flights = new List<Flight>()
                    {
                        // A -> B -> E -> F
                        airports[0].Flights.ElementAt(0), airports[1].Flights.ElementAt(1), airports[4].Flights.ElementAt(1)
                    }
                }
            };

            RouteBuilder routeBuilder = this.CreateTestObject();

            // Act 
            IEnumerable<Route> routes = await routeBuilder.BuildAsync(airports.First(), airports.Last(), DateTime.Today, 1);

            // Assert
            Assert.AreEqual(expectedRoutes.Count, routes.Count());
        }

        #endregion
    }
}
