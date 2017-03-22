using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public class BaseEntityConfiguration : EntityTypeConfiguration<BaseEntity>
    {
        public BaseEntityConfiguration()
        {
            Property(be => be.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
