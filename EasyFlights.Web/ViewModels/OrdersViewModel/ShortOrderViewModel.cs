using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyFlights.Web.ViewModels.OrdersViewModel
{
    public class ShortOrderViewModel
    {
        public int OrderId { get; set; }

        public string DepartureCity { get; set; }

        public string DestinationCity { get; set; }

        public decimal Cost { get; set; }

        public string DateOfOrdering { get; set; }

        public string SetOffDate { get; set; }

        public string Duration { get; set; }
    }
}