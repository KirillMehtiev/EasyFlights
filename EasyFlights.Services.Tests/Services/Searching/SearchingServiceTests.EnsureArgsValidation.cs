using System;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Airports;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Services.Searching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyFlights.Services.Tests.Services.Searching
{
    public partial class SearchingServiceTests
    {
        #region FindRoutesBetweenAirportsAsync Tests

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
            Airport none = null;
            int departureAirportId = 1;
            int destinationAirportId = 2;
            int numberOfPeople = 1;

            var mockRepository = new Mock<IAirportsRepository>();
            mockRepository
                .Setup(mock => mock.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(none);

            SearchingService service = this.CreateTestObject(mockRepository);

            // Act
            Func<Task> act = async () => await service.FindRoutesBetweenAirportsAsync(departureAirportId, destinationAirportId, numberOfPeople, DateTime.Now);

            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(act);
        }

        [TestMethod]
        public async Task FindRoutesBetweenAirportsAsync_WhenReturnDateIsBeforeDepartureDate_ThrowsArgumentException()
        {
            // Arrange
            int departureAirportId = 1;
            int destinationAirportId = 2;
            int numberOfPeople = 1;
            DateTime departureDateTime = DateTime.Now;
            DateTime returnDateTime = departureDateTime.Subtract(TimeSpan.FromDays(1));

            Mock<IAirportsRepository> mockRepository = this.CreateMockRepository();
            var mockRouteBuilder = this.CreateMockRouteBuilder();

            SearchingService service = this.CreateTestObject(mockRepository, mockRouteBuilder);

            // Act
            Func<Task> act = async () => await service.FindRoutesBetweenAirportsAsync(departureAirportId, destinationAirportId, numberOfPeople, departureDateTime, returnDateTime);

            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(act);
        }

        #endregion
    }
}
