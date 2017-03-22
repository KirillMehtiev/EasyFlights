using System.Collections.Generic;
using System.Linq;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;
using EasyFlights.WebApi.ApiControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyFlights.WebApi.Tests.ApiControllers
{
    [TestClass]
    public class TypeaheadControllerTest
    {
        [TestMethod]
        public void GetCitiesForTypeahead()
        {
            var mock = new Mock<ITypeaheadProvider<City>>();
            mock.Setup(x => x.GetTypeahead("Nam")).Returns(new List<City>() { new City() { Name = "Name" } });
            var controller = new TypeaheadController(mock.Object);
            var expected = "Name";
            List<City> result = controller.GetCitiesForTypeahead("Nam");
            Assert.IsNotNull(result.FirstOrDefault());
            Assert.AreEqual(expected, result.FirstOrDefault()?.Name);
        }
    }
}
