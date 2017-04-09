using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyFlights.Web.ViewModels.OrdersViewModel
{
    using EasyFlights.DomainModel.Entities.Enums;

    public class EditOrderPassengerInformationViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public string DocumentNumber { get; set; }

        public Sex Sex { get; set; }

        public IEnumerable<EditOrderTicketViewModel> Tickets { get; set; }
    }
}