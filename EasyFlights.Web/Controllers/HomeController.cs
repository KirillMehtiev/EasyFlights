using System.Web.Mvc;
using EasyFlights.Data.DataContexts;
using EasyFlights.Data.Repositories.Base;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Services.Interfaces;
using Ninject;

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