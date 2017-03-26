using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class PassengerConfiguration : BaseEntityConfiguration<Passenger>
    {
        public PassengerConfiguration()
        {
            Property(p => p.FirstName).IsRequired();
            Property(p => p.LastName).IsRequired();
            Property(p => p.DocumentNumber).IsRequired();
        }
    }
}
