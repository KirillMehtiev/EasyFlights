using System;
using System.Collections.Generic;
using EasyFlights.Data.Repositories.Airports;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;
using EasyFlights.Services.Services.Searching;
using Moq;

namespace EasyFlights.Services.Tests.Services.Searching
{
    public partial class SearchingServiceTests
    {
        private SearchingService CreateTestObject(Mock<IAirportsRepository> mockRepository = null, Mock<IRouteBuilder> mockRouteBuilder = null)
        {
            if (mockRepository == null)
            {
                mockRepository = this.CreateMockRepository();
            }
            if (mockRouteBuilder == null)
            {
                mockRouteBuilder = this.CreateMockRouteBuilder();
            }

            return new SearchingService(mockRepository.Object, mockRouteBuilder.Object);
        }

        private Mock<IAirportsRepository> CreateMockRepository(int? departureAirportId = null, int? destinationAirportId = null, Airport departureAirport = null, Airport destinationAiport = null)
        {
            if (departureAirportId == null)
            {
                departureAirportId = 1;
            }
            if (destinationAirportId == null)
            {
                destinationAirportId = 2;
            }
            if (departureAirport == null)
            {
                departureAirport = new Airport();
            }
            if (destinationAiport == null)
            {
                destinationAiport = new Airport();
            }

            var mockRepository = new Mock<IAirportsRepository>();
            mockRepository
                .Setup(mock => mock.FindByIdAsync(It.Is<int>(p => p == departureAirportId)))
                .ReturnsAsync(departureAirport);
            mockRepository
                .Setup(mock => mock.FindByIdAsync(It.Is<int>(p => p == destinationAirportId)))
                .ReturnsAsync(destinationAiport);

            return mockRepository;
        }

        private Mock<IRouteBuilder> CreateMockRouteBuilder(IEnumerable<Route> fakeRoutes = null)
        {
            if (fakeRoutes == null)
            {
                fakeRoutes = this.CreateFakeRoutes(1);
            }

            var mockRouteBuilder = new Mock<IRouteBuilder>();
            mockRouteBuilder
                .Setup(mock => mock.BuildAsync(It.IsAny<Airport>(), It.IsAny<Airport>(), It.IsAny<DateTime>(), It.IsAny<int>()))
                .ReturnsAsync(fakeRoutes);

            return mockRouteBuilder;
        }

        private IEnumerable<Route> CreateFakeRoutes(int count)
        {
            var result = new List<Route>();

            for (int i = 0; i < count; i++)
            {
                result.Add(new Route()
                {
                    Flights = new List<Flight>()
                    {
                        new Flight()
                        {
                            DepartureAirport = new Airport(),
                            DestinationAirport = new Airport()
                        }
                    }
                });
            }

            return result;
        }
    }
}
