using System.ComponentModel.DataAnnotations;

namespace EasyFlights.Web.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string UserPhone { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }
    }
}