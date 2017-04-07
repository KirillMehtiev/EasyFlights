using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Enums;

namespace EasyFlights.Web.ViewModels.OrdersViewModels
{
	public class BookOrderViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public string DocumentNumber { get; set; }
        public Sex Sex { get; set; }

        public List<TicketViewModel> Tickets { get; set; }

        public string RouteId { get; set; }
    }
}