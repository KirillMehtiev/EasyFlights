using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Web.Util.Converters
{
    using System.Text;

    /// <summary>
    /// Implementation of IRouteConverter
    /// </summary>
    public class RouteConverter : IRouteConverter
    {
        public string ConvertFlightsToRoutId(IEnumerable<FlightDto> flights)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FlightDto> ConvertRouteIdToFlights(string routeId)
        {
            throw new NotImplementedException();
        }
    }
}