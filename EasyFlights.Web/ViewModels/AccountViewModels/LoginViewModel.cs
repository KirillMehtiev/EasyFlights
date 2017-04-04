using System.ComponentModel.DataAnnotations;

namespace EasyFlights.Web.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }

        public string RememberMe { get; set; }
    }
}