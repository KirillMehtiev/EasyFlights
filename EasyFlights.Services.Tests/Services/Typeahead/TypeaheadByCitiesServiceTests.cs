using System.Collections.Generic;
using EasyFlights.DomainModel.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyFlights.Services.Tests.Services.Typeahead
{
    [TestClass]
    public class TypeaheadByCitiesServiceTests
    {
        [TestMethod]
        public void GetTypeahead()
        {
            var mock=new Mock<IRepository<City>>();
        }
    }
}
