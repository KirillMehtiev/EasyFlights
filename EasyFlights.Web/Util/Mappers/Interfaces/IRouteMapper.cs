using EasyFlights.DomainModel.DTOs;
using EasyFlights.Web.ViewModels;

namespace EasyFlights.Web.Util.Mappers.Interfaces
{
    public interface IRouteMapper
    {
        RouteViewModel MapToRouteViewModel(RouteDto route);

        FlightViewModel MapToFlightViewModel(FlightDto flight);
    }
}