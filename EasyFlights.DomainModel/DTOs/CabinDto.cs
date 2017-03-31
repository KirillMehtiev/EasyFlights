﻿using System.Collections.Generic;

namespace EasyFlights.DomainModel.DTOs
{
    public class CabinDto
    {
        public int RowsCount { get; set; }

        public int SeatsPerRow { get; set; }

        public ICollection<int> BoookedSeats { get; set; }
    }
}
