using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Cabin")]
    public class CabinController : ApiController
    {
        private readonly IFlightService service;

        public CabinController(IFlightService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route]
        public async Task<CabinDto> GetCabin(int flightId = 1)
        {
            CabinDto cabin = await this.service.GetCabinForFlight(flightId);
            return cabin;
        }
    }
}