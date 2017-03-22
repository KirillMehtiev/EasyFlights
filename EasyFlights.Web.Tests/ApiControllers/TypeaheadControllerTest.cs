using System.Collections.Generic;
using System.Linq;
using EasyFlights.DomainModel.DTOs;
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
            var mock = new Mock<ITypeaheadProvider<CityDto>>();
            mock.Setup(x => x.GetTypeahead("Nam")).Returns(new List<CityDto>() { new CityDto() { Name = "Name" } });
            var controller = new TypeaheadController(mock.Object);
            var expected = "Name";
            List<CityDto> result = controller.GetCitiesForTypeahead("Nam");
            Assert.AreEqual(expected, result.FirstOrDefault()?.Name);
        }
    }
}
