using EasyFlights.Data.Repositories.Base;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Web.ApiControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyFlights.WebApi.Tests.ApiControllers
{
    [TestClass]
    public class FlightsControllerTestcs
    {
        [TestMethod]
        public void GetFlightsBySomeId()
        {
            // Initial
            var mock = new Mock<IRepository<Flight>>();
            mock.Setup(x=>x.GetAll()).re
            var controller = new FlightsController();
        }
    }
}
