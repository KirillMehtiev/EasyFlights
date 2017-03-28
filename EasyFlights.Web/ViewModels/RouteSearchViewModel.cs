using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyFlights.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RouteSearchViewModel
    {
        [Required]
        public int DepartureAirportId { get; set; }

        [Required]
        public int DestinationAirportId { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        public DateTime? ReturnTime { get; set; }
    }
}