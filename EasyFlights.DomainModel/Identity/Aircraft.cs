namespace EasyFlights.DomainModel.Identity
{
    public class Aircraft : BaseEntity
    {
        public string Model { get; set; }
        public int Capacity { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
