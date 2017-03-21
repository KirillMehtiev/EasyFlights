﻿namespace EasyFlights.Data.MappingConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using EasyFlights.DomainModel.Entities;

    public class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketConfiguration()
        {
            this.Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Tickets");
            });

            this.HasRequired(ticket => ticket.Passenger);
            this.HasRequired(ticket => ticket.Flight);
            this.HasRequired(ticket => ticket.Order).WithMany(order => order.Tickets);
        }
    }
}
