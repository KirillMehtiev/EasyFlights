using System;

namespace EasyFlights.DomainModel.Identity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
