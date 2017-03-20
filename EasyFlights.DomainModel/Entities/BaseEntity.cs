using System;

namespace EasyFlights.DomainModel.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
