using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Airports;
using EasyFlights.Data.Repositories.Cities;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;
using EasyFlights.Services.Services.Searching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyFlights.Services.Tests.Services.Searching
{
    [TestClass]
    public class SearchingServiceTests
    {
        #region FindRoutesBetweenAirportsAsync Tests

        #region FindRoutesBetweenAirportsAsync Ensure Valid Parameters

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenReceivesWrongDepartureAirportId_ThrowsArgumentException()
        {
            // Arrange
            SearchingService service = this.CreateTestObject();

            // Act
            Func<Task> act = async () => await service.FindRoutesBetweenAirportsAsync(-1, 1, 1, DateTime.Now);

            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(act);
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenReceivesWrongDestinationAirportId_ThrowsArgumentException()
        {
            // Arrange
            SearchingService service = this.CreateTestObject();

            // Act
            Func<Task> act = async () => await service.FindRoutesBetweenAirportsAsync(1, -1, 1, DateTime.Now);

            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(act);
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenReceivesWrongNumberOfPeople_ThrowsArgumentException()
        {
            // Arrange
            SearchingService service = this.CreateTestObject();

            // Act
            Func<Task> act = async () => await service.FindRoutesBetweenAirportsAsync(1, 1, -1, DateTime.Now);

            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(act);
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenAirportDoesNotExist_ThrowsArgumentException()
        {
            // Arrange
            Airport airport = null;
            var mockRepository = new Mock<IAirportsRepository>();
            mockRepository.Setup(mock => mock.FindByIdAsync(It.IsAny<int>())).ReturnsAsync(airport);

            SearchingService service = this.CreateTestObject(mockRepository);

            // Act
            Func<Task> act = async () => await service.FindRoutesBetweenAirportsAsync(1, 1, 1, DateTime.Now);

            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(act);
        }

        #endregion

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenReceivesValidParams_CallsIRouteBuilderBuildAsyncMethod()
        {
            // Arrange
            int departureAirportId = 1;
            int destinationAirportId = 2;
            int numberOfPeople = 1;
            var departureAirport = new Airport();
            var destinationAiport = new Airport();
            var dateTime = DateTime.Now;

            var mockRepository = new Mock<IAirportsRepository>();
            mockRepository
                .Setup(mock => mock.FindByIdAsync(It.Is<int>(p => p == departureAirportId)))
                .ReturnsAsync(departureAirport);
            mockRepository
                .Setup(mock => mock.FindByIdAsync(It.Is<int>(p => p == destinationAirportId)))
                .ReturnsAsync(destinationAiport);

            var mockRouteBuilder = new Mock<IRouteBuilder>();

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder);

            // Act
            IEnumerable<RouteDto> result = await service.FindRoutesBetweenAirportsAsync(departureAirportId, destinationAirportId, numberOfPeople, dateTime);

            // Assert
            mockRouteBuilder.Verify(mock => mock.BuildAsync(departureAirport, destinationAiport, dateTime, numberOfPeople), Times.Once());
        }

        #endregion


        #region Helper Methods

        private SearchingService CreateTestObject(Mock<IAirportsRepository> mockRepository = null, Mock<IRouteBuilder> mockRouteBuilder = null)
        {
            return new SearchingService(mockRepository?.Object, mockRouteBuilder?.Object);
        }

        #endregion
    }
}
