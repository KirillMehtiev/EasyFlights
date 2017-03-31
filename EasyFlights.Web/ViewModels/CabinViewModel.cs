using System.Collections.Generic;

namespace EasyFlights.Web.ViewModels
{
    public class CabinViewModel
    {
        public int RowsCount { get; set; }

        public int SeatsPerRow { get; set; }

        public int[] BoookedSeats { get; set; }
    }
}