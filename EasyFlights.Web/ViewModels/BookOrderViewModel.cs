using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyFlights.DomainModel.DTOs;

namespace EasyFlights.Web.ViewModels
{
	public class BookOrderViewModel
    {
        public List<TicketDto> Tickets { get; set; }
        public string RouteId { get; set; }
    }
}