using System.Threading.Tasks;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Web.Util.Converters
{
    /// <summary>
    /// Interface allows to convert strings flights and vice versa
    /// </summary>
    public interface IRouteConverter
    {
        /// <summary>
        /// Based on flights create RouteId
        /// RouteId contains a set of flights ids connected by hyphen '-'
        /// </summary>
        /// <param name="route">A route from which routeId will be created.</param>
        /// <returns>RouteId which is create based on flights</returns>
        string ConvertRouteToRouteId(RouteDto route);

        /// <summary>
        /// Based on string return flights which belongs to route
        /// </summary>
        /// <param name="routeId">
        /// Contains a set of flights ids connected by hyphen '-' the sequence of ids is important
        /// </param>
        /// <returns>Flights which belongs to route</returns>
        Task<RouteDto> RestoreRouteFromRouteIdAsync(string routeId);
    }
}
