namespace EasyFlights.DomainModel
{
    public class Aircraft : BaseEntity
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
    }
}
