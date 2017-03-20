using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.DomainModel.Identity
{
    public sealed class AppRole : IdentityRole
    {
        public AppRole() { }
        public AppRole(string name, string description) : base(name)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
