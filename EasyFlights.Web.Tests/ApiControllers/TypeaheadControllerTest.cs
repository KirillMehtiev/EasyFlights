using System.Collections.Generic;
using System.Linq;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;
using EasyFlights.Web.ApiControllers;
using EasyFlights.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyFlights.WebApi.Tests.ApiControllers
{
    [TestClass]
    public class TypeaheadControllerTest
    {
        [TestMethod]
        public void GetTypeaheadByCityNameAsync()
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            var city = new City() { Name = "Name", Airports = new List<Airport>() };
            var airport = new Airport() { Title = "Ttl" };
            airport.City = city;
            city.Airports.Add(airport);
            mock.Setup(x => x.GetTypeaheadAsync("Nam")).ReturnsAsync(new List<City>() { city });
            var controller = new TypeaheadController(mock.Object);
            var expected = "Ttl";
            List<TypeaheadViewModel> result = controller.GetAirportsForTypeaheadAsync("Nam").Result;
            Assert.AreEqual(expected, result.FirstOrDefault()?.Value);
        }

        [TestMethod]
        public void GetTypeaheadByAirportTitleAsync()
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            var city = new City() { Name = "Name", Airports = new List<Airport>() };
            var airport = new Airport() { Title = "Ttl" };
            airport.City = city;
            city.Airports.Add(airport);
            mock.Setup(x => x.GetTypeaheadAsync("Ttl")).ReturnsAsync(new List<City>() { city });
            var controller = new TypeaheadController(mock.Object);
            var expected = "Ttl";
            List<TypeaheadViewModel> result = controller.GetAirportsForTypeaheadAsync("Ttl").Result;
            Assert.AreEqual(expected, result.FirstOrDefault()?.Value);
        }

        [TestMethod]
        public void GetTypeaheadWithWrongNameAsync()
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            var city = new City() { Name = "Name", Airports = new List<Airport>() };
            var airport = new Airport() { Title = "Ttl" };
            airport.City = city;
            city.Airports.Add(airport);
            mock.Setup(x => x.GetTypeaheadAsync("Name")).ReturnsAsync(new List<City>() { city });
            var controller = new TypeaheadController(mock.Object);
            List<TypeaheadViewModel> result = controller.GetAirportsForTypeaheadAsync("Ttl").Result;
            Assert.IsTrue(result.Count == 0);
        }
    }
}
