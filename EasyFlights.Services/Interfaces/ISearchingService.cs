using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Services.Interfaces
{
    /// <summary>
    /// Searches possible routes
    /// </summary>
    public interface ISearchingService
    {
        Task<IEnumerable<RouteDto>> FindRoutesBetweenCitiesAsync(int deaprtureCityId, int destinationCityId, int numberOfPassengers, DateTime departureTime, DateTime? returnTime);
    }
}
