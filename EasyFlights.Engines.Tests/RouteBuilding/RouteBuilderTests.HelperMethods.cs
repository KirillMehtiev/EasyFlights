using EasyFlights.Engines.Infrastructure;
using EasyFlights.Engines.RouteBuilding;
using Moq;

namespace EasyFlights.Engines.Tests.RouteBuilding
{
    public partial class RouteBuilderTests
    {
        private RouteBuilder CreateTestObject()
        {
            var mockAppSettings = new Mock<IAppSettings>();
            mockAppSettings
                .SetupGet(mock => mock.MaxAmountOfHoursToWaitFlight)
                .Returns(24.0);
            mockAppSettings
               .SetupGet(mock => mock.MinAmountOfHoursToWaitFlight)
               .Returns(0.5);

            return new RouteBuilder(mockAppSettings.Object);
        }
    }
}
