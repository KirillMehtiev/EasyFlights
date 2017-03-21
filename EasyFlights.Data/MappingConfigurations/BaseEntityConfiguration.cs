namespace EasyFlights.Data.MappingConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using EasyFlights.DomainModel.Entities;

    class BaseEntityConfiguration : EntityTypeConfiguration<BaseEntity>
    {
        BaseEntityConfiguration()
        {
            this.Property(be => be.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
