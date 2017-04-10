using System;
using System.Collections.Generic;
using System.Linq;
using EasyFlights.DomainModel.Entities.Enums;
using System.Web;

namespace EasyFlights.Web.ViewModels.OrdersViewModel
{
    public class DetailedTicketViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public string DocumentNumber { get; set; }

        public Sex Sex { get; set; }

        public int Seat { get; set; }

        public decimal Price { get; set; }

        public string DeparturePlace { get; set; }

        public string DestinationPlace { get; set; }

        public string DepartureDate { get; set; }

        public string Duration { get; set; }

        public string ArrivalTime { get; set; }
    }
}