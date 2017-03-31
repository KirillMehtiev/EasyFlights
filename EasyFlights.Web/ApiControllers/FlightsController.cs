using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Web.Util.Converters;
using EasyFlights.Web.ViewModels;

namespace EasyFlights.Web.ApiControllers
{
    [RoutePrefix("api/Flights")]
    public class FlightsController : ApiController
    {
        private IRouteConverter converter;

        public FlightsController(IRouteConverter converter)
        {
            this.converter = converter;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<FlightViewModel>> GetFlights([FromUri]string routeId)
        {
            RouteDto routeDto = await converter.RestoreRouteFromRouteIdAsync(routeId);
            var result = new List<FlightViewModel>();
            foreach (FlightDto flight in routeDto.Flights)
            {
                var element = new FlightViewModel()
                {
                    ArrivalTime = flight.ScheduledArrivalTime.ToLongTimeString(),
                    DepartureAirport = flight.DepartureAirportTitle,
                    DepartureTime = flight.ScheduledDepartureTime.ToLongTimeString(),
                    DestinationAirport = flight.DestinationAirportTitle,
                    Duration = DateTime.FromFileTimeUtc(
                        flight.ScheduledArrivalTime.ToFileTimeUtc() - flight.ScheduledDepartureTime.ToFileTimeUtc()).ToShortTimeString(),
                    Fare = flight.DefaultFare,                   
                };
                result.Add(element);
            }
            return result;
        }
    }
}
