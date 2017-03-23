using System.Web.Mvc;

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