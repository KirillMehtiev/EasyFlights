using System;
using EasyFlights.DomainModel.Entities.Enums;

namespace EasyFlights.DomainModel.DTOs
{
    public class PassengerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string DocumentNumber { get; set; }

        public Sex Sex { get; set; }
    }
}
