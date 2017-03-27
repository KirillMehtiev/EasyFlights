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
        public void GetTypeaheadByCityName()
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            var city = new City() { Name = "Name", Airports = new List<Airport>() };
            var airport = new Airport() { Title = "Ttl" };
            airport.City = city;
            city.Airports.Add(airport);
            mock.Setup(x => x.GetTypeahead("Nam")).Returns(new List<City>() { city });
            var controller = new TypeaheadController(mock.Object);
            var expected = "Name";
            List<AirportViewModel> result = controller.GetAirportsForTypeahead("Nam");
            Assert.AreEqual(expected, result.FirstOrDefault()?.City);
        }

        [TestMethod]
        public void GetTypeaheadByAirportTitle()
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            var city = new City() { Name = "Name", Airports = new List<Airport>() };
            var airport = new Airport() { Title = "Ttl" };
            airport.City = city;
            city.Airports.Add(airport);
            mock.Setup(x => x.GetTypeahead("Ttl")).Returns(new List<City>() { city });
            var controller = new TypeaheadController(mock.Object);
            var expected = "Name";
            List<AirportViewModel> result = controller.GetAirportsForTypeahead("Ttl");
            Assert.AreEqual(expected, result.FirstOrDefault()?.City);
        }

        [TestMethod]
        public void GetTypeaheadWithWrongName()
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            var city = new City() { Name = "Name", Airports = new List<Airport>() };
            var airport = new Airport() { Title = "Ttl" };
            airport.City = city;
            city.Airports.Add(airport);
            mock.Setup(x => x.GetTypeahead("Name")).Returns(new List<City>() { city });
            var controller = new TypeaheadController(mock.Object);
            List<AirportViewModel> result = controller.GetAirportsForTypeahead("Ttl");
            Assert.IsTrue(result.Count == 0);
        }
        [TestMethod]
        public async void GetTypeaheadByCityNameAsync()
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            var city = new City() { Name = "Name", Airports = new List<Airport>() };
            var airport = new Airport() { Title = "Ttl" };
            airport.City = city;
            city.Airports.Add(airport);
            mock.Setup(x => x.GetTypeaheadAsync("Nam")).ReturnsAsync(new List<City>() { city });
            var controller = new TypeaheadController(mock.Object);
            var expected = "Name";
            List<AirportViewModel> result = await controller.GetAirportsForTypeaheadAsync("Nam");
            Assert.AreEqual(expected, result.FirstOrDefault()?.City);
        }

        [TestMethod]
        public async void GetTypeaheadByAirportTitleAsync()
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            var city = new City() { Name = "Name", Airports = new List<Airport>() };
            var airport = new Airport() { Title = "Ttl" };
            airport.City = city;
            city.Airports.Add(airport);
            mock.Setup(x => x.GetTypeaheadAsync("Ttl")).ReturnsAsync(new List<City>() { city });
            var controller = new TypeaheadController(mock.Object);
            var expected = "Name";
            List<AirportViewModel> result = await controller.GetAirportsForTypeaheadAsync("Ttl");
            Assert.AreEqual(expected, result.FirstOrDefault()?.City);
        }

        [TestMethod]
        public async void GetTypeaheadWithWrongNameAsync()
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            var city = new City() { Name = "Name", Airports = new List<Airport>() };
            var airport = new Airport() { Title = "Ttl" };
            airport.City = city;
            city.Airports.Add(airport);
            mock.Setup(x => x.GetTypeaheadAsync("Name")).ReturnsAsync(new List<City>() { city });
            var controller = new TypeaheadController(mock.Object);
            List<AirportViewModel> result = await controller.GetAirportsForTypeaheadAsync("Ttl");
            Assert.IsTrue(result.Count == 0);
        }
    }
}
