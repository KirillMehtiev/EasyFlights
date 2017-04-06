using System.ComponentModel.DataAnnotations;

namespace EasyFlights.Web.ViewModels.AccountViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string NewPasswordConfirm { get; set; }
    }
}