using System;
using System.Web.Mvc;
using EasyFlights.Data.Typeahead;
using EasyFlights.DomainModel.Entities;

namespace EasyFlights.Web.Controllers
{    
    public class HomeController : Controller
    {
        [Route("~/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCitiesForTypeahead(string name, ITypeaheadProvider<City> provider)
        {
            try
            {
                return Json(provider.GetTypeahead(name));
            }
            catch (ArgumentException)
            {
                return Json(null);
            }
        }
    }
}