using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyFlights.Web.ViewModels.AccountViewModels
{
	public class LoginViewModel
	{
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public string RememberMe { get; set; }
    }
}