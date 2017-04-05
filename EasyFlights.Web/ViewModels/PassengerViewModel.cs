using EasyFlights.DomainModel.Entities.Enums;

namespace EasyFlights.Web.ViewModels
{
    public class PassengerViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public string DocumentNumber { get; set; }

        public Sex Sex { get; set; }
    }
}
