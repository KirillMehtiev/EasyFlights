using System;
using System.Web.Mvc;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;

namespace EasyFlights.Web.Controllers
{    
    public class HomeController : Controller
    {
        [Route("~/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}