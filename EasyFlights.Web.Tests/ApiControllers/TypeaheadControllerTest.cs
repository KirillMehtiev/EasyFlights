using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
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
        public List<TypeaheadViewModel> GetTypeadResult(string testString)
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            if (testString.IsNullOrEmpty())
            {
                mock.Setup(x => x.GetTypeaheadAsync(testString)).ReturnsAsync(new List<City>());
            }
            else
            {
                var city = new City() { Name = "Name", Airports = new List<Airport>() };
                var airport = new Airport() { Title = "Ttl" };
                airport.City = city;
                city.Airports.Add(airport);
                mock.Setup(x => x.GetTypeaheadAsync(testString)).ReturnsAsync(new List<City>() { city });               
            }
            var controller = new TypeaheadController(mock.Object);
            return controller.GetAirportsForTypeaheadAsync(testString).Result;
        }
        [TestMethod]
        public void GetTypeaheadByCityNameAsync()
        {
            var testString = "Nam";
            var expected = "Ttl";
            Assert.AreEqual(expected, GetTypeadResult(testString).FirstOrDefault()?.Value);
        }

        [TestMethod]
        public void GetTypeaheadByAirportTitleAsync()
        {
            var testString = "Ttl";
            var expected = "Ttl";
            Assert.AreEqual(expected, GetTypeadResult(testString).FirstOrDefault()?.Value);
        }

        [TestMethod]
        public void GetTypeaheadWithWrongNameAsync()
        {
            string testString = string.Empty;
            Assert.IsTrue(GetTypeadResult(testString).Count == 0);
        }
    }
}
