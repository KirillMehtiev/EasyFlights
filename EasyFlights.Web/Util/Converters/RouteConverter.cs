using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.Data.Repositories.Flights;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;
using EasyFlights.Services.Common;
using EasyFlights.Services.DtoMappers;

namespace EasyFlights.Web.Util.Converters
{
    /// <summary>
    /// Implementation of IRouteConverter
    /// </summary>
    public class RouteConverter : IRouteConverter
    {
        private readonly char delimiter = '-';

        private readonly IFlightsRepository flightsRepository;
        private readonly IRouteGeneralInfoCalculator routeGeneralInfoCalculator;
        private readonly IRouteDtoMapper routeDtoMapper;

        public RouteConverter(IFlightsRepository flightsRepository, IRouteGeneralInfoCalculator routeGeneralInfoCalculator, IRouteDtoMapper routeDtoMapper)
        {
            this.flightsRepository = flightsRepository;
            this.routeGeneralInfoCalculator = routeGeneralInfoCalculator;
            this.routeDtoMapper = routeDtoMapper;
        }

        public string ConvertRouteToRouteId(RouteDto route)
        {
            IEnumerable<int> flightIds = route.Flights.Select(flight => flight.Id);

            string result = string.Empty;
            foreach (int id in flightIds)
            {
                result += $"{id}{this.delimiter}";
            }

            // remove the last delimiter
            result = result.Remove(result.Length - 1);

            return result;
        }

        public async Task<RouteDto> RestoreRouteFromRouteIdAsync(string routeId)
        {
            var route = new Route();
            foreach (string idStr in routeId.Split(this.delimiter))
            {
                int id = Convert.ToInt32(idStr);
                Flight flight = await this.flightsRepository.FindByIdAsync(id);

                Guard.ArgumentValid(flight != null, "mes", nameof(routeId));

                route.Flights.Add(flight);
            }

            decimal totalCost = this.routeGeneralInfoCalculator.GetTotalCost(route);
            TimeSpan totalTime = this.routeGeneralInfoCalculator.GetTotalTime(route);

            return this.routeDtoMapper.Map(route, totalCost, totalTime);
        }
    }
}