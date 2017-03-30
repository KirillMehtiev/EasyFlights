namespace EasyFlights.DomainModel.Entities
{
    public class Aircraft : BaseEntity
    {
        public string Model { get; set; } 

        public int Capacity { get; set; }

        public int Row { get; set; }
    }
}
