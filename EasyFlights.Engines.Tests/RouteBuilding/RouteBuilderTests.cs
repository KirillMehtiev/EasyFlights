using System;
using System.Collections.Generic;
using System.Linq;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyFlights.Engines.Tests.RouteBuilding
{
    [TestClass]
    public partial class RouteBuilderTests
    {
        [TestMethod]
        public void Build_ForFakeGraph_ReturnsAllPossibleRoutes()
        {
            // Arrange
            List<Airport> airports = this.CreateFakeGraph();

            var expectedRoutes = new List<Route>()
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
            IEnumerable<Route> routes = routeBuilder.Build(airports.First(), airports.Last(), DateTime.Today, 1).ToList();

            // Assert
            Assert.AreEqual(expectedRoutes.Count, routes.Count());
            Assert.IsTrue(routes.Any(route => route.Flights.SequenceEqual(expectedRoutes[0].Flights)));
            Assert.IsTrue(routes.Any(route => route.Flights.SequenceEqual(expectedRoutes[1].Flights)));
        }
    }
}
