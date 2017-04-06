using EasyFlights.DomainModel.DTOs;
using System.Collections.Generic;

namespace EasyFlights.Web.ViewModels
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public List<TicketDto> Tickets { get; set; }
        public string RouteId { get; set; }
    }
}