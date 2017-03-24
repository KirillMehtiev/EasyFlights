using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFlights.Services.Services.Searching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyFlights.Services.Tests.Services.Searching
{
    [TestClass]
    public class SearchingServiceTests
    {
        #region FindRoutesBetweenAirportsAsync Tests

        [TestMethod]
        public void FindRoutesBetweenAirportsAsync__()
        {
            // Arrange

            // Act

            // Assert
        }

        #endregion


        #region Helper Methods

        private SearchingService CreateTestObject()
        {
            return new SearchingService(null, null);
        }

        #endregion
    }
}
