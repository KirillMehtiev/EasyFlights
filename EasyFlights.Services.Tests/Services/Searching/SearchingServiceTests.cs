using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Airports;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;
using EasyFlights.Services.DtoMappers;
using EasyFlights.Services.Services.Searching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyFlights.Services.Tests.Services.Searching
{
    [TestClass]
    public partial class SearchingServiceTests
    {
        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenReceivesValidParams_CallsIRouteBuilderBuildAsyncMethod()
        {
            // Arrange
            var departureAirport = new Airport();
            var destinationAiport = new Airport();
            var departureAirportId = 1;
            var destinationAirportId = 2;
            var numberOfPeople = 1;
            DateTime dateTime = DateTime.Now;

            Mock<IAirportsRepository> mockRepository = this.CreateMockRepository(departureAirportId, destinationAirportId, departureAirport, destinationAiport);
            Mock<IRouteBuilder> mockRouteBuilder = this.CreateMockRouteBuilder();

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder);

            // Act
            await service.FindRoutesBetweenAirportsAsync(departureAirportId, destinationAirportId, numberOfPeople, dateTime);

            // Assert
            mockRouteBuilder.Verify(mock => mock.Build(departureAirport, destinationAiport, dateTime, numberOfPeople), Times.Once());
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenReceivesValidReturnDate_CallsIRouteBuilderBuildAsyncMethodTwiceAndUniteRoutes()
        {
            // Arrange
            var departureAirport = new Airport();
            var destinationAiport = new Airport();
            var departureAirportId = 1;
            var destinationAirportId = 2;
            var numberOfPeople = 1;
            DateTime departureDateTime = DateTime.Now;
            DateTime returnDateTime = departureDateTime.AddDays(1);

            var countOfFakeRoutes = 2;
            IEnumerable<Route> fakeRoutes = this.CreateFakeRoutes(countOfFakeRoutes);

            Mock<IAirportsRepository> mockRepository = this.CreateMockRepository(departureAirportId, destinationAirportId, departureAirport, destinationAiport);

            Mock<IRouteBuilder> mockRouteBuilder = this.CreateMockRouteBuilder(fakeRoutes);

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder);

            // Act
            IEnumerable<RouteDto> result = await service.FindRoutesBetweenAirportsAsync(departureAirportId, destinationAirportId, numberOfPeople, departureDateTime, returnDateTime);

            // Assert
            mockRouteBuilder.Verify(mock => mock.Build(departureAirport, destinationAiport, departureDateTime, numberOfPeople), Times.Once());
            mockRouteBuilder.Verify(mock => mock.Build(destinationAiport, departureAirport, returnDateTime, numberOfPeople), Times.Once());

            Assert.AreEqual(countOfFakeRoutes * 2, result.Count());
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenIRouteBuilderCannotBuildDirectRoute_ThrowsInvalidOperationException()
        {
            // Arrange
            var departureAirportId = 1;
            var destinationAirportId = 2;
            var numberOfPeople = 1;
            DateTime departureDateTime = DateTime.Now;
            DateTime returnDateTime = departureDateTime.AddDays(1);

            var countOfFakeRoutes = 0;
            IEnumerable<Route> fakeRoutes = this.CreateFakeRoutes(countOfFakeRoutes);

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
            DateTime departureDateTime = DateTime.Now;
            DateTime returnDateTime = departureDateTime.AddDays(1);

            var mockRouteBuilder = new Mock<IRouteBuilder>();
            mockRouteBuilder
                .SetupSequence(mock => mock.Build(It.IsAny<Airport>(), It.IsAny<Airport>(), It.IsAny<DateTime>(), It.IsAny<int>()))
                .Returns(this.CreateFakeRoutes(2))
                .Returns(this.CreateFakeRoutes(0));

            Mock<IAirportsRepository> mockRepository = this.CreateMockRepository();

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder);

            // Act
            Func<Task> act = async () => await service.FindRoutesBetweenAirportsAsync(1, 2, 1, departureDateTime, returnDateTime);

            // Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(act);
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenRoutesAreFound_CallsIRouteGeneralInfoCalculatorForEachRoute()
        {
            // Arrange
            var numberOfRoutes = 2;
            IEnumerable<Route> fakeRoutes = this.CreateFakeRoutes(numberOfRoutes);

            Mock<IRouteBuilder> mockRouteBuilder = this.CreateMockRouteBuilder(fakeRoutes);
            Mock<IAirportsRepository> mockRepository = this.CreateMockRepository();
            Mock<IRouteGeneralInfoCalculator> mockRouteGeneralInfoCalculator = this.CreateMockRouteGeneralInfoCalculator();

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder, mockRouteGeneralInfoCalculator);

            // Act
            await service.FindRoutesBetweenAirportsAsync(1, 1, 1, DateTime.Now);

            // Assert
            mockRouteGeneralInfoCalculator.Verify(mock => mock.GetTotalCost(It.IsAny<Route>()), Times.Exactly(numberOfRoutes));
            mockRouteGeneralInfoCalculator.Verify(mock => mock.GetTotalTime(It.IsAny<Route>()), Times.Exactly(numberOfRoutes));
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenRoutesAreFound_CallsIRouteDtoMapperForEachRoute()
        {
            // Arrange
            var numberOfRoutes = 2;
            IEnumerable<Route> fakeRoutes = this.CreateFakeRoutes(numberOfRoutes);

            Mock<IRouteBuilder> mockRouteBuilder = this.CreateMockRouteBuilder(fakeRoutes);
            Mock<IAirportsRepository> mockRepository = this.CreateMockRepository();
            Mock<IRouteGeneralInfoCalculator> mockRouteGeneralInfoCalculator = this.CreateMockRouteGeneralInfoCalculator();
            var mockRouteDtoMapper = new Mock<IRouteDtoMapper>();

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder, mockRouteGeneralInfoCalculator, mockRouteDtoMapper);

            // Act
            await service.FindRoutesBetweenAirportsAsync(1, 1, 1, DateTime.Now);

            // Assert
            mockRouteDtoMapper.Verify(mock => mock.Map(It.IsAny<Route>(), It.IsAny<decimal>(), It.IsAny<TimeSpan>()), Times.Exactly(numberOfRoutes));
        }
    }
}
