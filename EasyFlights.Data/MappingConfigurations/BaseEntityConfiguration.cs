using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Data.MappingConfigurations
{
    public abstract class BaseEntityConfiguration<TEntityType> : EntityTypeConfiguration<TEntityType>
        where TEntityType: BaseEntity
    {
        protected BaseEntityConfiguration()
        {
            Property(be => be.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
