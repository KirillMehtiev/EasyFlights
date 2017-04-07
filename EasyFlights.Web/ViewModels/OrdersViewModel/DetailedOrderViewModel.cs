using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyFlights.Web.ViewModels.OrdersViewModel
{
    public class DetailedOrderViewModel
    {
        public string OrderedDate { get; set; }

        public IEnumerable<DetailedTicketViewModel> Tickets { get; set; }
    }
}