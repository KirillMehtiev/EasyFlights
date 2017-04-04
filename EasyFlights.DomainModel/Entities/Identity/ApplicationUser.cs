using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyFlights.DomainModel.Entities.Enums;
using Microsoft.AspNet.Identity;
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            userIdentity.AddClaim(new Claim("lastname", LastName));
            userIdentity.AddClaim(new Claim("firstname", FirstName));
            userIdentity.AddClaim(new Claim("sex", Sex.ToString()));
            userIdentity.AddClaim(new Claim("dateofbirth", DateOfBirth?.ToString(CultureInfo.InvariantCulture)));

            // Add custom user claims here
            return userIdentity;
        }
    }
}
