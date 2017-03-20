using System;

namespace EasyFlights.DomainModel.Identity
{
    public enum AgeCategory
    {
        Adult = 0,
        Child = 1
    }

    public enum Sex
    {
        Male = 0,
        Female = 1
    }

    public class Passenger : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string DocumentNo { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public Sex Sex { get; set; }
    }
}
