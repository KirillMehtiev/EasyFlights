using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Airports;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;
using EasyFlights.Services.Services.Searching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyFlights.Services.Tests.Services.Searching
{
    [TestClass]
    public partial class SearchingServiceTests
    {
        #region FindRoutesBetweenAirportsAsync Tests


        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenReceivesValidParams_CallsIRouteBuilderBuildAsyncMethod()
        {
            // Arrange
            var departureAirport = new Airport();
            var destinationAiport = new Airport();
            int departureAirportId = 1;
            int destinationAirportId = 2;
            int numberOfPeople = 1;
            DateTime dateTime = DateTime.Now;

            Mock<IAirportsRepository> mockRepository = this.CreateMockRepository(departureAirportId, destinationAirportId, departureAirport, destinationAiport);
            var mockRouteBuilder = this.CreateMockRouteBuilder();

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder);

            // Act
            IEnumerable<RouteDto> result = await service.FindRoutesBetweenAirportsAsync(departureAirportId, destinationAirportId, numberOfPeople, dateTime);

            // Assert
            mockRouteBuilder.Verify(mock => mock.BuildAsync(departureAirport, destinationAiport, dateTime, numberOfPeople), Times.Once());
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenReceivesValidReturnDate_CallsIRouteBuilderBuildAsyncMethodTwiceAndUniteRoutes()
        {
            // Arrange
            var departureAirport = new Airport();
            var destinationAiport = new Airport();
            int departureAirportId = 1;
            int destinationAirportId = 2;
            int numberOfPeople = 1;
            DateTime departureDateTime = DateTime.Now;
            DateTime returnDateTime = departureDateTime.AddDays(1);

            int countOfFakeRoutes = 2;
            var fakeRoutes = this.CreateFakeRoutes(countOfFakeRoutes);

            Mock<IAirportsRepository> mockRepository = this.CreateMockRepository(departureAirportId, destinationAirportId, departureAirport, destinationAiport);

            var mockRouteBuilder = this.CreateMockRouteBuilder(fakeRoutes);

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder);

            // Act
            IEnumerable<RouteDto> result = await service.FindRoutesBetweenAirportsAsync(departureAirportId, destinationAirportId, numberOfPeople, departureDateTime, returnDateTime);

            // Assert
            mockRouteBuilder.Verify(mock => mock.BuildAsync(departureAirport, destinationAiport, departureDateTime, numberOfPeople), Times.Once());
            mockRouteBuilder.Verify(mock => mock.BuildAsync(destinationAiport, departureAirport, returnDateTime, numberOfPeople), Times.Once());

            Assert.AreEqual(countOfFakeRoutes * 2, result.Count());
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenIRouteBuilderCannotBuildDirectRoute_ThrowsInvalidOperationException()
        {
            // Arrange
            int departureAirportId = 1;
            int destinationAirportId = 2;
            int numberOfPeople = 1;
            DateTime departureDateTime = DateTime.Now;
            DateTime returnDateTime = departureDateTime.AddDays(1);

            int countOfFakeRoutes = 0;
            var fakeRoutes = this.CreateFakeRoutes(countOfFakeRoutes);

            Mock<IRouteBuilder> mockRouteBuilder = this.CreateMockRouteBuilder(fakeRoutes);
            Mock<IAirportsRepository> mockRepository = this.CreateMockRepository();

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder);

            // Act
            Func<Task> act = async () => await service.FindRoutesBetweenAirportsAsync(departureAirportId, destinationAirportId, numberOfPeople, departureDateTime, returnDateTime);

            // Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(act);
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenIRouteBuilderCannotBuildReverseRoute_ThrowsInvalidOperationException()
        {
            // Arrange
            int departureAirportId = 1;
            int destinationAirportId = 2;
            int numberOfPeople = 1;
            DateTime departureDateTime = DateTime.Now;
            DateTime returnDateTime = departureDateTime.AddDays(1);

            var mockRouteBuilder = new Mock<IRouteBuilder>();
            mockRouteBuilder
                .SetupSequence(mock => mock.BuildAsync(It.IsAny<Airport>(), It.IsAny<Airport>(), It.IsAny<DateTime>(), It.IsAny<int>()))
                .ReturnsAsync(this.CreateFakeRoutes(2))
                .ReturnsAsync(this.CreateFakeRoutes(0));

            Mock<IAirportsRepository> mockRepository = this.CreateMockRepository();

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder);

            // Act
            Func<Task> act = async () => await service.FindRoutesBetweenAirportsAsync(departureAirportId, destinationAirportId, numberOfPeople, departureDateTime, returnDateTime);

            // Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(act);
        }

        #endregion
    }
}
