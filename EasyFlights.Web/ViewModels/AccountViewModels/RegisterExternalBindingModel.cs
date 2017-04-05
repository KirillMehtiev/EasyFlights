﻿using System.ComponentModel.DataAnnotations;

namespace EasyFlights.Web.ViewModels.AccountViewModels
{
    public class RegisterExternalBindingModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Provider { get; set; }

        [Required]
        public string ExternalAccessToken { get; set; }

    }
}