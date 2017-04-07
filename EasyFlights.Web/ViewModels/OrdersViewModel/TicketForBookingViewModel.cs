using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyFlights.DomainModel.DTOs;
using EasyFlights.DomainModel.Entities.Enums;

namespace EasyFlights.Web.ViewModels.OrdersViewModels
{
	public class TicketForBookingViewModel
    {
        public int FlightId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string DocumentNumber { get; set; }

        public Sex Sex { get; set; }

        public int Seat { get; set; }
    }
}