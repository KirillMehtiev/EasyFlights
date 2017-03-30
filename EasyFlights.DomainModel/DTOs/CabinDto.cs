using System.Collections.Generic;

namespace EasyFlights.DomainModel.DTOs
{
    public class CabinDto
    {
        public int RowCount { get; set; }

        public ICollection<SeatDto> Seats { get; set; }
    }
}
