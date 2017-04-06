using System;
using System.Collections.Generic;
using EasyFlights.DomainModel.Entities.Enums;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.DomainModel.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Sex? Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
