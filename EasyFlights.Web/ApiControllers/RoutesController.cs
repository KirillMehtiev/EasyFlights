using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.Services.Interfaces;
using EasyFlights.Web.Util.Converters;
using EasyFlights.Web.ViewModels;

namespace EasyFlights.Web.ApiControllers
{
    public class RoutesController : ApiController
    {
        private const string DateFormat = "D";
        private const string DurationFormat = @"dd\.hh\:mm";

        private readonly ISearchingService searchingService;
        private readonly IRouteConverter routeConverter;

        public RoutesController(ISearchingService searchingService, IRouteConverter routeConverter)
        {
            this.searchingService = searchingService;
            this.routeConverter = routeConverter;
        }

        // GET api/<controller>
        public async Task<IEnumerable<RouteViewModel>> GetAsync([FromUri] RouteSearchViewModel search)
        {
            IEnumerable<RouteDto> routes = await searchingService.FindRoutesBetweenAirportsAsync(
                search.DepartureAirportId,
                search.DestinationAirportId,
                search.NumberOfPeople,
                search.DepartureTime,
                search.ReturnTime);

            IEnumerable<RouteViewModel> result = routes.Select(MapToRouteViewModel);

            return result;
        }

        private RouteViewModel MapToRouteViewModel(RouteDto route)
        {
            var routeViewModel = new RouteViewModel();
            FlightDto firstFlight = route.Flights.FirstOrDefault();
            FlightDto lastFlight = route.Flights.LastOrDefault();

            routeViewModel.TotalCoast = route.TotalCost;
            routeViewModel.TotalTime = route.TotalTime.ToString(DurationFormat);
            routeViewModel.Flights = route.Flights.Select(MapToFlightViewModel);
            routeViewModel.Id = routeConverter.ConvertRouteToRouteId(route);

            if (firstFlight != null)
            {
                routeViewModel.DeparturePlace = firstFlight.DepartureAirportTitle;
                routeViewModel.DepartureTime = firstFlight.ScheduledDepartureTime.ToString(DateFormat);
            }
            if (lastFlight != null)
            {
                routeViewModel.ArrivalTime = lastFlight.ScheduledArrivalTime.ToString(DateFormat);
                routeViewModel.DestinationPlace = lastFlight.DestinationAirportTitle;
            }

            return routeViewModel;
        }

        private FlightViewModel MapToFlightViewModel(FlightDto flight)
        {
            return new FlightViewModel
            {
                DepartureAirport = flight.DepartureAirportTitle,
                DestinationAirport = flight.DestinationAirportTitle,
                ArrivalTime = flight.ScheduledArrivalTime.ToString(DateFormat),
                DepartureTime = flight.ScheduledDepartureTime.ToString(DateFormat),
                Duration = flight.Duration.ToString(DurationFormat),
                Fare = flight.DefaultFare
            };
        }
    }
}