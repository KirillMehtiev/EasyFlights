using System.Collections.Generic;
using EasyFlights.Web.ViewModels;

namespace EasyFlights.Web.Wrappers
{
    public class GetTicketsWrapper
    {
        public string RouteId { get; set; }

        public List<PassengerViewModel> Passengers { get; set; }
    }
}