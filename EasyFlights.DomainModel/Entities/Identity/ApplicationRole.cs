using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyFlights.DomainModel.Entities.Identity
{
    public sealed class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string name, string description) : base(name)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
