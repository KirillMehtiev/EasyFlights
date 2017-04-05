using System.Collections.Generic;
using EasyFlights.DomainModel.Entities.Enums;

namespace EasyFlights.Web.ViewModels
{
    public class TicketVIewModel
    {
        public decimal Fare { get; set; }

        public decimal Discount { get; set; }

        public int Seat { get; set; }

        public FlightClass Class { get; set; }

        public List<PassengerViewModel> Passengers { get; set; }
    }
}