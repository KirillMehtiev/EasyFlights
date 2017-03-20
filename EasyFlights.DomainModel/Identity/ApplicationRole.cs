using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.DomainModel.Identity
{
    public sealed class AppRole : IdentityRole
    {

        public string Description { get; set; }

        public AppRole()
        {
        }

        public AppRole(string name, string description) : base(name)
        {
            this.Description = description;
        }
    }
}
